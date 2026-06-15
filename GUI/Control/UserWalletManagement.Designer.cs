namespace GUI.Control
{
    partial class UserWalletManagement
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
            dgvUsers = new DataGridView();
            btnBan = new Button();
            btnUnban = new Button();
            btnRefresh = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(280, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "WALLET MANAGEMENT";
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsers.Location = new Point(20, 55);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(580, 250);
            dgvUsers.TabIndex = 1;
            dgvUsers.Columns.Add("Id", "ID");
            dgvUsers.Columns.Add("Username", "Username");
            dgvUsers.Columns.Add("Role", "Role");
            dgvUsers.Columns.Add("Balance", "Balance");
            dgvUsers.Columns.Add("State", "State");
            // 
            // btnBan
            // 
            btnBan.Location = new Point(20, 320);
            btnBan.Name = "btnBan";
            btnBan.Size = new Size(100, 35);
            btnBan.TabIndex = 2;
            btnBan.Text = "Ban Wallet";
            btnBan.UseVisualStyleBackColor = true;
            // 
            // btnUnban
            // 
            btnUnban.Location = new Point(130, 320);
            btnUnban.Name = "btnUnban";
            btnUnban.Size = new Size(100, 35);
            btnUnban.TabIndex = 3;
            btnUnban.Text = "Unban Wallet";
            btnUnban.UseVisualStyleBackColor = true;
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
            // UserWalletManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRefresh);
            Controls.Add(btnUnban);
            Controls.Add(btnBan);
            Controls.Add(dgvUsers);
            Controls.Add(lblTitle);
            Name = "UserWalletManagement";
            Size = new Size(637, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private DataGridView dgvUsers;
        private Button btnBan;
        private Button btnUnban;
        private Button btnRefresh;
    }
}
