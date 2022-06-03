using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.DTO.MetricUnit;
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.MetricUnit
{
    public partial class frmMetricUnit : Form
    {
        MetricUnitAPIService metricUnitAPIService = new MetricUnitAPIService();
        private DTO.MetricUnit.MetricUnitResponse? selectedRow;
        private bool design = false;
        public frmMetricUnit()
        {
            InitializeComponent();
            dgvMetricUnits.AutoGenerateColumns = false;
        }

        private async void frmMetricUnit_Load(object sender, EventArgs e)
        {
            await getGridData();
        }

        private async Task getGridData()
        {
            var metricUnits = await metricUnitAPIService.Get();
            dgvMetricUnits.DataSource = metricUnits;
        }

        private void dgvMetricUnits_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = dgvMetricUnits.SelectedRows[0].DataBoundItem as DTO.MetricUnit.MetricUnitResponse;
            design = true;
            loadRowData();
        }

        private void loadRowData()
        {
            txtName.Text = selectedRow.Name;
            txtDescription.Text = selectedRow.Description;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                MetricUnitUpsertRequest upsert = new MetricUnitUpsertRequest();
                upsert.Name = txtName.Text;
                upsert.Description = txtDescription.Text;
                if (!design)
                {
                    var response = await metricUnitAPIService.Post(upsert);
                    await getGridData();
                    if (response != null)
                        MessageBox.Show("Successfully added data!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (design)
                {
                    var response = await metricUnitAPIService.Put(selectedRow.MetricUnitId, upsert);
                    await getGridData();
                    if (response != null)
                        MessageBox.Show("Successfully updated data!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                clearForm();
            }
        }

        private void clearForm()
        {
            if (design)
            {
                design = false;
                selectedRow = null;
            }
            txtName.Text = null;
            txtDescription.Text = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        /** VALIDATION **/
        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                e.Cancel = true;
                txtName.Focus();
                errorProvider.SetError(txtName, "Name field cannot be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtName, null);
            }
        }
    }
}
