using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypeRush_Final.Data;

namespace TypeRush_Final
{
    public partial class SignUpForm : BaseControl
    {
        private FormContainer formContainer;
        private List<Image> avatar = new List<Image>();
        private int currentAvatarIndex = 0, timerTick = 0;
        private bool passwordShown = false;
        private DBUserInformation userInformation = new DBUserInformation();
        private AuthenticationError result;
        public SignUpForm(FormContainer form)
        {
            InitializeComponent();
            formContainer = form;
            SetElements();
            SetResources();
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
        private void SetElements()
        {
            tbxPassword.PasswordChar = '•';
            SignUpPanel.Parent = pbxBackground;
            pbxLoadingBar.Visible = false;
            pbxLoadingBar.Parent = pbxBackground;
            btnPrevious.MouseHover += Button_MouseHover;
            btnNext.MouseHover += Button_MouseHover;
            btnPrevious.MouseHover += Button_MouseHover;
            btnSignUp.MouseHover += Button_MouseHover;
            btnGoBack.MouseHover += Button_MouseHover;
            btnSignUp.MouseLeave += Button_MouseLeave;
            btnGoBack.MouseLeave += Button_MouseLeave;
            btnPrevious.MouseClick += Button_MouseClick;
            btnGoBack.MouseClick += Button_MouseClick;
            btnNext.MouseClick += Button_MouseClick;
            btnSignUp.MouseClick += Button_MouseClick;
            btnPassword.MouseHover += Button_MouseHover;
            btnPassword.MouseClick += Button_MouseClick;
            btnPassword.MouseHover += Button_MouseHover;
        }
        private void Button_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                if (btn == btnSignUp)
                    btnSignUp.BackgroundImage = Properties.Resources._2H_SIGNUP;
                else if (btn == btnGoBack)
                    btnGoBack.BackgroundImage = Properties.Resources._2H_GOBACK;

            }
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                if (btn == btnSignUp)
                    btnSignUp.BackgroundImage = Properties.Resources._2NH_SIGNUP;
                else if (btn == btnGoBack)
                    btnGoBack.BackgroundImage = Properties.Resources._2NH_GOBACK;
            }
        }
        private async void Button_MouseClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;

                if (btn == btnSignUp)
                {
                    timerTick = 0;
                    ResetWarningLabels();
                    EnsureAllAreFilled();
                    if (!lblDisplayName.Visible && !lblUsername.Visible && !lblEmailAddress.Visible && !lblPassword.Visible)
                    {
                        ShowOrHideSignUpPanel(false);
                        pbxBackground.Image = Properties.Resources.LoadingFormBG;
                        pbxLoadingBar.BringToFront();
                        pbxLoadingBar.Visible = true;
                        await HandleSignUp();
                        timer.Start();
                    }
                }
                else if (btn == btnGoBack)
                {
                    formContainer.LoadUserControlIntoPanel(new LandingForm(formContainer));
                }
                else if (btn == btnNext)
                {
                    ShiftAvatar("NEXT");
                }
                else if (btn == btnPrevious)
                {
                    ShiftAvatar("PREVIOUS");
                }
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



        private void SetResources()
        {
            avatar.Add((Bitmap)Properties.Resources.ResourceManager.GetObject("NULL_PROFILE"));
            avatar.Add((Bitmap)Properties.Resources.ResourceManager.GetObject("UploadYourOwn"));

            for (int i = 1; i <= 9; i++)
                avatar.Add((Bitmap)Properties.Resources.ResourceManager.GetObject($"Avatar{i}"));

            tbxDisplayName.TextChanged += TextBox_TextChanged;
            tbxUsername.TextChanged += TextBox_TextChanged;
            tbxEmailAddress.TextChanged += TextBox_TextChanged;
            tbxPassword.TextChanged += TextBox_TextChanged;
        }
        private void ShiftAvatar(string PreviousOrNext)
        {
            if (PreviousOrNext == "NEXT")
            {
                currentAvatarIndex++;
                if (currentAvatarIndex >= avatar.Count)
                    currentAvatarIndex = 0;
                profile.Image = avatar[currentAvatarIndex];
            }
            else if (PreviousOrNext == "PREVIOUS")
            {
                currentAvatarIndex--;
                if (currentAvatarIndex < 0)
                    currentAvatarIndex = avatar.Count - 1;
                profile.Image = avatar[currentAvatarIndex];

            }

        }
        private void profile_Click(object sender, EventArgs e)
        {
            profile.Cursor = Cursors.Hand;
            if (profile.Image == avatar[1])
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        profile.Image = Image.FromFile(openFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading image: " + ex.Message);
                    }
                }
            }
        }
        private void ShowOrHideSignUpPanel(bool showOrHide)
        {
            SignUpPanel.Visible = showOrHide;
            tbxDisplayName.Visible = showOrHide;
            tbxEmailAddress.Visible = showOrHide;
            tbxPassword.Visible = showOrHide;
            tbxUsername.Visible = showOrHide;
            profile.Visible = showOrHide;
            btnSignUp.Visible = showOrHide;
            btnGoBack.Visible = showOrHide;
            btnPrevious.Visible = showOrHide;
            btnNext.Visible = showOrHide;
            btnPassword.Visible = showOrHide;
        }
        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox == tbxPassword)
                {
                    lblPassword.Visible = false; 
                }
            }
            else if (sender is RichTextBox rtextBox)
            {
                if (rtextBox == tbxDisplayName)
                {
                    lblDisplayName.Visible = false;
                }
                else if (rtextBox == tbxUsername)
                {
                    lblUsername.Visible = false;
                }
                else if (rtextBox == tbxEmailAddress)
                {
                    lblEmailAddress.Visible = false;
                }
            }
        }


        private async Task HandleSignUp()
        {
            result = await userInformation.CheckIfUsernameOrEmailExists(tbxUsername.Text, tbxEmailAddress.Text);
        }

        private async void timer_Tick(object sender, EventArgs e)
        {
            timerTick++;
            if (timerTick == 2)
            {
                timer.Stop();
                if (result == AuthenticationError.successfulOperation)
                {
                    if (currentAvatarIndex > 1)
                    {
                        formContainer.LoadUserControlIntoPanel(new ConfirmationCodeForm(
                        formContainer,
                        this,
                        tbxUsername.Text,
                        tbxDisplayName.Text,
                        tbxPassword.Text,
                        tbxEmailAddress.Text,
                        currentAvatarIndex,
                        null
                    )

                    );
                    }
                    else
                    {
                        await Task.Run(() => { });
                        formContainer.LoadUserControlIntoPanel(new ConfirmationCodeForm(
                        formContainer,
                        this,
                        tbxUsername.Text,
                        tbxDisplayName.Text,
                        tbxPassword.Text,
                        tbxEmailAddress.Text,
                        -1,
                        profile
                        ));
                    }

                }

                else
                {
                    pbxBackground.Image = Properties.Resources.LogInSignUpBG;
                    pbxLoadingBar.Visible = false;
                    ShowOrHideSignUpPanel(true);
                    DisplayAuthenticationResult();
                }
            }
        }



        private void EnsureAllAreFilled()
        {

            if (String.IsNullOrWhiteSpace(tbxDisplayName.Text))
            {
                lblDisplayName.Text = "* REQUIRED";
                lblDisplayName.Visible = true;
            }
            if (String.IsNullOrWhiteSpace(tbxUsername.Text))
            {
                lblUsername.Text = "* REQUIRED";
                lblUsername.Visible = true;
            }
            if (String.IsNullOrWhiteSpace(tbxEmailAddress.Text))
            {
                lblEmailAddress.Text = "* REQUIRED";
                lblEmailAddress.Visible = true;
            }
            if (String.IsNullOrWhiteSpace(tbxPassword.Text))
            {
                lblPassword.Text = "* REQUIRED";
                lblPassword.Visible = true;
            }
        }
        private void DisplayAuthenticationResult()
        {
            if (result == AuthenticationError.usernameExists)
            {
                lblUsername.Text = "x USERNAME ALREADY EXISTS!";
                lblUsername.Visible = true;
            }
            else if (result == AuthenticationError.emailExists)
            {
                lblEmailAddress.Text = "x EMAIL ALREADY EXISTS!";
                lblEmailAddress.Visible = true;
            }
            else if (result == AuthenticationError.usernameAndEmailExists)
            {
                lblUsername.Text = "x USERNAME ALREADY EXISTS!";
                lblUsername.Visible = true;
                lblEmailAddress.Text = "x EMAIL ALREADY EXISTS!";
                lblEmailAddress.Visible = true;
            }
            else if (result == AuthenticationError.databaseError)
            {
                MessageBox.Show("An error occurred while connecting to the database. Please try again later.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ShowOrHideSignUpPanel(true);
                pbxBackground.Image = Properties.Resources.LogInSignUpBG;
                pbxLoadingBar.Visible = false;
            }
        }

        private void ResetWarningLabels()
        {
            lblDisplayName.Visible = false;
            lblUsername.Visible = false;
            lblEmailAddress.Visible = false;
            lblPassword.Visible = false;
        }

        private void SignUpForm_Load(object sender, EventArgs e)
        {
            ShowOrHideSignUpPanel(true);
            pbxLoadingBar.Visible = false;
            pbxBackground.Image = Properties.Resources.LogInSignUpBG;
        }
    }
}
