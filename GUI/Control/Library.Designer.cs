namespace GUI
{
    partial class Library
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            dgvLibrary = new DataGridView();
            btnRefund = new Button();
            btnRefresh = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(132, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "LIBRARY";
            // 
            // dgvLibrary
            // 
            dgvLibrary.AllowUserToAddRows = false;
            dgvLibrary.AllowUserToDeleteRows = false;
            dgvLibrary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibrary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibrary.Location = new Point(20, 55);
            dgvLibrary.MultiSelect = false;
            dgvLibrary.Name = "dgvLibrary";
            dgvLibrary.ReadOnly = true;
            dgvLibrary.RowHeadersVisible = false;
            dgvLibrary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibrary.Size = new Size(580, 250);
            dgvLibrary.TabIndex = 1;
            dgvLibrary.Columns.Add("Id", "ID");
            dgvLibrary.Columns.Add("Name", "Nama");
            dgvLibrary.Columns.Add("Price", "Harga");
            dgvLibrary.Columns.Add("Status", "Status");
            // 
            // btnRefund
            // 
            btnRefund.Location = new Point(20, 320);
            btnRefund.Name = "btnRefund";
            btnRefund.Size = new Size(120, 35);
            btnRefund.TabIndex = 2;
            btnRefund.Text = "Ajukan Refund";
            btnRefund.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(150, 320);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // Library
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(btnRefresh);
            Controls.Add(btnRefund);
            Controls.Add(dgvLibrary);
            Controls.Add(lblTitle);
            Name = "Library";
            Size = new Size(637, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private DataGridView dgvLibrary;
        private Button btnRefund;
        private Button btnRefresh;
    }
}
