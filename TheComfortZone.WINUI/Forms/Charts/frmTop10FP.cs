using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.Charts
{
    public partial class frmTop10FP : Form
    {
        FurnitureItemAPIService furnitureItemAPIService = new FurnitureItemAPIService();
        SpaceAPIService spaceAPIService = new SpaceAPIService();
        List<DTO.Charts.LineChartListResponse> chartData = new List<DTO.Charts.LineChartListResponse>();
        public frmTop10FP()
        {
            InitializeComponent();
            formsPlot.Plot.XLabel("Months");
            formsPlot.Plot.YLabel("Number of units sold");
            formsPlot.Plot.SetAxisLimitsX(1, 12);
            formsPlot.Plot.Style(Style.Blue1);
        }

        private async void frmTop10FP_Load(object sender, EventArgs e)
        {
            await loadSpaces();
        }

        private async Task loadSpaces()
        {
            var spaces = await spaceAPIService.Get();
            cmbSpace.DataSource = spaces;
            cmbSpace.DisplayMember = "Name";
            cmbSpace.ValueMember = "SpaceId";
            await loadChartData();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            await loadChartData();
        }

        private async Task loadChartData()
        {
            string space = cmbSpace.Text;
            chartData = await furnitureItemAPIService.GetLineChartData(space);

            formsPlot.Plot.Clear();
            for (int i = 0; i < chartData.Count; i++)
            {
                var xAxis = chartData[i].ChartData.Select(x => (double)x.XValue).ToArray();
                var yAxis = chartData[i].ChartData.Select(y => (double)y.YValue).ToArray();
                var scatter = formsPlot.Plot.AddScatter(xAxis, yAxis, label: chartData[i].FurnitureName);
                scatter.MarkerSize = 10;
            }

            formsPlot.Plot.Legend(true, Alignment.UpperRight);
            formsPlot.Refresh();
        }
    }
}
