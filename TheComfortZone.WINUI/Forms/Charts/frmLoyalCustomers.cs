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
    public partial class frmLoyalCustomers : Form
    {
        ChartAPIService chartAPIService = new ChartAPIService();
        private List<double> pieValues = new List<double>();
        private List<string> sliceLabels = new List<string>();
        public frmLoyalCustomers()
        {
            InitializeComponent();
            formsPlot.Plot.Style(Style.Seaborn);
            dgvLoyalCustomers.AutoGenerateColumns = false;
            formsPlot.Plot.Title("Graphic representation of data");
        }

        private async void frmLoyalCustomers_Load(object sender, EventArgs e)
        {
            await getGridData();
        }

        private async Task getGridData()
        {
            var loyalCustomers = await chartAPIService.GetLoyalCustomers();
            dgvLoyalCustomers.DataSource = loyalCustomers;

            pieValues = loyalCustomers.Select(x => (double)x.AmountSpent).ToList();
            sliceLabels = loyalCustomers.Select(x => x.Customer).ToList();

            loadChartData();
        }

        private void loadChartData()
        {
            formsPlot.Plot.Clear();

            var pie = formsPlot.Plot.AddPie(pieValues.ToArray());
            pie.SliceLabels = sliceLabels.ToArray();
            pie.ShowPercentages = true;
            pie.Explode = true;
            pie.DonutSize = .6;

            formsPlot.Plot.Legend(true, Alignment.LowerRight);
            formsPlot.Refresh();
        }

    }
}
