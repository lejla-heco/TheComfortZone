using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.DTO.FurnitureItem;
using TheComfortZone.DTO.Utils;
using TheComfortZone.WINUI.Service;
using TheComfortZone.WINUI.Utils;

namespace TheComfortZone.WINUI.Forms.FurnitureItem
{
    public partial class frmFurnitureItemAddEdit : Form
    {
        SpaceAPIService spaceAPIService = new SpaceAPIService();
        CategoryAPIService categoryAPIService = new CategoryAPIService();
        DesignerAPIService designerAPIService = new DesignerAPIService();
        CollectionAPIService collectionAPIService = new CollectionAPIService();
        MetricUnitAPIService metricUnitAPIService = new MetricUnitAPIService();
        MaterialAPIService materialAPIService = new MaterialAPIService();
        ColorAPIService colorAPIService = new ColorAPIService();
        FurnitureItemAPIService furnitureItemAPIService = new FurnitureItemAPIService();

        private FurnitureItemResponse? furnitureItem;
        private bool design = false;
        public frmFurnitureItemAddEdit(FurnitureItemResponse furnitureItem = null)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterParent;
            openFileDialog.Filter = "Image (*.jpg, *.png)|*.jpg; *.png|All (*.*)|*.*";
            this.furnitureItem = furnitureItem;
            design = this.furnitureItem == null ? false : true;
        }

        private void frmFurnitureItemAddEdit_Load(object sender, EventArgs e)
        {
            loadSpaces();
            loadDesigners();
            loadMetricUnits();
            loadMaterials();
            loadColors();
            loadStates();
        }

        private async void loadSpaces()
        {
            var spaces = await spaceAPIService.GetSpacesWithCateroryData();
            if (spaces.Count != 0) loadCategories(spaces[0].SpaceId);
            cmbSpace.DataSource = spaces;
            cmbSpace.DisplayMember = "Name";
            cmbSpace.ValueMember = "SpaceId";
        }

        private async void loadCategories(int spaceId)
        {
            var categories = await categoryAPIService.GetCategoriesBySpaceId(spaceId);
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "CategoryId";
        }

        private async void loadDesigners()
        {
            var designers = await designerAPIService.GetDesignersWithCollectionData();
            if (designers.Count != 0) loadCollections(designers[0].DesignerId);
            cmbDesigner.DataSource = designers;
            cmbDesigner.DisplayMember = "Name";
            cmbDesigner.ValueMember = "DesignerId";
        }

        private async void loadCollections(int designerId)
        {
            var collections = await collectionAPIService.GetCollectionsByDesignerId(designerId);
            cmbCollection.DataSource = collections;
            cmbCollection.DisplayMember = "Name";
            cmbCollection.ValueMember = "CollectionId";
        }

