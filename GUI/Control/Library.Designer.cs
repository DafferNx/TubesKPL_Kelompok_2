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
            ((System.ComponentModel.ISupportInitialize)dgvLibrary).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 150, 255);
            lblTitle.Location = new Point(30, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "LIBRARY";
            // 
            // dgvLibrary
            // 
            dgvLibrary.AllowUserToAddRows = false;
            dgvLibrary.AllowUserToDeleteRows = false;
            dgvLibrary.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLibrary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLibrary.BackgroundColor = Color.FromArgb(35, 35, 35);
            dgvLibrary.BorderStyle = BorderStyle.None;
            dgvLibrary.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLibrary.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLibrary.ColumnHeadersHeight = 40;
            dgvLibrary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLibrary.EnableHeadersVisualStyles = false;
            dgvLibrary.GridColor = Color.FromArgb(50, 50, 50);
            dgvLibrary.Location = new Point(30, 100);
            dgvLibrary.MultiSelect = false;
            dgvLibrary.Name = "dgvLibrary";
            dgvLibrary.ReadOnly = true;
            dgvLibrary.RowHeadersVisible = false;
            dgvLibrary.RowTemplate.Height = 38;
            dgvLibrary.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLibrary.Size = new Size(577, 240);
            dgvLibrary.TabIndex = 1;
            dgvLibrary.Columns.Add("Id", "ID");
            dgvLibrary.Columns.Add("Name", "Nama");
            dgvLibrary.Columns.Add("Price", "Harga");
            dgvLibrary.Columns.Add("Status", "Status");
            // 
            // btnRefund
            // 
            btnRefund.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefund.BackColor = Color.FromArgb(180, 70, 70);
            btnRefund.FlatAppearance.BorderSize = 0;
            btnRefund.FlatStyle = FlatStyle.Flat;
            btnRefund.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRefund.ForeColor = Color.White;
            btnRefund.Location = new Point(30, 365);
            btnRefund.Name = "btnRefund";
            btnRefund.Size = new Size(160, 50);
            btnRefund.TabIndex = 2;
            btnRefund.Text = "Ajukan Refund";
            btnRefund.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(60, 60, 60);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(507, 33);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 40);
            btnRefresh.TabIndex = 3;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // Library
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 28);
            Controls.Add(btnRefresh);
            Controls.Add(btnRefund);
            Controls.Add(dgvLibrary);
            Controls.Add(lblTitle);
            Name = "Library";
            Size = new Size(637, 450);
            ((System.ComponentModel.ISupportInitialize)dgvLibrary).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private DataGridView dgvLibrary;
        private Button btnRefund;
        private Button btnRefresh;
    }
}
