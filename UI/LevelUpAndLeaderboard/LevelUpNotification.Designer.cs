namespace TypeRush_Final.UI.AchievementsAndLeaderboard
{
    partial class LevelUpNotification
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
            btnGoBack = new Button();
            lblCongrats = new Label();
            lblLevel = new Label();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbxBackground).BeginInit();
            SuspendLayout();
            // 
            // pbxBackground
            // 
            pbxBackground.Dock = DockStyle.Fill;
            pbxBackground.Image = Properties.Resources.Congrats_BG;
            pbxBackground.Location = new Point(0, 0);
            pbxBackground.Name = "pbxBackground";
            pbxBackground.Size = new Size(900, 500);
            pbxBackground.TabIndex = 0;
            pbxBackground.TabStop = false;
            // 
            // btnGoBack
            // 
            btnGoBack.Font = new Font("monogram", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGoBack.ForeColor = SystemColors.ControlDarkDark;
            btnGoBack.Location = new Point(379, 419);
            btnGoBack.Name = "btnGoBack";
            btnGoBack.Size = new Size(143, 30);
            btnGoBack.TabIndex = 1;
            btnGoBack.Text = "GO BACK";
            btnGoBack.UseVisualStyleBackColor = true;
            // 
            // lblCongrats
            // 
            lblCongrats.AutoSize = true;
            lblCongrats.BackColor = Color.FromArgb(180, 205, 213);
            lblCongrats.Font = new Font("Vaticanus", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCongrats.ForeColor = SystemColors.ButtonHighlight;
            lblCongrats.Location = new Point(116, 112);
            lblCongrats.Name = "lblCongrats";
            lblCongrats.Size = new Size(684, 40);
            lblCongrats.TabIndex = 2;
            lblCongrats.Text = "CONGRATULATIONS! YOU LEVELED UP!";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.BackColor = Color.FromArgb(180, 205, 213);
            lblLevel.Font = new Font("Vaticanus", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLevel.ForeColor = SystemColors.ButtonHighlight;
            lblLevel.Location = new Point(317, 336);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(270, 31);
            lblLevel.TabIndex = 3;
            lblLevel.Text = "LEVEL 1 - TYPIST";
            // 
            // timer
            // 
            timer.Interval = 50;
            timer.Tick += timer_Tick;
            // 
            // LevelUpNotification
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 500);
            Controls.Add(lblLevel);
            Controls.Add(lblCongrats);
            Controls.Add(btnGoBack);
            Controls.Add(pbxBackground);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "LevelUpNotification";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)pbxBackground).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxBackground;
        private Button btnGoBack;
        private Label lblCongrats;
        private Label lblLevel;
        private System.Windows.Forms.Timer timer;
    }
}
