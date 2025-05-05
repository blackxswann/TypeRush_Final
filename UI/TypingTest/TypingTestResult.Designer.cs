namespace TypeRush_Final.UI.TypingTest
{
    partial class TypingTestResult
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
            lblWPM = new Label();
            lblAccuracy = new Label();
            barGraph = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            goBackPbx = new PictureBox();
            label1 = new Label();
            pbxLevel = new PictureBox();
            lblCongrats = new Label();
            lblLevel = new Label();
            btnBack = new Button();
            textTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbxBackground).BeginInit();
            ((System.ComponentModel.ISupportInitialize)goBackPbx).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxLevel).BeginInit();
            SuspendLayout();
            // 
            // pbxBackground
            // 
            pbxBackground.BackgroundImage = Properties.Resources.resultsFINALBG;
            pbxBackground.Dock = DockStyle.Fill;
            pbxBackground.Image = Properties.Resources.resultsFINALBG;
            pbxBackground.Location = new Point(0, 0);
            pbxBackground.Name = "pbxBackground";
            pbxBackground.Size = new Size(1543, 991);
            pbxBackground.TabIndex = 0;
            pbxBackground.TabStop = false;
            pbxBackground.MouseHover += pbxBackground_MouseHover;
            // 
            // lblWPM
            // 
            lblWPM.AutoSize = true;
            lblWPM.BackColor = Color.FromArgb(100, 73, 112);
            lblWPM.Font = new Font("Vaticanus", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWPM.ForeColor = Color.FromArgb(254, 232, 139);
            lblWPM.Location = new Point(371, 439);
            lblWPM.Name = "lblWPM";
            lblWPM.Size = new Size(101, 37);
            lblWPM.TabIndex = 3;
            lblWPM.Text = "WPM:";
            // 
            // lblAccuracy
            // 
            lblAccuracy.AutoSize = true;
            lblAccuracy.BackColor = Color.FromArgb(100, 73, 112);
            lblAccuracy.Font = new Font("Vaticanus", 22F);
            lblAccuracy.ForeColor = Color.FromArgb(254, 232, 139);
            lblAccuracy.Location = new Point(371, 526);
            lblAccuracy.Name = "lblAccuracy";
            lblAccuracy.Size = new Size(178, 37);
            lblAccuracy.TabIndex = 5;
            lblAccuracy.Text = "Accuracy:";
            // 
            // barGraph
            // 
            barGraph.Location = new Point(759, 366);
            barGraph.MatchAxesScreenDataRatio = false;
            barGraph.Name = "barGraph";
            barGraph.Size = new Size(413, 316);
            barGraph.TabIndex = 7;
            // 
            // goBackPbx
            // 
            goBackPbx.BackColor = Color.Transparent;
            goBackPbx.Image = Properties.Resources.drill_nh_goback;
            goBackPbx.Location = new Point(387, 676);
            goBackPbx.Name = "goBackPbx";
            goBackPbx.Size = new Size(246, 50);
            goBackPbx.SizeMode = PictureBoxSizeMode.StretchImage;
            goBackPbx.TabIndex = 8;
            goBackPbx.TabStop = false;
            goBackPbx.Click += goBackPbx_Click;
            goBackPbx.MouseLeave += goBackPbx_MouseLeave;
            goBackPbx.MouseHover += goBackPbx_MouseHover;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(240, 210, 229);
            label1.Font = new Font("Vaticanus", 22F);
            label1.ForeColor = SystemColors.ActiveCaption;
            label1.Location = new Point(779, 326);
            label1.Name = "label1";
            label1.Size = new Size(377, 37);
            label1.TabIndex = 9;
            label1.Text = "Mistyped Characters";
            // 
            // pbxLevel
            // 
            pbxLevel.Image = Properties.Resources.Congrats_BG1;
            pbxLevel.Location = new Point(321, 245);
            pbxLevel.Name = "pbxLevel";
            pbxLevel.Size = new Size(900, 500);
            pbxLevel.TabIndex = 24;
            pbxLevel.TabStop = false;
            pbxLevel.Visible = false;
            // 
            // lblCongrats
            // 
            lblCongrats.AutoSize = true;
            lblCongrats.BackColor = Color.FromArgb(180, 205, 213);
            lblCongrats.Font = new Font("Vaticanus", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCongrats.ForeColor = SystemColors.ButtonHighlight;
            lblCongrats.Location = new Point(429, 363);
            lblCongrats.Name = "lblCongrats";
            lblCongrats.Size = new Size(684, 40);
            lblCongrats.TabIndex = 25;
            lblCongrats.Text = "CONGRATULATIONS! YOU LEVELED UP!";
            lblCongrats.Visible = false;
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.BackColor = Color.FromArgb(180, 205, 213);
            lblLevel.Font = new Font("Vaticanus", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLevel.ForeColor = SystemColors.ButtonHighlight;
            lblLevel.Location = new Point(607, 583);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(270, 31);
            lblLevel.TabIndex = 26;
            lblLevel.Text = "LEVEL 1 - TYPIST";
            lblLevel.Visible = false;
            // 
            // btnBack
            // 
            btnBack.Font = new Font("monogram", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = SystemColors.ControlDarkDark;
            btnBack.Location = new Point(702, 652);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(143, 30);
            btnBack.TabIndex = 27;
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
            // TypingTestResult
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnBack);
            Controls.Add(lblLevel);
            Controls.Add(lblCongrats);
            Controls.Add(pbxLevel);
            Controls.Add(label1);
            Controls.Add(goBackPbx);
            Controls.Add(lblAccuracy);
            Controls.Add(lblWPM);
            Controls.Add(barGraph);
            Controls.Add(pbxBackground);
            Name = "TypingTestResult";
            Size = new Size(1543, 991);
            ((System.ComponentModel.ISupportInitialize)pbxBackground).EndInit();
            ((System.ComponentModel.ISupportInitialize)goBackPbx).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxLevel).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxBackground;
        private Label lblWPM;
        private Label lblAccuracy;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart barGraph;
        private PictureBox goBackPbx;
        private Label label1;
        private PictureBox pbxLevel;
        private Label lblCongrats;
        private Label lblLevel;
        private Button btnBack;
        private System.Windows.Forms.Timer textTimer;
    }
}
