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
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.FurnitureItem
{
    public partial class frmFurnitureOverview : Form
    {
        FurnitureItemAPIService furnitureItemAPIService = new FurnitureItemAPIService();
        private DTO.FurnitureItem.FurnitureItemResponse selectedRow = null;
        public frmFurnitureOverview()
        {
            InitializeComponent();
            dgvFurnitureItems.AutoGenerateColumns = false;
        }

        private async void frmFurnitureOverview_Load(object sender, EventArgs e)
        {
            getGridData();
        }

        private async void getGridData()
        {
            try
            {
                var furnitureItems = await furnitureItemAPIService.Get();
                dgvFurnitureItems.DataSource = furnitureItems;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't display furniture items!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show(response, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                getGridData();
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
    }
}
