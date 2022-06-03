using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.DTO.Category;
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.Category
{
    public partial class frmCategory : Form
    {
        SpaceAPIService spaceAPIService = new SpaceAPIService();
        private CategoryAPIService categoryAPIService = new CategoryAPIService();
        private DTO.Category.CategoryResponse? selectedRow;
        private bool design = false;

        public frmCategory()
        {
            InitializeComponent();
            dgvCategories.AutoGenerateColumns = false;
        }

        private async void frmCategory_Load(object sender, EventArgs e)
        {
            await getGridData();
            await loadSpaces();
        }

        private async Task loadSpaces()
        {
            var spaces = await spaceAPIService.Get();
            cmbSpace.DataSource = spaces;
            cmbSpace.DisplayMember = "Name";
            cmbSpace.ValueMember = "SpaceId";
        }

        private async Task getGridData()
        {
            var categories = await categoryAPIService.Get();
            dgvCategories.DataSource = categories;
        }

        private void dgvCategories_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = dgvCategories.SelectedRows[0].DataBoundItem as DTO.Category.CategoryResponse;
            design = true;
            loadRowData();
        }
        private void loadRowData()
        {
            txtName.Text = selectedRow.Name;
            txtDescription.Text = selectedRow.Description;
            cmbSpace.SelectedIndex = ((List<DTO.Space.SpaceResponse>)cmbSpace.DataSource).FindIndex(s => s.SpaceId == selectedRow.SpaceId);
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                CategoryUpsertRequest upsert = new CategoryUpsertRequest();
                upsert.Name = txtName.Text;
                upsert.Description = txtDescription.Text;
                upsert.SpaceId = ((DTO.Space.SpaceResponse)cmbSpace.SelectedItem).SpaceId;
                if (!design)
                {
                    var response = await categoryAPIService.Post(upsert);
                    await getGridData();
                    if (response != null)
                        MessageBox.Show("Successfully added data!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (design)
                {
                    var response = await categoryAPIService.Put(selectedRow.CategoryId, upsert);
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
            cmbSpace.SelectedIndex = -1;
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

        private void cmbSpace_Validating(object sender, CancelEventArgs e)
        {
            if (cmbSpace.SelectedIndex == -1)
            {
                e.Cancel = true;
                cmbSpace.Focus();
                errorProvider.SetError(cmbSpace, "Space field cannot be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbSpace, null);
            }
        }
    }
}
