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
using TheComfortZone.DTO.OrderItem;
using TheComfortZone.DTO.Utils;
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.Order
{
    public partial class frmOrderDetails : Form
    {
        OrderItemAPIService orderItemAPIService = new OrderItemAPIService();
        private OrderResponse order;
        private OrderItemSearchRequest searchRequest = new OrderItemSearchRequest();
        public frmOrderDetails(OrderResponse order)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            dgvOrderItems.AutoGenerateColumns = false;
            this.order = order;
            searchRequest.OrderId = order.OrderId;
        }

        private async void frmOrderDetails_Load(object sender, EventArgs e)
        {
            loadOrderStatus();
            loadCustomerInfo();
            loadFooterInfo();
            await getGridData();
        }

        private void loadCustomerInfo()
        {
            txtCustomer.Text = order.Customer;
            txtAdress.Text = order.Adress;
            txtPhoneNumber.Text = order.PhoneNumber;
            var discount = order.Discount == null ? 0 : order.Discount;
            txtDiscount.Text = $"{discount}%";
        }

        private void loadFooterInfo()
        {
            lblTotalPrice.Text = order.TotalPrice.ToString();
            cmbOrderStatus.SelectedIndex = cmbOrderStatus.FindStringExact(order.Status);
        }

        private void loadOrderStatus()
        {
            var orderStatus = Enum.GetValues(typeof(OrderStatus));
            cmbOrderStatus.DataSource = orderStatus;
        }
        private async Task getGridData()
        {
            var orderItems = await orderItemAPIService.Get(searchRequest);
            dgvOrderItems.DataSource = orderItems;
        }
    }
}
