namespace TypeRush_Final
{
    partial class SignUpForm
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
            components = new System.ComponentModel.Container();
            pbxBackground = new PictureBox();
            SignUpPanel = new PictureBox();
            profile = new PictureBox();
            btnPrevious = new Button();
            btnNext = new Button();
            btnSignUp = new Button();
            btnGoBack = new Button();
            tbxPassword = new TextBox();
            tbxDisplayName = new RichTextBox();
            tbxUsername = new RichTextBox();
            tbxEmailAddress = new RichTextBox();
            btnPassword = new Button();
            lblDisplayName = new Label();
            lblUsername = new Label();
            lblPassword = new Label();
            lblEmailAddress = new Label();
            pbxLoadingBar = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbxBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SignUpPanel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)profile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxLoadingBar).BeginInit();
            SuspendLayout();
            // 
            // pbxBackground
            // 
            pbxBackground.Dock = DockStyle.Fill;
            pbxBackground.Image = Properties.Resources.LogInSignUpBG;
            pbxBackground.Location = new Point(0, 0);
            pbxBackground.Name = "pbxBackground";
            pbxBackground.Size = new Size(1920, 991);
            pbxBackground.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxBackground.TabIndex = 0;
            pbxBackground.TabStop = false;
            // 
            // SignUpPanel
            // 
            SignUpPanel.BackColor = Color.Transparent;
            SignUpPanel.Image = Properties.Resources.SignUpPanel;
            SignUpPanel.Location = new Point(341, 140);
            SignUpPanel.Name = "SignUpPanel";
            SignUpPanel.Size = new Size(1242, 747);
            SignUpPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            SignUpPanel.TabIndex = 1;
            SignUpPanel.TabStop = false;
            // 
            // profile
            // 
            profile.BackColor = Color.Transparent;
            profile.Image = Properties.Resources.NULL_PROFILE;
            profile.Location = new Point(477, 323);
            profile.Name = "profile";
            profile.Size = new Size(262, 253);
            profile.SizeMode = PictureBoxSizeMode.StretchImage;
            profile.TabIndex = 2;
            profile.TabStop = false;
            profile.Click += profile_Click;
            // 
            // btnPrevious
            // 
            btnPrevious.BackgroundImage = Properties.Resources.PreviousButton;
            btnPrevious.BackgroundImageLayout = ImageLayout.Stretch;
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Location = new Point(451, 620);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(32, 46);
            btnPrevious.TabIndex = 3;
            btnPrevious.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            btnNext.BackgroundImage = Properties.Resources.NextButton;
            btnNext.BackgroundImageLayout = ImageLayout.Stretch;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Location = new Point(730, 620);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(32, 46);
            btnNext.TabIndex = 4;
            btnNext.UseVisualStyleBackColor = true;
            // 
            // btnSignUp
            // 
            btnSignUp.BackgroundImage = Properties.Resources._2NH_SIGNUP;
            btnSignUp.BackgroundImageLayout = ImageLayout.Stretch;
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.Location = new Point(645, 736);
            btnSignUp.Margin = new Padding(0);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(264, 56);
            btnSignUp.TabIndex = 5;
            btnSignUp.TabStop = false;
            btnSignUp.UseVisualStyleBackColor = true;
            // 
            // btnGoBack
            // 
            btnGoBack.BackgroundImage = Properties.Resources._2NH_GOBACK;
            btnGoBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnGoBack.FlatAppearance.BorderSize = 0;
            btnGoBack.FlatStyle = FlatStyle.Flat;
            btnGoBack.Location = new Point(1031, 736);
            btnGoBack.Margin = new Padding(0);
            btnGoBack.Name = "btnGoBack";
            btnGoBack.Size = new Size(264, 56);
            btnGoBack.TabIndex = 6;
            btnGoBack.TabStop = false;
            btnGoBack.UseVisualStyleBackColor = true;
            // 
            // tbxPassword
            // 
            tbxPassword.BackColor = Color.FromArgb(242, 239, 235);
            tbxPassword.BorderStyle = BorderStyle.None;
            tbxPassword.Font = new Font("monogram", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxPassword.ForeColor = Color.DimGray;
            tbxPassword.Location = new Point(877, 545);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(541, 24);
            tbxPassword.TabIndex = 9;
            // 
            // tbxDisplayName
            // 
            tbxDisplayName.BackColor = Color.FromArgb(242, 239, 235);
            tbxDisplayName.BorderStyle = BorderStyle.None;
            tbxDisplayName.Font = new Font("monogram", 18F, FontStyle.Bold);
            tbxDisplayName.ForeColor = Color.DimGray;
            tbxDisplayName.Location = new Point(877, 341);
            tbxDisplayName.Name = "tbxDisplayName";
            tbxDisplayName.Size = new Size(582, 24);
            tbxDisplayName.TabIndex = 11;
            tbxDisplayName.Text = "";
            // 
            // tbxUsername
            // 
            tbxUsername.BackColor = Color.FromArgb(242, 239, 235);
            tbxUsername.BorderStyle = BorderStyle.None;
            tbxUsername.Font = new Font("monogram", 18F, FontStyle.Bold);
            tbxUsername.ForeColor = Color.DimGray;
            tbxUsername.Location = new Point(877, 447);
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(582, 24);
            tbxUsername.TabIndex = 12;
            tbxUsername.Text = "";
            // 
            // tbxEmailAddress
            // 
            tbxEmailAddress.BackColor = Color.FromArgb(242, 239, 235);
            tbxEmailAddress.BorderStyle = BorderStyle.None;
            tbxEmailAddress.Font = new Font("monogram", 18F, FontStyle.Bold);
            tbxEmailAddress.ForeColor = Color.DimGray;
            tbxEmailAddress.Location = new Point(877, 642);
            tbxEmailAddress.Name = "tbxEmailAddress";
            tbxEmailAddress.Size = new Size(582, 24);
            tbxEmailAddress.TabIndex = 13;
            tbxEmailAddress.Text = "";
            // 
            // btnPassword
            // 
            btnPassword.BackgroundImage = Properties.Resources.HidePassword;
            btnPassword.BackgroundImageLayout = ImageLayout.Stretch;
            btnPassword.FlatAppearance.BorderSize = 0;
            btnPassword.FlatStyle = FlatStyle.Flat;
            btnPassword.Location = new Point(1434, 553);
            btnPassword.Name = "btnPassword";
            btnPassword.Size = new Size(25, 13);
            btnPassword.TabIndex = 14;
            btnPassword.UseVisualStyleBackColor = true;
            // 
            // lblDisplayName
            // 
            lblDisplayName.AutoSize = true;
            lblDisplayName.BackColor = Color.FromArgb(137, 106, 149);
            lblDisplayName.Font = new Font("Vaticanus", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDisplayName.ForeColor = SystemColors.InactiveCaption;
            lblDisplayName.Location = new Point(1069, 298);
            lblDisplayName.Name = "lblDisplayName";
            lblDisplayName.Size = new Size(94, 23);
            lblDisplayName.TabIndex = 15;
            lblDisplayName.Text = "x error";
            lblDisplayName.Visible = false;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.FromArgb(137, 106, 149);
            lblUsername.Font = new Font("Vaticanus", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = SystemColors.InactiveCaption;
            lblUsername.Location = new Point(1015, 404);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(94, 23);
            lblUsername.TabIndex = 16;
            lblUsername.Text = "x error";
            lblUsername.Visible = false;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.FromArgb(137, 106, 149);
            lblPassword.Font = new Font("Vaticanus", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = SystemColors.InactiveCaption;
            lblPassword.Location = new Point(1023, 502);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(94, 23);
            lblPassword.TabIndex = 17;
            lblPassword.Text = "x error";
            lblPassword.Visible = false;
            // 
            // lblEmailAddress
            // 
            lblEmailAddress.AutoSize = true;
            lblEmailAddress.BackColor = Color.FromArgb(137, 106, 149);
            lblEmailAddress.Font = new Font("Vaticanus", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmailAddress.ForeColor = SystemColors.InactiveCaption;
            lblEmailAddress.Location = new Point(1092, 602);
            lblEmailAddress.Name = "lblEmailAddress";
            lblEmailAddress.Size = new Size(94, 23);
            lblEmailAddress.TabIndex = 18;
            lblEmailAddress.Text = "x error";
            lblEmailAddress.Visible = false;
            // 
            // pbxLoadingBar
            // 
            pbxLoadingBar.BackColor = Color.Transparent;
            pbxLoadingBar.Image = Properties.Resources.loadGIF;
            pbxLoadingBar.Location = new Point(933, 548);
            pbxLoadingBar.Name = "pbxLoadingBar";
            pbxLoadingBar.Size = new Size(48, 47);
            pbxLoadingBar.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxLoadingBar.TabIndex = 19;
            pbxLoadingBar.TabStop = false;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblEmailAddress);
            Controls.Add(lblPassword);
            Controls.Add(lblUsername);
            Controls.Add(lblDisplayName);
            Controls.Add(btnPassword);
            Controls.Add(tbxEmailAddress);
            Controls.Add(tbxUsername);
            Controls.Add(tbxDisplayName);
            Controls.Add(tbxPassword);
            Controls.Add(btnGoBack);
            Controls.Add(btnSignUp);
            Controls.Add(btnNext);
            Controls.Add(btnPrevious);
            Controls.Add(profile);
            Controls.Add(SignUpPanel);
            Controls.Add(pbxLoadingBar);
            Controls.Add(pbxBackground);
            DoubleBuffered = true;
            Name = "SignUpForm";
            Size = new Size(1920, 991);
            Load += SignUpForm_Load;
            ((System.ComponentModel.ISupportInitialize)pbxBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)SignUpPanel).EndInit();
            ((System.ComponentModel.ISupportInitialize)profile).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxLoadingBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxBackground;
        private PictureBox SignUpPanel;
        private PictureBox profile;
        private Button btnPrevious;
        private Button btnNext;
        private Button btnSignUp;
        private Button btnGoBack;
        private TextBox tbxPassword;
        private RichTextBox tbxDisplayName;
        private RichTextBox tbxUsername;
        private RichTextBox tbxEmailAddress;
        private Button btnPassword;
        private Label lblDisplayName;
        private Label lblUsername;
        private Label lblPassword;
        private Label lblEmailAddress;
        private PictureBox pbxLoadingBar;
        private System.Windows.Forms.Timer timer;
    }
}