        private void cmbSpace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSpace.SelectedIndex != -1 && int.TryParse(cmbSpace.SelectedValue.ToString(), out int spaceId))
            {
                loadCategories(spaceId);
            }
        }

        private void cmbDesigner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDesigner.SelectedIndex <= -1 && int.TryParse(cmbDesigner.SelectedValue.ToString(), out int designerId))
            {
                    loadCollections(designerId);
            }
        }

        private void loadComboBoxMetricUnitData(ComboBox comboBox, List<DTO.MetricUnit.MetricUnitResponse> data,
            string displayMember, string valueMember)
        {
            comboBox.DataSource = data;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }

        private async void loadMetricUnitsISQ()
        {
            var metricUnits = await metricUnitAPIService.Get();
            loadComboBoxMetricUnitData(cmbMetricUnitISQ, metricUnits, "Name", "MetricUnitId");
        }

        private async void loadMetricUnitsH()
        {
            var metricUnits = await metricUnitAPIService.Get();
            loadComboBoxMetricUnitData(cmbMetricUnitH, metricUnits, "Name", "MetricUnitId");
        }

        private async void loadMetricUnitsW()
        {
            var metricUnits = await metricUnitAPIService.Get();
            loadComboBoxMetricUnitData(cmbMetricUnitW, metricUnits, "Name", "MetricUnitId");
        }

        private async void loadMetricUnits()
        {
            var metricUnits = await metricUnitAPIService.Get();
            loadMetricUnitsISQ();
            loadMetricUnitsH();
            loadMetricUnitsW();
        }

        private async void loadMaterials()
        {
            var materials = await materialAPIService.Get();
            cmbMaterial.DataSource = materials;
            cmbMaterial.DisplayMember = "Name";
            cmbMaterial.ValueMember = "MaterialId";
        }

        private async void loadColors()
        {
            var colors = await colorAPIService.Get();
            clbColors.DataSource = colors;
            clbColors.DisplayMember = "Name";
            clbColors.ValueMember = "ColorId";
        }

        private void loadStates()
        {
            cmbState.DataSource = Enum.GetValues(typeof(StateEnum));
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() && ImageHelper.ValidateImage(pbImage, imageErrorProvider)) {
                FurnitureItemUpsertRequest insert = new FurnitureItemUpsertRequest();
                insert.Name = txtName.Text;
                insert.CategoryId = (cmbCategory.SelectedItem as DTO.Category.CategoryResponse).CategoryId;
                insert.CollectionId = (cmbCollection.SelectedItem as DTO.Collection.CollectionResponse).CollectionId;
                insert.MaterialId = (cmbMaterial.SelectedItem as DTO.Material.MaterialResponse).MaterialId;
                insert.RegularPrice = int.Parse(nudRegularPrice.Value.ToString());
                insert.DiscountPrice = int.Parse(nudDiscountPrice.Value.ToString());
                insert.OnSale = cbOnSale.Checked;
                insert.Image = ImageHelper.FromImageToByte(pbImage.Image);
                insert.State = cmbState.SelectedValue.ToString();
                insert.Description = txtDescription.Text;
                insert.MetricUnitId = (cmbMetricUnitISQ.SelectedItem as DTO.MetricUnit.MetricUnitResponse).MetricUnitId;
                insert.InStockQuantity = int.Parse(nudInStockQuantity.Value.ToString());
                insert.Height = $"{nudHeight.Value} {cmbMetricUnitH.Text}";
                insert.Width = $"{nudWidth.Value} {cmbMetricUnitW.Text}";
                insert.ColorIdList = clbColors.CheckedItems.Cast<DTO.Color.ColorResponse>().ToList().Select(x => x.ColorId).ToList();

                if (!design)
                {
                    await furnitureItemAPIService.Post(insert);
                    DialogResult = DialogResult.OK;
                }
            }
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
            if (cmbSpace.SelectedItem == null)
            {
                e.Cancel = true;
                cmbSpace.Focus();
                errorProvider.SetError(cmbSpace, "Select space!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbSpace, null);
            }
        }

        private void cmbCategory_Validating(object sender, CancelEventArgs e)
        {
            if (cmbCategory.SelectedItem == null)
            {
                e.Cancel = true;
                cmbCategory.Focus();
                errorProvider.SetError(cmbCategory, "Select category type!");
            }
            else
            {
                e.Cancel= false;
                errorProvider.SetError(cmbCategory, null);
            }
        }

        private void cmbDesigner_Validating(object sender, CancelEventArgs e)
        {
            if (cmbDesigner.SelectedItem == null)
            {
                e.Cancel = true;
                cmbDesigner.Focus();
                errorProvider.SetError(cmbDesigner, "Select designer!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbDesigner, null);
            }
        }

        private void cmbCollection_Validating(object sender, CancelEventArgs e)
        {
            if (cmbCollection.SelectedItem == null)
            {
                e.Cancel = true;
                cmbCollection.Focus();
                errorProvider.SetError(cmbCollection, "Select designer!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbCollection, null);
            }
        }

        private void cmbMetricUnitISQ_Validating(object sender, CancelEventArgs e)
        {
            if (cmbMetricUnitISQ.SelectedItem == null)
            {
                e.Cancel = true;
                cmbMetricUnitISQ.Focus();
                errorProvider.SetError(cmbMetricUnitISQ, "Select metric unit for in stock quantity field!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbMetricUnitISQ, null);
            }
        }

        private void cmbMetricUnitH_Validating(object sender, CancelEventArgs e)
        {
            if (cmbMetricUnitH.SelectedItem == null)
            {
                e.Cancel = true;
                cmbMetricUnitH.Focus();
                errorProvider.SetError(cmbMetricUnitH, "Select metric unit for height field!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbMetricUnitH, null);
            }
        }

        private void cmbMetricUnitW_Validating(object sender, CancelEventArgs e)
        {
            if (cmbMetricUnitW.SelectedItem == null)
            {
                e.Cancel = true;
                cmbMetricUnitW.Focus();
                errorProvider.SetError(cmbMetricUnitW, "Select metric unit for width field!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbMetricUnitW, null);
            }
        }

        private void cmbMaterial_Validating(object sender, CancelEventArgs e)
        {
            if (cmbMaterial.SelectedItem == null)
            {
                e.Cancel = true;
                cmbMaterial.Focus();
                errorProvider.SetError(cmbMaterial, "Select material!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbMaterial, null);
            }
        }

        private void cmbState_Validating(object sender, CancelEventArgs e)
        {
            if (cmbState.SelectedItem == null)
            {
                e.Cancel = true;
                cmbState.Focus();
                errorProvider.SetError(cmbState, "Select state!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(cmbState, null);
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                e.Cancel = true;
                txtDescription.Focus();
                errorProvider.SetError(txtDescription, "Description field cannot be left blank!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(txtDescription, null);
            }
        }
    }
}
