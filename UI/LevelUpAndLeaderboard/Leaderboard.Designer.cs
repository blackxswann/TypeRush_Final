namespace TypeRush_Final
{
    partial class Leaderboard
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
            dgv1 = new DataGridView();
            lbl = new Label();
            lblByLevel = new Label();
            MostStars = new Label();
            TypingSpeed = new Label();
            Accuracy = new Label();
            minigame = new Label();
            ((System.ComponentModel.ISupportInitialize)dgv1).BeginInit();
            SuspendLayout();
            // 
            // dgv1
            // 
            dgv1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv1.Location = new Point(559, 268);
            dgv1.Name = "dgv1";
            dgv1.RowHeadersWidth = 51;
            dgv1.Size = new Size(734, 556);
            dgv1.TabIndex = 1;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.BackColor = Color.Transparent;
            lbl.Location = new Point(582, 217);
            lbl.Name = "lbl";
            lbl.Size = new Size(0, 20);
            lbl.TabIndex = 2;
            // 
            // lblByLevel
            // 
            lblByLevel.AutoSize = true;
            lblByLevel.BackColor = Color.Transparent;
            lblByLevel.Font = new Font("Vaticanus", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblByLevel.ForeColor = Color.FromArgb(205, 208, 231);
            lblByLevel.Location = new Point(297, 206);
            lblByLevel.Name = "lblByLevel";
            lblByLevel.Size = new Size(119, 31);
            lblByLevel.TabIndex = 3;
            lblByLevel.Text = "       ";
            lblByLevel.Click += lblByLevel_Click_1;
            // 
            // MostStars
            // 
            MostStars.AutoSize = true;
            MostStars.BackColor = Color.Transparent;
            MostStars.Font = new Font("Vaticanus", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MostStars.ForeColor = Color.FromArgb(135, 135, 163);
            MostStars.Location = new Point(474, 206);
            MostStars.Name = "MostStars";
            MostStars.Size = new Size(194, 31);
            MostStars.TabIndex = 4;
            MostStars.Text = "            ";
            MostStars.Click += MostStars_Click;
            // 
            // TypingSpeed
            // 
            TypingSpeed.AutoSize = true;
            TypingSpeed.BackColor = Color.Transparent;
            TypingSpeed.Font = new Font("Vaticanus", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TypingSpeed.ForeColor = Color.FromArgb(135, 135, 163);
            TypingSpeed.Location = new Point(694, 206);
            TypingSpeed.Name = "TypingSpeed";
            TypingSpeed.Size = new Size(164, 31);
            TypingSpeed.TabIndex = 5;
            TypingSpeed.Text = "          ";
            TypingSpeed.Click += TypingSpeed_Click;
            // 
            // Accuracy
            // 
            Accuracy.AutoSize = true;
            Accuracy.BackColor = Color.Transparent;
            Accuracy.Font = new Font("Vaticanus", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Accuracy.ForeColor = Color.FromArgb(135, 135, 163);
            Accuracy.Location = new Point(945, 206);
            Accuracy.Name = "Accuracy";
            Accuracy.Size = new Size(119, 31);
            Accuracy.TabIndex = 6;
            Accuracy.Text = "       ";
            Accuracy.Click += Accuracy_Click;
            // 
            // minigame
            // 
            minigame.AutoSize = true;
            minigame.BackColor = Color.Transparent;
            minigame.Font = new Font("Vaticanus", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            minigame.ForeColor = Color.FromArgb(135, 135, 163);
            minigame.Location = new Point(1152, 206);
            minigame.Name = "minigame";
            minigame.Size = new Size(119, 31);
            minigame.TabIndex = 7;
            minigame.Text = "       ";
            minigame.Click += minigame_Click;
            // 
            // Leaderboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.f_lead1;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(minigame);
            Controls.Add(Accuracy);
            Controls.Add(TypingSpeed);
            Controls.Add(MostStars);
            Controls.Add(lblByLevel);
            Controls.Add(lbl);
            Controls.Add(dgv1);
            Name = "Leaderboard";
            Size = new Size(1543, 991);
            ((System.ComponentModel.ISupportInitialize)dgv1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgv1;
        private Label lbl;
        private Label lblByLevel;
        private Label MostStars;
        private Label TypingSpeed;
        private Label Accuracy;
        private Label minigame;
    }
}
