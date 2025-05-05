using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView;
using SkiaSharp;
using LiveChartsCore;
using System;
using System.Linq;
using System.Windows.Forms;
using LiveChartsCore.Defaults;
using LiveChartsCore.Drawing;
using LiveChartsCore.SkiaSharpView.Painting;
using TypeRush_Final.Data;

namespace TypeRush_Final.UI.Analytics
{
    public partial class AnalyticsMistakeOverviewcs : BaseControl
    {
        private FormContainer fcontainer;
        private DBAnalytics _analytics;
        private int _currentUserId;
        private Label lblTitle;
        private SubContainerForm subContainerForm;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParams = base.CreateParams;
                handleParams.ExStyle |= 0x02000000;
                return handleParams;
            }
        }

        public AnalyticsMistakeOverviewcs(FormContainer fcontainer, int userId, SubContainerForm form)
        {
            InitializeComponent();
            this.fcontainer = fcontainer;
            subContainerForm = form;
            _analytics = new DBAnalytics();
            _currentUserId = userId;


            lblTitle = new Label
            {
                Text = "Top 10 Mistyped Characters",
                Font = new System.Drawing.Font("Segoe UI", 12, System.Drawing.FontStyle.Bold),
                AutoSize = true,
                Location = new System.Drawing.Point(10, 10)
            };
            this.Controls.Add(lblTitle);

                     SetupDefaultChart();

            cbxChoice.SelectedIndexChanged += CbxChoice_SelectedIndexChanged;

            if (cbxChoice.Items.Count > 0)
                cbxChoice.SelectedIndex = 0;
            else
               LoadChartData(0); 
        }

        private void SetupDefaultChart()
        {
            var barSeries = new RowSeries<int>
            {
                Values = new[] { 0 },
                Fill = new SolidColorPaint(SKColors.Blue),
                Stroke = null,
                MaxBarWidth = double.MaxValue,
                DataLabelsSize = 14,
                DataLabelsPaint = new SolidColorPaint(SKColors.White),
                DataLabelsPosition = LiveChartsCore.Measure.DataLabelsPosition.End,
                Name = "Mistype Frequency"
            };

            barChart.Series = new ISeries[] { barSeries };

            barChart.XAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Frequency",
                    NamePaint = new SolidColorPaint(SKColors.Black),
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize = 12
                }
            };

            barChart.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Mistyped Characters",
                    Labels = new[] { "Loading..." },
                    NamePaint = new SolidColorPaint(SKColors.Black),
                    LabelsPaint = new SolidColorPaint(SKColors.Black),
                    TextSize = 12
                }
            };

            barChart.LegendPosition = LiveChartsCore.Measure.LegendPosition.Right;
            barChart.LegendTextPaint = new SolidColorPaint(SKColors.Black);
            barChart.LegendTextSize = 11;
            barChart.LegendBackgroundPaint = new SolidColorPaint(SKColors.LightGray.WithAlpha(100));
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
                _analytics.PopulateMistypeChart(barChart, _currentUserId, timePeriod, 5);

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

                lblTitle.Text = $"Top 10 Mistyped Characters ({periodText})";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lbl2_Click(object sender, EventArgs e)
        {
            subContainerForm.LoadUserControlIntoPanel(new AnalyticsTypingTest(fcontainer, CurrentUser.UserID, subContainerForm));
        }
    }
}