using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypeRush_Final
{
    public partial class LandingForm : UserControl
    {
        FormContainer formContainer;
        public LandingForm(FormContainer form)
        {
            InitializeComponent();
            formContainer = form;
            SetElements();
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
            btnLogIn.Parent = pbxBackground;
            btnSignUp.Parent = pbxBackground;

            btnLogIn.MouseHover += Button_MouseHover;
            btnLogIn.MouseLeave += Button_MouseLeave;
            btnSignUp.MouseHover += Button_MouseHover;
            btnSignUp.MouseLeave += Button_MouseLeave;
        }
        private void Button_MouseHover(object sender, EventArgs e)
        {
            PictureBox btn = sender as PictureBox;

            if (btn != null)
            {
                btn.Cursor = Cursors.Hand;

                if (btn == btnLogIn)
                    btn.Image = Properties.Resources.H_LogIn;
                else if (btn == btnSignUp)
                    btn.Image = Properties.Resources.H_SignUp;
            }
        }
        private void Button_MouseLeave(object sender, EventArgs e)
        {
            PictureBox btn = sender as PictureBox;

            if (btn != null)
            {
                if (btn == btnLogIn)
                    btn.Image = Properties.Resources.NH_LogIn;
                else if (btn == btnSignUp)
                    btn.Image = Properties.Resources.NH_SignUp;
            }
        }
        private void btnLogIn_Click(object sender, EventArgs e)
        {
            formContainer.LoadUserControlIntoPanel(new LogInForm(formContainer));
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            formContainer.LoadUserControlIntoPanel(new SignUpForm(formContainer));
        }
    }
}
