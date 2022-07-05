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
using TheComfortZone.DTO.Coupon;
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.Charts
{
    public partial class frmLoyalCustomers : Form
    {
        ChartAPIService chartAPIService = new ChartAPIService();
        CouponAPIService couponAPIService = new CouponAPIService();
        PieChartCustomerResponse selectedRow = null;
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
            if (pieValues != null && pieValues.Count > 0)
            {
                formsPlot.Plot.Clear();

                var pie = formsPlot.Plot.AddPie(pieValues.ToArray());
                pie.SliceLabels = sliceLabels.ToArray();
                pie.Explode = true;
                pie.DonutSize = .6;

                formsPlot.Plot.Legend(true, Alignment.LowerRight);
                formsPlot.Refresh();
            }
        }

        private void dgvLoyalCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = dgvLoyalCustomers.SelectedRows[0].DataBoundItem as PieChartCustomerResponse;
            btnDiscount.Enabled = true;
        }

        private async void btnDiscount_Click(object sender, EventArgs e)
        {
            CouponInsertRequest insert = new CouponInsertRequest();
            insert.UserId = selectedRow.UserId;
            insert.Discount = (int)nudDiscount.Value;

            var response = await couponAPIService.Post(insert);
            if (response != null)
            {
                MessageBox.Show("Successfully gifted discount coupon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }

            selectedRow = null;
            btnDiscount.Enabled = false;
        }
    }
}
