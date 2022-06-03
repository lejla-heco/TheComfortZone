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
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.Employee
{
    public partial class frmEmployee : Form
    {
        UserAPIService userAPIService = new UserAPIService();
        private const string EMPLOYEE_ROLE = "Employee";
        private UserSearchRequest searchRequest = new UserSearchRequest();
        public frmEmployee()
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
    }
}
