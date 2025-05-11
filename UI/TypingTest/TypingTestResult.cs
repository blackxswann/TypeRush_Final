using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TypeRush_Final.Data;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using Microsoft.Data.SqlClient;

namespace TypeRush_Final.UI.TypingTest
{
    public partial class TypingTestResult : BaseControl
    {
        private string[] messages = {
            "CONGRATULATIONS! YOU LEVELED UP!",
            $"LEVEL  - TYPIST"
        };
        private string connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";
        private int currentMessageIndex = 0;
        private int charIndex = 0;
        private int newLevel;
        private SubContainerForm form;
        private int userID;
        private int wpm;
        private int accuracy;
        private TimeSpan elapsedTime;
        private Dictionary<char, int> mistypedCharacters;
        private string testMode;
        private string difficultyLevel;
        private DBAnalytics dbAnalytics;

        public TypingTestResult()
        {
            InitializeComponent();
        }

        public TypingTestResult(SubContainerForm form, int userID, int wpm, int accuracy,
        TimeSpan elapsedTime, Dictionary<char, int> mistypedCharacters,
        string testMode, string difficultyLevel)
        {
            InitializeComponent();
            goBackPbx.Parent = pbxBackground;
            this.form = form;
            this.userID = userID;
            this.wpm = wpm;
            this.accuracy = accuracy;
            this.mistypedCharacters = mistypedCharacters;
            this.testMode = testMode;
            this.difficultyLevel = difficultyLevel;
            this.dbAnalytics = new DBAnalytics();
            this.Load += TypingTestResult_Load;

            int xpGained = CalculateXPGained();
            UpdateUserXP(xpGained);

            DisplayResults();
        }
        

        private void TypingTestResult_Load(object sender, EventArgs e)
        {
            DisplayResults();
        }

        private void DisplayResults()
        {
            PopulateMistypesBarGraph();
            lblWPM.Text = $"WPM: {wpm.ToString()}";
            lblAccuracy.Text = $"Accuracy: {accuracy.ToString()}%";
            CheckForLevelUp(); 
        }

