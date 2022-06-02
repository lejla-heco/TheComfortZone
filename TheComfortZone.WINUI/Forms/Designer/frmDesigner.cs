using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.DTO.Designer;
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.Designer
{
    public partial class frmDesigner : Form
    {
        DesignerAPIService designerAPIService = new DesignerAPIService();
        private DTO.Designer.DesignerResponse? selectedRow;
        private bool design = false;
        public frmDesigner()
        {
            InitializeComponent();
            dgvDesigners.AutoGenerateColumns = false;
            nudConsultationPrice.Minimum = 10;
            nudConsultationPrice.Maximum = 750;
        }

        private async void frmDesigner_Load(object sender, EventArgs e)
        {
            await getGridData();
        }

        private async Task getGridData()
        {
            var designers = await designerAPIService.Get();
            dgvDesigners.DataSource = designers;
        }

        private void dgvDesigners_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = dgvDesigners.SelectedRows[0].DataBoundItem as DTO.Designer.DesignerResponse;
            design = true;
            loadRowData();
        }
        private void loadRowData()
        {
            txtName.Text = selectedRow.Name;
            nudConsultationPrice.Value = (decimal)selectedRow.ConsultationPrice;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                DesignerUpsertRequest upsert = new DesignerUpsertRequest();
                upsert.Name = txtName.Text;
                upsert.ConsultationPrice = (float)nudConsultationPrice.Value;
                if (!design)
                {
                    var response = await designerAPIService.Post(upsert);
                    await getGridData();
                    if (response != null)
                        MessageBox.Show("Successfully added data!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (design)
                {
                    var response = await designerAPIService.Put(selectedRow.DesignerId, upsert);
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
            nudConsultationPrice.Value = 10;
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
