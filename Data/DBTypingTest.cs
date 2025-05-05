using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace TypeRush_Final.Data
{
    public class DBTypingTest
    {
        private string _connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";

        public DBTypingTest()
        {
        }

        public void SaveTypingTestResults(
            int userID,
            string testMode,
            string difficultyLevel,
            int durationSeconds,
            int correctTypedCharacters,
            int totalTypedCharacters,
            TimeSpan elapsedTime,
            Dictionary<char, int> mistypedCharacters)
        {
            int wpm = CalculateWPM(correctTypedCharacters, durationSeconds);
            int accuracy = CalculateAccuracy(correctTypedCharacters, totalTypedCharacters);
            int xpGained = 150; 

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    int testID = InsertTypingTestSession(connection, userID, testMode, difficultyLevel,
                                                         durationSeconds, wpm, accuracy, xpGained);

                    if (mistypedCharacters.Count > 0)
                    {
                        InsertMistypedCharacterData(connection, testID, mistypedCharacters);
                    }

                    DisplayResults(wpm, accuracy, mistypedCharacters);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int InsertTypingTestSession(
            SqlConnection connection,
            int userID,
            string testMode,
            string difficultyLevel,
            int durationSeconds,
            int wpm,
            int accuracy,
            int xpGained)
        {
            string query = @"
                INSERT INTO TypingTestSession (UserID, TestMode, DifficultyLevel, DateTaken, DurationSeconds, WPM, Accuracy, XPGained)
                VALUES (@UserID, @TestMode, @DifficultyLevel, @DateTaken, @DurationSeconds, @WPM, @Accuracy, @XPGained);
                SELECT SCOPE_IDENTITY();";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", userID);
                command.Parameters.AddWithValue("@TestMode", testMode);
                command.Parameters.AddWithValue("@DifficultyLevel", difficultyLevel);
                command.Parameters.AddWithValue("@DateTaken", DateTime.Now);
                command.Parameters.AddWithValue("@DurationSeconds", durationSeconds);
                command.Parameters.AddWithValue("@WPM", wpm);
                command.Parameters.AddWithValue("@Accuracy", accuracy);
                command.Parameters.AddWithValue("@XPGained", xpGained);

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void InsertMistypedCharacterData(
            SqlConnection connection,
            int testID,
            Dictionary<char, int> mistypedCharacters)
        {
            StringBuilder charsBuilder = new StringBuilder();
            StringBuilder freqBuilder = new StringBuilder();

            foreach (var kvp in mistypedCharacters)
            {
                charsBuilder.Append(kvp.Key).Append(" ");
                freqBuilder.Append(kvp.Value).Append(" ");
            }

            string chars = charsBuilder.ToString().Trim();
            string frequencies = freqBuilder.ToString().Trim();

            string query = @"
                INSERT INTO MistypedCharacter (TestID, MistypedCharacter, MistypedCharacterFrequency)
                VALUES (@TestID, @MistypedCharacter, @MistypedCharacterFrequency)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TestID", testID);
                command.Parameters.AddWithValue("@MistypedCharacter", chars);
                command.Parameters.AddWithValue("@MistypedCharacterFrequency", frequencies);

                command.ExecuteNonQuery();
            }
        }

        private int CalculateWPM(int correctTypedCharacters, int durationSeconds)
        {
            double minutes = durationSeconds / 60.0;
            if (minutes > 0)
            {
                return (int)Math.Round((correctTypedCharacters / 5.0) / minutes);
            }
            return 0;
        }

        private int CalculateAccuracy(int correctTypedCharacters, int totalTypedCharacters)
        {
            if (totalTypedCharacters > 0)
            {
                return (int)Math.Round((double)correctTypedCharacters / totalTypedCharacters * 100);
            }
            return 0;
        }

        private void DisplayResults(int wpm, int accuracy, Dictionary<char, int> mistypedCharacters)
        {
            StringBuilder resultMessage = new StringBuilder();
            resultMessage.AppendLine($"Test Results:\n");
            resultMessage.AppendLine($"WPM: {wpm}");
            resultMessage.AppendLine($"Accuracy: {accuracy}%");
            resultMessage.AppendLine($"Total Mistyped Characters: {mistypedCharacters.Count}");

            if (mistypedCharacters.Count > 0)
            {
                resultMessage.AppendLine("\nMistyped Characters:");
                foreach (var mistyped in mistypedCharacters.OrderByDescending(m => m.Value))
                {
                    resultMessage.AppendLine($"'{mistyped.Key}': {mistyped.Value} times");
                }
            }
        }

        public List<(DateTime DateTaken, int WPM, int Accuracy, string DifficultyLevel)> GetUserTestHistory(int userID)
        {
            List<(DateTime, int, int, string)> history = new List<(DateTime, int, int, string)>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT DateTaken, WPM, Accuracy, DifficultyLevel
                        FROM TypingTestSession
                        WHERE UserID = @UserID
                        ORDER BY DateTaken DESC";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                history.Add((
                                    reader.GetDateTime(0),
                                    reader.GetInt32(1),
                                    reader.GetInt32(2),
                                    reader.GetString(3)
                                ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving test history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return history;
        }
        public void ShowUserDrillStarsEarned(int userID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                        WITH MaxStarsPerExercise AS (
                            SELECT 
                                p.DrillExerciseID,
                                MAX(p.StarsGained) AS MaxStars,
                                c.CategoryName,
                                e.ExerciseName,
                                e.ExerciseNumber
                            FROM UserPracticeDrillProgress p
                            INNER JOIN DrillExercises e ON p.DrillExerciseID = e.DrillExerciseID
                            INNER JOIN DrillCategory c ON e.DrillCategoryID = c.DrillCategoryID
                            WHERE p.UserID = @UserID
                            GROUP BY p.DrillExerciseID, c.CategoryName, e.ExerciseName, e.ExerciseNumber
                        )
                        SELECT 
                            CategoryName,
                            ExerciseName,
                            ExerciseNumber,
                            MaxStars
                        FROM MaxStarsPerExercise
                        ORDER BY CategoryName, ExerciseNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);

                        Dictionary<string, List<(string ExerciseName, int ExerciseNumber, int Stars)>> starsByCategory =
                            new Dictionary<string, List<(string, int, int)>>();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string categoryName = reader.GetString(0);
                                string exerciseName = reader.GetString(1);
                                int exerciseNumber = reader.GetInt32(2);
                                int stars = reader.GetInt32(3);

                                if (!starsByCategory.ContainsKey(categoryName))
                                {
                                    starsByCategory[categoryName] = new List<(string, int, int)>();
                                }

                                starsByCategory[categoryName].Add((exerciseName, exerciseNumber, stars));
                            }
                        }

                        DisplayDrillStarsEarned(starsByCategory);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving drill stars: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayDrillStarsEarned(Dictionary<string, List<(string ExerciseName, int ExerciseNumber, int Stars)>> starsByCategory)
        {
            if (starsByCategory.Count == 0)
            {
                MessageBox.Show("No drill exercises completed yet.", "Drill Stars", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            StringBuilder resultMessage = new StringBuilder();
            resultMessage.AppendLine("Stars Earned in Drill Exercises:\n");

            foreach (var category in starsByCategory.Keys)
            {
                resultMessage.AppendLine($"Category: {category}");

                foreach (var exercise in starsByCategory[category].OrderBy(e => e.ExerciseNumber))
                {
                    string starDisplay = new string('★', exercise.Stars) + new string('☆', 3 - exercise.Stars);
                    resultMessage.AppendLine($"  Exercise {exercise.ExerciseNumber}: {exercise.ExerciseName} - {starDisplay} ({exercise.Stars}/3)");
                }

                resultMessage.AppendLine();
            }

            MessageBox.Show(resultMessage.ToString(), "Drill Stars Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public (int AvgWPM, int AvgAccuracy, TimeSpan TotalTime, int TotalStars) GetUserProfileStats(int userID)
        {
            int avgWPM = 0;
            int avgAccuracy = 0;
            TimeSpan totalTime = TimeSpan.Zero;
            int totalStars = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string typingStatsQuery = @"
                    SELECT 
                        AVG(CAST(WPM AS FLOAT)) AS AvgWPM,
                        AVG(CAST(Accuracy AS FLOAT)) AS AvgAccuracy,
                        SUM(CAST(DurationSeconds AS FLOAT)) AS TotalSeconds
                    FROM TypingTestSession
                    WHERE UserID = @UserID";

                    using (SqlCommand command = new SqlCommand(typingStatsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                avgWPM = !reader.IsDBNull(0) ? (int)Math.Round(reader.GetDouble(0)) : 0;
                                avgAccuracy = !reader.IsDBNull(1) ? (int)Math.Round(reader.GetDouble(1)) : 0;
                                double totalSeconds = !reader.IsDBNull(2) ? reader.GetDouble(2) : 0;
                                totalTime = TimeSpan.FromSeconds(totalSeconds);
                            }
                        }
                    }

                    string starsQuery = @"
                    SELECT SUM(MaxStars) AS TotalStars
                    FROM (
                        SELECT 
                            DrillExerciseID,
                            MAX(StarsGained) AS MaxStars
                        FROM UserPracticeDrillProgress
                        WHERE UserID = @UserID
                        GROUP BY DrillExerciseID
                    ) AS MaxStarsPerExercise";

                    using (SqlCommand command = new SqlCommand(starsQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);

                        object result = command.ExecuteScalar();
                        totalStars = result != null && result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving user statistics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return (avgWPM, avgAccuracy, totalTime, totalStars);
        }
    }
}