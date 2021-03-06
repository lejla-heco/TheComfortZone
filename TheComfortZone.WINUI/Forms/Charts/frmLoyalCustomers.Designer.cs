namespace TheComfortZone.WINUI.Forms.Charts
{
    partial class frmLoyalCustomers
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
            this.formsPlot = new ScottPlot.FormsPlot();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvLoyalCustomers = new System.Windows.Forms.DataGridView();
            this.Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfPurchases = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfAppointments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountSpent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudDiscount = new System.Windows.Forms.NumericUpDown();
            this.btnDiscount = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoyalCustomers)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).BeginInit();
            this.SuspendLayout();
            // 
            // formsPlot
            // 
            this.formsPlot.Location = new System.Drawing.Point(501, 113);
            this.formsPlot.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.formsPlot.Name = "formsPlot";
            this.formsPlot.Size = new System.Drawing.Size(421, 419);
            this.formsPlot.TabIndex = 9;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvLoyalCustomers);
            this.groupBox2.Location = new System.Drawing.Point(11, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 419);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Most loyal customers";
            // 
            // dgvLoyalCustomers
            // 
            this.dgvLoyalCustomers.AllowUserToAddRows = false;
            this.dgvLoyalCustomers.AllowUserToDeleteRows = false;
            this.dgvLoyalCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLoyalCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Customer,
            this.NumberOfPurchases,
            this.NumberOfAppointments,
            this.AmountSpent});
            this.dgvLoyalCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLoyalCustomers.Location = new System.Drawing.Point(3, 23);
            this.dgvLoyalCustomers.Name = "dgvLoyalCustomers";
            this.dgvLoyalCustomers.ReadOnly = true;
            this.dgvLoyalCustomers.RowHeadersVisible = false;
            this.dgvLoyalCustomers.RowHeadersWidth = 51;
            this.dgvLoyalCustomers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLoyalCustomers.Size = new System.Drawing.Size(479, 393);
            this.dgvLoyalCustomers.TabIndex = 0;
            this.dgvLoyalCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLoyalCustomers_CellClick);
            // 
            // Customer
            // 
            this.Customer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Customer.DataPropertyName = "Customer";
            this.Customer.HeaderText = "Customer";
            this.Customer.MinimumWidth = 6;
            this.Customer.Name = "Customer";
            this.Customer.ReadOnly = true;
            // 
            // NumberOfPurchases
            // 
            this.NumberOfPurchases.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumberOfPurchases.DataPropertyName = "NumberOfPurchases";
            this.NumberOfPurchases.HeaderText = "No. of purchases";
            this.NumberOfPurchases.MinimumWidth = 6;
            this.NumberOfPurchases.Name = "NumberOfPurchases";
            this.NumberOfPurchases.ReadOnly = true;
            // 
            // NumberOfAppointments
            // 
            this.NumberOfAppointments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumberOfAppointments.DataPropertyName = "NumberOfAppointments";
            this.NumberOfAppointments.HeaderText = "No. of appointments";
            this.NumberOfAppointments.MinimumWidth = 6;
            this.NumberOfAppointments.Name = "NumberOfAppointments";
            this.NumberOfAppointments.ReadOnly = true;
            // 
            // AmountSpent
            // 
            this.AmountSpent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AmountSpent.DataPropertyName = "AmountSpent";
            this.AmountSpent.HeaderText = "Amount spent (KM)";
            this.AmountSpent.MinimumWidth = 6;
            this.AmountSpent.Name = "AmountSpent";
            this.AmountSpent.ReadOnly = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudDiscount);
            this.groupBox1.Controls.Add(this.btnDiscount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(9, 34);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(911, 74);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // nudDiscount
            // 
            this.nudDiscount.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudDiscount.Location = new System.Drawing.Point(354, 27);
            this.nudDiscount.Maximum = new decimal(new int[] {
            75,
            0,
            0,
            0});
            this.nudDiscount.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudDiscount.Name = "nudDiscount";
            this.nudDiscount.Size = new System.Drawing.Size(266, 27);
            this.nudDiscount.TabIndex = 6;
            this.nudDiscount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnDiscount
            // 
            this.btnDiscount.Enabled = false;
            this.btnDiscount.Location = new System.Drawing.Point(676, 26);
            this.btnDiscount.Name = "btnDiscount";
            this.btnDiscount.Size = new System.Drawing.Size(189, 29);
            this.btnDiscount.TabIndex = 2;
            this.btnDiscount.Text = "Gift discount coupon";
            this.btnDiscount.UseVisualStyleBackColor = true;
            this.btnDiscount.Click += new System.EventHandler(this.btnDiscount_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(263, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Discount:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(333, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "Top 10 most loyal customers";
            // 
            // frmLoyalCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 538);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.formsPlot);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmLoyalCustomers";
            this.Text = "Top 10 most loyal customers";
            this.Load += new System.EventHandler(this.frmLoyalCustomers_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLoyalCustomers)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDiscount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.FormsPlot formsPlot;
        private GroupBox groupBox2;
        private DataGridView dgvLoyalCustomers;
        private GroupBox groupBox1;
        private NumericUpDown nudDiscount;
        private Button btnDiscount;
        private Label label1;
        private Label label2;
        private DataGridViewTextBoxColumn Customer;
        private DataGridViewTextBoxColumn NumberOfPurchases;
        private DataGridViewTextBoxColumn NumberOfAppointments;
        private DataGridViewTextBoxColumn AmountSpent;
    }
}