namespace TheComfortZone.WINUI.Forms.Charts
{
    partial class frmRevenue
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
            this.dgvIncome = new System.Windows.Forms.DataGridView();
            this.formsPlot = new ScottPlot.FormsPlot();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfSalesMade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumberOfAppointments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Income = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvIncome);
            this.groupBox2.Location = new System.Drawing.Point(11, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 420);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Revenue";
            // 
            // dgvIncome
            // 
            this.dgvIncome.AllowUserToAddRows = false;
            this.dgvIncome.AllowUserToDeleteRows = false;
            this.dgvIncome.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncome.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Employee,
            this.NumberOfSalesMade,
            this.NumberOfAppointments,
            this.Income});
            this.dgvIncome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIncome.Location = new System.Drawing.Point(3, 23);
            this.dgvIncome.Name = "dgvIncome";
            this.dgvIncome.ReadOnly = true;
            this.dgvIncome.RowHeadersVisible = false;
            this.dgvIncome.RowHeadersWidth = 51;
            this.dgvIncome.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncome.Size = new System.Drawing.Size(479, 394);
            this.dgvIncome.TabIndex = 0;
            // 
            // formsPlot
            // 
            this.formsPlot.Location = new System.Drawing.Point(501, 113);
            this.formsPlot.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.formsPlot.Name = "formsPlot";
            this.formsPlot.Size = new System.Drawing.Size(421, 419);
            this.formsPlot.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClearSearch);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(911, 94);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search (optional)";
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Enabled = false;
            this.btnClearSearch.Location = new System.Drawing.Point(769, 37);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(127, 29);
            this.btnClearSearch.TabIndex = 4;
            this.btnClearSearch.Text = "Clear search";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(374, 38);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(265, 27);
            this.dtpToDate.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "To:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(669, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 29);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "From:";
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(59, 38);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(265, 27);
            this.dtpFromDate.TabIndex = 0;
            // 
            // Employee
            // 
            this.Employee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Employee.DataPropertyName = "Employee";
            this.Employee.HeaderText = "Employee";
            this.Employee.MinimumWidth = 6;
            this.Employee.Name = "Employee";
            this.Employee.ReadOnly = true;
            // 
            // NumberOfSalesMade
            // 
            this.NumberOfSalesMade.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumberOfSalesMade.DataPropertyName = "NumberOfSalesMade";
            this.NumberOfSalesMade.HeaderText = "No. of sales";
            this.NumberOfSalesMade.MinimumWidth = 6;
            this.NumberOfSalesMade.Name = "NumberOfSalesMade";
            this.NumberOfSalesMade.ReadOnly = true;
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
            // Income
            // 
            this.Income.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Income.DataPropertyName = "Income";
            this.Income.HeaderText = "Revenue (KM)";
            this.Income.MinimumWidth = 6;
            this.Income.Name = "Income";
            this.Income.ReadOnly = true;
            // 
            // frmRevenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 538);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.formsPlot);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmRevenue";
            this.Text = "Revenue per employee";
            this.Load += new System.EventHandler(this.frmIncome_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncome)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox2;
        private DataGridView dgvIncome;
        private ScottPlot.FormsPlot formsPlot;
        private GroupBox groupBox1;
        private Button btnClearSearch;
        private DateTimePicker dtpToDate;
        private Label label2;
        private Button btnSearch;
        private Label label1;
        private DateTimePicker dtpFromDate;
        private DataGridViewTextBoxColumn Employee;
        private DataGridViewTextBoxColumn NumberOfSalesMade;
        private DataGridViewTextBoxColumn NumberOfAppointments;
        private DataGridViewTextBoxColumn Income;
    }
}