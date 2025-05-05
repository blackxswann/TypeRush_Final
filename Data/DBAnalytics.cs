using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using Microsoft.Data.SqlClient;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace TypeRush_Final.Data
{
    internal class DBAnalytics
    {
        LiveChartsCore.SkiaSharpView.WinForms.CartesianChart barChart;

        private readonly string _connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";

        public Dictionary<char, int> GetTopMistypedCharsForDebug(int userId, int timePeriod, int topCount = 10)
        {
            var mistypedChars = GetMistypedCharactersData(userId, timePeriod);
            var topMistyped = mistypedChars
                .OrderByDescending(x => x.Value)
                .Take(topCount)
                .ToDictionary(x => x.Key, x => x.Value);

            string debugQuery = GetDebugQueryText(userId, timePeriod);
            Debug.WriteLine($"Debug Query: {debugQuery}");
            Debug.WriteLine($"Time Period: {timePeriod}, Found: {mistypedChars.Count} characters, Top {topCount}: {topMistyped.Count}");

            return topMistyped;
        }

        public void PopulateMistypeChart(LiveChartsCore.SkiaSharpView.WinForms.CartesianChart barChart, int userId, int timePeriod, int topCount = 10)
        {
            this.barChart = barChart;

            barChart.BackColor = System.Drawing.Color.White;

            try
            {
                var mistypedChars = GetMistypedCharactersData(userId, timePeriod);
                var topMistyped = mistypedChars
                    .OrderByDescending(x => x.Value)
                    .Take(topCount)
                    .ToList();

                if (topMistyped.Count == 0)
                {
                    barChart.Series = new ISeries[]
                    {
                new RowSeries<int>
                {
                    Values = new[] { 0 },
                    Fill = new SolidColorPaint(SKColors.LightGray),
                    Name = "No Data"
                }
                    };

                    barChart.YAxes = new Axis[]
                    {
                new Axis
                {
                    Labels = new[] { "No mistakes found" },
                    NamePaint = new SolidColorPaint(SKColors.Black),
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize = 14
                }
                    };

                    barChart.XAxes = new Axis[]
                    {
                new Axis
                {
                    Name = "Frequency",
                    Labels = new[] { "0" },
                    NamePaint = new SolidColorPaint(SKColors.Black),
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize = 14
                }
                    };

                    return;
                }

                var values = topMistyped.Select(x => x.Value).ToArray();

                var labels = topMistyped.Select(x =>
                {
                    if (x.Key == ' ')
                        return "Space";
                    else if (x.Key == '\t')
                        return "Tab";
                    else if (x.Key == '\n')
                        return "Enter";
                    else
                        return x.Key.ToString();
                }).ToArray();

                var barSeries = new RowSeries<int>
                {
                    Values = values,
                    Fill = new SolidColorPaint(SKColors.DodgerBlue),
                    Stroke = null,
                    MaxBarWidth = 25,

                    DataLabelsSize = 14,
                    DataLabelsPaint = new SolidColorPaint(SKColors.Black),
                    DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.End,
                    DataLabelsFormatter = point => $"{point.Coordinate.PrimaryValue}",
                    Name = "Mistype Frequency"
                };

                barChart.Series = new ISeries[] { barSeries };

                barChart.XAxes = new Axis[]
                {
            new Axis
            {
                Name = "Frequency",
                NamePaint = new SolidColorPaint(SKColors.Black),
                LabelsPaint = new SolidColorPaint(SKColors.Black),
                TextSize = 14,
                NameTextSize = 16
            }
                };

                barChart.YAxes = new Axis[]
                {
            new Axis
            {
                Name = "Mistyped Characters",
                Labels = labels,
                NamePaint = new SolidColorPaint(SKColors.Black),
                LabelsPaint = new SolidColorPaint(SKColors.Black),
                TextSize = 14,
                NameTextSize = 16
            }
                };

                barChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Top;
                barChart.LegendTextPaint = new SolidColorPaint(SKColors.Black);
                barChart.LegendTextSize = 14;
                barChart.LegendBackgroundPaint = new SolidColorPaint(SKColors.LightGray.WithAlpha(100));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in PopulateMistypeChart: {ex.Message}\n\n{ex.StackTrace}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Dictionary<char, int> GetMistypedCharactersData(int userId, int timePeriod)
        {
            DateTime startDate = timePeriod switch
            {
                0 => DateTime.Today,
                1 => DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek),
                2 => new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1),
                _ => DateTime.Today
            };

            var mistypedChars = new Dictionary<char, int>();

            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                string query = @"
                    SELECT m.MistypedCharacter, m.MistypedCharacterFrequency
                    FROM MistypedCharacter m
                    JOIN TypingTestSession t ON m.TestID = t.TestID
                    WHERE t.UserID = @UserID AND t.DateTaken >= @StartDate";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@StartDate", startDate);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0) && !reader.IsDBNull(1))
                    {
                        string characters = reader.GetString(0);
                        string frequencies = reader.GetString(1);

                        string[] chars = characters.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        string[] freqs = frequencies.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                        int minLength = Math.Min(chars.Length, freqs.Length);

                        for (int i = 0; i < minLength; i++)
                        {
                            if (chars[i].Length == 1 && int.TryParse(freqs[i], out int freq))
                            {
                                char c = chars[i][0];
                                if (mistypedChars.ContainsKey(c))
                                    mistypedChars[c] += freq;
                                else
                                    mistypedChars[c] = freq;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error: {ex.Message}\nStack trace: {ex.StackTrace}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\nInner exception: {ex.InnerException.Message}";
                }
                Debug.WriteLine(errorMessage);
                MessageBox.Show(errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return mistypedChars;
        }

        private string GetDebugQueryText(int userId, int timePeriod)
        {
            DateTime startDate = timePeriod switch
            {
                0 => DateTime.Today,
                1 => DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek),
                2 => new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1),
                _ => DateTime.Today
            };

            return $@"
                SELECT m.MistypedCharacter, m.MistypedCharacterFrequency
                FROM MistypedCharacter m
                JOIN TypingTestSession t ON m.TestID = t.TestID
                WHERE t.UserID = {userId} AND t.DateTaken >= '{startDate:yyyy-MM-dd}'";
        }


        public class TypingTestData
        {
            public string Difficulty { get; set; }
            public double TimedWPM { get; set; }
            public double UntimedWPM { get; set; }
            public double TimedAccuracy { get; set; }
            public double UntimedAccuracy { get; set; }
        }

        public List<TypingTestData> GetTypingTestAnalytics(int userId, int timePeriod)
        {
        

            var result = new List<TypingTestData>
            {
                new TypingTestData { Difficulty = "easy" },
                new TypingTestData { Difficulty = "intermediate" },
                new TypingTestData { Difficulty = "hard" }
            };

            DateTime startDate = timePeriod switch
            {
                0 => DateTime.Today,
                1 => DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek),
                2 => new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1),
                _ => DateTime.Today
            };

            try
            {
                using var connection = new SqlConnection(_connectionString);
                connection.Open();

                string query = @"
                    SELECT 
                        DifficultyLevel,
                        TestMode,
                        AVG(WPM) as AvgWPM,
                        AVG(Accuracy) as AvgAccuracy
                    FROM TypingTestSession
                    WHERE UserID = @UserID 
                        AND DateTaken >= @StartDate
                    GROUP BY DifficultyLevel, TestMode";

                using var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@UserID", userId);
                command.Parameters.AddWithValue("@StartDate", startDate);

                using var reader = command.ExecuteReader();
                while (reader.Read())
                {

                    string difficulty = reader.GetString(0).ToLower();
                    string testMode = reader.GetString(1).ToLower();
                    int avgWPM = reader.GetInt32(2);
                    int avgAccuracy = reader.GetInt32(3);

                    var item = result.FirstOrDefault(r => r.Difficulty.ToLower() == difficulty);
                    if (item != null)
                    {
                        if (testMode == "timed")
                        {
                            item.TimedWPM = avgWPM;
                            item.TimedAccuracy = avgAccuracy;
                        }
                        else if (testMode == "untimed")
                        {
                            item.UntimedWPM = avgWPM;
                            item.UntimedAccuracy = avgAccuracy;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errorMessage = $"Error: {ex.Message}\nStack trace: {ex.StackTrace}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\nInner exception: {ex.InnerException.Message}";
                }
                Debug.WriteLine(errorMessage);
                MessageBox.Show(errorMessage, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        public void PopulateTypingTestCharts(
            LiveChartsCore.SkiaSharpView.WinForms.CartesianChart wpmChart,
            LiveChartsCore.SkiaSharpView.WinForms.CartesianChart accuracyChart,
            int userId,
            int timePeriod)
        {
            try
            {
                if (wpmChart != null) wpmChart.BackColor = System.Drawing.Color.White;
                if (accuracyChart != null) accuracyChart.BackColor = System.Drawing.Color.White;

                var testData = GetTypingTestAnalytics(userId, timePeriod);

                if (testData.Count == 0 || testData.All(d => d.TimedWPM == 0 && d.UntimedWPM == 0))
                {
                    SetupEmptyCharts(wpmChart, accuracyChart);
                    return;
                }

                var timedWpmValues = testData.Select(x => x.TimedWPM).ToList();
                var untimedWpmValues = testData.Select(x => x.UntimedWPM).ToList();
                var labels = testData.Select(x => x.Difficulty).ToList();

                var timedWpmSeries = new ColumnSeries<double>
                {
                    Name = "Timed Mode",
                    Values = timedWpmValues,
                    Fill = new SolidColorPaint(SKColors.DodgerBlue),
                    Stroke = null,
                    MaxBarWidth = 30
                };

                var untimedWpmSeries = new ColumnSeries<double>
                {
                    Name = "Untimed Mode",
                    Values = untimedWpmValues,
                    Fill = new SolidColorPaint(SKColors.Orange),
                    Stroke = null,
                    MaxBarWidth = 30
                };

                wpmChart.Series = new ISeries[] { timedWpmSeries, untimedWpmSeries };

                wpmChart.XAxes = new Axis[]
                {
                    new Axis
                    {
                        Labels = labels,
                        NamePaint = new SolidColorPaint(SKColors.Black),
                        LabelsPaint = new SolidColorPaint(SKColors.Black),
                        TextSize = 12
                    }
                };

                wpmChart.YAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Words Per Minute",
                        NamePaint = new SolidColorPaint(SKColors.Black),
                        LabelsPaint = new SolidColorPaint(SKColors.Black),
                        TextSize = 12
                    }
                };

                var timedAccValues = testData.Select(x => x.TimedAccuracy).ToList();
                var untimedAccValues = testData.Select(x => x.UntimedAccuracy).ToList();

                var timedAccSeries = new ColumnSeries<double>
                {
                    Name = "Timed Mode",
                    Values = timedAccValues,
                    Fill = new SolidColorPaint(SKColors.DodgerBlue),
                    Stroke = null,
                    MaxBarWidth = 30
                };

                var untimedAccSeries = new ColumnSeries<double>
                {
                    Name = "Untimed Mode",
                    Values = untimedAccValues,
                    Fill = new SolidColorPaint(SKColors.Orange),
                    Stroke = null,
                    MaxBarWidth = 30
                };

                accuracyChart.Series = new ISeries[] { timedAccSeries, untimedAccSeries };

                accuracyChart.XAxes = new Axis[]
                {
                    new Axis
                    {
                        Labels = labels,
                        NamePaint = new SolidColorPaint(SKColors.Black),
                        LabelsPaint = new SolidColorPaint(SKColors.Black),
                        TextSize = 12
                    }
                };

                accuracyChart.YAxes = new Axis[]
                {
                    new Axis
                    {
                        Name = "Accuracy (%)",
                        NamePaint = new SolidColorPaint(SKColors.Black),
                        LabelsPaint = new SolidColorPaint(SKColors.Black),
                        TextSize = 12,
                        MinLimit = 0,
                        MaxLimit = 100
                    }
                };

                wpmChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Top;
                wpmChart.LegendTextPaint = new SolidColorPaint(SKColors.Black);
                wpmChart.LegendTextSize = 11;
                wpmChart.LegendBackgroundPaint = new SolidColorPaint(SKColors.LightGray.WithAlpha(100));

                accuracyChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Top;
                accuracyChart.LegendTextPaint = new SolidColorPaint(SKColors.Black);
                accuracyChart.LegendTextSize = 11;
                accuracyChart.LegendBackgroundPaint = new SolidColorPaint(SKColors.LightGray.WithAlpha(100));

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in PopulateTypingTestCharts: {ex.Message}\n\n{ex.StackTrace}", "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupEmptyCharts(
            LiveChartsCore.SkiaSharpView.WinForms.CartesianChart wpmChart,
            LiveChartsCore.SkiaSharpView.WinForms.CartesianChart accuracyChart)
        {
            var emptyValues = new[] { 0.0, 0.0, 0.0 };
            var defaultLabels = new[] { "Easy", "Intermediate", "Hard" };

            var emptyWpmSeries = new ColumnSeries<double>
            {
                Values = emptyValues,
                Fill = new SolidColorPaint(SKColors.LightGray),
                Name = "No Data Available"
            };

            wpmChart.Series = new ISeries[] { emptyWpmSeries };
            wpmChart.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = defaultLabels,
                    NamePaint = new SolidColorPaint(SKColors.Black),
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize = 12
                }
            };
            wpmChart.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Words Per Minute",
                    NamePaint = new SolidColorPaint(SKColors.Black),
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize = 12
                }
            };

            var emptyAccuracySeries = new ColumnSeries<double>
            {
                Values = emptyValues,
                Fill = new SolidColorPaint(SKColors.LightGray),
                Name = "No Data Available"
            };

            accuracyChart.Series = new ISeries[] { emptyAccuracySeries };
            accuracyChart.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = defaultLabels,
                    NamePaint = new SolidColorPaint(SKColors.Black),
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize = 12
                }
            };
            accuracyChart.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Accuracy (%)",
                    NamePaint = new SolidColorPaint(SKColors.Black),
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize = 12,
                    MinLimit = 0,
                    MaxLimit = 100
                }
            };

            wpmChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Top;
            wpmChart.LegendTextPaint = new SolidColorPaint(SKColors.Black);
            wpmChart.LegendTextSize = 11;
            wpmChart.LegendBackgroundPaint = new SolidColorPaint(SKColors.LightGray.WithAlpha(100));

            accuracyChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Top;
            accuracyChart.LegendTextPaint = new SolidColorPaint(SKColors.Black);
            accuracyChart.LegendTextSize = 11;
            accuracyChart.LegendBackgroundPaint = new SolidColorPaint(SKColors.LightGray.WithAlpha(100));
        }
    }
}