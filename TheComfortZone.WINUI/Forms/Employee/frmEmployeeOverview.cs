using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.DTO.User;
using TheComfortZone.DTO.Utils;
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.Employee
{
    public partial class frmEmployeeOverview : Form
    {
        UserAPIService userAPIService = new UserAPIService();
        private string EMPLOYEE_ROLE = UserType.Employee.ToString();
        private UserSearchRequest searchRequest = new UserSearchRequest();
        private UserResponse selectedRow = null;
        public frmEmployeeOverview()
        {
            InitializeComponent();
            dgvEmployees.AutoGenerateColumns = false;
            searchRequest.RoleName = EMPLOYEE_ROLE;
        }

        private async void frmEmployee_Load(object sender, EventArgs e)
        {
            await getGridData();
        }

        private async Task getGridData()
        {
            var employees = await userAPIService.Get(searchRequest);
            dgvEmployees.DataSource = employees;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            searchRequest.Username = txtUsername.Text;
            await getGridData();
        }

        private async void btnNewEmployee_Click(object sender, EventArgs e)
        {
            frmEmployeeAddEdit frm = new frmEmployeeAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await getGridData();
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            selectedRow = dgvEmployees.SelectedRows[0].DataBoundItem as DTO.User.UserResponse;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Are you sure you want to delete selected employee?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (selectedRow != null && confirmation == DialogResult.Yes)
            {
                string response = await userAPIService.Delete(selectedRow.UserId);
                if (!string.IsNullOrWhiteSpace(response))
                {
                    MessageBox.Show(response, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    getGridData();
                }
            }

            selectedRow = null;
            btnDelete.Enabled = false;
        }

        private void dgvEmployees_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedItem = dgvEmployees.SelectedRows[0].DataBoundItem as UserResponse;
            frmEmployeeAddEdit frm = new frmEmployeeAddEdit(selectedItem);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                getGridData();
            }
        }
    }
}
