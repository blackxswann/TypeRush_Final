using Azure.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CrypticWizard.RandomWordGenerator;
using static CrypticWizard.RandomWordGenerator.WordGenerator;
using RandomString4Net;
using TypeRush_Final.Data;
using TypeRush_Final.UI.Minigame;

namespace TypeRush_Final
{
    public partial class HomeForm : BaseControl
    {
        private int timerTick = 0;
        private string currentUser; 
        private string welcomeMessage { get; set; }
        private string message = "Welcome back, @shayne!";
        private FormContainer fcontainer; 
        private SubContainerForm subContainerForm; 
        public HomeForm(FormContainer fcontainer, SubContainerForm form, string username)
        {
            InitializeComponent();
            this.currentUser = username;
            this.fcontainer = fcontainer;
            subContainerForm = form;
            this.fcontainer = fcontainer;
            SetResources();
            InitializeUserData();
        }

        private async Task InitializeUserData() 
        {
            bool needToFetchUserData = string.IsNullOrEmpty(CurrentUser.Username) ||
                                        CurrentUser.Username != currentUser;

            if (needToFetchUserData)
            {
                DBUserInformation db = new DBUserInformation();
                await db.FetchUserInformation(currentUser); 
            }

            message = "Welcome back, @" + CurrentUser.Username + "!";
            timerTick = 0;
            lblWelcomeText.Text = "";

            timer.Start();

            lblDisplayName.Text = $"@{CurrentUser.DisplayName}";
            lblUsername.Text = $"@{CurrentUser.Username}";

            UpdateDisplayPicture(); 
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (timerTick < message.Length)
            {
                lblWelcomeText.Text += message[timerTick];
                timerTick++;
            }
            else
            {
                timer.Stop();
            }
        }
        private void SetResources()
        {
            btnViewProfile.MouseHover += Control_MouseHover;
            pnlPracticeDrill.MouseHover += Control_MouseHover;
            pnlLeaderboard.MouseHover += Control_MouseHover;
            pnlMinigames.MouseHover += Control_MouseHover;
            pnlTypingTest.MouseHover += Control_MouseHover;
            btnViewProfile.MouseLeave += Control_MouseLeave;
            pnlPracticeDrill.MouseLeave += Control_MouseLeave;
            pnlLeaderboard.MouseLeave += Control_MouseLeave;
            pnlMinigames.MouseLeave += Control_MouseLeave;
            pnlTypingTest.MouseLeave += Control_MouseLeave;

            btnViewProfile.MouseClick += Control_MouseClick;

            pnlPracticeDrill.MouseClick += Control_MouseClick;
            pnlLeaderboard.MouseClick += Control_MouseClick;
            pnlMinigames.MouseClick += Control_MouseClick;
            pnlTypingTest.MouseClick += Control_MouseClick;

        }

        private void BtnViewProfile_MouseClick(object? sender, MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Control_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            Panel pnl = sender as Panel;

            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                if (btn == btnViewProfile)
                    btnViewProfile.BackgroundImage = Properties.Resources.P_H_VIEWPROFILE;
            }
            if (pnl != null)
            {
                pnl.Cursor = Cursors.Hand;
                if (pnl == pnlPracticeDrill)
                    pnlPracticeDrill.BackgroundImage = Properties.Resources.H_H_OPTION;
                else if (pnl == pnlLeaderboard)
                    pnlLeaderboard.BackgroundImage = Properties.Resources.H_H_OPTION;
                else if (pnl == pnlMinigames)
                    pnlMinigames.BackgroundImage = Properties.Resources.H_H_OPTION;
                else if (pnl == pnlTypingTest)
                    pnlTypingTest.BackgroundImage = Properties.Resources.H_H_OPTION;
            }
        }
        private void Control_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            Panel pnl = sender as Panel;

            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                if (btn == btnViewProfile)
                    btnViewProfile.BackgroundImage = Properties.Resources.P_NH_VIEWPROFILE;
            }
            if (pnl != null)
            {
                pnl.Cursor = Cursors.Hand;
                if (pnl == pnlPracticeDrill)
                    pnlPracticeDrill.BackgroundImage = Properties.Resources.H_NH_PDRILL;
                else if (pnl == pnlLeaderboard)
                    pnlLeaderboard.BackgroundImage = Properties.Resources.H_NH_LEADERBOARD;
                else if (pnl == pnlMinigames)
                    pnlMinigames.BackgroundImage = Properties.Resources.H_NH_MINIGAME;
                else if (pnl == pnlTypingTest)
                    pnlTypingTest.BackgroundImage = Properties.Resources.H_NH_TYPINGTEST;
            }
        }
        private void Control_MouseClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Panel pnl = sender as Panel;

            if (btn != null)
            {
                if (btn == btnViewProfile)
                {
                    subContainerForm.LoadUserControlIntoPanel(new ProfileForm(fcontainer, subContainerForm));
                    subContainerForm.ChangePanel("Profile"); 
                }
            }
            if (pnl != null)
            {
                if (pnl == pnlTypingTest)
                {
                    subContainerForm.LoadUserControlIntoPanel(new TypingTestSelection(fcontainer, subContainerForm));
                    subContainerForm.ChangePanel("TypingTest");
                }
                else if (pnl == pnlLeaderboard)
                {
                    subContainerForm.LoadUserControlIntoPanel(new Leaderboard(fcontainer));
                    subContainerForm.ChangePanel("Leaderboard");
                }
                else if (pnl == pnlPracticeDrill)
                {
                    subContainerForm.LoadUserControlIntoPanel(new PracticeDrillSelection(fcontainer, subContainerForm));
                    subContainerForm.ChangePanel("PracticeDrill"); 
                }
                else if (pnl == pnlMinigames)
                {
                    subContainerForm.LoadUserControlIntoPanel(new WordBlastStart(subContainerForm));
                    subContainerForm.ChangePanel("Minigame");
                }
            }
        }
        private async void HomeForm_Load(object sender, EventArgs e)
        {
            bool needToFetchUserData = string.IsNullOrEmpty(CurrentUser.Username) ||
                                      CurrentUser.Username != currentUser;

            if (needToFetchUserData)
            {
                DBUserInformation db = new DBUserInformation();
                await db.FetchUserInformation(currentUser);

                
            }

            message = "Welcome back, @" + CurrentUser.Username + "!";

            timerTick = 0;
            lblWelcomeText.Text = "";

            timer.Start();

            lblDisplayName.Text = $"@{CurrentUser.DisplayName}";
            lblUsername.Text = $"@{CurrentUser.Username}";

            UpdateDisplayPicture();
        }

        private void UpdateDisplayPicture()
        {
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
                        pbxDisplayPicture.Image = Properties.Resources.NULL_PROFILE;
                        break;
                }
            }
            else if (CurrentUser.DisplayPicturePath != "NO_PICTURE_UPLOADED" && File.Exists(CurrentUser.DisplayPicturePath))
            {
                try
                {
                    using (var img = Image.FromFile(CurrentUser.DisplayPicturePath))
                    {
                        pbxDisplayPicture.Image = new Bitmap(img);
                    }
                }
                catch (Exception ex)
                {
                    pbxDisplayPicture.Image = Properties.Resources.NULL_PROFILE;
                    Console.WriteLine($"Error loading profile image: {ex.Message}");
                }
            }
            else
            {
                pbxDisplayPicture.Image = Properties.Resources.NULL_PROFILE;
            }
        }
    }
}