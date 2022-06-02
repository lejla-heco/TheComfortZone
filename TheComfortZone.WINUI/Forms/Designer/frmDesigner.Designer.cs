namespace TheComfortZone.WINUI.Forms.Designer
{
    partial class frmDesigner
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
            this.dgvDesigners = new System.Windows.Forms.DataGridView();
            this.DesignerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ConsultationPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.nudConsultationPrice = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesigners)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConsultationPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvDesigners);
            this.groupBox1.Location = new System.Drawing.Point(18, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(896, 358);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Designers overview";
            // 
            // dgvDesigners
            // 
            this.dgvDesigners.AllowUserToAddRows = false;
            this.dgvDesigners.AllowUserToDeleteRows = false;
            this.dgvDesigners.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDesigners.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DesignerName,
            this.ConsultationPrice});
            this.dgvDesigners.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDesigners.Location = new System.Drawing.Point(3, 23);
            this.dgvDesigners.Name = "dgvDesigners";
            this.dgvDesigners.ReadOnly = true;
            this.dgvDesigners.RowHeadersWidth = 51;
            this.dgvDesigners.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDesigners.Size = new System.Drawing.Size(890, 332);
            this.dgvDesigners.TabIndex = 0;
            this.dgvDesigners.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDesigners_CellDoubleClick);
            // 
            // DesignerName
            // 
            this.DesignerName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DesignerName.DataPropertyName = "Name";
            this.DesignerName.HeaderText = "Designer";
            this.DesignerName.MinimumWidth = 6;
            this.DesignerName.Name = "DesignerName";
            this.DesignerName.ReadOnly = true;
            // 
            // ConsultationPrice
            // 
            this.ConsultationPrice.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ConsultationPrice.DataPropertyName = "ConsultationPrice";
            this.ConsultationPrice.HeaderText = "Consultation price (KM)";
            this.ConsultationPrice.MinimumWidth = 6;
            this.ConsultationPrice.Name = "ConsultationPrice";
            this.ConsultationPrice.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.nudConsultationPrice);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Location = new System.Drawing.Point(18, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(896, 150);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            // 
            // nudConsultationPrice
            // 
            this.nudConsultationPrice.Location = new System.Drawing.Point(190, 73);
            this.nudConsultationPrice.Maximum = new decimal(new int[] {
            750,
            0,
            0,
            0});
            this.nudConsultationPrice.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudConsultationPrice.Name = "nudConsultationPrice";
            this.nudConsultationPrice.Size = new System.Drawing.Size(684, 27);
            this.nudConsultationPrice.TabIndex = 51;
            this.nudConsultationPrice.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 20);
            this.label2.TabIndex = 49;
            this.label2.Text = "Consultation price (KM):";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(355, 111);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 46;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(455, 111);
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
            this.label1.Location = new System.Drawing.Point(132, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(190, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(684, 27);
            this.txtName.TabIndex = 3;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // frmDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 538);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmDesigner";
            this.Text = "Designers";
            this.Load += new System.EventHandler(this.frmDesigner_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDesigners)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudConsultationPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox1;
        private DataGridView dgvDesigners;
        private GroupBox groupBox2;
        private NumericUpDown nudConsultationPrice;
        private Label label2;
        private Button btnCancel;
        private Button btnSave;
        private Label label1;
        private TextBox txtName;
        private DataGridViewTextBoxColumn DesignerName;
        private DataGridViewTextBoxColumn ConsultationPrice;
        private ErrorProvider errorProvider;
    }
}