using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;


namespace TypeRush_Final
{
    public class AchievementChecker
    {
        private static readonly string connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";

        public static void CheckAchievements(int userId, int wpm, int accuracy, int xpGained)
        {
            try
            {
                UpdateUserXP(userId, xpGained);

                bool leveledUp = CheckForLevelUp(userId);

                if (leveledUp)
                {
                }
            }
            catch (Exception ex)
            {
                LogError($"Error in CheckAchievements: {ex.Message}");
            }
        }

        private static void UpdateUserXP(int userId, int xpGained)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        UPDATE UserInformation 
                        SET XP = XP + @XPGained 
                        WHERE UserID = @UserID;
                        
                        SELECT XP FROM UserInformation WHERE UserID = @UserID;";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.Parameters.AddWithValue("@XPGained", xpGained);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            CurrentUser.XP = result.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogError($"Error updating XP: {ex.Message}");
            }
        }

        private static bool CheckForLevelUp(int userId)
        {
            try
            {
                if (string.IsNullOrEmpty(CurrentUser.XP) ||
                    string.IsNullOrEmpty(CurrentUser.currentLevel) ||
                    string.IsNullOrEmpty(CurrentUser.NextLevelXPRequired))
                {
                    return false; 
                }

                int currentXP = int.Parse(CurrentUser.XP);
                int currentLevel = int.Parse(CurrentUser.currentLevel);

                if (string.IsNullOrEmpty(CurrentUser.NextLevelXPRequired))
                {
                    return false; 
                }

                int nextLevelXPRequired = int.Parse(CurrentUser.NextLevelXPRequired);

                if (currentXP >= nextLevelXPRequired)
                {
                    int newLevel = currentLevel + 1;
                    UpdateUserLevel(userId, newLevel);
                    return true; 
                }

                return false; 
            }
            catch (Exception ex)
            {
                LogError($"Error checking for level up: {ex.Message}");
                return false;
            }
        }

        private static void UpdateUserLevel(int userId, int newLevel)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "UPDATE UserInformation SET CurrentLevel = @NewLevel WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@NewLevel", newLevel);
                        cmd.Parameters.AddWithValue("@UserID", userId);
                        cmd.ExecuteNonQuery();
                    }

                    CurrentUser.currentLevel = newLevel.ToString();

                    RefreshUserLevelInfo(userId);
                }
                catch (Exception ex)
                {
                    LogError($"Error updating user level: {ex.Message}");
                }
            }
        }

        private static void RefreshUserLevelInfo(int userId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"
                        SELECT l.[LevelName], l.[XPRequired],
                               nextLevel.[LevelID] AS NextLevelID, 
                               nextLevel.[LevelName] AS NextLevelName, 
                               nextLevel.[XPRequired] AS NextLevelXPRequired
                        FROM Level l
                        LEFT JOIN Level nextLevel ON nextLevel.LevelID = (l.LevelID + 1)
                        WHERE l.LevelID = @CurrentLevel";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@CurrentLevel", int.Parse(CurrentUser.currentLevel));
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                CurrentUser.levelName = reader.IsDBNull(0) ? "Unknown" : reader.GetString(0);
                                CurrentUser.XPRequired = reader.IsDBNull(1) ? "0" : reader.GetInt32(1).ToString();
                                CurrentUser.NextLevelID = reader.IsDBNull(2) ? null : reader.GetInt32(2).ToString();
                                CurrentUser.NextLevelName = reader.IsDBNull(3) ? null : reader.GetString(3);
                                CurrentUser.NextLevelXPRequired = reader.IsDBNull(4) ? null : reader.GetInt32(4).ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    LogError($"Error refreshing level info: {ex.Message}");
                }
            }
        }

    

        private static void LogError(string errorMessage)
        {
            try
            {
                string logPath = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "logs", "error_log.txt");

                System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(logPath));

                System.IO.File.AppendAllText(
                    logPath,
                    $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {errorMessage}{Environment.NewLine}"
                );
            }
            catch
            {
            }
        }
    }
}