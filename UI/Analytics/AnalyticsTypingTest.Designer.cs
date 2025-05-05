namespace TypeRush_Final.UI.Analytics
{
    partial class AnalyticsTypingTest
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
            label1 = new Label();
            WPMChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            AccuracyChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            cbxChoice = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pbxBackground).BeginInit();
            SuspendLayout();
            // 
            // pbxBackground
            // 
            pbxBackground.Dock = DockStyle.Fill;
            pbxBackground.Image = Properties.Resources.Analytics2;
            pbxBackground.Location = new Point(0, 0);
            pbxBackground.Name = "pbxBackground";
            pbxBackground.Size = new Size(1543, 991);
            pbxBackground.TabIndex = 0;
            pbxBackground.TabStop = false;
            // 
            // LBLMistakeOverview
            // 
            LBLMistakeOverview.AutoSize = true;
            LBLMistakeOverview.BackColor = Color.FromArgb(83, 61, 92);
            LBLMistakeOverview.Font = new Font("Vaticanus", 20F);
            LBLMistakeOverview.ForeColor = Color.FromArgb(135, 135, 163);
            LBLMistakeOverview.Location = new Point(175, 168);
            LBLMistakeOverview.Name = "LBLMistakeOverview";
            LBLMistakeOverview.Size = new Size(289, 35);
            LBLMistakeOverview.TabIndex = 2;
            LBLMistakeOverview.Text = "Mistake Overview";
            LBLMistakeOverview.Click += LBLMistakeOverview_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(101, 73, 112);
            label1.Font = new Font("Vaticanus", 20F);
            label1.ForeColor = SystemColors.GradientActiveCaption;
            label1.Location = new Point(575, 168);
            label1.Name = "label1";
            label1.Size = new Size(194, 35);
            label1.TabIndex = 3;
            label1.Text = "Typing Test";
            // 
            // WPMChart
            // 
            WPMChart.Location = new Point(789, 382);
            WPMChart.MatchAxesScreenDataRatio = false;
            WPMChart.Name = "WPMChart";
            WPMChart.Size = new Size(532, 460);
            WPMChart.TabIndex = 5;
            // 
            // AccuracyChart
            // 
            AccuracyChart.Location = new Point(237, 382);
            AccuracyChart.MatchAxesScreenDataRatio = false;
            AccuracyChart.Name = "AccuracyChart";
            AccuracyChart.Size = new Size(532, 460);
            AccuracyChart.TabIndex = 6;
            // 
            // cbxChoice
            // 
            cbxChoice.BackColor = Color.FromArgb(222, 160, 198);
            cbxChoice.FlatStyle = FlatStyle.Popup;
            cbxChoice.Font = new Font("monogram", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cbxChoice.ForeColor = Color.FromArgb(124, 124, 124);
            cbxChoice.FormattingEnabled = true;
            cbxChoice.Items.AddRange(new object[] { "Today", "This week", "This month" });
            cbxChoice.Location = new Point(237, 323);
            cbxChoice.Name = "cbxChoice";
            cbxChoice.Size = new Size(278, 34);
            cbxChoice.TabIndex = 7;
            // 
            // AnalyticsTypingTest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cbxChoice);
            Controls.Add(AccuracyChart);
            Controls.Add(WPMChart);
            Controls.Add(label1);
            Controls.Add(LBLMistakeOverview);
            Controls.Add(pbxBackground);
            DoubleBuffered = true;
            Name = "AnalyticsTypingTest";
            Size = new Size(1543, 991);
            ((System.ComponentModel.ISupportInitialize)pbxBackground).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxBackground;
        private Label LBLMistakeOverview;
        private Label label1;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart WPMChart;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart AccuracyChart;
        private ComboBox cbxChoice;
    }
}
