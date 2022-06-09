using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.DTO.Utils;
using TheComfortZone.WINUI.Forms.Appointment;
using TheComfortZone.WINUI.Forms.Category;
using TheComfortZone.WINUI.Forms.Charts;
using TheComfortZone.WINUI.Forms.Collection;
using TheComfortZone.WINUI.Forms.Coupon;
using TheComfortZone.WINUI.Forms.Designer;
using TheComfortZone.WINUI.Forms.Employee;
using TheComfortZone.WINUI.Forms.FurnitureItem;
using TheComfortZone.WINUI.Forms.HomePage;
using TheComfortZone.WINUI.Forms.MetricUnit;
using TheComfortZone.WINUI.Forms.Order;
using TheComfortZone.WINUI.Forms.Space;
using TheComfortZone.WINUI.Properties;

namespace TheComfortZone.WINUI.Forms
{
    public partial class MDIParent : Form
    {
        private readonly UserType? LoggedInUserType = null;
        public MDIParent()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            string userRole = Settings.Default.LoggedInUserType;
            if (userRole != null)
            {
                switch (userRole)
                {
                    case "Administrator":
                        LoggedInUserType = UserType.Administrator;
                        break;
                    case "Employee":
                        LoggedInUserType = UserType.Employee;
                        break;
                    case "User":
                        LoggedInUserType = UserType.User;
                        break;
                }
            }
            else
            {
                MessageBox.Show("An error occurred while logging in", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MDIParent_Load(object sender, EventArgs e)
        {
            administrationToolStripMenuItem.Visible = false;
            employeesToolStripMenuItem.Visible = false;
            designersToolStripMenuItem.Visible = false;
            collectionsToolStripMenuItem.Visible = false;
            unitsOfMeasurementToolStripMenuItem.Visible = false;
            furnitureOverviewToolStripMenuItem.Visible = false;
            spacesToolStripMenuItem.Visible = false;
            categoriesToolStripMenuItem.Visible = false;
            ordersToolStripMenuItem.Visible = false;
            appointmentsToolStripMenuItem.Visible = false;
            discountCouponsToolStripMenuItem.Visible = false;
            reportsToolStripMenuItem.Visible = false;

            if (LoggedInUserType.HasValue)
            {
                switch (LoggedInUserType.Value)
                {
                    case UserType.Administrator:
                        administrationToolStripMenuItem.Visible = true;
                        employeesToolStripMenuItem.Visible = true;
                        designersToolStripMenuItem.Visible = true;
                        collectionsToolStripMenuItem.Visible = true;
                        unitsOfMeasurementToolStripMenuItem.Visible = true;
                        furnitureOverviewToolStripMenuItem.Visible = true;
                        spacesToolStripMenuItem.Visible = true;
                        categoriesToolStripMenuItem.Visible = true;
                        ordersToolStripMenuItem.Visible = true;
                        appointmentsToolStripMenuItem.Visible = true;
                        discountCouponsToolStripMenuItem.Visible = true;
                        reportsToolStripMenuItem.Visible = true;
                        break;
                    case UserType.Employee:
                        furnitureOverviewToolStripMenuItem.Visible = true;
                        spacesToolStripMenuItem.Visible = true;
                        categoriesToolStripMenuItem.Visible = true;
                        ordersToolStripMenuItem.Visible = true;
                        appointmentsToolStripMenuItem.Visible = true;
                        toolStripSeparator5.Visible = false;
                        toolStripSeparator9.Visible = false;
                        toolStripSeparator10.Visible = false;
                        toolStripSeparator11.Visible = false;
                        break;
                }
            }

            frmHomePage frm = new frmHomePage();
            OpenForm(frm);
        }

        private void OpenForm(Form frm)
        {
            if (!MdiChildren.Select(f => f.Name).Contains(frm.Name))
            {
                foreach (Form childForm in MdiChildren)
                {
                    childForm.Close();
                }

                frm.MdiParent = this;

                frm.ControlBox = false;
                frm.WindowState = FormWindowState.Maximized;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;

                frm.Show();
            }
        }

        private void furnitureOverviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFurnitureOverview frm = new frmFurnitureOverview();
            OpenForm(frm);
        }

        private void ordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrdersOverview frm = new frmOrdersOverview();
            OpenForm(frm);
        }

        private void spacesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSpace frm = new frmSpace();
            OpenForm(frm);
        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCategory frm = new frmCategory();
            OpenForm(frm);
        }

        private void designersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDesigner frm = new frmDesigner();
            OpenForm(frm);
        }

        private void collectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCollection frm = new frmCollection();
            OpenForm(frm);
        }

        private void unitsOfMeasurementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMetricUnit frm = new frmMetricUnit();
            OpenForm(frm);
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEmployeeOverview frm = new frmEmployeeOverview();
            OpenForm(frm);
        }
        private void appointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAppointmentOverview frm = new frmAppointmentOverview();
            OpenForm(frm);
        }

        private void discountCouponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCouponOverview frm = new frmCouponOverview();
            OpenForm(frm);
        }

        private void top10BestSellingProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTop10FP frm = new frmTop10FP();
            OpenForm(frm);
        }

        private void salesInACertainPeriodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSales frm = new frmSales();
            OpenForm(frm);
        }

        private void incomePerEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRevenue frm = new frmRevenue();
            OpenForm(frm);
        }

        private void top10MostLoyalCustomersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLoyalCustomers frm = new frmLoyalCustomers();
            OpenForm(frm);
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Restart();
        }
    }
}
