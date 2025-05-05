using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypeRush_Final.Data;
using TypeRush_Final.UI.AchievementsAndLeaderboard;
using TypeRush_Final.UI.LevelUpAndLeaderboard;

namespace TypeRush_Final
{
    public partial class LogInForm : BaseControl
    {
        FormContainer formContainer;
        private bool passwordShown = false;
        private AuthenticationError result;
        private DBUserInformation userInformation = new DBUserInformation();
        private int timerTick = 0;
        public LogInForm(FormContainer form)
        {
            InitializeComponent();
            formContainer = form;
            SetElements();

        }
      

        private void SetElements()
        {
            pbxLoadingBar.Visible = false;
            pbxLoadingBar.Parent = pbxBackground;
            tbxPassword.PasswordChar = '•';
            logInPanel.Parent = pbxBackground;
            ActiveControl = pbxBackground;
            btnLogIn.MouseHover += Button_MouseHover;
            btnGoBack.MouseHover += Button_MouseHover;
            btnLogIn.MouseClick += Button_MouseClick;
            btnGoBack.MouseClick += Button_MouseClick;
            btnLogIn.MouseLeave += Button_MouseLeave;
            btnGoBack.MouseLeave += Button_MouseLeave;
            btnPassword.MouseClick += Button_MouseClick;
            btnPassword.MouseHover += Button_MouseHover;
            tbxUsername.TextChanged += Textbox_TextChanged;
            tbxPassword.TextChanged += Textbox_TextChanged; 

        }
        private void Button_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                if (btn == btnLogIn)
                    btnLogIn.BackgroundImage = Properties.Resources._2H_LOGIN;
                else if (btn == btnGoBack)
                    btnGoBack.BackgroundImage = Properties.Resources._2H_GOBACK;

            }
        }
        private async void Button_MouseClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                timerTick = 0;
                btn.Cursor = Cursors.Hand;
                if (btn == btnLogIn)
                {
                    ShowOrHidePanel(false);
                    pbxBackground.Image = Properties.Resources.LoadingFormBG;
                    pbxLoadingBar.BringToFront();
                    pbxLoadingBar.Visible = true;
                    await HandleLogIn();
                    timer.Start();
                }
                else if (btn == btnGoBack)
                    formContainer.LoadUserControlIntoPanel(new LandingForm(formContainer));
                else if (btn == btnPassword && passwordShown == false)
                {
                    btnPassword.BackgroundImage = Properties.Resources.RevealPassword;
                    tbxPassword.PasswordChar = '\0';
                    passwordShown = true;
                }
                else if (btn == btnPassword && passwordShown == true)
                {
                    btnPassword.BackgroundImage = Properties.Resources.HidePassword;
                    tbxPassword.PasswordChar = '•';
                    passwordShown = false;
                }
            }
        }
        private void Textbox_TextChanged(object sender, EventArgs e)
        {
            TextBox tbx = sender as TextBox;
            RichTextBox rtbx = sender as RichTextBox;

            if (tbx == tbxPassword || rtbx == tbxUsername)
                lblUsername.Visible = false; 
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                if (btn == btnLogIn)
                    btnLogIn.BackgroundImage = Properties.Resources._2NH_LOGIN;
                else if (btn == btnGoBack)
                    btnGoBack.BackgroundImage = Properties.Resources._2NH_GOBACK;
            }
        }

        private void lblPassword_Click(object sender, EventArgs e)
        {

        }
        private void ShowOrHidePanel(bool showOrHide)
        {
            btnPassword.Visible = showOrHide;
            btnLogIn.Visible = showOrHide;
            btnGoBack.Visible = showOrHide;
            tbxUsername.Visible = showOrHide;
            tbxPassword.Visible = showOrHide;
            logInPanel.Visible = showOrHide;

        }
        private async Task HandleLogIn()
        {
            result = await userInformation.LoginUser(
                tbxUsername.Text,
                tbxPassword.Text
            );
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timerTick++;
            if (timerTick == 2)
            {
                timer.Stop();
                pbxBackground.Image = Properties.Resources.LogInSignUpBG;
                pbxLoadingBar.Visible = false;
                if (result == AuthenticationError.usernameNotFound)
                {
                    ShowOrHidePanel(true);
                    lblUsername.Text = "x USERNAME NOT FOUND"; 
                    lblUsername.Visible = true; 
                }
                else if (result == AuthenticationError.incorrectPassword)
                {
                    ShowOrHidePanel(true);
                    lblPass.Text = "x INCORRECT PASSWORD";
                    lblPass.Visible = true;
                }
                else
                {

                    formContainer.LoadUserControlIntoPanel(new SubContainerForm(formContainer, tbxUsername.Text));
                }

            }
        }
    }
}
