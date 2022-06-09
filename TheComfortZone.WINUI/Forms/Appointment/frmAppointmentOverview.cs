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
        public frmAppointmentOverview()
        {
            InitializeComponent();
            dgvAppointments.AutoGenerateColumns = false;
        }

        private async void frmAppointmentOverview_Load(object sender, EventArgs e)
        {
            await getGridData();
        }
        private async Task getGridData(AppointmentSearchRequest searchRequest = null)
        {
            List<AppointmentResponse> appointments = new List<AppointmentResponse>();

            if (USER_ROLE == UserType.Administrator.ToString())
                appointments = await appointmentAPIService.Get(searchRequest);
            if (USER_ROLE == UserType.Employee.ToString())
                appointments = await appointmentAPIService.GetAppointmentsByEmployeeId(USER_ID, searchRequest);

            dgvAppointments.DataSource = appointments;
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            AppointmentSearchRequest searchRequest = new AppointmentSearchRequest();
            searchRequest.AppointmentDate = dtpAppointmentDate.Value;
            btnClearSearch.Enabled = true;

            await getGridData(searchRequest);
        }

        private async void btnClearSearch_Click(object sender, EventArgs e)
        {
            dtpAppointmentDate.Value = DateTime.Now;
            btnClearSearch.Enabled = false;

            await getGridData();
        }

        private async void dgvAppointments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedRow = dgvAppointments.SelectedRows[0].DataBoundItem as AppointmentResponse;
            bool statusChanged = false;

            /** ACCEPTED CHANGED **/
            if (e.ColumnIndex == 6)
            {
                if (selectedRow.Approved == null) selectedRow.Approved = true;
                else selectedRow.Approved = !selectedRow.Approved;
                statusChanged = true;
            }
            /** DECLINED CHANGED **/
            if (e.ColumnIndex == 7)
            {
                if (selectedRow.Approved == null) selectedRow.Approved = false;
                else selectedRow.Approved = !selectedRow.Approved;
                statusChanged = true;
            }

            if (statusChanged)
            {
                AppointmentUpdateRequest update = new AppointmentUpdateRequest();
                update.Approved = selectedRow.Approved;
                var result = await appointmentAPIService.Put(selectedRow.AppointmentId, update);

                if (result != null)
                {
                    MessageBox.Show("Successfully updated appointment status!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await getGridData();
                }
            }
        }
    }
}
