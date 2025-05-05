using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using OpenTK.Graphics.ES20;

namespace TypeRush_Final
{
    public partial class Leaderboard : UserControl
    {
        private string _connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";
        FormContainer fcontainer;
        private string currentView = "Level";

        public Leaderboard(FormContainer fcontainer)
        {
            InitializeComponent();
            this.fcontainer = fcontainer;

            SetupDataGridView();
            LoadLeaderboardData("Level");
        }

        private void SetupDataGridView()
        {
            dgv1.Columns.Clear();

            dgv1.Columns.Add("Rank", "Rank");
            dgv1.Columns.Add("Username", "Username");
            dgv1.Columns.Add("DisplayName", "Display Name");

            dgv1.Columns.Add("Level", "Level");
            dgv1.Columns.Add("LevelName", "Level Name");
            dgv1.Columns.Add("XP", "XP");
            dgv1.Columns.Add("Stars", "Total Stars");
            dgv1.Columns.Add("WPM", "Average WPM");
            dgv1.Columns.Add("Accuracy", "Average Accuracy (%)");
            dgv1.Columns.Add("MinigameScore", "Highest Score");
            dgv1.Columns.Add("TotalXP", "Total XP Gained");

            dgv1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv1.AllowUserToAddRows = false;
            dgv1.AllowUserToDeleteRows = false;
            dgv1.ReadOnly = true;
            dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv1.RowHeadersVisible = false;
            dgv1.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        public void LoadLeaderboardData(string viewType)
        {
            try
            {
                dgv1.Rows.Clear();
                currentView = viewType;

                UpdateColumnVisibility(viewType);

                string query = CreateQueryForViewType(viewType);

                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int rank = 1;

                            while (reader.Read())
                            {
                                string username = reader["Username"].ToString();
                                string displayName = reader["DisplayName"].ToString();

                                var row = new object[11]; // Array to accommodate all columns
                                row[0] = rank;
                                row[1] = username;
                                row[2] = displayName;

                                switch (viewType)
                                {
                                    case "Level":
                                        row[3] = reader.IsDBNull(reader.GetOrdinal("CurrentLevel")) ? 0 : Convert.ToInt32(reader["CurrentLevel"]);
                                        row[4] = reader.IsDBNull(reader.GetOrdinal("LevelName")) ? "None" : reader["LevelName"].ToString();
                                        row[5] = reader.IsDBNull(reader.GetOrdinal("XP")) ? 0 : Convert.ToInt32(reader["XP"]);
                                        break;
                                    case "Stars":
                                        row[6] = reader.IsDBNull(reader.GetOrdinal("TotalStars")) ? 0 : Convert.ToInt32(reader["TotalStars"]);
                                        break;
                                    case "WPM":
                                        row[7] = reader.IsDBNull(reader.GetOrdinal("AvgWPM")) ? 0.0 : Math.Round(Convert.ToDouble(reader["AvgWPM"]), 1);
                                        break;
                                    case "Accuracy":
                                        row[8] = reader.IsDBNull(reader.GetOrdinal("AvgAccuracy")) ? 0.0 : Math.Round(Convert.ToDouble(reader["AvgAccuracy"]), 1);
                                        break;
                                    case "Minigame":
                                        row[9] = reader.IsDBNull(reader.GetOrdinal("HighestScore")) ? 0 : Convert.ToInt32(reader["HighestScore"]);
                                        row[10] = reader.IsDBNull(reader.GetOrdinal("TotalXPGained")) ? 0 : Convert.ToInt32(reader["TotalXPGained"]);
                                        break;
                                }

                                dgv1.Rows.Add(row);
                                rank++;
                            }
                        }
                    }
                }

