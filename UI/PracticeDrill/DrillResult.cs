using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using TypeRush_Final.UI.AchievementsAndLeaderboard;
using TypeRush_Final.UI.LevelUpAndLeaderboard;

namespace TypeRush_Final
{
    public partial class DrilLResult : UserControl
    {
        private string[] messages = {
        "CONGRATULATIONS! YOU LEVELED UP!",
        $"LEVEL  - TYPIST"
        };

        private int currentMessageIndex = 0;
        private int charIndex = 0;
        private int WPM { get; set; }
        private int accuracy { get; set; }
        private int starsGained { get; set; }
        private int xpGained { get; set; }
        private int timerTick = 0, newLevel, counter = 0;
        private SubContainerForm subContainerForm { get; set; }
        private FormContainer form { get; set; }
        private string connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";

        public DrilLResult(FormContainer fcontainer, int WPM, int accuracy, int starsGained, int xpGained, SubContainerForm form)
        {
            InitializeComponent();
            this.WPM = WPM;
            this.accuracy = accuracy;
            this.starsGained = starsGained;
            this.xpGained = xpGained;
            this.subContainerForm = form;
            this.form = fcontainer;

            SetElements();
            timer.Start();

            UpdateUserXP();
            CheckForLevelUp();
        }

        private void SetElements()
        {
            lblStars.Text = $"You earned {starsGained}/3 for this drill!";
            lblWPM.Text = $"Your speed was {WPM} WPM with {accuracy}% accuracy.";
            lblCongrats.Text = "";
            lblLevel.Text = "";

            textTimer.Interval = 50;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (timerTick == 0 && starsGained >= 1)
            {
                star1.Visible = true;
            }
            else if (timerTick == 1 && starsGained >= 2)
            {
                star2.Visible = true;
            }
            else if (timerTick == 2 && starsGained == 3)
            {
                star3.Visible = true;
            }

            timerTick++;

            if (timerTick >= starsGained)
            {
                timer.Stop();
            }
        }

        private void btnGoBack_MouseHover(object sender, EventArgs e)
        {
            btnGoBack.Cursor = Cursors.Hand;
            btnGoBack.BackgroundImage = Properties.Resources.t_h_back;
        }

        private void btnGoBack_MouseLeave(object sender, EventArgs e)
        {
            btnGoBack.BackgroundImage = Properties.Resources.t_nh_back;
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            subContainerForm.LoadUserControlIntoPanel(new PracticeDrillSelection(form, subContainerForm));
        }

        private void UpdateUserXP()
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
                        cmd.Parameters.AddWithValue("@UserID", CurrentUser.UserID);
                        cmd.Parameters.AddWithValue("@XPGained", xpGained);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            CurrentUser.XP = result.ToString();
                        }
                    }
                }
            }
            catch (Exception) { }
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

        private void ShowLevelUpNotification(int newLevel)
        {
            showAward(true, true);
        }
     

        private void button1_Click(object sender, EventArgs e)
        {
         
        }


        private void showAward(bool determine, bool signal)
        {
            messages = new string[] {
            "CONGRATULATIONS! YOU LEVELED UP!",
            $"LEVEL {CurrentUser.currentLevel}  - {CurrentUser.levelName}"
            };  
            lblCongrats.Text = "";
            lblLevel.Text = "";
            pbxLevel.Visible = determine;
            btnBack.Visible = determine;
            lblLevel.Visible = determine;
            lblCongrats.Visible = determine;

            if (signal == true)
            {
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            showAward(false, false);
        }
    }
}