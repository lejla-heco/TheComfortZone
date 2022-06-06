using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.DTO.Appointment;
using TheComfortZone.DTO.Utils;
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.Appointment
{
    public partial class frmAppointmentOverview : Form
    {
        AppointmentAPIService appointmentAPIService = new AppointmentAPIService();
        private string USER_ROLE = Properties.Settings.Default.LoggedInUserType;
        private int USER_ID = Properties.Settings.Default.LoggedInUserId;
        private AppointmentSearchRequest searchRequest = new AppointmentSearchRequest();
        public frmAppointmentOverview()
        {
            InitializeComponent();
            dgvAppointments.AutoGenerateColumns = false;
        }

        private async void frmAppointmentOverview_Load(object sender, EventArgs e)
        {
            await getGridData();
        }
        private async Task getGridData()
        {
            if (USER_ROLE == UserType.Employee.ToString())
                searchRequest.EmployeeId = USER_ID;

            var appointments = await appointmentAPIService.Get(searchRequest);
            dgvAppointments.DataSource = appointments;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            searchRequest.AppointmentDate = dtpAppointmentDate.Value;
            btnClearSearch.Enabled = true;

            await getGridData();
        }

        private async void btnClearSearch_Click(object sender, EventArgs e)
        {
            searchRequest.AppointmentDate = null;
            dtpAppointmentDate.Value = DateTime.Now;
            btnClearSearch.Enabled = false;

            await getGridData();
        }
    }
}
