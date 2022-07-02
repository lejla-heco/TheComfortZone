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

        private async void frmFurnitureItemAddEdit_Load(object sender, EventArgs e)
        {
            await loadSpaces();
            await loadDesigners();
            await loadMetricUnits();
            await loadMaterials();
            await loadColors();
            loadStates();

            if (design)
                loadItemData();
        }

        private async Task loadSpaces()
        {
            var spaces = await spaceAPIService.GetSpacesWithCateroryData();
            cmbSpace.DataSource = spaces;
            cmbSpace.DisplayMember = "Name";
            cmbSpace.ValueMember = "SpaceId";
            if (spaces.Count != 0) await loadCategories(spaces[0].SpaceId);
        }

        private async Task loadCategories(int spaceId)
        {
            var categories = await categoryAPIService.GetCategoriesBySpaceId(spaceId);
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "CategoryId";
        }

        private async Task loadDesigners()
        {
            var designers = await designerAPIService.GetDesignersWithCollectionData();
            cmbDesigner.DataSource = designers;
            cmbDesigner.DisplayMember = "Name";
            cmbDesigner.ValueMember = "DesignerId";
            if (designers.Count != 0) await loadCollections(designers[0].DesignerId);
        }

        private async Task loadCollections(int designerId)
        {
            var collections = await collectionAPIService.GetCollectionsByDesignerId(designerId);
            cmbCollection.DataSource = collections;
            cmbCollection.DisplayMember = "Name";
            cmbCollection.ValueMember = "CollectionId";
        }

        private async void cmbSpace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSpace.SelectedIndex != -1 && int.TryParse(cmbSpace.SelectedValue.ToString(), out int spaceId))
            {
                await loadCategories(spaceId);
            }
        }

        private async void cmbDesigner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDesigner.SelectedIndex != -1 && int.TryParse(cmbDesigner.SelectedValue.ToString(), out int designerId))
            {
                await loadCollections(designerId);
            }
        }

        private void loadComboBoxMetricUnitData(ComboBox comboBox, List<DTO.MetricUnit.MetricUnitResponse> data,
            string displayMember, string valueMember)
        {
            comboBox.DataSource = data;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;
        }

        private async Task loadMetricUnitsISQ()
        {
            var metricUnits = await metricUnitAPIService.Get();
            loadComboBoxMetricUnitData(cmbMetricUnitISQ, metricUnits, "Name", "MetricUnitId");
        }

        private async Task loadMetricUnitsH()
        {
            var metricUnits = await metricUnitAPIService.Get();
            loadComboBoxMetricUnitData(cmbMetricUnitH, metricUnits, "Name", "MetricUnitId");
        }

        private async Task loadMetricUnitsW()
        {
            var metricUnits = await metricUnitAPIService.Get();
            loadComboBoxMetricUnitData(cmbMetricUnitW, metricUnits, "Name", "MetricUnitId");
        }

        private async Task loadMetricUnits()
        {
            var metricUnits = await metricUnitAPIService.Get();
            await loadMetricUnitsISQ();
            await loadMetricUnitsH();
            await loadMetricUnitsW();
        }

        private async Task loadMaterials()
        {
            var materials = await materialAPIService.Get();
            cmbMaterial.DataSource = materials;
            cmbMaterial.DisplayMember = "Name";
            cmbMaterial.ValueMember = "MaterialId";
        }

        private async Task loadColors()
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

        private void loadItemData()
        {
            txtName.Text = furnitureItem.Name;
            cmbSpace.SelectedIndex = ((List<DTO.Space.SpaceResponse>)cmbSpace.DataSource).FindIndex(s => s.SpaceId == furnitureItem.SpaceId);
            cmbCategory.SelectedIndex = ((List<DTO.Category.CategoryResponse>)cmbCategory.DataSource).FindIndex(c => c.CategoryId == furnitureItem.CategoryId);
            cmbDesigner.SelectedIndex = ((List<DTO.Designer.DesignerResponse>)cmbDesigner.DataSource).FindIndex(d => d.DesignerId == furnitureItem.DesignerId);
            cmbCollection.SelectedIndex = ((List<DTO.Collection.CollectionResponse>)cmbCollection.DataSource).FindIndex(c => c.CollectionId == furnitureItem.CollectionId);
            nudInStockQuantity.Value = furnitureItem.InStockQuantity;
            cmbMetricUnitISQ.SelectedIndex = ((List<DTO.MetricUnit.MetricUnitResponse>)cmbMetricUnitISQ.DataSource).FindIndex(m => m.MetricUnitId == furnitureItem.MetricUnitId);

            var heightData = furnitureItem.Height.Split(' ');
            var widthData = furnitureItem.Width.Split(' ');

            nudHeight.Value = int.Parse(heightData[0]);
            nudWidth.Value = int.Parse(widthData[0]);

            cmbMetricUnitH.SelectedIndex = cmbMetricUnitH.FindStringExact(heightData[1]);
            cmbMetricUnitW.SelectedIndex = cmbMetricUnitW.FindStringExact(widthData[1]);

            cmbMaterial.SelectedIndex =((List<DTO.Material.MaterialResponse>)cmbMaterial.DataSource).FindIndex(m => m.MaterialId == furnitureItem.MaterialId);

            var colors = clbColors.Items.Cast<DTO.Color.ColorResponse>().ToList();
            for (int i = 0; i < colors.Count; i++) 
            {
                if (furnitureItem.Colors.Contains(colors[i].Name))
                {
                    clbColors.SetItemChecked(i, true);
                }
            }

            nudRegularPrice.Value = (decimal)furnitureItem.RegularPrice;
            nudDiscountPrice.Value = (decimal)furnitureItem.DiscountPrice;
            cbOnSale.Checked = furnitureItem.OnSale ?? false;
            cmbState.SelectedIndex = cmbState.FindStringExact(furnitureItem.State);
            txtDescription.Text = furnitureItem.Description;
            pbImage.Image = ImageHelper.FromByteToImage(furnitureItem.Image);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren() && ImageHelper.ValidateImage(pbImage, imageErrorProvider)) {
                FurnitureItemUpsertRequest upsert = new FurnitureItemUpsertRequest();
                upsert.Name = txtName.Text;
                upsert.CategoryId = (cmbCategory.SelectedItem as DTO.Category.CategoryResponse).CategoryId;
                upsert.CollectionId = (cmbCollection.SelectedItem as DTO.Collection.CollectionResponse).CollectionId;
                upsert.MaterialId = (cmbMaterial.SelectedItem as DTO.Material.MaterialResponse).MaterialId;
                upsert.RegularPrice = int.Parse(nudRegularPrice.Value.ToString());
                upsert.DiscountPrice = int.Parse(nudDiscountPrice.Value.ToString());
                upsert.OnSale = cbOnSale.Checked;
                upsert.Image = ImageHelper.FromImageToByte(pbImage.Image);
                upsert.State = cmbState.SelectedValue.ToString();
                upsert.Description = txtDescription.Text;
                upsert.MetricUnitId = (cmbMetricUnitISQ.SelectedItem as DTO.MetricUnit.MetricUnitResponse).MetricUnitId;
                upsert.InStockQuantity = int.Parse(nudInStockQuantity.Value.ToString());
                upsert.Height = $"{nudHeight.Value} {cmbMetricUnitH.Text}";
                upsert.Width = $"{nudWidth.Value} {cmbMetricUnitW.Text}";
                upsert.ColorIdList = clbColors.CheckedItems.Cast<DTO.Color.ColorResponse>().ToList().Select(x => x.ColorId).ToList();

                if (!design)
                {
                    var response = await furnitureItemAPIService.Post(upsert);
                    if (response != null)
                    {
                        MessageBox.Show("Successfully added new furniture item!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                }
                if (design)
                {
                    var response = await furnitureItemAPIService.Put(furnitureItem.FurnitureItemId, upsert);
                    if (response != null)
                    {
                        MessageBox.Show("Successfully updated furniture item!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
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

        private void clbColors_Validating(object sender, CancelEventArgs e)
        {
            if (clbColors.CheckedItems.Count == 0)
            {
                e.Cancel = true;
                clbColors.Focus();
                errorProvider.SetError(clbColors, "Furniture item must have at least one color!");
            }
            else
            {
                e.Cancel = false;
                errorProvider.SetError(clbColors, null);
            }
        }
    }
}
