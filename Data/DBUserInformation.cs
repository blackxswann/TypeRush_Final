using System;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace TypeRush_Final.Data
{
    public class DBUserInformation
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public string CurrentLevel { get; set; }
        public string XP { get; set; }
        public int AvatarIndex { get; set; }
        public string DisplayPicture { get; set; }

        public string LevelName { get; set; }
        public string XPRequired { get; set; }

        public string NextLevelID { get; set; }
        public string NextLevelName { get; set; }
        public string NextLevelXPRequired { get; set; }


        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        public async Task<AuthenticationError> CheckAndCreateAccount(string username, string displayName, string password, string email, int level, int XP, int AvatarIndex, PictureBox displayPicture)
        {

            string connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    string checkBothQuery = "SELECT " +
                                            "(SELECT COUNT(*) FROM UserInformation WHERE Username = @Username) AS UsernameCount, " +
                                            "(SELECT COUNT(*) FROM UserInformation WHERE EmailAddress = @EmailAddress) AS EmailCount";

                    using (SqlCommand checkCmd = new SqlCommand(checkBothQuery, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@Username", username);
                        checkCmd.Parameters.AddWithValue("@EmailAddress", email);

                        using (SqlDataReader reader = await checkCmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                int usernameCount = reader.GetInt32(0);
                                int emailCount = reader.GetInt32(1);

                                if (usernameCount > 0 && emailCount > 0)
                                {
                                    return AuthenticationError.usernameAndEmailExists;
                                }
                                else if (usernameCount > 0)
                                {
                                    return AuthenticationError.usernameExists;
                                }
                                else if (emailCount > 0)
                                {
                                    return AuthenticationError.emailExists;
                                }
                            }
                        }
                    }


                    byte[] displayPictureBytes = null;
                    if (displayPicture != null && displayPicture.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            displayPicture.Image.Save(ms, displayPicture.Image.RawFormat);
                            displayPictureBytes = ms.ToArray();
                        }
                    }

                    string hashedPassword = HashPassword(password);

                    string insertQuery = @"
                    INSERT INTO [dbo].[UserInformation]
                    ([Username], [DisplayName], [HashedPassword], [EmailAddress], [CurrentLevel], [XP], [AvatarIndex], [DisplayPicture])
                    VALUES (@Username, @DisplayName, @HashedPassword, @EmailAddress, @CurrentLevel, @XP, @AvatarIndex, @DisplayPicture)";

                    using (SqlCommand insertCmd = new SqlCommand(insertQuery, connection))
                    {
                        insertCmd.Parameters.AddWithValue("@Username", username);
                        insertCmd.Parameters.AddWithValue("@DisplayName", displayName);
                        insertCmd.Parameters.AddWithValue("@HashedPassword", hashedPassword);
                        insertCmd.Parameters.AddWithValue("@EmailAddress", email);
                        insertCmd.Parameters.AddWithValue("@CurrentLevel", 1);
                        insertCmd.Parameters.AddWithValue("@XP", 0);
                        insertCmd.Parameters.AddWithValue("@AvatarIndex", AvatarIndex);
                        insertCmd.Parameters.AddWithValue("@DisplayPicture", displayPictureBytes ?? new byte[0]);

                        int rows = await insertCmd.ExecuteNonQueryAsync();

                        return AuthenticationError.successfulOperation;
                    }
                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    return AuthenticationError.databaseError;
                }
            }

        }
        public async Task<AuthenticationError> LoginUser(string username, string password)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    string query = "SELECT HashedPassword FROM UserInformation WHERE Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);

                        object result = await cmd.ExecuteScalarAsync();

                        if (result == null)
                        {
                            return AuthenticationError.usernameNotFound;
                        }

                        string storedHashedPassword = result.ToString();
                        string enteredHashedPassword = HashPassword(password);

                        if (storedHashedPassword == enteredHashedPassword)
                        {
                            return AuthenticationError.successfulOperation;
                        }
                        else
                        {
                            return AuthenticationError.incorrectPassword;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    return AuthenticationError.databaseError;
                }
            }
        }
        
        public async Task<DBUserInformation> FetchUserInformation(string username)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    string query = @"
