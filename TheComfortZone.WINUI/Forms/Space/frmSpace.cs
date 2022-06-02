using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.DTO.Space;
using TheComfortZone.WINUI.Service;
using TheComfortZone.WINUI.Utils;

namespace TheComfortZone.WINUI.Forms.Space
{
    public partial class frmSpace : Form
    {
        SpaceAPIService spaceAPIService = new SpaceAPIService();
        private DTO.Space.SpaceResponse? selectedRow;
        private bool design = false;
        public frmSpace()
        {
            InitializeComponent();
            openFileDialog.Filter = "Image (*.jpg, *.png)|*.jpg; *.png|All (*.*)|*.*";
            dgvSpaces.AutoGenerateColumns = false;
        }

        private async void frmSpace_Load(object sender, EventArgs e)
        {
           await getGridData();
        }

        private async Task getGridData()
        {
            var spaces = await spaceAPIService.Get();
            dgvSpaces.DataSource = spaces;
        }

        private void dgvSpaces_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            selectedRow = dgvSpaces.SelectedRows[0].DataBoundItem as DTO.Space.SpaceResponse;
            design = true;
            loadRowData();
        }

        private void loadRowData()
        {
            txtName.Text = selectedRow.Name;
            txtDescription.Text = selectedRow.Description;
            pbImage.Image = ImageHelper.FromByteToImage(selectedRow.Image);
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK && ImageHelper.ValidateImageUpload(openFileDialog.FileName))
            {
                try
                {
                    var fileName = openFileDialog.FileName;
                    var file = File.ReadAllBytes(fileName);
                    var image = Image.FromFile(fileName);
                    pbImage.Image = image;
                }
                catch
                {
                    MessageBox.Show("Image upload size is too large, try uploading another image!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() && ImageHelper.ValidateImage(pbImage, errorProvider))
            {
                SpaceUpsertRequest upsert = new SpaceUpsertRequest();
                upsert.Name = txtName.Text;
                upsert.Description = txtDescription.Text;
                upsert.Image = ImageHelper.FromImageToByte(pbImage.Image);
                if (!design)
                {
                    var response = await spaceAPIService.Post(upsert);
                    await getGridData();
                    if (response != null)
                        MessageBox.Show("Successfully added data!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (design)
                {
                    var response = await spaceAPIService.Put(selectedRow.SpaceId, upsert);
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
            pbImage.Image = null;
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
