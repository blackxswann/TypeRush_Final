using System;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeRush_Final.Data
{
    public class DBMinigameSession
    {
        private static readonly string connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";


        public static async Task<bool> SaveGameSession(int userId, int score)
        {
            try
            {
                int xpGained = CalculateXPGained(score);

                bool sessionSaved = await SaveMinigameSession(userId, score, xpGained);
                if (!sessionSaved)
                {
                    return false;
                }

                bool xpUpdated = await UpdateUserXP(userId, xpGained);

                return xpUpdated;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing game session: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        private static async Task<bool> SaveMinigameSession(int userId, int score, int xpGained)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    string insertQuery = @"
                        INSERT INTO [dbo].[MinigameSession]
                        ([UserID], [Score], [XPGained], [DatePlayed])
                        VALUES (@UserID, @Score, @XPGained, @DatePlayed)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@Score", score);
                        cmd.Parameters.AddWithValue("@XPGained", xpGained);
                        cmd.Parameters.AddWithValue("@DatePlayed", DateTime.Now); 

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        return rowsAffected > 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving game session: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private static async Task<bool> UpdateUserXP(int userId, int additionalXP)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    string getUserQuery = @"
                        SELECT u.XP, u.CurrentLevel, 
                               l.XPRequired AS CurrentLevelXPRequired,
                               l.LevelName AS CurrentLevelName,
                               nextLevel.LevelID AS NextLevelID, 
                               nextLevel.LevelName AS NextLevelName, 
                               nextLevel.XPRequired AS NextLevelXPRequired
                        FROM UserInformation u
                        LEFT JOIN Level l ON u.CurrentLevel = l.LevelID
                        LEFT JOIN Level nextLevel ON nextLevel.LevelID = (u.CurrentLevel + 1)
                        WHERE u.UserID = @UserID";

                    int currentXP = 0;
                    int currentLevel = 0;
                    string currentLevelName = string.Empty;
                    int? nextLevelID = null;
                    string nextLevelName = null;
                    int? nextLevelXPRequired = null;

                    using (SqlCommand getCmd = new SqlCommand(getUserQuery, connection))
                    {
                        getCmd.Parameters.AddWithValue("@UserID", userId);

                        using (SqlDataReader reader = await getCmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                currentXP = reader.GetInt32(0);
                                currentLevel = reader.GetInt32(1);
                                currentLevelName = !reader.IsDBNull(3) ? reader.GetString(3) : "Unknown";

                                if (!reader.IsDBNull(4))
                                {
                                    nextLevelID = reader.GetInt32(4);
                                    nextLevelName = !reader.IsDBNull(5) ? reader.GetString(5) : null;
                                    nextLevelXPRequired = !reader.IsDBNull(6) ? reader.GetInt32(6) : null;
                                }
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }

                    int newXP = currentXP + additionalXP;

                    bool leveledUp = false;
                    int newLevel = currentLevel;

                    if (nextLevelID.HasValue && nextLevelXPRequired.HasValue && newXP >= nextLevelXPRequired.Value)
                    {
                        leveledUp = true;
                        newLevel = nextLevelID.Value;
                    }

                    string updateQuery = leveledUp
                        ? "UPDATE UserInformation SET XP = @NewXP, CurrentLevel = @NewLevel WHERE UserID = @UserID"
                        : "UPDATE UserInformation SET XP = @NewXP WHERE UserID = @UserID";

                    using (SqlCommand updateCmd = new SqlCommand(updateQuery, connection))
                    {
                        updateCmd.Parameters.AddWithValue("@NewXP", newXP);
                        updateCmd.Parameters.AddWithValue("@UserID", userId);

                        if (leveledUp)
                        {
                            updateCmd.Parameters.AddWithValue("@NewLevel", newLevel);
                        }

                        int rowsAffected = await updateCmd.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            CurrentUser.XP = newXP.ToString();

                            if (leveledUp)
                            {
                                CurrentUser.currentLevel = newLevel.ToString();
                                CurrentUser.levelName = nextLevelName;

                                await UpdateNextLevelInfo(connection, newLevel);

                                MessageBox.Show($"Congratulations! You've reached Level {newLevel}: {nextLevelName}!",
                                    "Level Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            return true;
                        }
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating XP: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }


        private static async Task UpdateNextLevelInfo(SqlConnection connection, int currentLevel)
        {
            try
            {
                string getNextLevelQuery = @"
                    SELECT LevelID, LevelName, XPRequired
                    FROM Level
                    WHERE LevelID = @NextLevelID";

                using (SqlCommand getNextCmd = new SqlCommand(getNextLevelQuery, connection))
                {
                    getNextCmd.Parameters.AddWithValue("@NextLevelID", currentLevel + 1);

                    using (SqlDataReader reader = await getNextCmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            CurrentUser.NextLevelID = reader.GetInt32(0).ToString();
                            CurrentUser.NextLevelName = reader.GetString(1);
                            CurrentUser.NextLevelXPRequired = reader.GetInt32(2).ToString();
                        }
                        else
                        {
                            CurrentUser.NextLevelID = null;
                            CurrentUser.NextLevelName = null;
                            CurrentUser.NextLevelXPRequired = null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating next level info: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  
        private static int CalculateXPGained(int score)
        {
            return (int)(score * 0.1);
        }
    }
}