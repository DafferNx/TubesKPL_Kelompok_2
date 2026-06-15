namespace GUI.Control
{
    partial class RefundManagement
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
            dgvRefunds = new DataGridView();
            btnApprove = new Button();
            btnReject = new Button();
            btnRefresh = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(311, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "REFUND MANAGEMENT";
            // 
            // dgvRefunds
            // 
            dgvRefunds.AllowUserToAddRows = false;
            dgvRefunds.AllowUserToDeleteRows = false;
            dgvRefunds.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRefunds.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRefunds.Location = new Point(20, 55);
            dgvRefunds.MultiSelect = false;
            dgvRefunds.Name = "dgvRefunds";
            dgvRefunds.ReadOnly = true;
            dgvRefunds.RowHeadersVisible = false;
            dgvRefunds.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRefunds.Size = new Size(580, 250);
            dgvRefunds.TabIndex = 1;
            dgvRefunds.Columns.Add("UserId", "User ID");
            dgvRefunds.Columns.Add("Id", "Game ID");
            dgvRefunds.Columns.Add("Name", "Nama");
            dgvRefunds.Columns.Add("Price", "Harga");
            // 
            // btnApprove
            // 
            btnApprove.Location = new Point(20, 320);
            btnApprove.Name = "btnApprove";
            btnApprove.Size = new Size(100, 35);
            btnApprove.TabIndex = 2;
            btnApprove.Text = "Approve";
            btnApprove.UseVisualStyleBackColor = true;
            // 
            // btnReject
            // 
            btnReject.Location = new Point(130, 320);
            btnReject.Name = "btnReject";
            btnReject.Size = new Size(100, 35);
            btnReject.TabIndex = 3;
            btnReject.Text = "Reject";
            btnReject.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(240, 320);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // RefundManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRefresh);
            Controls.Add(btnReject);
            Controls.Add(btnApprove);
            Controls.Add(dgvRefunds);
            Controls.Add(lblTitle);
            Name = "RefundManagement";
            Size = new Size(637, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private DataGridView dgvRefunds;
        private Button btnApprove;
        private Button btnReject;
        private Button btnRefresh;
    }
}
