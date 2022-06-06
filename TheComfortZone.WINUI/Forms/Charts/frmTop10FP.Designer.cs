namespace TheComfortZone.WINUI.Forms.Charts
{
    partial class frmTop10FP
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbSpace = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // formsPlot
            // 
            this.formsPlot.BackColor = System.Drawing.SystemColors.Control;
            this.formsPlot.Location = new System.Drawing.Point(8, 27);
            this.formsPlot.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.formsPlot.Name = "formsPlot";
            this.formsPlot.Size = new System.Drawing.Size(894, 400);
            this.formsPlot.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(303, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(313, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Top 10 best selling furniture pieces";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.formsPlot);
            this.groupBox2.Location = new System.Drawing.Point(16, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(904, 434);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Line chart";
            // 
            // cmbSpace
            // 
            this.cmbSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpace.FormattingEnabled = true;
            this.cmbSpace.Location = new System.Drawing.Point(303, 57);
            this.cmbSpace.Name = "cmbSpace";
            this.cmbSpace.Size = new System.Drawing.Size(313, 28);
            this.cmbSpace.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 20);
            this.label2.TabIndex = 51;
            this.label2.Text = "Space:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(714, 57);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 29);
            this.btnSearch.TabIndex = 53;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // frmTop10FP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 538);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cmbSpace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label1);
            this.Name = "frmTop10FP";
            this.Text = "Top 10 best selling furniture pieces";
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ScottPlot.FormsPlot formsPlot;
        private Label label1;
        private GroupBox groupBox2;
        private ComboBox cmbSpace;
        private Label label2;
        private Button btnSearch;
    }
}