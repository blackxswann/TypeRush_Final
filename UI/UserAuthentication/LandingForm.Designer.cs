namespace TypeRush_Final
{
    partial class LandingForm
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pbxBackground = new PictureBox();
            btnLogIn = new PictureBox();
            btnSignUp = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbxBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnLogIn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnSignUp).BeginInit();
            SuspendLayout();
            // 
            // pbxBackground
            // 
            pbxBackground.Dock = DockStyle.Fill;
            pbxBackground.Image = Properties.Resources.LandingFormBG;
            pbxBackground.Location = new Point(0, 0);
            pbxBackground.Name = "pbxBackground";
            pbxBackground.Size = new Size(1920, 991);
            pbxBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxBackground.TabIndex = 0;
            pbxBackground.TabStop = false;
            // 
            // btnLogIn
            // 
            btnLogIn.BackColor = Color.Transparent;
            btnLogIn.Image = Properties.Resources.NH_LogIn;
            btnLogIn.Location = new Point(746, 566);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(431, 114);
            btnLogIn.SizeMode = PictureBoxSizeMode.StretchImage;
            btnLogIn.TabIndex = 1;
            btnLogIn.TabStop = false;
            btnLogIn.Click += btnLogIn_Click;
            // 
            // btnSignUp
            // 
            btnSignUp.BackColor = Color.Transparent;
            btnSignUp.Image = Properties.Resources.NH_SignUp;
            btnSignUp.Location = new Point(746, 690);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(431, 114);
            btnSignUp.SizeMode = PictureBoxSizeMode.StretchImage;
            btnSignUp.TabIndex = 2;
            btnSignUp.TabStop = false;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // LandingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnSignUp);
            Controls.Add(btnLogIn);
            Controls.Add(pbxBackground);
            DoubleBuffered = true;
            Name = "LandingForm";
            Size = new Size(1920, 991);
            ((System.ComponentModel.ISupportInitialize)pbxBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnLogIn).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnSignUp).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbxBackground;
        private PictureBox btnLogIn;
        private PictureBox btnSignUp;
    }
}
