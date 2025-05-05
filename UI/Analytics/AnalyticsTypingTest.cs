using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using LiveChartsCore;
using System;
using System.Windows.Forms;
using LiveChartsCore.SkiaSharpView.Painting;
using TypeRush_Final.Data;

namespace TypeRush_Final.UI.Analytics
{
    public partial class AnalyticsTypingTest : BaseControl
    {
        private DBAnalytics _analytics;
        private int _currentUserId;
        private CartesianChart wpmChart;
        private CartesianChart accuracyChart;
        private Label lblWpmTitle;
        private Label lblAccuracyTitle;
        private SubContainerForm form;
        private FormContainer container; 

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParams = base.CreateParams;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
        }

        public AnalyticsTypingTest(FormContainer container, int userId, SubContainerForm form)
        {
            InitializeComponent();
            this.container = container; 
            this.form = form; 
            _analytics = new DBAnalytics();
            _currentUserId = userId;
            lblWpmTitle = new Label
            {
                Text = "Average WPM by Difficulty Level",
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(10, 50)
            };
            this.Controls.Add(lblWpmTitle);

            lblAccuracyTitle = new Label
            {
                Text = "Average Accuracy by Difficulty Level",
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(10, 340)
            };
            this.Controls.Add(lblAccuracyTitle);

            this.Controls.Add(accuracyChart);

            SetupDefaultCharts();

            cbxChoice.SelectedIndexChanged += CbxChoice_SelectedIndexChanged;

            if (cbxChoice.Items.Count > 0)
                cbxChoice.SelectedIndex = 0;
            else
                LoadChartData(0);
        }

        private void SetupDefaultCharts()
        {
            var defaultSeries = new ColumnSeries<double>
            {
                Values = new[] { 0.0, 0.0, 0.0 },
                Fill = new SolidColorPaint(SKColors.Blue),
                Name = "Loading..."
            };

            WPMChart.Series = new ISeries[] { defaultSeries };
            WPMChart.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = new[] { "Easy", "Intermediate", "Hard" },
                    NamePaint = new SolidColorPaint(SKColors.Black),
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize = 12
                }
            };
            WPMChart.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Words Per Minute",
                    NamePaint = new SolidColorPaint(SKColors.Black),
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize = 12
                }
            };

            AccuracyChart.Series = new ISeries[] { defaultSeries };
            AccuracyChart.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = new[] { "Easy", "Intermediate", "Hard" },
                    NamePaint = new SolidColorPaint(SKColors.Black),
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize = 12
                }
            };
            AccuracyChart.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Accuracy (%)",
                    NamePaint = new SolidColorPaint(SKColors.Black),
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize = 12,
                    MinLimit = 0,
                    MaxLimit = 100
                }
            };
        }

        private void CbxChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedPeriod = cbxChoice.SelectedIndex;
            LoadChartData(selectedPeriod);
        }

        private void LoadChartData(int timePeriod)
        {
            try
            {
                _analytics.PopulateTypingTestCharts(WPMChart, AccuracyChart, _currentUserId, timePeriod);

                string periodText = "Today";
                switch (timePeriod)
                {
                    case 0:
                        periodText = "Today";
                        break;
                    case 1:
                        periodText = "This week";
                        break;
                    case 2:
                        periodText = "This month";
                        break;
                }

                lblWpmTitle.Text = $"Average WPM by Difficulty Level ({periodText})";
                lblAccuracyTitle.Text = $"Average Accuracy by Difficulty Level ({periodText})";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LBLMistakeOverview_Click(object sender, EventArgs e)
        {
            form.LoadUserControlIntoPanel(new AnalyticsMistakeOverviewcs(container, CurrentUser.UserID, form));
        }
    }
}