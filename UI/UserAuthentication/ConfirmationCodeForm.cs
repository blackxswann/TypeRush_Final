using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypeRush_Final.Data;

namespace TypeRush_Final
{
    public partial class ConfirmationCodeForm : BaseControl
    {
        private FormContainer formContainer;
        private SignUpForm signUpForm;
        private string username;
        private string displayName;
        private string password;
        private string email;
        private int avatarIndex, timerTick = 0;
        private PictureBox profile;
        private string generatedCode;
        private DBUserInformation userInformation = new DBUserInformation();
        private List<Image> avatar = new List<Image>();
        private AuthenticationError result;
        private string verifyOrReset;

        public ConfirmationCodeForm(FormContainer formContainer, SignUpForm signUp, string username, string displayName, string password, string email, int avatarIndex, PictureBox profile)
        {
            InitializeComponent();
            this.formContainer = formContainer;
            this.signUpForm = signUp;
            this.username = username;
            this.displayName = displayName;
            this.password = password;
            this.email = email;
            this.avatarIndex = avatarIndex;
            this.profile = profile;
            SetElements();
        }

        private async Task SetElements()
        {
            pbxLoadingBar.Visible = false;
            avatar.Add((Bitmap)Properties.Resources.ResourceManager.GetObject("NULL_PROFILE"));
            avatar.Add((Bitmap)Properties.Resources.ResourceManager.GetObject("UploadYourOwn"));
            for (int i = 1; i <= 9; i++)
                avatar.Add((Bitmap)Properties.Resources.ResourceManager.GetObject($"Avatar{i}"));

            ActiveControl = pbxBackground;
            pbxLoadingBar.Parent = pbxBackground;
            panel.Parent = pbxBackground;
            btnVerify.MouseHover += Button_MouseHover;
            btnBack.MouseHover += Button_MouseHover;
            btnVerify.MouseLeave += Button_MouseLeave;
            btnBack.MouseLeave += Button_MouseLeave;
            btnVerify.MouseClick += Button_MouseClick;
            btnBack.MouseClick += Button_MouseClick;
            tbx1.TextChanged += Textbox_Changed;
            tbx2.TextChanged += Textbox_Changed;
            tbx3.TextChanged += Textbox_Changed;
            tbx4.TextChanged += Textbox_Changed;
            tbx5.TextChanged += Textbox_Changed;

            generatedCode = GenerateVerificationCode();
            await SendConfirmationEmail(email, generatedCode);
        }

        private string GenerateVerificationCode()
        {
            Random random = new Random();
            int code = random.Next(10000, 99999);
            return code.ToString();
        }

        private void Textbox_Changed(object sender, EventArgs e)
        {
            ActiveControl = pbxBackground;
            panel.Image = Properties.Resources.EmailVerificationPanel1;
            TextBox tbx = sender as TextBox;
            if (tbx.Text.Length > 1)
            {
                tbx.Text = tbx.Text.Substring(tbx.Text.Length - 1);
                tbx.SelectionStart = tbx.Text.Length;
            }
        }

 
        private async Task SendConfirmationEmail(string recipientEmail, string code)
        {
            try
            {
                using (SmtpClient client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("puertoshaynerose8@gmail.com", "ttskgbicgmoxldjz");

                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress("puertoshaynerose8@gmail.com", "Type Rush"),
                        Subject = "Type Rush: Almost There! Confirm Your Email.",
                        Body = $"Hi there! 👋\n\nYour Type Rush verification code is: {code}\n\nIf you didn’t request this, please ignore this message.\n\nCheers,\nThe Type Rush Team",
                        IsBodyHtml = false
                    };
                    mailMessage.To.Add(recipientEmail);

                    await client.SendMailAsync(mailMessage); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send email. " + ex.Message);
            }
        }

        
        private async void Button_MouseClick(object sender, EventArgs e)
        {
            ActiveControl = pbxBackground;
            Button btn = sender as Button;

            if (btn != null)
            {
                timerTick = 0;

                btn.Cursor = Cursors.Hand;
                if (btn == btnBack)
                    formContainer.LoadUserControlIntoPanel(new LandingForm(formContainer)); 
                else if (btn == btnVerify)
                {
                    string enteredCode = tbx1.Text + tbx2.Text + tbx3.Text + tbx4.Text + tbx5.Text;
                    if (enteredCode == generatedCode)
                    {
                        pbxBackground.Image = Properties.Resources.LoadingFormBG;
                        pbxLoadingBar.Visible = true;
                        showOrHideConfirmationPanel(false);
                        await HandleSignUp();
                        timer.Start();
                    }
                    else
                    {
                        panel.Image = Properties.Resources.EmailVerificationPanel2; 
                    }
                }

            }
        }

        private void Button_MouseHover(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                if (btn == btnBack)
                    btnBack.BackgroundImage = Properties.Resources.V_H_BACK;
                else if (btn == btnVerify)
                    btnVerify.BackgroundImage = Properties.Resources.V_H_VERIFY;
            }
        }

        private void Button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;
                if (btn == btnBack)
                    btnBack.BackgroundImage = Properties.Resources.V_NH_BACK;
                else if (btn == btnVerify)
                    btnVerify.BackgroundImage = Properties.Resources.V_NH_VERIFY;
            }
        }

        private async Task HandleSignUp()
        {
            bool isCustomImage = true;

            if (profile != null && profile.Image != null)
            {
                foreach (Bitmap avatarImage in avatar)
                {
                    if (profile.Image == avatarImage && avatarImage != avatar[0] && avatarImage != avatar[1])
                    {
                        isCustomImage = false;
                        break;
                    }
                }
            }
            else if (profile != null && profile.Image == avatar[1])
            {
                isCustomImage = false;
            }
            else
            {
                isCustomImage = false;
            }

            if (isCustomImage)
            {

                result = await userInformation.CheckAndCreateAccount(
                    username,
                    displayName,
                    password,
                    email,
                    1,
                    0,
                    -1,
                    profile
                    
                );
            }
            else
            {
                result = await userInformation.CheckAndCreateAccount(
                    username,
                    displayName,
                    password,
                    email,
                    1,
                    0,
                    avatarIndex,
                    null
                    
                );
            }
        }



        private void showOrHideConfirmationPanel(bool showOrHide)
        {
            panel.Visible = showOrHide;
            btnVerify.Visible = showOrHide;
            btnBack.Visible = showOrHide;
            tbx1.Visible = showOrHide;
            tbx2.Visible = showOrHide;
            tbx3.Visible = showOrHide;
            tbx4.Visible = showOrHide;
            tbx5.Visible = showOrHide;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timerTick++;
            if (timerTick == 2)
            {
                timer.Stop();
                if (result == AuthenticationError.successfulOperation)
                {
                    formContainer.LoadUserControlIntoPanel(new SubContainerForm(formContainer, username));
                }
                else
                {
                    pbxBackground.Image = Properties.Resources.LogInSignUpBG;
                    pbxLoadingBar.Visible = false;
                }
            }
        }
    }
}