        private string FormatElapsedTime(TimeSpan time)
        {
            if (time.TotalHours >= 1)
            {
                return $"{(int)time.TotalHours}h {time.Minutes}m {time.Seconds}s";
            }
            else if (time.TotalMinutes >= 1)
            {
                return $"{time.Minutes}m {time.Seconds}s";
            }
            else
            {
                return $"{time.Seconds}s";
            }
        }
        private void PopulateMistypesBarGraph()
        {
            try
            {
                if (mistypedCharacters == null || mistypedCharacters.Count == 0)
                {
                    ShowEmptyBarGraph();
                    return;
                }

                var topMistypes = mistypedCharacters
                    .OrderByDescending(x => x.Value)
                    .Take(10)
                    .ToList();

                if (topMistypes.Count == 0)
                {
                    ShowEmptyBarGraph();
                    return;
                }

                var values = topMistypes.Select(x => x.Value).ToArray();

                var labels = topMistypes.Select(x =>
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
                barGraph.Series = new ISeries[] { barSeries };

                barGraph.XAxes = new Axis[]
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

                barGraph.YAxes = new Axis[]
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


                barGraph.LegendPosition = LiveChartsCore.Measure.LegendPosition.Top;
                barGraph.LegendTextPaint = new SolidColorPaint(SKColors.Black);
                barGraph.LegendTextSize = 14;
                barGraph.LegendBackgroundPaint = new SolidColorPaint(SKColors.LightGray.WithAlpha(100));

                barGraph.BackColor = Color.White;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error displaying mistype chart: {ex.Message}",
                    "Chart Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowEmptyBarGraph()
        {
            barGraph.Series = new ISeries[]
            {
                new RowSeries<int>
                {
                    Values = new[] { 0 },
                    Fill = new SolidColorPaint(SKColors.LightGray),
                    Name = "No Mistakes"
                }
            };

            barGraph.YAxes = new Axis[]
            {
                new Axis
                {
                    Labels = new[] { "No mistakes found" },
                    NamePaint = new SolidColorPaint(SKColors.Black),
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize = 14
                }
            };

            barGraph.XAxes = new Axis[]
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

            barGraph.BackColor = Color.White;
        }

       
        private void CheckForLevelUp()
        {
            try
            {
                if (string.IsNullOrEmpty(CurrentUser.XP) ||
                    string.IsNullOrEmpty(CurrentUser.currentLevel) ||
                    string.IsNullOrEmpty(CurrentUser.NextLevelXPRequired))
                {
                    return;
                }

                int currentXP = int.Parse(CurrentUser.XP);
                int currentLevel = int.Parse(CurrentUser.currentLevel);
                int nextLevelXPRequired = int.Parse(CurrentUser.NextLevelXPRequired);
                bool leveledUp = false;
                int levelsGained = 0;
                int finalLevel = currentLevel;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    while (currentXP >= nextLevelXPRequired)
                    {
                        leveledUp = true;
                        levelsGained++;
                        finalLevel = currentLevel + levelsGained;

                        string nextLevelQuery = @"
                    SELECT [XPRequired]
                    FROM Level
                    WHERE LevelID = @NextLevelID";

                        using (SqlCommand cmd = new SqlCommand(nextLevelQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@NextLevelID", finalLevel + 1);
                            object result = cmd.ExecuteScalar();

                            if (result == null || result == DBNull.Value)
                            {
                                break;
                            }

                            nextLevelXPRequired = Convert.ToInt32(result);

                            if (currentXP < nextLevelXPRequired)
                            {
                                break;
                            }
                        }
                    }

                    if (leveledUp)
                    {
                        string updateQuery = "UPDATE UserInformation SET CurrentLevel = @NewLevel WHERE UserID = @UserID";
                        using (SqlCommand cmd = new SqlCommand(updateQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@NewLevel", finalLevel);
                            cmd.Parameters.AddWithValue("@UserID", CurrentUser.UserID); 
                            cmd.ExecuteNonQuery();
                        }

                        CurrentUser.currentLevel = finalLevel.ToString();

                        string levelQuery = @"
                    SELECT l.[LevelName], l.[XPRequired],
                           nextLevel.[LevelID] AS NextLevelID, 
                           nextLevel.[LevelName] AS NextLevelName, 
                           nextLevel.[XPRequired] AS NextLevelXPRequired
                    FROM Level l
                    LEFT JOIN Level nextLevel ON nextLevel.LevelID = (l.LevelID + 1)
                    WHERE l.LevelID = @CurrentLevel";

                        using (SqlCommand cmd = new SqlCommand(levelQuery, connection))
                        {
                            cmd.Parameters.AddWithValue("@CurrentLevel", finalLevel);
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

                        ShowLevelUpNotification(finalLevel);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking for level up: {ex.Message}", "Level Up Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int CalculateXPGained()
        {
            return 150;
        }

        private void UpdateUserXP(int xpGained)
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
                        cmd.Parameters.AddWithValue("@UserID", userID);
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
                MessageBox.Show($"Error updating XP: {ex.Message}", "XP Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowLevelUpNotification(int newLevel)
        {
            messages = new string[] {
        "CONGRATULATIONS! YOU LEVELED UP!",
        $"LEVEL {CurrentUser.currentLevel} - {CurrentUser.levelName}"
    };

            showAward(true, true);
        }

        private void showAward(bool determine, bool signal)
        {
    

            lblCongrats.Text = "";
            lblLevel.Text = "";
            pbxLevel.Visible = determine;
            btnBack.Visible = determine;
            lblLevel.Visible = determine;
            lblCongrats.Visible = determine;

            if (determine)
            {
                pbxLevel.BringToFront();
                lblCongrats.BringToFront();
                lblLevel.BringToFront();
                btnBack.BringToFront();
            }

            if (signal)
            {
                currentMessageIndex = 0;
                charIndex = 0;
                textTimer.Enabled = true;
                textTimer.Start();
            }
        }
        private void textTimer_Tick(object sender, EventArgs e)
        {
            if (currentMessageIndex == 0)
            {
                if (charIndex < messages[0].Length)
                {
                    lblCongrats.Text += messages[0][charIndex];
                    charIndex++;
                }
                else
                {
                    currentMessageIndex = 1;
                    charIndex = 0;
                }
            }
            else if (currentMessageIndex == 1)
            {
                if (charIndex < messages[1].Length)
                {
                    lblLevel.Text += messages[1][charIndex];
                    charIndex++;
                }
                else
                {
                    textTimer.Stop();
                }
            }
        }
        private void pbxBackground_MouseHover(object sender, EventArgs e)
        {

        }

        private void goBackPbx_MouseLeave(object sender, EventArgs e)
        {
            goBackPbx.Image = Properties.Resources.drill_nh_goback;

        }

        private void goBackPbx_MouseHover(object sender, EventArgs e)
        {
            goBackPbx.Cursor = Cursors.Hand;
            goBackPbx.Image = Properties.Resources.drill_h_goback;
        }

        private void goBackPbx_Click(object sender, EventArgs e)
        {
            form.LoadUserControlIntoPanel(new TypingTestSelection(form));
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            showAward(false, false);
        }
    }
}