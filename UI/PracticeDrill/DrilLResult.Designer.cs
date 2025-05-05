namespace TypeRush_Final
{
    partial class DrilLResult
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
            star1 = new PictureBox();
            star2 = new PictureBox();
            star3 = new PictureBox();
            timer = new System.Windows.Forms.Timer(components);
            lblStars = new Label();
            lblWPM = new Label();
            btnGoBack = new Button();
            pbxLevel = new PictureBox();
            lblCongrats = new Label();
            lblLevel = new Label();
            btnBack = new Button();
            textTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbxBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)star1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)star2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)star3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxLevel).BeginInit();
            SuspendLayout();
            // 
            // pbxBackground
            // 
            pbxBackground.Dock = DockStyle.Fill;
            pbxBackground.Image = Properties.Resources.PDRILL_RESULTSBG;
            pbxBackground.Location = new Point(0, 0);
            pbxBackground.Name = "pbxBackground";
            pbxBackground.Size = new Size(1543, 991);
            pbxBackground.TabIndex = 0;
            pbxBackground.TabStop = false;
            // 
            // star1
            // 
            star1.Image = Properties.Resources.star;
            star1.Location = new Point(628, 391);
            star1.Name = "star1";
            star1.Size = new Size(94, 90);
            star1.TabIndex = 2;
            star1.TabStop = false;
            star1.Visible = false;
            // 
            // star2
            // 
            star2.Image = Properties.Resources.star;
            star2.Location = new Point(745, 350);
            star2.Name = "star2";
            star2.Size = new Size(94, 90);
            star2.TabIndex = 3;
            star2.TabStop = false;
            star2.Visible = false;
            // 
            // star3
            // 
            star3.Image = Properties.Resources.star;
            star3.Location = new Point(861, 391);
            star3.Name = "star3";
            star3.Size = new Size(94, 90);
            star3.TabIndex = 4;
            star3.TabStop = false;
            star3.Visible = false;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // lblStars
            // 
            lblStars.AutoSize = true;
            lblStars.BackColor = Color.FromArgb(171, 140, 183);
            lblStars.Font = new Font("Vaticanus", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStars.ForeColor = Color.FromArgb(249, 237, 177);
            lblStars.Location = new Point(481, 498);
            lblStars.Name = "lblStars";
            lblStars.Size = new Size(267, 40);
            lblStars.TabIndex = 5;
            lblStars.Text = "You received ";
            // 
            // lblWPM
            // 
            lblWPM.AutoSize = true;
            lblWPM.BackColor = Color.FromArgb(171, 140, 183);
            lblWPM.Font = new Font("Vaticanus", 20F);
            lblWPM.ForeColor = Color.FromArgb(198, 212, 219);
            lblWPM.Location = new Point(417, 538);
            lblWPM.Name = "lblWPM";
            lblWPM.Size = new Size(228, 35);
            lblWPM.TabIndex = 6;
            lblWPM.Text = "You received ";
            // 
            // btnGoBack
            // 
            btnGoBack.BackColor = Color.FromArgb(148, 122, 158);
            btnGoBack.BackgroundImage = Properties.Resources.t_nh_back;
            btnGoBack.BackgroundImageLayout = ImageLayout.Zoom;
            btnGoBack.FlatAppearance.BorderSize = 0;
            btnGoBack.FlatStyle = FlatStyle.Flat;
            btnGoBack.Location = new Point(280, 630);
            btnGoBack.Name = "btnGoBack";
            btnGoBack.Size = new Size(189, 56);
            btnGoBack.TabIndex = 22;
            btnGoBack.UseVisualStyleBackColor = false;
            btnGoBack.Click += btnGoBack_Click;
            btnGoBack.MouseLeave += btnGoBack_MouseLeave;
            btnGoBack.MouseHover += btnGoBack_MouseHover;
            // 
            // pbxLevel
            // 
            pbxLevel.Image = Properties.Resources.Congrats_BG1;
            pbxLevel.Location = new Point(304, 225);
            pbxLevel.Name = "pbxLevel";
            pbxLevel.Size = new Size(900, 500);
            pbxLevel.TabIndex = 23;
            pbxLevel.TabStop = false;
            pbxLevel.Visible = false;
            // 
            // lblCongrats
            // 
            lblCongrats.AutoSize = true;
            lblCongrats.BackColor = Color.FromArgb(180, 205, 213);
            lblCongrats.Font = new Font("Vaticanus", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCongrats.ForeColor = SystemColors.ButtonHighlight;
            lblCongrats.Location = new Point(429, 323);
            lblCongrats.Name = "lblCongrats";
            lblCongrats.Size = new Size(684, 40);
            lblCongrats.TabIndex = 24;
            lblCongrats.Text = "CONGRATULATIONS! YOU LEVELED UP!";
            lblCongrats.Visible = false;
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.BackColor = Color.FromArgb(180, 205, 213);
            lblLevel.Font = new Font("Vaticanus", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLevel.ForeColor = SystemColors.ButtonHighlight;
            lblLevel.Location = new Point(440, 585);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(270, 31);
            lblLevel.TabIndex = 25;
            lblLevel.Text = "LEVEL 1 - TYPIST";
            lblLevel.Visible = false;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("monogram", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = SystemColors.ControlDarkDark;
            btnBack.Location = new Point(682, 643);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(143, 30);
            btnBack.TabIndex = 26;
            btnBack.Text = "GO BACK";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Visible = false;
            btnBack.Click += btnBack_Click;
            // 
            // textTimer
            // 
            textTimer.Interval = 50;
            textTimer.Tick += textTimer_Tick;
            // 
            // DrilLResult
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnBack);
            Controls.Add(lblLevel);
            Controls.Add(lblCongrats);
            Controls.Add(pbxLevel);
            Controls.Add(btnGoBack);
            Controls.Add(lblWPM);
            Controls.Add(lblStars);
            Controls.Add(star3);
            Controls.Add(star2);
            Controls.Add(star1);
            Controls.Add(pbxBackground);
            Name = "DrilLResult";
            Size = new Size(1543, 991);
            ((System.ComponentModel.ISupportInitialize)pbxBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)star1).EndInit();
            ((System.ComponentModel.ISupportInitialize)star2).EndInit();
            ((System.ComponentModel.ISupportInitialize)star3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxLevel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxBackground;
        private PictureBox star1;
        private PictureBox star2;
        private PictureBox star3;
        private System.Windows.Forms.Timer timer;
        private Label lblStars;
        private Label lblWPM;
        private Button btnGoBack;
        private PictureBox pbxLevel;
        private Label lblCongrats;
        private Label lblLevel;
        private Button btnBack;
        private System.Windows.Forms.Timer textTimer;
    }
}