                if (dgv1.Rows.Count == 0)
                {
                    MessageBox.Show($"No user data found for the {viewType} leaderboard.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading {viewType} leaderboard data: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateColumnVisibility(string viewType)
        {
            dgv1.Columns["Level"].Visible = false;
            dgv1.Columns["LevelName"].Visible = false;
            dgv1.Columns["XP"].Visible = false;
            dgv1.Columns["Stars"].Visible = false;
            dgv1.Columns["WPM"].Visible = false;
            dgv1.Columns["Accuracy"].Visible = false;
            dgv1.Columns["MinigameScore"].Visible = false;
            dgv1.Columns["TotalXP"].Visible = false;

            switch (viewType)
            {
                case "Level":
                    dgv1.Columns["Level"].Visible = true;
                    dgv1.Columns["LevelName"].Visible = true;
                    dgv1.Columns["XP"].Visible = true;
                    break;
                case "Stars":
                    dgv1.Columns["Stars"].Visible = true;
                    break;
                case "WPM":
                    dgv1.Columns["WPM"].Visible = true;
                    break;
                case "Accuracy":
                    dgv1.Columns["Accuracy"].Visible = true;
                    break;
                case "Minigame":
                    dgv1.Columns["MinigameScore"].Visible = true;
                    dgv1.Columns["TotalXP"].Visible = true;
                    break;
            }
        }

        private string CreateQueryForViewType(string viewType)
        {
            string query = "";

            switch (viewType)
            {
                case "Minigame":
                    query = @"
                SELECT 
                    u.Username, 
                    u.DisplayName, 
                    ISNULL(MAX(m.Score), 0) AS HighestScore,
                    ISNULL(SUM(m.XPGained), 0) AS TotalXPGained,
                    MAX(m.DatePlayed) AS LastPlayed
                FROM 
                    UserInformation u
                LEFT JOIN 
                    MinigameSession m ON u.UserID = m.UserID
                GROUP BY 
                    u.Username, u.DisplayName
                ORDER BY 
                    HighestScore DESC";
                    break;

                // Other cases remain the same
                case "Level":
                    query = @"
                SELECT 
                    u.Username, 
                    u.DisplayName, 
                    u.CurrentLevel, 
                    l.LevelName, 
                    u.XP 
                FROM 
                    UserInformation u
                LEFT JOIN 
                    Level l ON u.CurrentLevel = l.LevelID
                ORDER BY 
                    u.CurrentLevel DESC, u.XP DESC";
                    break;

                case "Stars":
                    query = @"
                SELECT 
                    u.Username, 
                    u.DisplayName, 
                    ISNULL(SUM(p.StarsGained), 0) AS TotalStars
                FROM 
                    UserInformation u
                LEFT JOIN 
                    UserPracticeDrillProgress p ON u.UserID = p.UserID
                GROUP BY 
                    u.Username, u.DisplayName
                ORDER BY 
                    TotalStars DESC";
                    break;

                case "WPM":
                    query = @"
                SELECT 
                    u.Username, 
                    u.DisplayName, 
                    ISNULL(AVG(p.WPM), 0) AS AvgWPM
                FROM 
                    UserInformation u
                LEFT JOIN 
                    UserPracticeDrillProgress p ON u.UserID = p.UserID
                GROUP BY 
                    u.Username, u.DisplayName
                ORDER BY 
                    AvgWPM DESC";
                    break;

                case "Accuracy":
                    query = @"
                SELECT 
                    u.Username, 
                    u.DisplayName, 
                    ISNULL(AVG(p.Accuracy), 0) AS AvgAccuracy
                FROM 
                    UserInformation u
                LEFT JOIN 
                    UserPracticeDrillProgress p ON u.UserID = p.UserID
                GROUP BY 
                    u.Username, u.DisplayName
                ORDER BY 
                    AvgAccuracy DESC";
                    break;
            }

            return query;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadLeaderboardData(currentView);
        }

        private void lblByLevel_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.f_lead1;
            LoadLeaderboardData("Level");
        }

        private void MostStars_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.f_lead2;
            LoadLeaderboardData("Stars");
        }

        private void TypingSpeed_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.f_lead3;
            LoadLeaderboardData("WPM");

        }

        private void Accuracy_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.f_lead4;
            LoadLeaderboardData("Accuracy");

        }

        private void minigame_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.f_lead5;
            LoadLeaderboardData("Minigame");
        }

        private void lblByLevel_Click_1(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.f_lead1;
            LoadLeaderboardData("Level");
        }
    }
}