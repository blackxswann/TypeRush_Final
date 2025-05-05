namespace TypeRush_Final
{
    partial class HomeForm
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
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            lblWelcomeText = new Label();
            lblDisplayName = new Label();
            lblUsername = new Label();
            btnViewProfile = new Button();
            pnlPracticeDrill = new Panel();
            pnlTypingTest = new Panel();
            pnlMinigames = new Panel();
            pnlLeaderboard = new Panel();
            timer = new System.Windows.Forms.Timer(components);
            pbxDisplayPicture = new PictureBox();
            pbxBackground = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxDisplayPicture).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxBackground).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ButtonHighlight;
            pictureBox1.Location = new Point(123, 315);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 48);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.ButtonHighlight;
            pictureBox2.Image = Properties.Resources.emojiGIF;
            pictureBox2.Location = new Point(133, 317);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(43, 43);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.ButtonHighlight;
            pictureBox3.Image = Properties.Resources.moonMovingGIF;
            pictureBox3.Location = new Point(70, 512);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(44, 46);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // lblWelcomeText
            // 
            lblWelcomeText.AutoSize = true;
            lblWelcomeText.BackColor = Color.FromArgb(101, 73, 112);
            lblWelcomeText.Font = new Font("Vaticanus", 19F);
            lblWelcomeText.ForeColor = Color.FromArgb(254, 232, 139);
            lblWelcomeText.Location = new Point(109, 252);
            lblWelcomeText.Name = "lblWelcomeText";
            lblWelcomeText.Size = new Size(382, 32);
            lblWelcomeText.TabIndex = 3;
            lblWelcomeText.Text = "Welcome to TypeRush, @!";
            // 
            // lblDisplayName
            // 
            lblDisplayName.AutoSize = true;
            lblDisplayName.BackColor = Color.FromArgb(171, 140, 183);
            lblDisplayName.Font = new Font("Vaticanus", 19F);
            lblDisplayName.ForeColor = Color.FromArgb(205, 208, 231);
            lblDisplayName.Location = new Point(1146, 460);
            lblDisplayName.Name = "lblDisplayName";
            lblDisplayName.Size = new Size(202, 32);
            lblDisplayName.TabIndex = 4;
            lblDisplayName.Text = "DISPLAYNAME";
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.BackColor = Color.FromArgb(171, 140, 183);
            lblUsername.Font = new Font("Vaticanus", 15F);
            lblUsername.ForeColor = Color.FromArgb(249, 237, 177);
            lblUsername.Location = new Point(1146, 492);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(28, 25);
            lblUsername.TabIndex = 5;
            lblUsername.Text = "@";
            // 
            // btnViewProfile
            // 
            btnViewProfile.BackgroundImage = Properties.Resources.P_NH_VIEWPROFILE;
            btnViewProfile.BackgroundImageLayout = ImageLayout.Stretch;
            btnViewProfile.FlatAppearance.BorderSize = 0;
            btnViewProfile.FlatStyle = FlatStyle.Flat;
            btnViewProfile.Location = new Point(1235, 530);
            btnViewProfile.Name = "btnViewProfile";
            btnViewProfile.Size = new Size(215, 40);
            btnViewProfile.TabIndex = 20;
            btnViewProfile.UseVisualStyleBackColor = true;
            // 
            // pnlPracticeDrill
            // 
            pnlPracticeDrill.BackgroundImage = Properties.Resources.H_NH_PDRILL;
            pnlPracticeDrill.BackgroundImageLayout = ImageLayout.None;
            pnlPracticeDrill.Location = new Point(99, 602);
            pnlPracticeDrill.Name = "pnlPracticeDrill";
            pnlPracticeDrill.Size = new Size(433, 141);
            pnlPracticeDrill.TabIndex = 21;
            // 
            // pnlTypingTest
            // 
            pnlTypingTest.BackgroundImage = Properties.Resources.H_NH_TYPINGTEST;
            pnlTypingTest.BackgroundImageLayout = ImageLayout.None;
            pnlTypingTest.Location = new Point(548, 602);
            pnlTypingTest.Name = "pnlTypingTest";
            pnlTypingTest.Size = new Size(433, 141);
            pnlTypingTest.TabIndex = 22;
            // 
            // pnlMinigames
            // 
            pnlMinigames.BackgroundImage = Properties.Resources.H_NH_MINIGAME;
            pnlMinigames.BackgroundImageLayout = ImageLayout.None;
            pnlMinigames.Location = new Point(99, 762);
            pnlMinigames.Name = "pnlMinigames";
            pnlMinigames.Size = new Size(433, 141);
            pnlMinigames.TabIndex = 22;
            // 
            // pnlLeaderboard
            // 
            pnlLeaderboard.BackgroundImage = Properties.Resources.H_NH_LEADERBOARD;
            pnlLeaderboard.BackgroundImageLayout = ImageLayout.None;
            pnlLeaderboard.Location = new Point(548, 762);
            pnlLeaderboard.Name = "pnlLeaderboard";
            pnlLeaderboard.Size = new Size(433, 141);
            pnlLeaderboard.TabIndex = 23;
            // 
            // timer
            // 
            timer.Interval = 125;
            timer.Tick += timer_Tick;
            // 
            // pbxDisplayPicture
            // 
            pbxDisplayPicture.Location = new Point(1254, 252);
            pbxDisplayPicture.Name = "pbxDisplayPicture";
            pbxDisplayPicture.Size = new Size(168, 169);
            pbxDisplayPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbxDisplayPicture.TabIndex = 24;
            pbxDisplayPicture.TabStop = false;
            // 
            // pbxBackground
            // 
            pbxBackground.Dock = DockStyle.Fill;
            pbxBackground.Image = Properties.Resources.HOMEBG;
            pbxBackground.Location = new Point(0, 0);
            pbxBackground.Name = "pbxBackground";
            pbxBackground.Size = new Size(1543, 991);
            pbxBackground.TabIndex = 25;
            pbxBackground.TabStop = false;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            Controls.Add(pbxDisplayPicture);
            Controls.Add(pnlLeaderboard);
            Controls.Add(pnlMinigames);
            Controls.Add(pnlTypingTest);
            Controls.Add(pnlPracticeDrill);
            Controls.Add(btnViewProfile);
            Controls.Add(lblUsername);
            Controls.Add(lblDisplayName);
            Controls.Add(lblWelcomeText);
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(pbxBackground);
            DoubleBuffered = true;
            Name = "HomeForm";
            Size = new Size(1543, 991);
            Load += HomeForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxDisplayPicture).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxBackground).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label lblWelcomeText;
        private Label lblDisplayName;
        private Label lblUsername;
        private Button btnViewProfile;
        private Panel pnlPracticeDrill;
        private Panel pnlTypingTest;
        private Panel pnlMinigames;
        private Panel pnlLeaderboard;
        private System.Windows.Forms.Timer timer;
        private PictureBox pbxDisplayPicture;
        private PictureBox pbxBackground;
    }
}
