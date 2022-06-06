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
        public frmCouponOverview()
        {
            InitializeComponent();
            dgvCoupons.AutoGenerateColumns = false;
        }

        private async void frmCouponOverview_Load(object sender, EventArgs e)
        {
            await getGridData();
        }
        private async Task getGridData(CouponSearchRequest searchRequest = null)
        {
            var coupons = await couponAPIService.Get(searchRequest);
            dgvCoupons.DataSource = coupons;
        }
    }
}
