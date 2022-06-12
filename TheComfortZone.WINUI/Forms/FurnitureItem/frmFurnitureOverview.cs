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

namespace TheComfortZone.WINUI.Forms.FurnitureItem
{
    public partial class frmFurnitureOverview : Form
    {
        FurnitureItemAPIService furnitureItemAPIService = new FurnitureItemAPIService();
        SpaceAPIService spaceAPIService = new SpaceAPIService();
        CategoryAPIService categoryAPIService = new CategoryAPIService();
        private DTO.FurnitureItem.FurnitureItemResponse selectedRow = null;
        public frmFurnitureOverview()
        {
            InitializeComponent();
            dgvFurnitureItems.AutoGenerateColumns = false;
        }

        private async void frmFurnitureOverview_Load(object sender, EventArgs e)
        {
            await loadSpaces();
            loadStates();

            await getGridData();
        }
        private async Task loadSpaces()
        {
            var spaces = await spaceAPIService.GetSpacesWithCateroryData();
            cmbSpace.DataSource = spaces;
            cmbSpace.DisplayMember = "Name";
            cmbSpace.ValueMember = "SpaceId";
            cmbSpace.SelectedIndex = -1;
        }

        private async Task loadCategories(int spaceId)
        {
            var categories = await categoryAPIService.GetCategoriesBySpaceId(spaceId);
            cmbCategory.DataSource = categories;
            cmbCategory.DisplayMember = "Name";
            cmbCategory.ValueMember = "CategoryId";
        }

        private void loadStates()
        {
            cmbState.DataSource = Enum.GetValues(typeof(StateEnum));
            cmbState.SelectedIndex = -1;
        }

        private async void cmbSpace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSpace.SelectedIndex != -1 && int.TryParse(cmbSpace.SelectedValue?.ToString(), out int spaceId))
            {
                await loadCategories(spaceId);
            }
        }

        private async Task getGridData(DTO.FurnitureItem.FurnitureItemSearchRequest searchRequest = null)
        {
            var furnitureItems = await furnitureItemAPIService.Get(searchRequest);
            dgvFurnitureItems.DataSource = furnitureItems;
        }

        private async void btnNewItem_Click(object sender, EventArgs e)
        {
            frmFurnitureItemAddEdit frm = new frmFurnitureItemAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await getGridData();
            }
        }

        private void dgvFurnitureItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            selectedRow = dgvFurnitureItems.SelectedRows[0].DataBoundItem as DTO.FurnitureItem.FurnitureItemResponse;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Are you sure you want to delete selected item?\nIf you choose Yes, orders that contain this item will also be deleted!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (selectedRow != null && confirmation == DialogResult.Yes)
            {
                string response = await furnitureItemAPIService.Delete(selectedRow.FurnitureItemId);
                if (!string.IsNullOrWhiteSpace(response))
                {
                    MessageBox.Show(response, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await ClearFields();
                }
            }

            selectedRow = null;
            btnDelete.Enabled = false;
        }

        private async void dgvFurnitureItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedItem = dgvFurnitureItems.SelectedRows[0].DataBoundItem as FurnitureItemResponse;
            frmFurnitureItemAddEdit frm = new frmFurnitureItemAddEdit(selectedItem);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                await getGridData();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            FurnitureItemSearchRequest searchRequest = new FurnitureItemSearchRequest();
            searchRequest.Name = txtName.Text;
            searchRequest.CategoryId = ((DTO.Category.CategoryResponse)cmbCategory.SelectedItem)?.CategoryId;
            searchRequest.State = cmbState.SelectedIndex == -1 ? null : cmbState.Text;

            if (!string.IsNullOrWhiteSpace(searchRequest.Name) || searchRequest.CategoryId.HasValue == true ||
                !string.IsNullOrWhiteSpace(searchRequest.State))
                btnClearFields.Enabled = true;

            await getGridData(searchRequest);
        }

        private async void btnClearFields_Click(object sender, EventArgs e)
        {
            await ClearFields();
        }

        private async Task ClearFields()
        {
            if (btnClearFields.Enabled)
            {
                btnClearFields.Enabled = false;
                txtName.Text = null;
                cmbSpace.SelectedIndex = -1;
                cmbCategory.DataSource = null;
                cmbState.SelectedIndex = -1;
            }

            await getGridData();
        }
    }
}
