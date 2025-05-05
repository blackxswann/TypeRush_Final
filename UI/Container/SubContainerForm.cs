using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypeRush_Final.Data;
using TypeRush_Final.UI.Minigame;
using TypeRush_Final.UI.Analytics;
using TypeRush_Final.UI.AchievementsAndLeaderboard;
namespace TypeRush_Final
{
    public partial class SubContainerForm : BaseControl
    {
        private string currentUser;
        FormContainer formContainer;

        public SubContainerForm(FormContainer form, string username)
        {
            InitializeComponent();
            currentUser = username;
            formContainer = form;
            SetElements();
            LoadUserControlIntoPanel(new HomeForm(form, this, currentUser));
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParams = base.CreateParams;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
        }
        public void LoadUserControlIntoPanel(UserControl form)
        {
            pnlContainer.SuspendLayout();
            pnlContainer.Visible = false;
            pnlContainer.Controls.Clear();
            form.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(form);
            pnlContainer.ResumeLayout();
            pnlContainer.Visible = true;
        }
        private void SetElements()
        {
            pnlHome.MouseClick += Panel_MouseClick;
            pnlProfile.MouseClick += Panel_MouseClick;
            pnlPracticeDrill.MouseClick += Panel_MouseClick;
            pnlTypingTest.MouseClick += Panel_MouseClick;
            pnlMinigames.MouseClick += Panel_MouseClick;
            pnlLeaderboard.MouseClick += Panel_MouseClick;
            pnlAnalytics.MouseClick += Panel_MouseClick;
            pnlSettings.MouseClick += Panel_MouseClick;
            pnlLogOut.MouseClick += Panel_MouseClick;


        }
        private void Panel_MouseClick(object sender, EventArgs e)
        {
            Panel pnl = sender as Panel;

            if (pnl != null)
            {
                pnl.Cursor = Cursors.Hand;

                ChangePanelToDefault();

                if (pnl == pnlHome)
                {
                    pnlHome.BackgroundImage = Properties.Resources.HOVERED_BTNHOME;
                    LoadUserControlIntoPanel(new HomeForm(formContainer, this, CurrentUser.Username));
                }
                else if (pnl == pnlProfile)
                {
                    pnlProfile.BackgroundImage = Properties.Resources.HOVERED_BTNPROFILE;
                    LoadUserControlIntoPanel(new ProfileForm(formContainer, this));

                }
                else if (pnl == pnlPracticeDrill)
                {
                    pnlPracticeDrill.BackgroundImage = Properties.Resources.HOVERED_BTNPRACTICEDRILL;
                    LoadUserControlIntoPanel(new PracticeDrillSelection(formContainer, this));
                }
                else if (pnl == pnlTypingTest)
                {
                    pnlTypingTest.BackgroundImage = Properties.Resources.HOVERED_BTNTYPINGTEST;
                    LoadUserControlIntoPanel(new TypingTestSelection(formContainer, this));
                }
                else if (pnl == pnlMinigames)
                {
                    pnlMinigames.BackgroundImage = Properties.Resources.HOVERED_BTNMINIGAMES;
                    LoadUserControlIntoPanel(new WordBlastStart(this));

                }
                else if (pnl == pnlLeaderboard)
                {
                    pnlLeaderboard.BackgroundImage = Properties.Resources.HOVERED_BTNLEADERBOARD;
                    LoadUserControlIntoPanel(new Leaderboard(formContainer));
                }

                else if (pnl == pnlAnalytics)
                {
                    pnlAnalytics.BackgroundImage = Properties.Resources.HOVERED_BTNANALYTICS;
                    LoadUserControlIntoPanel(new AnalyticsMistakeOverviewcs(formContainer, CurrentUser.UserID, this));

                }
                else if (pnl == pnlSettings)
                {
                    pnlSettings.BackgroundImage = Properties.Resources.HOVERED_BTNSETTINGS;
                    LoadUserControlIntoPanel(new SettingsForm(formContainer));
                }
                else if (pnl == pnlLogOut)
                {
                    pnlLogOut.BackgroundImage = Properties.Resources.HOVERED_BTNLOGOUT;
                    var result = MessageBox.Show("Do you want to log out?", "Log Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        formContainer.LoadUserControlIntoPanel(new LandingForm(formContainer));
                    }
                }
            }
        }
        
        
        private void ChangePanelToDefault()
        {
            pnlHome.BackgroundImage = Properties.Resources.NHOVERED_BTNHOME;
            pnlProfile.BackgroundImage = Properties.Resources.NHOVERED_BTNPROFILE;
            pnlPracticeDrill.BackgroundImage = Properties.Resources.NHOVERED_BTNPRACTICEDRILL;
            pnlTypingTest.BackgroundImage = Properties.Resources.NHOVERED_BTNTYPINGTEST;
            pnlMinigames.BackgroundImage = Properties.Resources.NHOVERED_BTNMINIGAMES;
            pnlLeaderboard.BackgroundImage = Properties.Resources.NHOVERED_BTNLEADERBOARD;
            pnlAnalytics.BackgroundImage = Properties.Resources.NHOVERED_BTNANALYTICS;
            pnlSettings.BackgroundImage = Properties.Resources.NHOVERED_BTNSETTINGS;
            pnlLogOut.BackgroundImage = Properties.Resources.NHOVERED_BTNLOGOUT;
        }
        public void ChangePanel(string determine)
        {
            ChangePanelToDefault();
            if (determine == "Profile")
                pnlProfile.BackgroundImage = Properties.Resources.HOVERED_BTNPROFILE;
            else if (determine == "PracticeDrill")
                pnlPracticeDrill.BackgroundImage = Properties.Resources.HOVERED_BTNPRACTICEDRILL;
            else if (determine == "Minigame")
                pnlMinigames.BackgroundImage = Properties.Resources.HOVERED_BTNMINIGAMES;
            else if (determine == "TypingTest")
                pnlTypingTest.BackgroundImage = Properties.Resources.HOVERED_BTNTYPINGTEST;
            else if (determine == "Leaderboard")
                pnlLeaderboard.BackgroundImage = Properties.Resources.HOVERED_BTNLEADERBOARD;
            else if (determine == "Analytics")
                pnlAnalytics.BackgroundImage = Properties.Resources.HOVERED_BTNANALYTICS;
    
            else if (determine == "Settings")
                pnlProfile.BackgroundImage = Properties.Resources.HOVERED_BTNSETTINGS;

        }
    }
}
