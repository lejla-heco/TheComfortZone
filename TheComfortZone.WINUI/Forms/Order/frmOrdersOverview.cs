using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.DTO.Order;
using TheComfortZone.DTO.Utils;
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.Order
{
    public partial class frmOrdersOverview : Form
    {
        OrderAPIService orderAPIService = new OrderAPIService();
        private string USER_ROLE = Properties.Settings.Default.LoggedInUserType;
        private int USER_ID = Properties.Settings.Default.LoggedInUserId;
        private OrderResponse selectedRow = null;
        public frmOrdersOverview()
        {
            InitializeComponent();
            dgvOrders.AutoGenerateColumns = false;
        }

        private async void frmOrdersOverview_Load(object sender, EventArgs e)
        {
            await getGridData();
        }
        private async Task getGridData(OrderSearchRequest searchRequest = null)
        {
            List<OrderResponse> orders = new List<OrderResponse>();

            if (USER_ROLE == UserType.Employee.ToString())
                orders = await orderAPIService.GetOrdersByEmployeeId(USER_ID, searchRequest);
            if (USER_ROLE == UserType.Administrator.ToString())
                orders = await orderAPIService.Get(searchRequest);

            dgvOrders.DataSource = orders;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            OrderSearchRequest searchRequest = new OrderSearchRequest();
            searchRequest.OrderDate = dtpOrderDate.Value;
            btnClearSearch.Enabled = true;

            await getGridData(searchRequest);
        }

        private async void btnClearSearch_Click(object sender, EventArgs e)
        {
            dtpOrderDate.Value = DateTime.Now;
            btnClearSearch.Enabled = false;

            await getGridData();
        }

        private async void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedItem = dgvOrders.SelectedRows[0].DataBoundItem as OrderResponse;
            frmOrderDetails frm = new frmOrderDetails(selectedItem);
            if (frm.ShowDialog() == DialogResult.OK)
                await getGridData();
        }
    }
}
