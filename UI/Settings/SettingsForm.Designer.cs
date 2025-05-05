namespace TypeRush_Final
{
    partial class SettingsForm
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
            pnlSettings = new Panel();
            btnResetPassword = new Button();
            pbxDisplayPicture = new PictureBox();
            btnPassword = new Button();
            tbxPassword = new TextBox();
            tbxEmailAddress = new RichTextBox();
            tbxUsername = new RichTextBox();
            tbxDisplayName = new RichTextBox();
            btnChange = new Button();
            btnCancel = new Button();
            btnSaveChanges = new Button();
            btnDeleteAccount = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            pbxBackground = new PictureBox();
            btnPrevious = new Button();
            btnNext = new Button();
            pnlSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbxDisplayPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxBackground).BeginInit();
            SuspendLayout();
            // 
            // pnlSettings
            // 
            pnlSettings.BackgroundImage = Properties.Resources.settingspnl1;
            pnlSettings.BackgroundImageLayout = ImageLayout.Zoom;
            pnlSettings.Controls.Add(btnNext);
            pnlSettings.Controls.Add(btnPrevious);
            pnlSettings.Controls.Add(btnResetPassword);
            pnlSettings.Controls.Add(pbxDisplayPicture);
            pnlSettings.Controls.Add(btnPassword);
            pnlSettings.Controls.Add(tbxPassword);
            pnlSettings.Controls.Add(tbxEmailAddress);
            pnlSettings.Controls.Add(tbxUsername);
            pnlSettings.Controls.Add(tbxDisplayName);
            pnlSettings.Controls.Add(btnChange);
            pnlSettings.Controls.Add(btnCancel);
            pnlSettings.Controls.Add(btnSaveChanges);
            pnlSettings.Controls.Add(btnDeleteAccount);
            pnlSettings.Location = new Point(280, 193);
            pnlSettings.Name = "pnlSettings";
            pnlSettings.Size = new Size(982, 679);
            pnlSettings.TabIndex = 0;
            // 
            // btnResetPassword
            // 
            btnResetPassword.BackgroundImage = Properties.Resources.S_NH_BTNRESETPASSWORD;
            btnResetPassword.BackgroundImageLayout = ImageLayout.Stretch;
            btnResetPassword.FlatAppearance.BorderSize = 0;
            btnResetPassword.FlatStyle = FlatStyle.Flat;
            btnResetPassword.Location = new Point(73, 385);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.Size = new Size(228, 40);
            btnResetPassword.TabIndex = 28;
            btnResetPassword.TabStop = false;
            btnResetPassword.UseVisualStyleBackColor = true;
            // 
            // pbxDisplayPicture
            // 
            pbxDisplayPicture.Image = Properties.Resources.picture;
            pbxDisplayPicture.Location = new Point(726, 174);
            pbxDisplayPicture.Name = "pbxDisplayPicture";
            pbxDisplayPicture.Size = new Size(186, 186);
            pbxDisplayPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxDisplayPicture.TabIndex = 27;
            pbxDisplayPicture.TabStop = false;
            // 
            // btnPassword
            // 
            btnPassword.BackgroundImage = Properties.Resources.HidePassword;
            btnPassword.BackgroundImageLayout = ImageLayout.Stretch;
            btnPassword.FlatAppearance.BorderSize = 0;
            btnPassword.FlatStyle = FlatStyle.Flat;
            btnPassword.Location = new Point(568, 400);
            btnPassword.Name = "btnPassword";
            btnPassword.Size = new Size(20, 10);
            btnPassword.TabIndex = 26;
            btnPassword.UseVisualStyleBackColor = true;
            btnPassword.Visible = false;
            // 
            // tbxPassword
            // 
            tbxPassword.BackColor = Color.FromArgb(242, 239, 235);
            tbxPassword.BorderStyle = BorderStyle.None;
            tbxPassword.Font = new Font("monogram", 16F, FontStyle.Bold);
            tbxPassword.ForeColor = Color.DimGray;
            tbxPassword.Location = new Point(89, 393);
            tbxPassword.Name = "tbxPassword";
            tbxPassword.Size = new Size(473, 22);
            tbxPassword.TabIndex = 25;
            tbxPassword.Visible = false;
            // 
            // tbxEmailAddress
            // 
            tbxEmailAddress.BackColor = Color.FromArgb(242, 239, 235);
            tbxEmailAddress.BorderStyle = BorderStyle.None;
            tbxEmailAddress.Font = new Font("monogram", 16F, FontStyle.Bold);
            tbxEmailAddress.ForeColor = Color.DimGray;
            tbxEmailAddress.Location = new Point(88, 301);
            tbxEmailAddress.Name = "tbxEmailAddress";
            tbxEmailAddress.Size = new Size(500, 21);
            tbxEmailAddress.TabIndex = 24;
            tbxEmailAddress.Text = "testing";
            // 
            // tbxUsername
            // 
            tbxUsername.BackColor = Color.FromArgb(242, 239, 235);
            tbxUsername.BorderStyle = BorderStyle.None;
            tbxUsername.Font = new Font("monogram", 16F, FontStyle.Bold);
            tbxUsername.ForeColor = Color.DimGray;
            tbxUsername.Location = new Point(89, 219);
            tbxUsername.Name = "tbxUsername";
            tbxUsername.Size = new Size(500, 21);
            tbxUsername.TabIndex = 23;
            tbxUsername.Text = "testing";
            // 
            // tbxDisplayName
            // 
            tbxDisplayName.BackColor = Color.FromArgb(242, 239, 235);
            tbxDisplayName.BorderStyle = BorderStyle.None;
            tbxDisplayName.Font = new Font("monogram", 16F, FontStyle.Bold);
            tbxDisplayName.ForeColor = Color.DimGray;
            tbxDisplayName.Location = new Point(89, 140);
            tbxDisplayName.Name = "tbxDisplayName";
            tbxDisplayName.Size = new Size(500, 21);
            tbxDisplayName.TabIndex = 22;
            tbxDisplayName.Text = "testing";
            // 
            // btnChange
            // 
            btnChange.BackgroundImage = Properties.Resources.S_NH_CHANGE;
            btnChange.BackgroundImageLayout = ImageLayout.Stretch;
            btnChange.FlatAppearance.BorderSize = 0;
            btnChange.FlatStyle = FlatStyle.Flat;
            btnChange.Location = new Point(754, 380);
            btnChange.Name = "btnChange";
            btnChange.Size = new Size(136, 40);
            btnChange.TabIndex = 21;
            btnChange.TabStop = false;
            btnChange.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.BackgroundImage = Properties.Resources.S_NH_CANCEL;
            btnCancel.BackgroundImageLayout = ImageLayout.Stretch;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(533, 593);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(215, 40);
            btnCancel.TabIndex = 20;
            btnCancel.TabStop = false;
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Visible = false;
            // 
            // btnSaveChanges
            // 
            btnSaveChanges.BackgroundImage = Properties.Resources.S_NH_SAVECHANGES;
            btnSaveChanges.BackgroundImageLayout = ImageLayout.Stretch;
            btnSaveChanges.FlatAppearance.BorderSize = 0;
            btnSaveChanges.FlatStyle = FlatStyle.Flat;
            btnSaveChanges.Location = new Point(208, 593);
            btnSaveChanges.Name = "btnSaveChanges";
            btnSaveChanges.Size = new Size(215, 40);
            btnSaveChanges.TabIndex = 19;
            btnSaveChanges.TabStop = false;
            btnSaveChanges.UseVisualStyleBackColor = true;
            btnSaveChanges.Visible = false;
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.BackgroundImage = Properties.Resources.S_NH_DELETEACCOUNT;
            btnDeleteAccount.BackgroundImageLayout = ImageLayout.Stretch;
            btnDeleteAccount.FlatAppearance.BorderSize = 0;
            btnDeleteAccount.FlatStyle = FlatStyle.Flat;
            btnDeleteAccount.Location = new Point(80, 513);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.Size = new Size(215, 40);
            btnDeleteAccount.TabIndex = 18;
            btnDeleteAccount.TabStop = false;
            btnDeleteAccount.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // pbxBackground
            // 
            pbxBackground.Dock = DockStyle.Fill;
            pbxBackground.Image = Properties.Resources.SettingsBG;
            pbxBackground.Location = new Point(0, 0);
            pbxBackground.Name = "pbxBackground";
            pbxBackground.Size = new Size(1543, 991);
            pbxBackground.TabIndex = 1;
            pbxBackground.TabStop = false;
            // 
            // btnPrevious
            // 
            btnPrevious.BackgroundImage = Properties.Resources.S_PreviousButton;
            btnPrevious.BackgroundImageLayout = ImageLayout.Stretch;
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Location = new Point(705, 384);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(32, 33);
            btnPrevious.TabIndex = 29;
            btnPrevious.UseVisualStyleBackColor = true;
            btnPrevious.Visible = false;
            // 
            // btnNext
            // 
            btnNext.BackgroundImage = Properties.Resources.S_NextButton;
            btnNext.BackgroundImageLayout = ImageLayout.Stretch;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Location = new Point(908, 382);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(32, 33);
            btnNext.TabIndex = 30;
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Visible = false;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            Controls.Add(pnlSettings);
            Controls.Add(pbxBackground);
            DoubleBuffered = true;
            Name = "SettingsForm";
            Size = new Size(1543, 991);
            Load += SettingsForm_Load;
            pnlSettings.ResumeLayout(false);
            pnlSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbxDisplayPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxBackground).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlSettings;
        private Button btnCancel;
        private Button btnSaveChanges;
        private Button btnDeleteAccount;
        private Button btnChange;
        private RichTextBox tbxDisplayName;
        private ContextMenuStrip contextMenuStrip1;
        private RichTextBox tbxEmailAddress;
        private RichTextBox tbxUsername;
        private TextBox tbxPassword;
        private PictureBox pbxDisplayPicture;
        private Button btnPassword;
        private Button btnResetPassword;
        private PictureBox pbxBackground;
        private Button btnPrevious;
        private Button btnNext;
    }
}