SELECT u.[UserID], u.[Username], u.[DisplayName], u.[HashedPassword], u.[EmailAddress], 
       u.[CurrentLevel], u.[XP], u.[AvatarIndex], u.[DisplayPicture], 
       l.[LevelName], l.[XPRequired],
       nextLevel.[LevelID] AS NextLevelID, 
       nextLevel.[LevelName] AS NextLevelName, 
       nextLevel.[XPRequired] AS NextLevelXPRequired
FROM UserInformation u
LEFT JOIN Level l ON u.CurrentLevel = l.LevelID
LEFT JOIN Level nextLevel ON nextLevel.LevelID = (u.CurrentLevel + 1)
WHERE u.Username = @Username";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                int? nextLevelID = null;
                                string nextLevelName = null;
                                string nextLevelXPRequired = null;

                                if (!reader.IsDBNull(11))
                                {
                                    nextLevelID = reader.GetInt32(11);
                                    nextLevelName = !reader.IsDBNull(12) ? reader.GetString(12) : null;
                                    nextLevelXPRequired = !reader.IsDBNull(13) ? reader.GetInt32(13).ToString() : null;
                                }

                                DBUserInformation userInfo = new DBUserInformation
                                {
                                    UserID = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    DisplayName = reader.GetString(2),
                                    Password = reader.GetString(3),
                                    EmailAddress = reader.GetString(4),
                                    CurrentLevel = reader.GetInt32(5).ToString(),
                                    XP = reader.GetInt32(6).ToString(),
                                    AvatarIndex = reader.IsDBNull(7) ? -1 : reader.GetInt32(7),
                                    DisplayPicture = reader.IsDBNull(8) ? "NO_PICTURE_UPLOADED" : SaveImageFromDb((byte[])reader[8]),
                                    LevelName = reader.IsDBNull(9) ? "Unknown" : reader.GetString(9),
                                    XPRequired = reader.IsDBNull(10) ? "0" : reader.GetInt32(10).ToString(),
                                    NextLevelID = nextLevelID?.ToString(),
                                    NextLevelName = nextLevelName,
                                    NextLevelXPRequired = nextLevelXPRequired
                                };

                                CurrentUser.UserID = userInfo.UserID;
                                CurrentUser.Username = userInfo.Username;
                                CurrentUser.DisplayName = userInfo.DisplayName;
                                CurrentUser.Password = userInfo.Password;
                                CurrentUser.EmailAddress = userInfo.EmailAddress;
                                CurrentUser.currentLevel = userInfo.CurrentLevel;
                                CurrentUser.XP = userInfo.XP;
                                CurrentUser.AvatarIndex = userInfo.AvatarIndex;
                                CurrentUser.DisplayPicturePath = userInfo.DisplayPicture;
                                CurrentUser.levelName = userInfo.LevelName;
                                CurrentUser.XPRequired = userInfo.XPRequired;
                                CurrentUser.NextLevelID = userInfo.NextLevelID;
                                CurrentUser.NextLevelName = userInfo.NextLevelName;
                                CurrentUser.NextLevelXPRequired = userInfo.NextLevelXPRequired;

                           

                                return userInfo;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
            return null;
        }
        public async Task<AuthenticationError> CheckIfUsernameOrEmailExists(string username, string email)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    string query = @"
                SELECT 
                    (SELECT COUNT(*) FROM UserInformation WHERE Username = @Username) AS UsernameCount,
                    (SELECT COUNT(*) FROM UserInformation WHERE EmailAddress = @EmailAddress) AS EmailCount
                ";

                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@EmailAddress", email);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                int usernameCount = reader.GetInt32(0);
                                int emailCount = reader.GetInt32(1);

                                if (usernameCount > 0 && emailCount > 0)
                                {
                                    return AuthenticationError.usernameAndEmailExists;
                                }
                                else if (usernameCount > 0)
                                {
                                    return AuthenticationError.usernameExists;
                                }
                                else if (emailCount > 0)
                                {
                                    return AuthenticationError.emailExists;
                                }
                                else
                                {
                                    return AuthenticationError.successfulOperation;
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    return AuthenticationError.databaseError;
                }
            }

            return AuthenticationError.databaseError;
        }

        private string SaveImageFromDb(byte[] imageBytes)
        {
            if (imageBytes == null || imageBytes.Length == 0)
            {
                return "NO_PICTURE_UPLOADED";
            }

            string tempPath = Path.Combine(Application.StartupPath, "tempProfilePic.jpg");
            File.WriteAllBytes(tempPath, imageBytes);
            return tempPath;
        }
        public async Task<AuthenticationError> UpdateUserInformation(string newUsername, string newDisplayName, string newEmailAddress, int avatarIndex, PictureBox newDisplayPicture)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();
                    byte[] displayPictureBytes = null;

                    if (avatarIndex == -1 && newDisplayPicture != null && newDisplayPicture.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            newDisplayPicture.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            displayPictureBytes = ms.ToArray();
                        }
                    }

                    string updateQuery = @"
                    UPDATE UserInformation
                    SET Username = @Username,
                        DisplayName = @DisplayName,
                        EmailAddress = @EmailAddress,
                        DisplayPicture = @DisplayPicture,
                        AvatarIndex = @AvatarIndex
                    WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                    {
                        cmd.Parameters.Add("@Username", System.Data.SqlDbType.NVarChar).Value = newUsername;
                        cmd.Parameters.Add("@DisplayName", System.Data.SqlDbType.NVarChar).Value = newDisplayName;
                        cmd.Parameters.Add("@EmailAddress", System.Data.SqlDbType.NVarChar).Value = newEmailAddress;
                        cmd.Parameters.Add("@UserID", System.Data.SqlDbType.Int).Value = CurrentUser.UserID;

                        if (avatarIndex == -1 && displayPictureBytes != null)
                        {
                            cmd.Parameters.Add("@DisplayPicture", System.Data.SqlDbType.VarBinary).Value = displayPictureBytes;
                            cmd.Parameters.Add("@AvatarIndex", System.Data.SqlDbType.Int).Value = DBNull.Value;
                        }
                        else
                        {
                            cmd.Parameters.Add("@DisplayPicture", System.Data.SqlDbType.VarBinary).Value = DBNull.Value;
                            cmd.Parameters.Add("@AvatarIndex", System.Data.SqlDbType.Int).Value = avatarIndex;
                        }

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();
                        if (rowsAffected > 0)
                        {
                            CurrentUser.Username = newUsername; 
                            CurrentUser.DisplayName = newDisplayName;
                            CurrentUser.EmailAddress = newEmailAddress;
                            CurrentUser.AvatarIndex = avatarIndex;


                            if (avatarIndex == -1 && displayPictureBytes != null)
                            {
                                string tempPath = Path.Combine(Application.StartupPath, "UpdatedProfilePicture.jpg");
                                File.WriteAllBytes(tempPath, displayPictureBytes);
                                CurrentUser.DisplayPicturePath = tempPath;
                            }
                            else
                            {
                                CurrentUser.DisplayPicturePath = "NO_PICTURE_UPLOADED";
                            }

                            return AuthenticationError.successfulOperation;
                        }
                        else
                        {
                            return AuthenticationError.databaseError;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating user information: {ex.Message}");
                    return AuthenticationError.databaseError;
                }
            }
        }

        public async Task<AuthenticationError> DeleteAccount()
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    await connection.OpenAsync();

                    string deleteQuery = "DELETE FROM UserInformation WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(deleteQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@UserID", UserID);

                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            return AuthenticationError.successfulOperation;
                        }
                        else
                        {
                            return AuthenticationError.databaseError;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting account: {ex.Message}");
                    return AuthenticationError.databaseError;
                }
            }
        }
    }
}
