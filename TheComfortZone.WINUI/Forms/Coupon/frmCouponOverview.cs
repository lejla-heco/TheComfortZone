using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.DTO.Coupon;
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.Coupon
{
    public partial class frmCouponOverview : Form
    {
        CouponAPIService couponAPIService = new CouponAPIService();
        UserAPIService userAPIService = new UserAPIService();
        public frmCouponOverview()
        {
            InitializeComponent();
            dgvCoupons.AutoGenerateColumns = false;
        }

        private async void frmCouponOverview_Load(object sender, EventArgs e)
        {
            await loadCustomers();
            await getGridData();
        }

        private async Task loadCustomers()
        {
            var customers = await userAPIService.GetUsernames();
            cmbCustomers.DataSource = customers;
            cmbCustomers.ValueMember = "UserId";
            cmbCustomers.DisplayMember = "Username";
        }
        private async Task getGridData(CouponSearchRequest searchRequest = null)
        {
            var coupons = await couponAPIService.Get(searchRequest);
            dgvCoupons.DataSource = coupons;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            CouponSearchRequest searchRequest = new CouponSearchRequest();
            searchRequest.Username = cmbCustomers.Text;
            btnClearSearch.Enabled = true;

            await getGridData(searchRequest);
        }

        private async void btnClearSearch_Click(object sender, EventArgs e)
        {
            btnClearSearch.Enabled = false;
            cmbCustomers.SelectedIndex = 0;

            await getGridData();
        }
    }
}
