namespace TheComfortZone.WINUI.Forms.FurnitureItem
{
    partial class frmFurnitureItemAddEdit
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDesigner = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbCollection = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.nudInStockQuantity = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbMetricUnitISQ = new System.Windows.Forms.ComboBox();
            this.cmbMetricUnitH = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nudHeight = new System.Windows.Forms.NumericUpDown();
            this.cmbMetricUnitW = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudWidth = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbMaterial = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.nudDiscountPrice = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.nudRegularPrice = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cbOnSale = new System.Windows.Forms.CheckBox();
            this.cmbState = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.clbColors = new System.Windows.Forms.CheckedListBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cmbSpace = new System.Windows.Forms.ComboBox();
            this.imageErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudInStockQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegularPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(149, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(312, 27);
            this.txtName.TabIndex = 1;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Space:";
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(149, 118);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(312, 28);
            this.cmbCategory.TabIndex = 5;
            this.cmbCategory.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCategory_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Category:";
            // 
            // cmbDesigner
            // 
            this.cmbDesigner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDesigner.FormattingEnabled = true;
            this.cmbDesigner.Location = new System.Drawing.Point(149, 166);
            this.cmbDesigner.Name = "cmbDesigner";
            this.cmbDesigner.Size = new System.Drawing.Size(312, 28);
            this.cmbDesigner.TabIndex = 7;
            this.cmbDesigner.SelectedIndexChanged += new System.EventHandler(this.cmbDesigner_SelectedIndexChanged);
            this.cmbDesigner.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDesigner_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Designer:";
            // 
            // cmbCollection
            // 
            this.cmbCollection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCollection.FormattingEnabled = true;
            this.cmbCollection.Location = new System.Drawing.Point(149, 213);
            this.cmbCollection.Name = "cmbCollection";
            this.cmbCollection.Size = new System.Drawing.Size(312, 28);
            this.cmbCollection.TabIndex = 9;
            this.cmbCollection.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCollection_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 220);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Collection:";
            // 
            // nudInStockQuantity
            // 
            this.nudInStockQuantity.Location = new System.Drawing.Point(149, 266);
            this.nudInStockQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudInStockQuantity.Name = "nudInStockQuantity";
            this.nudInStockQuantity.Size = new System.Drawing.Size(97, 27);
            this.nudInStockQuantity.TabIndex = 10;
            this.nudInStockQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "In stock quantity:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(269, 268);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Metric unit:";
            // 
            // cmbMetricUnitISQ
            // 
            this.cmbMetricUnitISQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetricUnitISQ.FormattingEnabled = true;
            this.cmbMetricUnitISQ.Location = new System.Drawing.Point(364, 265);
            this.cmbMetricUnitISQ.Name = "cmbMetricUnitISQ";
            this.cmbMetricUnitISQ.Size = new System.Drawing.Size(97, 28);
            this.cmbMetricUnitISQ.TabIndex = 13;
            this.cmbMetricUnitISQ.Validating += new System.ComponentModel.CancelEventHandler(this.cmbMetricUnitISQ_Validating);
            // 
            // cmbMetricUnitH
            // 
            this.cmbMetricUnitH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetricUnitH.FormattingEnabled = true;
            this.cmbMetricUnitH.Location = new System.Drawing.Point(364, 311);
            this.cmbMetricUnitH.Name = "cmbMetricUnitH";
            this.cmbMetricUnitH.Size = new System.Drawing.Size(97, 28);
            this.cmbMetricUnitH.TabIndex = 17;
            this.cmbMetricUnitH.Validating += new System.ComponentModel.CancelEventHandler(this.cmbMetricUnitH_Validating);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(269, 314);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "Metric unit:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 314);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = "Height:";
            // 
            // nudHeight
            // 
            this.nudHeight.Location = new System.Drawing.Point(149, 312);
            this.nudHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudHeight.Name = "nudHeight";
            this.nudHeight.Size = new System.Drawing.Size(97, 27);
            this.nudHeight.TabIndex = 14;
            this.nudHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbMetricUnitW
            // 
            this.cmbMetricUnitW.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMetricUnitW.FormattingEnabled = true;
            this.cmbMetricUnitW.Location = new System.Drawing.Point(364, 357);
            this.cmbMetricUnitW.Name = "cmbMetricUnitW";
            this.cmbMetricUnitW.Size = new System.Drawing.Size(97, 28);
            this.cmbMetricUnitW.TabIndex = 21;
            this.cmbMetricUnitW.Validating += new System.ComponentModel.CancelEventHandler(this.cmbMetricUnitW_Validating);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(269, 360);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 20);
            this.label10.TabIndex = 20;
            this.label10.Text = "Metric unit:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(23, 360);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Width:";
            // 
            // nudWidth
            // 
            this.nudWidth.Location = new System.Drawing.Point(149, 358);
            this.nudWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudWidth.Name = "nudWidth";
            this.nudWidth.Size = new System.Drawing.Size(97, 27);
            this.nudWidth.TabIndex = 18;
            this.nudWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(23, 457);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 20);
            this.label12.TabIndex = 24;
            this.label12.Text = "Colors:";
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.Location = new System.Drawing.Point(149, 403);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(312, 28);
            this.cmbMaterial.TabIndex = 23;
            this.cmbMaterial.Validating += new System.ComponentModel.CancelEventHandler(this.cmbMaterial_Validating);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 410);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 20);
            this.label13.TabIndex = 22;
            this.label13.Text = "Material:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(23, 656);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 20);
            this.label14.TabIndex = 29;
            this.label14.Text = "Discount price:";
            // 
            // nudDiscountPrice
            // 
            this.nudDiscountPrice.Location = new System.Drawing.Point(149, 654);
            this.nudDiscountPrice.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.nudDiscountPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDiscountPrice.Name = "nudDiscountPrice";
            this.nudDiscountPrice.Size = new System.Drawing.Size(97, 27);
            this.nudDiscountPrice.TabIndex = 28;
            this.nudDiscountPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(23, 610);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 20);
            this.label15.TabIndex = 27;
            this.label15.Text = "Regular price:";
            // 
            // nudRegularPrice
            // 
            this.nudRegularPrice.Location = new System.Drawing.Point(149, 608);
            this.nudRegularPrice.Maximum = new decimal(new int[] {
            2500,
            0,
            0,
            0});
            this.nudRegularPrice.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudRegularPrice.Name = "nudRegularPrice";
            this.nudRegularPrice.Size = new System.Drawing.Size(97, 27);
            this.nudRegularPrice.TabIndex = 26;
            this.nudRegularPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(252, 656);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(31, 20);
            this.label16.TabIndex = 31;
            this.label16.Text = "KM";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(252, 610);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(31, 20);
            this.label17.TabIndex = 30;
            this.label17.Text = "KM";
            // 
            // cbOnSale
            // 
            this.cbOnSale.AutoSize = true;
            this.cbOnSale.Location = new System.Drawing.Point(381, 652);
            this.cbOnSale.Name = "cbOnSale";
            this.cbOnSale.Size = new System.Drawing.Size(80, 24);
            this.cbOnSale.TabIndex = 32;
            this.cbOnSale.Text = "On sale";
            this.cbOnSale.UseVisualStyleBackColor = true;
            // 
            // cmbState
            // 
            this.cmbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbState.FormattingEnabled = true;
            this.cmbState.Location = new System.Drawing.Point(149, 702);
            this.cmbState.Name = "cmbState";
            this.cmbState.Size = new System.Drawing.Size(312, 28);
            this.cmbState.TabIndex = 34;
            this.cmbState.Validating += new System.ComponentModel.CancelEventHandler(this.cmbState_Validating);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(23, 706);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(46, 20);
            this.label18.TabIndex = 33;
            this.label18.Text = "State:";
            // 
            // pbImage
            // 
            this.pbImage.Location = new System.Drawing.Point(498, 23);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(350, 467);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 35;
            this.pbImage.TabStop = false;
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(704, 496);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(145, 29);
            this.btnUpload.TabIndex = 36;
            this.btnUpload.Text = "Upload image";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(498, 529);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 20);
            this.label19.TabIndex = 37;
            this.label19.Text = "Description:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(498, 552);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(351, 124);
            this.txtDescription.TabIndex = 38;
            this.txtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescription_Validating);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(654, 697);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 39;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(754, 697);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 40;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // clbColors
            // 
            this.clbColors.BackColor = System.Drawing.SystemColors.Menu;
            this.clbColors.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.clbColors.FormattingEnabled = true;
            this.clbColors.Location = new System.Drawing.Point(149, 457);
            this.clbColors.Name = "clbColors";
            this.clbColors.Size = new System.Drawing.Size(312, 132);
            this.clbColors.TabIndex = 41;
            this.clbColors.Validating += new System.ComponentModel.CancelEventHandler(this.clbColors_Validating);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // cmbSpace
            // 
            this.cmbSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpace.FormattingEnabled = true;
            this.cmbSpace.Location = new System.Drawing.Point(149, 70);
            this.cmbSpace.Name = "cmbSpace";
            this.cmbSpace.Size = new System.Drawing.Size(312, 28);
            this.cmbSpace.TabIndex = 3;
            this.cmbSpace.SelectedIndexChanged += new System.EventHandler(this.cmbSpace_SelectedIndexChanged);
            this.cmbSpace.Validating += new System.ComponentModel.CancelEventHandler(this.cmbSpace_Validating);
            // 
            // imageErrorProvider
            // 
            this.imageErrorProvider.ContainerControl = this;
            // 
            // frmFurnitureItemAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 753);
            this.Controls.Add(this.clbColors);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.pbImage);
            this.Controls.Add(this.cmbState);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.cbOnSale);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.nudDiscountPrice);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.nudRegularPrice);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbMaterial);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbMetricUnitW);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.nudWidth);
            this.Controls.Add(this.cmbMetricUnitH);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudHeight);
            this.Controls.Add(this.cmbMetricUnitISQ);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nudInStockQuantity);
            this.Controls.Add(this.cmbCollection);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbDesigner);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbSpace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.Name = "frmFurnitureItemAddEdit";
            this.Text = "Add / Edit Furniture Pieces";
            this.Load += new System.EventHandler(this.frmFurnitureItemAddEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudInStockQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscountPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRegularPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtName;
        private Label label2;
        private ComboBox cmbCategory;
        private Label label3;
        private ComboBox cmbDesigner;
        private Label label4;
        private ComboBox cmbCollection;
        private Label label5;
        private NumericUpDown nudInStockQuantity;
        private Label label6;
        private Label label7;
        private ComboBox cmbMetricUnitISQ;
        private ComboBox cmbMetricUnitH;
        private Label label8;
        private Label label9;
        private NumericUpDown nudHeight;
        private ComboBox cmbMetricUnitW;
        private Label label10;
        private Label label11;
        private NumericUpDown nudWidth;
        private Label label12;
        private ComboBox cmbMaterial;
        private Label label13;
        private Label label14;
        private NumericUpDown nudDiscountPrice;
        private Label label15;
        private NumericUpDown nudRegularPrice;
        private Label label16;
        private Label label17;
        private CheckBox cbOnSale;
        private ComboBox cmbState;
        private Label label18;
        private PictureBox pbImage;
        private Button btnUpload;
        private Label label19;
        private TextBox txtDescription;
        private Button btnCancel;
        private Button btnSave;
        private ErrorProvider errorProvider;
        private CheckedListBox clbColors;
        private OpenFileDialog openFileDialog;
        private ComboBox cmbSpace;
        private ErrorProvider imageErrorProvider;
    }
}