using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheComfortZone.WINUI.Service;

namespace TheComfortZone.WINUI.Forms.FurnitureItem
{
    public partial class frmFurnitureOverview : Form
    {
        FurnitureItemAPIService furnitureItemAPIService = new FurnitureItemAPIService();
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
    }
}
