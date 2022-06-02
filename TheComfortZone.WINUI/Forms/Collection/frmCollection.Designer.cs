namespace TheComfortZone.WINUI.Forms.Collection
{
    partial class frmCollection
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCollections = new System.Windows.Forms.DataGridView();
            this.CollectionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesignerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Created = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpCreated = new System.Windows.Forms.DateTimePicker();
            this.cmbDesigner = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollections)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvCollections);
            this.groupBox1.Location = new System.Drawing.Point(18, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(896, 329);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Collections overview";
            // 
            // dgvCollections
            // 
            this.dgvCollections.AllowUserToAddRows = false;
            this.dgvCollections.AllowUserToDeleteRows = false;
            this.dgvCollections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCollections.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CollectionName,
            this.DesignerName,
            this.Created});
            this.dgvCollections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCollections.Location = new System.Drawing.Point(3, 23);
            this.dgvCollections.Name = "dgvCollections";
            this.dgvCollections.ReadOnly = true;
            this.dgvCollections.RowHeadersWidth = 51;
            this.dgvCollections.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCollections.Size = new System.Drawing.Size(890, 303);
            this.dgvCollections.TabIndex = 0;
            this.dgvCollections.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCollections_CellDoubleClick);
            // 
            // CollectionName
            // 
            this.CollectionName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.CollectionName.DataPropertyName = "Name";
            this.CollectionName.HeaderText = "Collection";
            this.CollectionName.MinimumWidth = 6;
            this.CollectionName.Name = "CollectionName";
            this.CollectionName.ReadOnly = true;
            // 
            // DesignerName
            // 
            this.DesignerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DesignerName.DataPropertyName = "DesignerName";
            this.DesignerName.HeaderText = "DesignerName";
            this.DesignerName.MinimumWidth = 6;
            this.DesignerName.Name = "DesignerName";
            this.DesignerName.ReadOnly = true;
            // 
            // Created
            // 
            this.Created.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Created.DataPropertyName = "Created";
            this.Created.HeaderText = "Created";
            this.Created.MinimumWidth = 6;
            this.Created.Name = "Created";
            this.Created.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dtpCreated);
            this.groupBox2.Controls.Add(this.cmbDesigner);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Location = new System.Drawing.Point(18, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(896, 179);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 56;
            this.label3.Text = "Created:";
            // 
            // dtpCreated
            // 
            this.dtpCreated.Location = new System.Drawing.Point(136, 109);
            this.dtpCreated.Name = "dtpCreated";
            this.dtpCreated.Size = new System.Drawing.Size(738, 27);
            this.dtpCreated.TabIndex = 55;
            // 
            // cmbDesigner
            // 
            this.cmbDesigner.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDesigner.FormattingEnabled = true;
            this.cmbDesigner.Location = new System.Drawing.Point(136, 66);
            this.cmbDesigner.Name = "cmbDesigner";
            this.cmbDesigner.Size = new System.Drawing.Size(738, 28);
            this.cmbDesigner.TabIndex = 54;
            this.cmbDesigner.Validating += new System.ComponentModel.CancelEventHandler(this.cmbDesigner_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 20);
            this.label2.TabIndex = 53;
            this.label2.Text = "Designer:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(355, 144);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(455, 144);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(94, 29);
            this.btnSave.TabIndex = 45;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(136, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(738, 27);
            this.txtName.TabIndex = 3;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmCollection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 538);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmCollection";
            this.Text = "Collections";
            this.Load += new System.EventHandler(this.frmCollection_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCollections)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvCollections;
        private GroupBox groupBox2;
        private Button btnCancel;
        private Button btnSave;
        private Label label1;
        private TextBox txtName;
        private DataGridViewTextBoxColumn CollectionName;
        private DataGridViewTextBoxColumn DesignerName;
        private DataGridViewTextBoxColumn Created;
        private Label label3;
        private DateTimePicker dtpCreated;
        private ComboBox cmbDesigner;
        private Label label2;
        private ErrorProvider errorProvider;
    }
}