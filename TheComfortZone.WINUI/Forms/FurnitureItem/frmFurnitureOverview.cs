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

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            frmFurnitureItemAddEdit frm = new frmFurnitureItemAddEdit();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                getGridData();
            }
        }

        private void dgvFurnitureItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDelete.Enabled = true;
            selectedRow = dgvFurnitureItems.SelectedRows[0].DataBoundItem as DTO.FurnitureItem.FurnitureItemResponse;
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            var confirmation = MessageBox.Show("Are you sure you want to delete selected item?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (selectedRow != null && confirmation == DialogResult.Yes)
            {
                string response = await furnitureItemAPIService.Delete(selectedRow.FurnitureItemId);
                if (!string.IsNullOrWhiteSpace(response))
                {
                    MessageBox.Show(response, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await getGridData();
                }
            }

            selectedRow = null;
            btnDelete.Enabled = false;
        }

        private void dgvFurnitureItems_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedItem = dgvFurnitureItems.SelectedRows[0].DataBoundItem as FurnitureItemResponse;
            frmFurnitureItemAddEdit frm = new frmFurnitureItemAddEdit(selectedItem);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                getGridData();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            FurnitureItemSearchRequest searchRequest = new FurnitureItemSearchRequest();
            searchRequest.Name = txtName.Text;
            searchRequest.CategoryId = ((DTO.Category.CategoryResponse)cmbCategory.SelectedItem)?.CategoryId;
            searchRequest.State = cmbState.SelectedIndex == -1 ? null : cmbState.Text;

            await getGridData(searchRequest);
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            txtName.Text = null;
            cmbSpace.SelectedIndex = -1;
            cmbCategory.DataSource = null;
            cmbState.SelectedIndex = -1;
        }
    }
}
