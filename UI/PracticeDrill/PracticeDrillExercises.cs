using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypeRush_Final.Data;

namespace TypeRush_Final
{
    public partial class PracticeDrillExercises : BaseControl
    {
        private int categoryID;
        private int userID;
        private DBPracticeDrill dbPracticeDrill = new DBPracticeDrill();
        private List<string> exercises;
        private SubContainerForm subContainerForm;
        private FormContainer fcontainer;

        public PracticeDrillExercises(FormContainer fcontainer, int categoryID, SubContainerForm form)
        {
            InitializeComponent();
            this.categoryID = categoryID;
            this.fcontainer = fcontainer;
            this.subContainerForm = form;

            this.userID = CurrentUser.UserID;

            SetElements();
        }
        private void SetElements()
        {
            try
            {
                exercises = dbPracticeDrill.FetchDrillExercises(categoryID);

                if (exercises == null || exercises.Count < 6)
                {
                    MessageBox.Show($"Not enough exercises found for category {categoryID}. Expected 6, found {exercises?.Count ?? 0}.",
                                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DetermineLessonTitle();

                Lesson1.Text = exercises[0];
                Lesson2.Text = exercises[1];
                Lesson3.Text = exercises[2];
                Lesson4.Text = exercises[3];
                Lesson5.Text = exercises[4];
                Lesson6.Text = exercises[5];

                UpdateStarsDisplay();
                UpdatePerformanceMetrics();

                btnSelect1.MouseClick += Button_MouseClick;
                btnSelect2.MouseClick += Button_MouseClick;
                btnSelect3.MouseClick += Button_MouseClick;
                btnSelect4.MouseClick += Button_MouseClick;
                btnSelect5.MouseClick += Button_MouseClick;
                btnSelect6.MouseClick += Button_MouseClick;
                btnSelect1.MouseHover += Button_MouseHover;
                btnSelect2.MouseHover += Button_MouseHover;
                btnSelect3.MouseHover += Button_MouseHover;
                btnSelect4.MouseHover += Button_MouseHover;
                btnSelect5.MouseHover += Button_MouseHover;
                btnSelect6.MouseHover += Button_MouseHover;
                btnSelect1.MouseLeave += Button_MouseLeave;
                btnSelect2.MouseLeave += Button_MouseLeave;
                btnSelect3.MouseLeave += Button_MouseLeave;
                btnSelect4.MouseLeave += Button_MouseLeave;
                btnSelect5.MouseLeave += Button_MouseLeave;
                btnSelect6.MouseLeave += Button_MouseLeave;
                btnGoBack.MouseHover += Button_MouseHover;  
                btnGoBack.MouseLeave += Button_MouseLeave;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error setting up exercises: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Button_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                if (btn == btnSelect1) btnSelect1.BackgroundImage = Properties.Resources.PDRILL_H_BEGIN;
                else if (btn == btnSelect2) btnSelect2.BackgroundImage = Properties.Resources.PDRILL_H_BEGIN;
                else if (btn == btnSelect3) btnSelect3.BackgroundImage = Properties.Resources.PDRILL_H_BEGIN;
                else if (btn == btnSelect4) btnSelect4.BackgroundImage = Properties.Resources.PDRILL_H_BEGIN;
                else if (btn == btnSelect5) btnSelect5.BackgroundImage = Properties.Resources.PDRILL_H_BEGIN;
                else if (btn == btnSelect6) btnSelect6.BackgroundImage = Properties.Resources.PDRILL_H_BEGIN;
                else if (btn == btnGoBack) btnGoBack.BackgroundImage = Properties.Resources.PDRILL_H_GOBACK; 
            }
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                if (btn == btnSelect1) btnSelect1.BackgroundImage = Properties.Resources.PDRILL_NH_BEGIN;
                else if (btn == btnSelect2) btnSelect2.BackgroundImage = Properties.Resources.PDRILL_NH_BEGIN;
                else if (btn == btnSelect3) btnSelect3.BackgroundImage = Properties.Resources.PDRILL_NH_BEGIN;
                else if (btn == btnSelect4) btnSelect4.BackgroundImage = Properties.Resources.PDRILL_NH_BEGIN;
                else if (btn == btnSelect5) btnSelect5.BackgroundImage = Properties.Resources.PDRILL_NH_BEGIN;
                else if (btn == btnSelect6) btnSelect6.BackgroundImage = Properties.Resources.PDRILL_NH_BEGIN;
                else if (btn == btnGoBack) btnGoBack.BackgroundImage = Properties.Resources.PDRILL_NH_GOBACK;

            }
        }
        private void UpdateStarsDisplay()
        {
            try
            {
                List<int> exerciseIDs = GetExerciseIDs();

                if (exerciseIDs == null || exerciseIDs.Count < 6)
                {
                    MessageBox.Show($"Could not retrieve enough exercise IDs for category {categoryID}. Expected 6, found {exerciseIDs?.Count ?? 0}.",
                                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Dictionary<int, int> userStars = dbPracticeDrill.GetUserStarsForCategory(userID, categoryID);

                stars1.Text = $"{GetStarsForExercise(userStars, exerciseIDs[0])}/3 stars";
                stars2.Text = $"{GetStarsForExercise(userStars, exerciseIDs[1])}/3 stars";
                stars3.Text = $"{GetStarsForExercise(userStars, exerciseIDs[2])}/3 stars";
                stars4.Text = $"{GetStarsForExercise(userStars, exerciseIDs[3])}/3 stars";
                stars5.Text = $"{GetStarsForExercise(userStars, exerciseIDs[4])}/3 stars";
                stars6.Text = $"{GetStarsForExercise(userStars, exerciseIDs[5])}/3 stars";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating stars display: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetStarsForExercise(Dictionary<int, int> userStars, int exerciseID)
        {
            return userStars.ContainsKey(exerciseID) ? userStars[exerciseID] : 0;
        }

        private List<int> GetExerciseIDs()
        {
            var ids = dbPracticeDrill.GetExerciseIDsForCategory(categoryID);

            Console.WriteLine($"Exercise IDs for category {categoryID}: {string.Join(", ", ids)}");

            return ids;
        }

        private void DetermineLessonTitle()
        {
            if (categoryID == 1) lblTitle.Text = "Home Row Keys";
            else if (categoryID == 2) lblTitle.Text = "Top Row Keys";
            else if (categoryID == 3) lblTitle.Text = "Bottom Row Keys";
            else if (categoryID == 4) lblTitle.Text = "Numbers";
            else if (categoryID == 5) lblTitle.Text = "Symbols";
        }

        private void Button_MouseClick(object sender, EventArgs e)
        {
            try
            {
                Button btn = sender as Button;
                if (btn != null)
                {
                    btn.Cursor = Cursors.Hand;

                    // Get the actual exercise IDs for this category
                    List<int> exerciseIDs = dbPracticeDrill.GetExerciseIDsForCategory(categoryID);

                    if (exerciseIDs == null || exerciseIDs.Count < 6)
                    {
                        MessageBox.Show("Could not retrieve exercise IDs.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int actualExerciseID;

                    if (btn == btnSelect1)
                    {
                        actualExerciseID = exerciseIDs[0]; 
                        subContainerForm.LoadUserControlIntoPanel(new Drill(fcontainer, categoryID, actualExerciseID, subContainerForm));
                    }
                    else if (btn == btnSelect2)
                    {
                        actualExerciseID = exerciseIDs[1]; 
                        subContainerForm.LoadUserControlIntoPanel(new Drill(fcontainer, categoryID, actualExerciseID, subContainerForm));
                    }
                    else if (btn == btnSelect3)
                    {
                        actualExerciseID = exerciseIDs[2]; 
                        subContainerForm.LoadUserControlIntoPanel(new Drill(fcontainer, categoryID, actualExerciseID, subContainerForm));
                    }
                    else if (btn == btnSelect4)
                    {
                        actualExerciseID = exerciseIDs[3]; 
                        subContainerForm.LoadUserControlIntoPanel(new Drill(fcontainer, categoryID, actualExerciseID, subContainerForm));
                    }
                    else if (btn == btnSelect5)
                    {
                        actualExerciseID = exerciseIDs[4]; 
                        subContainerForm.LoadUserControlIntoPanel(new Drill(fcontainer, categoryID, actualExerciseID, subContainerForm));
                    }
                    else if (btn == btnSelect6)
                    {
                        actualExerciseID = exerciseIDs[5]; 
                        subContainerForm.LoadUserControlIntoPanel(new Drill(fcontainer, categoryID, actualExerciseID, subContainerForm));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading drill: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                subContainerForm.LoadUserControlIntoPanel(new PracticeDrillSelection(fcontainer, subContainerForm));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error returning to selection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    
     private void UpdatePerformanceMetrics()
        {
            try
            {
                List<int> exerciseIDs = GetExerciseIDs();

                if (exerciseIDs == null || exerciseIDs.Count < 6)
                {
                    MessageBox.Show($"Could not retrieve enough exercise IDs for performance metrics.",
                                    "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Dictionary<int, (int avgWPM, int avgAccuracy)> userAverages =
                    dbPracticeDrill.GetUserDrillAverages(userID, categoryID);

                lblWPM1.Text = $"WPM: {GetAvgWPM(userAverages, exerciseIDs[0])}";
                lblWPM2.Text = $"WPM: {GetAvgWPM(userAverages, exerciseIDs[1])}";
                lblWPM3.Text = $"WPM: {GetAvgWPM(userAverages, exerciseIDs[2])}";
                lblWPM4.Text = $"WPM: {GetAvgWPM(userAverages, exerciseIDs[3])}";
                lblWPM5.Text = $"WPM: {GetAvgWPM(userAverages, exerciseIDs[4])}";
                lblWPM6.Text = $"WPM: {GetAvgWPM(userAverages, exerciseIDs[5])}";

                lblAccuracy1.Text = $"Accuracy: {GetAvgAccuracy(userAverages, exerciseIDs[0])}%";
                lblAccuracy2.Text = $"Accuracy: {GetAvgAccuracy(userAverages, exerciseIDs[1])}%";
                lblAccuracy3.Text = $"Accuracy: {GetAvgAccuracy(userAverages, exerciseIDs[2])}%";
                lblAccuracy4.Text = $"Accuracy: {GetAvgAccuracy(userAverages, exerciseIDs[3])}%";
                lblAccuracy5.Text = $"Accuracy: {GetAvgAccuracy(userAverages, exerciseIDs[4])}%";
                lblAccuracy6.Text = $"Accuracy: {GetAvgAccuracy(userAverages, exerciseIDs[5])}%";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating performance metrics: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int GetAvgWPM(Dictionary<int, (int avgWPM, int avgAccuracy)> userAverages, int exerciseID)
        {
            return userAverages.ContainsKey(exerciseID) ? userAverages[exerciseID].avgWPM : 0;
        }

        private int GetAvgAccuracy(Dictionary<int, (int avgWPM, int avgAccuracy)> userAverages, int exerciseID)
        {
            return userAverages.ContainsKey(exerciseID) ? userAverages[exerciseID].avgAccuracy : 0;
        }
    }
}
    