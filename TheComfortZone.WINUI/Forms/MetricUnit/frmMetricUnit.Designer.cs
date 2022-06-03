namespace TheComfortZone.WINUI.Forms.MetricUnit
{
    partial class frmMetricUnit
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvMetricUnits = new System.Windows.Forms.DataGridView();
            this.MetricUnitName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetricUnits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Location = new System.Drawing.Point(18, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(896, 212);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(17, 88);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(858, 83);
            this.txtDescription.TabIndex = 56;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(355, 177);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 53;
            this.label1.Text = "Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(455, 177);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(137, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(738, 27);
            this.txtName.TabIndex = 54;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(17, 64);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(158, 20);
            this.label19.TabIndex = 55;
            this.label19.Text = "Description (optional):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvMetricUnits);
            this.groupBox1.Location = new System.Drawing.Point(18, 230);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(896, 296);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Metric units overview";
            // 
            // dgvMetricUnits
            // 
            this.dgvMetricUnits.AllowUserToAddRows = false;
            this.dgvMetricUnits.AllowUserToDeleteRows = false;
            this.dgvMetricUnits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMetricUnits.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MetricUnitName,
            this.Description});
            this.dgvMetricUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMetricUnits.Location = new System.Drawing.Point(3, 23);
            this.dgvMetricUnits.Name = "dgvMetricUnits";
            this.dgvMetricUnits.ReadOnly = true;
            this.dgvMetricUnits.RowHeadersWidth = 51;
            this.dgvMetricUnits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMetricUnits.Size = new System.Drawing.Size(890, 270);
            this.dgvMetricUnits.TabIndex = 0;
            this.dgvMetricUnits.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMetricUnits_CellDoubleClick);
            // 
            // MetricUnitName
            // 
            this.MetricUnitName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MetricUnitName.DataPropertyName = "Name";
            this.MetricUnitName.HeaderText = "Metric unit";
            this.MetricUnitName.MinimumWidth = 6;
            this.MetricUnitName.Name = "MetricUnitName";
            this.MetricUnitName.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmMetricUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 538);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmMetricUnit";
            this.Text = "Metric Units";
            this.Load += new System.EventHandler(this.frmMetricUnit_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMetricUnits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox2;
        private Button btnCancel;
        private Button btnSave;
        private GroupBox groupBox1;
        private DataGridView dgvMetricUnits;
        private TextBox txtDescription;
        private Label label1;
        private TextBox txtName;
        private Label label19;
        private DataGridViewTextBoxColumn MetricUnitName;
        private DataGridViewTextBoxColumn Description;
        private ErrorProvider errorProvider;
    }
}