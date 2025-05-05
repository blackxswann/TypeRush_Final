namespace TypeRush_Final
{
    partial class LogInForm
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
            logInPanel = new PictureBox();
            tbxUsername = new RichTextBox();
            tbxPassword = new TextBox();
            btnPassword = new Button();
            btnGoBack = new Button();
            btnLogIn = new Button();
            pbxLoadingBar = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            lblUsername = new Label();
            lblPass = new Label();
            ((System.ComponentModel.ISupportInitialize)pbxBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)logInPanel).BeginInit();
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
            // logInPanel
            // 
            logInPanel.BackColor = Color.Transparent;
            logInPanel.Image = Properties.Resources.loginPanel;
            logInPanel.Location = new Point(539, 267);
            logInPanel.Name = "logInPanel";
            logInPanel.Size = new Size(849, 477);
            logInPanel.SizeMode = PictureBoxSizeMode.StretchImage;
            logInPanel.TabIndex = 1;
            logInPanel.TabStop = false;
            // 
            // tbxUsername
            // 
            tbxUsername.BackColor = Color.FromArgb(242, 239, 235);
            tbxUsername.BorderStyle = BorderStyle.None;
            tbxUsername.Font = new Font("monogram", 18F, FontStyle.Bold);
            tbxUsername.ForeColor = Color.DimGray;
            tbxUsername.Location = new Point(634, 420);
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(650, 24);
            tbxUsername.TabIndex = 12;
            tbxUsername.Text = "";
            // 
            // tbxPassword
            // 
            tbxPassword.BackColor = Color.FromArgb(242, 239, 235);
            tbxPassword.BorderStyle = BorderStyle.None;
            tbxPassword.Font = new Font("monogram", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tbxPassword.ForeColor = Color.DimGray;
            tbxPassword.Location = new Point(634, 523);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(541, 24);
            tbxPassword.TabIndex = 13;
            // 
            // btnPassword
            // 
            btnPassword.BackgroundImage = Properties.Resources.HidePassword;
            btnPassword.BackgroundImageLayout = ImageLayout.Stretch;
            btnPassword.FlatAppearance.BorderSize = 0;
            btnPassword.FlatStyle = FlatStyle.Flat;
            btnPassword.Location = new Point(1259, 531);
            btnPassword.Name = "btnPassword";
            btnPassword.Size = new Size(25, 13);
            btnPassword.TabIndex = 15;
            btnPassword.UseVisualStyleBackColor = true;
            // 
            // btnGoBack
            // 
            btnGoBack.BackgroundImage = Properties.Resources._2NH_GOBACK;
            btnGoBack.BackgroundImageLayout = ImageLayout.Stretch;
            btnGoBack.FlatAppearance.BorderSize = 0;
            btnGoBack.FlatStyle = FlatStyle.Flat;
            btnGoBack.Location = new Point(1008, 619);
            btnGoBack.Name = "btnGoBack";
            btnGoBack.Size = new Size(218, 49);
            btnGoBack.TabIndex = 16;
            btnGoBack.UseVisualStyleBackColor = true;
            // 
            // btnLogIn
            // 
            btnLogIn.BackgroundImage = Properties.Resources._2NH_LOGIN;
            btnLogIn.BackgroundImageLayout = ImageLayout.Stretch;
            btnLogIn.FlatAppearance.BorderSize = 0;
            btnLogIn.FlatStyle = FlatStyle.Flat;
            btnLogIn.Location = new Point(695, 619);
            btnLogIn.Name = "btnLogIn";
            btnLogIn.Size = new Size(218, 49);
            btnLogIn.TabIndex = 17;
            btnLogIn.UseVisualStyleBackColor = true;
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
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.FromArgb(137, 106, 149);
            lblUsername.Font = new Font("Vaticanus", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUsername.ForeColor = SystemColors.InactiveCaption;
            lblUsername.Location = new Point(780, 376);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(94, 23);
            lblUsername.TabIndex = 20;
            lblUsername.Text = "x error";
            lblUsername.Visible = false;
            // 
            // lblPass
            // 
            lblPass.AutoSize = true;
            lblPass.BackColor = Color.FromArgb(137, 106, 149);
            lblPass.Font = new Font("Vaticanus", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPass.ForeColor = SystemColors.InactiveCaption;
            lblPass.Location = new Point(795, 474);
            lblPass.Name = "lblPass";
            lblPass.Size = new Size(94, 23);
            lblPass.TabIndex = 21;
            lblPass.Text = "x error";
            lblPass.Visible = false;
            // 
            // LogInForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblPass);
            Controls.Add(lblUsername);
            Controls.Add(btnLogIn);
            Controls.Add(btnGoBack);
            Controls.Add(btnPassword);
            Controls.Add(tbxPassword);
            Controls.Add(tbxUsername);
            Controls.Add(logInPanel);
            Controls.Add(pbxLoadingBar);
            Controls.Add(pbxBackground);
            DoubleBuffered = true;
            Name = "LogInForm";
            Size = new Size(1920, 991);
            ((System.ComponentModel.ISupportInitialize)pbxBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)logInPanel).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxLoadingBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxBackground;
        private PictureBox logInPanel;
        private RichTextBox tbxUsername;
        private TextBox tbxPassword;
        private Button btnPassword;
        private Button btnGoBack;
        private Button btnLogIn;
        private PictureBox pbxLoadingBar;
        private System.Windows.Forms.Timer timer;
        private Label lblUsername;
        private Label lblPass;
    }
}
