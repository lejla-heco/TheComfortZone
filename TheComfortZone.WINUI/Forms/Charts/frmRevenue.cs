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
using TheComfortZone.DTO.Charts;
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.Charts
{
    public partial class frmRevenue : Form
    {
        ChartAPIService chartAPIService = new ChartAPIService();
        private List<double> pieValues = new List<double>();
        private List<string> sliceLabels = new List<string>();
        public frmRevenue()
        {
            InitializeComponent();
            dgvIncome.AutoGenerateColumns = false;
            formsPlot.Plot.Style(Style.Seaborn);
            formsPlot.Plot.Title("Graphic representation of data");
        }

        private async void frmIncome_Load(object sender, EventArgs e)
        {
            await getGridData(null);
        }

        private async Task getGridData(DateRangeSearchRequest search = null)
        {
            var income = await chartAPIService.GetIncomePerEmployee(search);
            dgvIncome.DataSource = income;

            pieValues = income.Select(x => (double)x.Income).ToList();
            sliceLabels = income.Select(x => x.Employee).ToList();

            loadChartData();
        }

        private void loadChartData()
        {
            formsPlot.Plot.Clear();

            var pie = formsPlot.Plot.AddPie(pieValues.ToArray());
            pie.SliceLabels = sliceLabels.ToArray();
            pie.Explode = true;

            formsPlot.Plot.Legend(true, Alignment.LowerRight);
            formsPlot.Refresh();
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            DateRangeSearchRequest search = new DateRangeSearchRequest();
            search.FromDate = dtpFromDate.Value.Date;
            search.ToDate = dtpToDate.Value.Date;
            if (search.FromDate.Value.Date.CompareTo(search.ToDate.Value.Date) <= 0)
            {
                await getGridData(search);
                btnClearSearch.Enabled = true;
            }
            else MessageBox.Show("Start date must be earlier than end date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private async void btnClearSearch_Click(object sender, EventArgs e)
        {
            btnClearSearch.Enabled = false;
            await getGridData(null);
        }
    }
}
