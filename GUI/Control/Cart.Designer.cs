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
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(88, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "CART";
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F);
            lblTotal.Location = new Point(20, 55);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(55, 28);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total:";
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(20, 85);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(580, 200);
            dgvCart.TabIndex = 2;
            dgvCart.Columns.Add("Id", "ID");
            dgvCart.Columns.Add("Name", "Nama");
            dgvCart.Columns.Add("Price", "Harga");
            // 
            // btnCheckout
            // 
            btnCheckout.Location = new Point(20, 300);
            btnCheckout.Name = "btnCheckout";
            btnCheckout.Size = new Size(100, 35);
            btnCheckout.TabIndex = 3;
            btnCheckout.Text = "Checkout";
            btnCheckout.UseVisualStyleBackColor = true;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(130, 300);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(100, 35);
            btnRemove.TabIndex = 4;
            btnRemove.Text = "Hapus";
            btnRemove.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(240, 300);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.TabIndex = 5;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // Cart
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRefresh);
            Controls.Add(btnRemove);
            Controls.Add(btnCheckout);
            Controls.Add(dgvCart);
            Controls.Add(lblTotal);
            Controls.Add(lblTitle);
            Name = "Cart";
            Size = new Size(637, 450);
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
