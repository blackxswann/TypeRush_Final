using Microsoft.Data.SqlClient;
using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TypeRush_Final
{
    public partial class PracticeDrillSelection : BaseControl
    {
        private Dictionary<int, CategoryProgress> categoryProgressData;

        private int choiceCounter = 0; 
        private SubContainerForm subContainerForm;
        private FormContainer formContainer;
        public PracticeDrillSelection(FormContainer fcontainer, SubContainerForm form)
        {
            InitializeComponent();
            formContainer = fcontainer; 
            subContainerForm = form; 
            SetElements();
            LoadUserDrillProgress(CurrentUser.UserID);

        }

        private void SetElements()
        {
            pnl1.MouseHover += Panel_MouseHover;
            pnl1.MouseLeave += Panel_MouseLeave;
            pnl2.MouseHover += Panel_MouseHover;
            pnl2.MouseLeave += Panel_MouseLeave;
            pnl3.MouseHover += Panel_MouseHover;
            pnl3.MouseLeave += Panel_MouseLeave;
            pnl4.MouseHover += Panel_MouseHover;
            pnl4.MouseLeave += Panel_MouseLeave;
            pnl5.MouseHover += Panel_MouseHover;
            pnl5.MouseLeave += Panel_MouseLeave; 
            pnl1.MouseClick+= Panel_MouseClick; 
            pnl2.MouseClick += Panel_MouseClick;
            pnl3.MouseClick += Panel_MouseClick;
            pnl4.MouseClick += Panel_MouseClick;
            pnl5.MouseClick += Panel_MouseClick;
            btnNext.MouseClick += Button_MouseClick;
            btnPrevious.MouseClick += Button_MouseClick;

        }

        private void Panel_MouseHover(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl != null)
            {
                pnl.Cursor = Cursors.Hand;
                if (pnl == pnl1)
                {
                    pnl1.BackgroundImage = Properties.Resources.pdrill_hoveredpanel;
                }
                else if (pnl == pnl2)
                {
                    pnl2.BackgroundImage = Properties.Resources.pdrill_hoveredpanel;
                }
                else if (pnl == pnl3)
                {
                    pnl3.BackgroundImage = Properties.Resources.pdrill_hoveredpanel;
                }
                else if (pnl == pnl4)
                {
                    pnl4.BackgroundImage = Properties.Resources.pdrill_hoveredpanel;
                }
                else if (pnl == pnl5)
                {
                    pnl5.BackgroundImage = Properties.Resources.pdrill_hoveredpanel;
                }
            }
        }

        private void Panel_MouseLeave(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl != null)
            {
                if (pnl == pnl1)
                {
                    pnl1.BackgroundImage = Properties.Resources.pdrill_homerowpanel;
                }
                else if (pnl == pnl2)
                {
                    pnl2.BackgroundImage = Properties.Resources.pdrill_bottomrowpanel;
                }
                else if (pnl == pnl3)
                {
                    pnl3.BackgroundImage = Properties.Resources.pdrill_toprowpanel;
                }
                else if (pnl == pnl4)
                {
                    pnl4.BackgroundImage = Properties.Resources.pdrill_number; 
                }
                else if (pnl == pnl5)
                {
                    pnl5.BackgroundImage = Properties.Resources.pdrill_symbol; 
                }
            }
        }

        private void Panel_MouseClick(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;
            if (pnl != null)
            {
                if (pnl == pnl1)
                {
                    subContainerForm.LoadUserControlIntoPanel(new PracticeDrillExercises(formContainer, 1, subContainerForm)); 
                }
                else if (pnl == pnl2)
                {
                    subContainerForm.LoadUserControlIntoPanel(new PracticeDrillExercises(formContainer, 2, subContainerForm));
                }
                else if (pnl == pnl3)
                {
                    subContainerForm.LoadUserControlIntoPanel(new PracticeDrillExercises(formContainer, 3, subContainerForm));
                }
                else if (pnl == pnl4)
                {
                    subContainerForm.LoadUserControlIntoPanel(new PracticeDrillExercises(formContainer, 4, subContainerForm));
                }
                else if (pnl == pnl5)
                {
                    subContainerForm.LoadUserControlIntoPanel(new PracticeDrillExercises(formContainer, 5, subContainerForm));

                }
            }
        }

        private void Button_MouseClick(object sender, EventArgs e)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;
            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;

                if (btn == btnPrevious)
                {
                    choiceCounter--; 
                    if (choiceCounter < 0)
                    {
                        choiceCounter = 1; 
                    }
                    FirstOrSecondPage(choiceCounter); 
                }

                else if (btn == btnNext)
                {
                    choiceCounter++; 
                    if (choiceCounter > 1)
                    {
                        choiceCounter = 0;
                    }
                    FirstOrSecondPage(choiceCounter); 
                }
            }
        }

        private void FirstOrSecondPage(int page)
        {
            if (page == 1)
            {
                ShowOrHideFirstPage(false); 
                ShowOrHideSecondPage(true); 
            }
            else
            {
                ShowOrHideFirstPage(true);
                ShowOrHideSecondPage(false); 
            }
        }

        private void ShowOrHideFirstPage(bool showOrHide)
        {
            pnl1.Visible = showOrHide;
            pnl2.Visible = showOrHide;
            pnl3.Visible = showOrHide;
            p_pnl1.Visible = showOrHide;
            p_pnl2.Visible = showOrHide;
            p_pnl3.Visible = showOrHide;
        }

        private void ShowOrHideSecondPage(bool showOrHide)
        {
            pnl4.Visible = showOrHide;
            pnl5.Visible = showOrHide;
            p_pnl4.Visible = showOrHide;
            p_pnl5.Visible = showOrHide;
        }


        public void LoadUserDrillProgress(int userID)
        {
            categoryProgressData = new Dictionary<int, CategoryProgress>();
            string connectionString = @"Server=.\SQLEXPRESS;Database=Users;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    LoadCategoriesAndExerciseCounts(connection);

                    LoadUserProgressData(connection, userID);
                    UpdateProgressUI();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading progress data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCategoriesAndExerciseCounts(SqlConnection connection)
        {
            string query = @"
        SELECT 
            c.DrillCategoryID,
            c.CategoryName,
            COUNT(e.DrillExerciseID) AS TotalExercises
        FROM DrillCategory c
        LEFT JOIN DrillExercises e ON c.DrillCategoryID = e.DrillCategoryID
        GROUP BY c.DrillCategoryID, c.CategoryName";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int categoryID = reader.GetInt32(0);
                        string categoryName = reader.GetString(1);
                        int totalExercises = reader.GetInt32(2);

                        Console.WriteLine($"Found category: ID={categoryID}, Name={categoryName}, Exercises={totalExercises}");

                        categoryProgressData[categoryID] = new CategoryProgress
                        {
                            CategoryName = categoryName,
                            TotalExercises = totalExercises,
                            CompletedExercises = 0,
                            TotalStars = 0,
                            MaxPossibleStars = totalExercises * 3
                        };
                    }
                }
            }

            string exerciseQuery = @"
        SELECT 
            DrillExerciseID,
            DrillCategoryID,
            ExerciseName,
            ExerciseNumber
        FROM DrillExercises
        ORDER BY DrillCategoryID, ExerciseNumber";

            using (SqlCommand command = new SqlCommand(exerciseQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int exerciseID = reader.GetInt32(0);
                        int categoryID = reader.GetInt32(1);
                        string exerciseName = reader.GetString(2);
                        int exerciseNumber = reader.GetInt32(3);

                        if (categoryProgressData.ContainsKey(categoryID))
                        {
                            categoryProgressData[categoryID].Exercises.Add(new ExerciseProgress
                            {
                                ExerciseID = exerciseID,
                                ExerciseName = exerciseName,
                                ExerciseNumber = exerciseNumber,
                                StarsEarned = 0
                            });
                        }
                    }
                }
            }
        }

        private void LoadUserProgressData(SqlConnection connection, int userID)
        {
            string query = @"
        WITH MaxStarsPerExercise AS (
            SELECT 
                p.DrillExerciseID,
                MAX(p.StarsGained) AS MaxStars
            FROM UserPracticeDrillProgress p
            WHERE p.UserID = @UserID
            GROUP BY p.DrillExerciseID
        )
        SELECT 
            e.DrillExerciseID,
            e.DrillCategoryID,
            ISNULL(m.MaxStars, 0) AS StarsGained
        FROM DrillExercises e
        LEFT JOIN MaxStarsPerExercise m ON e.DrillExerciseID = m.DrillExerciseID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserID", userID);

                foreach (var category in categoryProgressData.Values)
                {
                    category.CompletedExercises = 0;
                    category.TotalStars = 0;
                }

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int exerciseID = reader.GetInt32(0);
                        int categoryID = reader.GetInt32(1);
                        int starsGained = reader.GetInt32(2);

                        if (categoryProgressData.ContainsKey(categoryID))
                        {
                            var category = categoryProgressData[categoryID];

                            var exercise = category.Exercises.FirstOrDefault(e => e.ExerciseID == exerciseID);

                            if (exercise != null)
                            {
                                exercise.StarsEarned = starsGained;

                                if (starsGained > 0)
                                {
                                    category.CompletedExercises++;
                                }

                                category.TotalStars += starsGained;
                            }
                            else
                            {
                                Console.WriteLine($"Warning: Could not find exercise ID {exerciseID} in category {categoryID}");
                            }
                        }
                    }
                }

                foreach (var category in categoryProgressData.Values)
                {
                    Console.WriteLine($"Category {category.CategoryName}: {category.CompletedExercises}/{category.TotalExercises} completed, {category.TotalStars}/{category.MaxPossibleStars} stars");
                }
            }
        }
        private void UpdateProgressUI()
        {
            Console.WriteLine($"Categories in progress data: {string.Join(", ", categoryProgressData.Keys)}");

            if (categoryProgressData.ContainsKey(1))
            {
                UpdateCategoryProgressBar(1, progressBar1, percentage1);
                UpdateCategoryStars(1, stars1);
                Console.WriteLine($"Updated UI for category 1: {categoryProgressData[1].CompletionPercentage}% complete");
            }
            else
            {
                Console.WriteLine("Category 1 not found in progress data");
            }

            if (categoryProgressData.ContainsKey(2))
            {
                UpdateCategoryProgressBar(2, progressBar2, percentage2);
                UpdateCategoryStars(2, stars2);
                Console.WriteLine($"Updated UI for category 2: {categoryProgressData[2].CompletionPercentage}% complete");
            }

            if (categoryProgressData.ContainsKey(3))
            {
                UpdateCategoryProgressBar(3, progressBar3, percentage3);
                UpdateCategoryStars(3, stars3);
                Console.WriteLine($"Updated UI for category 3: {categoryProgressData[3].CompletionPercentage}% complete");
            }

            if (categoryProgressData.ContainsKey(4))
            {
                UpdateCategoryProgressBar(4, progressBar4, percentage4);
                UpdateCategoryStars(4, stars4);
                Console.WriteLine($"Updated UI for category 4: {categoryProgressData[4].CompletionPercentage}% complete");
            }

            if (categoryProgressData.ContainsKey(5))
            {
                UpdateCategoryProgressBar(5, progressBar5, percentage5);
                UpdateCategoryStars(5, stars5);
                Console.WriteLine($"Updated UI for category 5: {categoryProgressData[5].CompletionPercentage}% complete");
            }
        }

        public void UpdateCategoryProgressBar(int categoryID, PictureBox progressBar, Label percentageLabel)
        {
            if (progressBar == null || percentageLabel == null)
            {
                Console.WriteLine($"Warning: Progress bar or label is null for category {categoryID}");
                return;
            }

            if (!categoryProgressData.ContainsKey(categoryID))
            {
                Console.WriteLine($"Warning: Category {categoryID} not found in progress data");
                return;
            }

            double percentage = categoryProgressData[categoryID].CompletionPercentage;
            Console.WriteLine($"Updating progress bar for category {categoryID}: {percentage}%");

            int width = (int)(475 * percentage / 100.0);
            width = Math.Min(475, Math.Max(0, width)); 

            progressBar.Width = width;
            percentageLabel.Text = $"{percentage:F0}%";

            progressBar.Refresh();
            percentageLabel.Refresh();
        }

        public void UpdateCategoryStars(int categoryID, Label starsLabel)
        {
            if (starsLabel == null)
            {
                Console.WriteLine($"Warning: Stars label is null for category {categoryID}");
                return;
            }

            if (!categoryProgressData.ContainsKey(categoryID))
            {
                Console.WriteLine($"Warning: Category {categoryID} not found in progress data");
                return;
            }

            int stars = categoryProgressData[categoryID].TotalStars;
            int maxStars = categoryProgressData[categoryID].MaxPossibleStars;

            Console.WriteLine($"Updating stars for category {categoryID}: {stars}/{maxStars}");

            starsLabel.Text = $"{stars}/{maxStars}";
            starsLabel.Refresh(); 
        }
       

        public CategoryProgress GetCategoryProgress(int categoryID)
        {
            if (categoryProgressData.ContainsKey(categoryID))
                return categoryProgressData[categoryID];

            return null;
        }
    }

    public class CategoryProgress
    {
        public string CategoryName { get; set; }
        public int TotalExercises { get; set; }
        public int CompletedExercises { get; set; }
        public int TotalStars { get; set; }
        public int MaxPossibleStars { get; set; }
        public List<ExerciseProgress> Exercises { get; set; }

        public CategoryProgress()
        {
            Exercises = new List<ExerciseProgress>();
        }

        public double CompletionPercentage
        {
            get => TotalExercises > 0 ? (double)CompletedExercises / TotalExercises * 100 : 0;
        }

    }

    public class ExerciseProgress
    {
        public int ExerciseID { get; set; }
        public string ExerciseName { get; set; }
        public int ExerciseNumber { get; set; }
        public int StarsEarned { get; set; }
    }

}
