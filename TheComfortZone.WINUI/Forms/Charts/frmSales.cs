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
    public partial class frmSales : Form
    {
        ChartAPIService chartAPIService = new ChartAPIService();
        public frmSales()
        {
            InitializeComponent();
            dgvSales.AutoGenerateColumns = false;
        }

        private async void frmSales_Load(object sender, EventArgs e)
        {
            await getGridData(null);
        }

        private async Task getGridData(DateRangeSearchRequest search = null)
        {
            var sales = await chartAPIService.GetSalesByPeriod(search);
            dgvSales.DataSource = sales;
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
