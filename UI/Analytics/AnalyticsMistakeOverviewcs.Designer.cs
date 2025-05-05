namespace TypeRush_Final.UI.Analytics
{
    partial class AnalyticsMistakeOverviewcs
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
            LBLMistakeOverview = new Label();
            lbl2 = new Label();
            cbxChoice = new ComboBox();
            barChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            ((System.ComponentModel.ISupportInitialize)pbxBackground).BeginInit();
            SuspendLayout();
            // 
            // pbxBackground
            // 
            pbxBackground.Dock = DockStyle.Fill;
            pbxBackground.Image = Properties.Resources.Analytic1;
            pbxBackground.Location = new Point(0, 0);
            pbxBackground.Name = "pbxBackground";
            pbxBackground.Size = new Size(1543, 991);
            pbxBackground.TabIndex = 0;
            pbxBackground.TabStop = false;
            // 
            // LBLMistakeOverview
            // 
            LBLMistakeOverview.AutoSize = true;
            LBLMistakeOverview.BackColor = Color.FromArgb(101, 73, 112);
            LBLMistakeOverview.Font = new Font("Vaticanus", 20F);
            LBLMistakeOverview.ForeColor = SystemColors.GradientActiveCaption;
            LBLMistakeOverview.Location = new Point(183, 165);
            LBLMistakeOverview.Name = "LBLMistakeOverview";
            LBLMistakeOverview.Size = new Size(289, 35);
            LBLMistakeOverview.TabIndex = 1;
            LBLMistakeOverview.Text = "Mistake Overview";
            // 
            // lbl2
            // 
            lbl2.AutoSize = true;
            lbl2.BackColor = Color.FromArgb(83, 61, 92);
            lbl2.Font = new Font("Vaticanus", 20F);
            lbl2.ForeColor = Color.FromArgb(135, 135, 163);
            lbl2.Location = new Point(574, 165);
            lbl2.Name = "lbl2";
            lbl2.Size = new Size(194, 35);
            lbl2.TabIndex = 3;
            lbl2.Text = "Typing Test";
            lbl2.Click += lbl2_Click;
            // 
            // cbxChoice
            // 
            cbxChoice.BackColor = Color.FromArgb(222, 160, 198);
            cbxChoice.FlatStyle = FlatStyle.Popup;
            cbxChoice.Font = new Font("monogram", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbxChoice.ForeColor = Color.FromArgb(124, 124, 124);
            cbxChoice.FormattingEnabled = true;
            cbxChoice.Items.AddRange(new object[] { "Today", "This week", "This month" });
            cbxChoice.Location = new Point(431, 348);
            cbxChoice.Name = "cbxChoice";
            cbxChoice.Size = new Size(278, 34);
            cbxChoice.TabIndex = 4;
            // 
            // barChart
            // 
            barChart.Location = new Point(431, 388);
            barChart.MatchAxesScreenDataRatio = false;
            barChart.Name = "barChart";
            barChart.Size = new Size(788, 406);
            barChart.TabIndex = 5;
            // 
            // AnalyticsMistakeOverviewcs
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(barChart);
            Controls.Add(cbxChoice);
            Controls.Add(lbl2);
            Controls.Add(LBLMistakeOverview);
            Controls.Add(pbxBackground);
            DoubleBuffered = true;
            Name = "AnalyticsMistakeOverviewcs";
            Size = new Size(1543, 991);
            ((System.ComponentModel.ISupportInitialize)pbxBackground).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxBackground;
        private Label LBLMistakeOverview;
        private Label lbl2;
        private ComboBox cbxChoice;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart barChart;
    }
}
