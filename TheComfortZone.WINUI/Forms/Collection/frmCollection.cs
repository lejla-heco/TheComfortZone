using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.DTO.Collection;
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.Collection
{
    public partial class frmCollection : Form
    {
        DesignerAPIService designerAPIService = new DesignerAPIService();
        CollectionAPIService collectionAPIService = new CollectionAPIService();
        private DTO.Collection.CollectionResponse? selectedRow;
        private bool design = false;
        public frmCollection()
        {
            InitializeComponent();
            dgvCollections.AutoGenerateColumns = false;
        }

        private async void frmCollection_Load(object sender, EventArgs e)
        {
            await getGridData();
            await loadDesigners();
        }

        private async Task loadDesigners()
        {
            var designers = await designerAPIService.Get();
            cmbDesigner.DataSource = designers;
            cmbDesigner.DisplayMember = "Name";
            cmbDesigner.ValueMember = "DesignerId";
        }

        private async Task getGridData()
        {
            var collections = await collectionAPIService.Get();
            dgvCollections.DataSource = collections;
        }

        private void dgvCollections_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = dgvCollections.SelectedRows[0].DataBoundItem as DTO.Collection.CollectionResponse;
            design = true;
            loadRowData();
        }
        private void loadRowData()
        {
            txtName.Text = selectedRow.Name;
            cmbDesigner.SelectedIndex = ((List<DTO.Designer.DesignerResponse>)cmbDesigner.DataSource).FindIndex(d => d.DesignerId == selectedRow.DesignerId);
            dtpCreated.Value = (DateTime)selectedRow.Created;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                CollectionUpsertRequest upsert = new CollectionUpsertRequest();
                upsert.Name = txtName.Text;
                upsert.Created = dtpCreated.Value;
                upsert.DesignerId = ((DTO.Designer.DesignerResponse)cmbDesigner.SelectedItem).DesignerId;
                if (!design)
                {
                    var response = await collectionAPIService.Post(upsert);
                    await getGridData();
                    if (response != null)
                        MessageBox.Show("Successfully added data!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (design)
                {
                    var response = await collectionAPIService.Put(selectedRow.CollectionId, upsert);
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
            dtpCreated.Value = DateTime.Now;
            cmbDesigner.SelectedIndex = -1;
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

        private void cmbDesigner_Validating(object sender, CancelEventArgs e)
        {
            if (cmbDesigner.SelectedIndex == -1)
            {
                e.Cancel = true;
                cmbDesigner.Focus();
                errorProvider.SetError(cmbDesigner, "Designer field cannot be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbDesigner, null);
            }
        }
    }
}
