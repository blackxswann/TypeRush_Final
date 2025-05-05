namespace TypeRush_Final.UI.LevelUpAndLeaderboard
{
    partial class NotifyLevel
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
            congrats = new PictureBox();
            lblCongrats = new Label();
            lblLevel = new Label();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)congrats).BeginInit();
            SuspendLayout();
            // 
            // congrats
            // 
            congrats.Dock = DockStyle.Fill;
            congrats.Image = Properties.Resources.Congrats_BG;
            congrats.Location = new Point(0, 0);
            congrats.Name = "congrats";
            congrats.Size = new Size(900, 500);
            congrats.TabIndex = 0;
            congrats.TabStop = false;
            // 
            // lblCongrats
            // 
            lblCongrats.AutoSize = true;
            lblCongrats.BackColor = Color.FromArgb(180, 205, 213);
            lblCongrats.Font = new Font("Vaticanus", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCongrats.ForeColor = SystemColors.ButtonHighlight;
            lblCongrats.Location = new Point(116, 118);
            lblCongrats.Name = "lblCongrats";
            lblCongrats.Size = new Size(684, 40);
            lblCongrats.TabIndex = 3;
            lblCongrats.Text = "CONGRATULATIONS! YOU LEVELED UP!";
            // 
            // lblLevel
            // 
            lblLevel.AutoSize = true;
            lblLevel.BackColor = Color.FromArgb(180, 205, 213);
            lblLevel.Font = new Font("Vaticanus", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLevel.ForeColor = SystemColors.ButtonHighlight;
            lblLevel.Location = new Point(315, 343);
            lblLevel.Name = "lblLevel";
            lblLevel.Size = new Size(270, 31);
            lblLevel.TabIndex = 4;
            lblLevel.Text = "LEVEL 1 - TYPIST";
            // 
            // NotifyLevel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblLevel);
            Controls.Add(lblCongrats);
            Controls.Add(congrats);
            Name = "NotifyLevel";
            Size = new Size(900, 500);
            ((System.ComponentModel.ISupportInitialize)congrats).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox congrats;
        private Label lblCongrats;
        private Label lblLevel;
        private System.Windows.Forms.Timer timer;
    }
}
