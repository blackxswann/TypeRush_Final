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
    public partial class ProfileForm : UserControl
    {
        SubContainerForm subContainerForm;
        private FormContainer fcontainer;
        public ProfileForm(FormContainer fcontainer, SubContainerForm form)
        {
            InitializeComponent();
            this.fcontainer = fcontainer;
            this.subContainerForm = form; // Fixed: storing the passed form reference
            DisplayUserStats(); // Get stats first
            SetElements();      // Then set UI elements with stats
        }

        private void SetElements()
        {
            lblLevel.Text = $"Level {CurrentUser.currentLevel}";
            lblLevelName.Text = CurrentUser.levelName;
            lblpoints.Text = CurrentUser.XP;

            if (!string.IsNullOrEmpty(CurrentUser.NextLevelXPRequired))
            {
                lblXP.Text = $"{CurrentUser.XP}/{CurrentUser.NextLevelXPRequired}";
            }
            else
            {
                lblXP.Text = CurrentUser.XP;
            }

            lblDisplayName.Text = CurrentUser.DisplayName;
            lblUsername.Text = $"@{CurrentUser.Username}";

            int maxBarWidth = 357;

            if (int.TryParse(CurrentUser.XP, out int currentXP) &&
                int.TryParse(CurrentUser.NextLevelXPRequired, out int requiredXP) &&
                requiredXP > 0)
            {
                float progress = (float)currentXP / requiredXP;
                int newBarWidth = (int)(progress * maxBarWidth);
                XPBar.Width = newBarWidth;
            }
            else if (int.TryParse(CurrentUser.XP, out currentXP))
            {
                XPBar.Width = maxBarWidth;
            }

            if (CurrentUser.AvatarIndex != -1)
            {
                switch (CurrentUser.AvatarIndex)
                {
                    case 2:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar1;
                        break;
                    case 3:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar2;
                        break;
                    case 4:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar3;
                        break;
                    case 5:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar4;
                        break;
                    case 6:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar5;
                        break;
                    case 7:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar6;
                        break;
                    case 8:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar7;
                        break;
                    case 9:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar8;
                        break;
                    case 10:
                        pbxDisplayPicture.Image = Properties.Resources.Avatar9;
                        break;
                    default:
                        pbxDisplayPicture.Image = null;
                        break;
                }
            }
            else
            {
                pbxDisplayPicture.Image = Image.FromFile(CurrentUser.DisplayPicturePath);
            }
        }

        private void DisplayUserStats()
        {
            DBTypingTest dbTypingTest = new DBTypingTest();

            var (avgWPM, avgAccuracy, totalTime, totalStars) = dbTypingTest.GetUserProfileStats(CurrentUser.UserID);

            string formattedTime;
            if (totalTime.TotalHours >= 1)
            {
                formattedTime = $"{(int)totalTime.TotalHours}h {totalTime.Minutes}m";
            }
            else
            {
                formattedTime = $"{totalTime.Minutes}m {totalTime.Seconds}s";
            }

           

            lblAverageWPM.Text = $"{avgWPM.ToString()}\nWPM";
            lblAverageAccuracy.Text = $"{avgAccuracy}\n%";
            lblTotalTime.Text = formattedTime;
            lblTotalStars.Text = $"{totalStars.ToString()}\nSTARS";
        }
    }
}