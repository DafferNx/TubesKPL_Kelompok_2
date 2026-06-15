namespace GUI
{
    partial class Cart
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
            lblTotal = new Label();
            dgvCart = new DataGridView();
            btnCheckout = new Button();
            btnRemove = new Button();
            btnRefresh = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 150, 255);
            lblTitle.Location = new Point(30, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(120, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CART";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(180, 180, 180);
            lblTotal.Location = new Point(30, 95);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(78, 37);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total:";
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.BackgroundColor = Color.FromArgb(35, 35, 35);
            dgvCart.BorderStyle = BorderStyle.None;
            dgvCart.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvCart.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvCart.ColumnHeadersHeight = 40;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvCart.EnableHeadersVisualStyles = false;
            dgvCart.GridColor = Color.FromArgb(50, 50, 50);
            dgvCart.Location = new Point(30, 145);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.RowTemplate.Height = 38;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(577, 185);
            dgvCart.TabIndex = 2;
            dgvCart.Columns.Add("Id", "ID");
            dgvCart.Columns.Add("Name", "Nama");
            dgvCart.Columns.Add("Price", "Harga");
            // 
            // btnCheckout
            // 
            btnCheckout.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCheckout.BackColor = Color.FromArgb(0, 140, 90);
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCheckout.ForeColor = Color.White;
            btnCheckout.Location = new Point(467, 350);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(140, 50);
            btnCheckout.TabIndex = 3;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = false;
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRemove.BackColor = Color.FromArgb(180, 70, 70);
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(30, 350);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(140, 50);
            btnRemove.TabIndex = 4;
            btnRemove.Text = "Hapus";
            btnRemove.UseVisualStyleBackColor = false;
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
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // Cart
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 28);
            Controls.Add(btnRefresh);
            Controls.Add(btnRemove);
            Controls.Add(btnCheckout);
            Controls.Add(dgvCart);
            Controls.Add(lblTotal);
            Controls.Add(lblTitle);
            Name = "Cart";
            Size = new Size(637, 450);
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblTotal;
        private DataGridView dgvCart;
        private Button btnCheckout;
        private Button btnRemove;
        private Button btnRefresh;
    }
}
