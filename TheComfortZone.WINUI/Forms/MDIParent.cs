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
using TheComfortZone.WINUI.Forms.FurnitureItem;
using TheComfortZone.WINUI.Forms.Order;
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
            if(userRole != null)
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
                        administrationToolStripMenuItem.Visible=true;
                        employeesToolStripMenuItem.Visible=true;
                        designersToolStripMenuItem.Visible=true;
                        collectionsToolStripMenuItem.Visible=true;
                        unitsOfMeasurementToolStripMenuItem.Visible=true;
                        furnitureOverviewToolStripMenuItem.Visible=true;
                        spacesToolStripMenuItem.Visible = true;
                        categoriesToolStripMenuItem.Visible=true;
                        ordersToolStripMenuItem.Visible = true;
                        appointmentsToolStripMenuItem.Visible=true;
                        discountCouponsToolStripMenuItem.Visible=true;
                        reportsToolStripMenuItem.Visible=true;
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

                frm.WindowState = FormWindowState.Maximized;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Dock = DockStyle.Fill;
                frm.ControlBox = false;

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
    }
}
