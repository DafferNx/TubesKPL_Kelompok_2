namespace GUI
{
    partial class Store
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
            lblWallet = new Label();
            dgvGames = new DataGridView();
            btnBuy = new Button();
            btnAddToCart = new Button();
            btnRefresh = new Button();
            btnToggleWallet = new Button();
            tbTopUp = new TextBox();
            btnTopUp = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(98, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "STORE";
            // 
            // lblWallet
            // 
            lblWallet.AutoSize = true;
            lblWallet.Font = new Font("Segoe UI", 10F);
            lblWallet.Location = new Point(20, 55);
            lblWallet.Name = "lblWallet";
            lblWallet.Size = new Size(89, 28);
            lblWallet.TabIndex = 1;
            lblWallet.Text = "Wallet: ...";
            // 
            // dgvGames
            // 
            dgvGames.AllowUserToAddRows = false;
            dgvGames.AllowUserToDeleteRows = false;
            dgvGames.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGames.Location = new Point(20, 85);
            dgvGames.MultiSelect = false;
            dgvGames.Name = "dgvGames";
            dgvGames.ReadOnly = true;
            dgvGames.RowHeadersVisible = false;
            dgvGames.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGames.Size = new Size(580, 200);
            dgvGames.TabIndex = 2;
            dgvGames.Columns.Add("Id", "ID");
            dgvGames.Columns.Add("Name", "Nama");
            dgvGames.Columns.Add("Price", "Harga");
            // 
            // btnBuy
            // 
            btnBuy.Location = new Point(20, 300);
            btnBuy.Name = "btnBuy";
            btnBuy.Size = new Size(100, 35);
            btnBuy.TabIndex = 3;
            btnBuy.Text = "Beli";
            btnBuy.UseVisualStyleBackColor = true;
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new Point(130, 300);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(100, 35);
            btnAddToCart.TabIndex = 4;
            btnAddToCart.Text = "Add to Cart";
            btnAddToCart.UseVisualStyleBackColor = true;
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
            // btnToggleWallet
            // 
            btnToggleWallet.Location = new Point(20, 350);
            btnToggleWallet.Name = "btnToggleWallet";
            btnToggleWallet.Size = new Size(160, 35);
            btnToggleWallet.TabIndex = 6;
            btnToggleWallet.UseVisualStyleBackColor = true;
            // 
            // tbTopUp
            // 
            tbTopUp.Location = new Point(20, 400);
            tbTopUp.Name = "tbTopUp";
            tbTopUp.PlaceholderText = "Jumlah";
            tbTopUp.Size = new Size(100, 31);
            tbTopUp.TabIndex = 7;
            // 
            // btnTopUp
            // 
            btnTopUp.Location = new Point(130, 398);
            btnTopUp.Name = "btnTopUp";
            btnTopUp.Size = new Size(100, 35);
            btnTopUp.TabIndex = 8;
            btnTopUp.Text = "Top Up";
            btnTopUp.UseVisualStyleBackColor = true;
            // 
            // Store
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            Controls.Add(btnTopUp);
            Controls.Add(tbTopUp);
            Controls.Add(btnToggleWallet);
            Controls.Add(btnRefresh);
            Controls.Add(btnAddToCart);
            Controls.Add(btnBuy);
            Controls.Add(dgvGames);
            Controls.Add(lblWallet);
            Controls.Add(lblTitle);
            Name = "Store";
            Size = new Size(637, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblWallet;
        private DataGridView dgvGames;
        private Button btnBuy;
        private Button btnAddToCart;
        private Button btnRefresh;
        private Button btnToggleWallet;
        private TextBox tbTopUp;
        private Button btnTopUp;
    }
}
