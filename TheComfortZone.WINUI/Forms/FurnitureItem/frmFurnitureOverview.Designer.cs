namespace TheComfortZone.WINUI.Forms.FurnitureItem
{
    partial class frmFurnitureOverview
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvFurnitureItems = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNewItem = new System.Windows.Forms.Button();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmbSpace = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FurnitureName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Designer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InStockQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dimensions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Material = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OnSale = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFurnitureItems)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvFurnitureItems);
            this.groupBox2.Location = new System.Drawing.Point(15, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(902, 364);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Furniture overview";
            // 
            // dgvFurnitureItems
            // 
            this.dgvFurnitureItems.AllowUserToAddRows = false;
            this.dgvFurnitureItems.AllowUserToDeleteRows = false;
            this.dgvFurnitureItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFurnitureItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FurnitureName,
            this.Designer,
            this.InStockQuantity,
            this.Dimensions,
            this.Material,
            this.Color,
            this.Price,
            this.OnSale});
            this.dgvFurnitureItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFurnitureItems.Location = new System.Drawing.Point(3, 23);
            this.dgvFurnitureItems.Name = "dgvFurnitureItems";
            this.dgvFurnitureItems.ReadOnly = true;
            this.dgvFurnitureItems.RowHeadersWidth = 51;
            this.dgvFurnitureItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFurnitureItems.Size = new System.Drawing.Size(896, 338);
            this.dgvFurnitureItems.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNewItem);
            this.groupBox1.Controls.Add(this.cmbState);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.cmbSpace);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(902, 154);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // btnNewItem
            // 
            this.btnNewItem.Location = new System.Drawing.Point(634, 38);
            this.btnNewItem.Name = "btnNewItem";
            this.btnNewItem.Size = new System.Drawing.Size(162, 29);
            this.btnNewItem.TabIndex = 3;
            this.btnNewItem.Text = "New furniture item";
            this.btnNewItem.UseVisualStyleBackColor = true;
            this.btnNewItem.Click += new System.EventHandler(this.btnNewItem_Click);
            // 
            // cmbState
            // 
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(681, 92);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(213, 28);
            this.cmbState.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(390, 92);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(213, 28);
            this.cmbCategory.TabIndex = 9;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(63, 39);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(249, 27);
            this.txtName.TabIndex = 1;
            // 
            // cmbSpace
            // 
            this.cmbSpace.FormattingEnabled = true;
            this.cmbSpace.Location = new System.Drawing.Point(73, 92);
            this.cmbSpace.Name = "cmbSpace";
            this.cmbSpace.Size = new System.Drawing.Size(213, 28);
            this.cmbSpace.TabIndex = 8;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(318, 38);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 29);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(619, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "State:";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(802, 38);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Category:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Space:";
            // 
            // FurnitureName
            // 
            this.FurnitureName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FurnitureName.DataPropertyName = "Name";
            this.FurnitureName.HeaderText = "Furniture";
            this.FurnitureName.MinimumWidth = 6;
            this.FurnitureName.Name = "FurnitureName";
            this.FurnitureName.ReadOnly = true;
            // 
            // Designer
            // 
            this.Designer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Designer.DataPropertyName = "DesignerName";
            this.Designer.HeaderText = "Designer";
            this.Designer.MinimumWidth = 6;
            this.Designer.Name = "Designer";
            this.Designer.ReadOnly = true;
            // 
            // InStockQuantity
            // 
            this.InStockQuantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.InStockQuantity.DataPropertyName = "InStockQuantityString";
            this.InStockQuantity.HeaderText = "In stock quantity";
            this.InStockQuantity.MinimumWidth = 6;
            this.InStockQuantity.Name = "InStockQuantity";
            this.InStockQuantity.ReadOnly = true;
            // 
            // Dimensions
            // 
            this.Dimensions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Dimensions.DataPropertyName = "Dimensions";
            this.Dimensions.HeaderText = "Dimensions";
            this.Dimensions.MinimumWidth = 6;
            this.Dimensions.Name = "Dimensions";
            this.Dimensions.ReadOnly = true;
            // 
            // Material
            // 
            this.Material.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Material.DataPropertyName = "Material";
            this.Material.HeaderText = "Material";
            this.Material.MinimumWidth = 6;
            this.Material.Name = "Material";
            this.Material.ReadOnly = true;
            // 
            // Color
            // 
            this.Color.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Color.DataPropertyName = "Colors";
            this.Color.HeaderText = "Color";
            this.Color.MinimumWidth = 6;
            this.Color.Name = "Color";
            this.Color.ReadOnly = true;
            this.Color.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Price
            // 
            this.Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Price.DataPropertyName = "Price";
            this.Price.HeaderText = "Price (KM)";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.ReadOnly = true;
            // 
            // OnSale
            // 
            this.OnSale.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.OnSale.DataPropertyName = "OnSale";
            this.OnSale.HeaderText = "On sale";
            this.OnSale.MinimumWidth = 6;
            this.OnSale.Name = "OnSale";
            this.OnSale.ReadOnly = true;
            // 
            // frmFurnitureOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 538);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFurnitureOverview";
            this.Text = "Furniture";
            this.Load += new System.EventHandler(this.frmFurnitureOverview_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFurnitureItems)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox2;
        private DataGridView dgvFurnitureItems;
        private GroupBox groupBox1;
        private Button btnNewItem;
        private ComboBox cmbState;
        private Label label1;
        private ComboBox cmbCategory;
        private TextBox txtName;
        private ComboBox cmbSpace;
        private Button btnSearch;
        private Label label4;
        private Button btnDelete;
        private Label label3;
        private Label label2;
        private DataGridViewTextBoxColumn FurnitureName;
        private DataGridViewTextBoxColumn Designer;
        private DataGridViewTextBoxColumn InStockQuantity;
        private DataGridViewTextBoxColumn Dimensions;
        private DataGridViewTextBoxColumn Material;
        private DataGridViewTextBoxColumn Color;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewCheckBoxColumn OnSale;
    }
}