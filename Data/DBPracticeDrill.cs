using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace TypeRush_Final.Data
{
    public class DBPracticeDrill
    {
        private string _connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";

        public DBPracticeDrill()
        {
        }

        public List<int> GetExerciseIDsForCategory(int categoryID)
        {
            List<int> exerciseIDs = new List<int>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"SELECT DrillExerciseID 
                            FROM DrillExercises 
                            WHERE DrillCategoryID = @CategoryID 
                            ORDER BY ExerciseNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@CategoryID", categoryID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                exerciseIDs.Add(reader.GetInt32(0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching exercise IDs: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return exerciseIDs;
        }

        public List<string> FetchPracticeWords(int categoryID, int drillExerciseID)
        {
            List<string> words = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = "SELECT Words FROM DrillExercises WHERE DrillExerciseID = @DrillExerciseID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DrillExerciseID", drillExerciseID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string wordsFromDb = reader.GetString(0);
                                words = SplitWords(wordsFromDb);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching practice words: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return words;
        }

        private List<string> SplitWords(string wordsFromDb)
        {
            List<string> wordsList = new List<string>();

            if (!string.IsNullOrEmpty(wordsFromDb))
            {
                string[] wordsArray = wordsFromDb.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var word in wordsArray)
                {
                    wordsList.Add(word.Trim());
                }
            }

            return wordsList;
        }

        public List<string> FetchDrillExercises(int category)
        {
            List<string> exercises = new List<string>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = "SELECT ExerciseName FROM DrillExercises WHERE DrillCategoryID = @DrillCategoryID ORDER BY ExerciseNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@DrillCategoryID", category);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                exercises.Add(reader.GetString(0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching drill exercises: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return exercises;
        }

        public Dictionary<int, int> GetUserStarsForCategory(int userID, int categoryID)
        {
            Dictionary<int, int> exerciseStars = new Dictionary<int, int>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                SELECT de.DrillExerciseID, ISNULL(MAX(up.StarsGained), 0) AS MaxStars
                FROM DrillExercises de
                LEFT JOIN UserPracticeDrillProgress up 
                    ON de.DrillExerciseID = up.DrillExerciseID AND up.UserID = @UserID
                WHERE de.DrillCategoryID = @DrillCategoryID
                GROUP BY de.DrillExerciseID, de.ExerciseNumber
                ORDER BY de.ExerciseNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@DrillCategoryID", categoryID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int drillExerciseID = reader.GetInt32(0);
                                int maxStars = reader.GetInt32(1);
                                exerciseStars[drillExerciseID] = maxStars;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching user stars: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return exerciseStars;
        }

        public void CalculateAndSavePerformance(int userID, int drillExerciseID, int durationSeconds,
                                              int correctChars, int totalChars,
                                              out int wpmOut, out int accuracyOut, out int starsGainedOut, out int xpGainedOut)
        {
            int wpm = CalculateWPM(correctChars, durationSeconds);
            int accuracy = CalculateAccuracy(correctChars, totalChars);
            int starsGained = CalculateStarsGained(accuracy);
            int xpGained = CalculateXPGained(accuracy);

            SaveUserProgress(userID, drillExerciseID, durationSeconds, wpm, accuracy, starsGained, xpGained);

            wpmOut = wpm;
            accuracyOut = accuracy;
            starsGainedOut = starsGained;
            xpGainedOut = xpGained;
        }

        private int CalculateWPM(int correctChars, int durationSeconds)
        {
            double minutes = durationSeconds / 60.0;
            int wpm = (int)Math.Round((correctChars / 5.0) / minutes);
            return wpm;
        }

        private int CalculateAccuracy(int correctChars, int totalChars)
        {
            if (totalChars == 0)
                return 0;

            int accuracy = (int)Math.Round((double)correctChars / totalChars * 100);
            return accuracy;
        }

        private int CalculateStarsGained(int accuracy)
        {
            if (accuracy >= 90)
                return 3;
            else if (accuracy >= 80)
                return 2;
            else if (accuracy >= 70)
                return 1;
            else
                return 0;
        }

        private int CalculateXPGained(int accuracy)
        {
            if (accuracy >= 90)
                return 100;
            else if (accuracy >= 80)
                return 80;
            else if (accuracy >= 70)
                return 60;
            else
                return 40;
        }

        private void SaveUserProgress(int userID, int drillExerciseID, int durationSeconds, int wpm, int accuracy, int starsGained, int xpGained)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string query = @"INSERT INTO UserPracticeDrillProgress 
                                  ([UserID], [DrillExerciseID], [DateTaken], [DurationSeconds], [WPM], [Accuracy], [StarsGained], [XPGained])
                                  VALUES 
                                  (@UserID, @DrillExerciseID, @DateTaken, @DurationSeconds, @WPM, @Accuracy, @StarsGained, @XPGained)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@DrillExerciseID", drillExerciseID);
                        command.Parameters.AddWithValue("@DateTaken", DateTime.Now);
                        command.Parameters.AddWithValue("@DurationSeconds", durationSeconds);
                        command.Parameters.AddWithValue("@WPM", wpm);
                        command.Parameters.AddWithValue("@Accuracy", accuracy);
                        command.Parameters.AddWithValue("@StarsGained", starsGained);
                        command.Parameters.AddWithValue("@XPGained", xpGained);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving user progress: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public Dictionary<int, (int avgWPM, int avgAccuracy)> GetUserDrillAverages(int userID, int categoryID)
        {
            Dictionary<int, (int avgWPM, int avgAccuracy)> drillAverages = new Dictionary<int, (int avgWPM, int avgAccuracy)>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    string query = @"
                    SELECT 
                        de.DrillExerciseID, 
                        ISNULL(AVG(CAST(up.WPM AS FLOAT)), 0) AS AvgWPM,
                        ISNULL(AVG(CAST(up.Accuracy AS FLOAT)), 0) AS AvgAccuracy
                    FROM DrillExercises de
                    LEFT JOIN UserPracticeDrillProgress up 
                        ON de.DrillExerciseID = up.DrillExerciseID AND up.UserID = @UserID
                    WHERE de.DrillCategoryID = @DrillCategoryID
                    GROUP BY de.DrillExerciseID, de.ExerciseNumber
                    ORDER BY de.ExerciseNumber";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserID", userID);
                        command.Parameters.AddWithValue("@DrillCategoryID", categoryID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int drillExerciseID = reader.GetInt32(0);
                                int avgWPM = (int)Math.Round(reader.GetDouble(1));
                                int avgAccuracy = (int)Math.Round(reader.GetDouble(2));

                                drillAverages[drillExerciseID] = (avgWPM, avgAccuracy);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching user drill averages: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return drillAverages;
        }
    }
}