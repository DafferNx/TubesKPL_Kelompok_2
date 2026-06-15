namespace GUI
{
    partial class Wallet
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
            lblBalance = new Label();
            lblWalletStatus = new Label();
            btnActivate = new Button();
            tbTopUp = new TextBox();
            btnTopUp = new Button();
            btnRefresh = new Button();
            pnlCard = new Panel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(30, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(162, 54);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "WALLET";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblBalance.ForeColor = Color.FromArgb(180, 180, 180);
            lblBalance.Location = new Point(30, 100);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(123, 37);
            lblBalance.TabIndex = 1;
            lblBalance.Text = "Balance:";
            // 
            // lblWalletStatus
            // 
            lblWalletStatus.AutoSize = true;
            lblWalletStatus.Font = new Font("Segoe UI", 12F);
            lblWalletStatus.ForeColor = Color.FromArgb(180, 180, 180);
            lblWalletStatus.Location = new Point(32, 155);
            lblWalletStatus.Name = "lblWalletStatus";
            lblWalletStatus.Size = new Size(127, 28);
            lblWalletStatus.TabIndex = 2;
            lblWalletStatus.Text = "Wallet Status:";
            // 
            // btnActivate
            // 
            btnActivate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnActivate.BackColor = Color.FromArgb(60, 60, 60);
            btnActivate.FlatAppearance.BorderSize = 0;
            btnActivate.FlatStyle = FlatStyle.Flat;
            btnActivate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnActivate.ForeColor = Color.White;
            btnActivate.Location = new Point(30, 215);
            btnActivate.Name = "btnActivate";
            btnActivate.Size = new Size(577, 45);
            btnActivate.TabIndex = 3;
            btnActivate.UseVisualStyleBackColor = false;
            // 
            // tbTopUp
            // 
            tbTopUp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tbTopUp.BackColor = Color.FromArgb(50, 50, 50);
            tbTopUp.BorderStyle = BorderStyle.FixedSingle;
            tbTopUp.Font = new Font("Segoe UI", 12F);
            tbTopUp.ForeColor = Color.White;
            tbTopUp.Location = new Point(30, 285);
            tbTopUp.Name = "tbTopUp";
            tbTopUp.PlaceholderText = "Jumlah Top Up";
            tbTopUp.Size = new Size(370, 34);
            tbTopUp.TabIndex = 4;
            // 
            // btnTopUp
            // 
            btnTopUp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTopUp.BackColor = Color.FromArgb(0, 120, 215);
            btnTopUp.FlatAppearance.BorderSize = 0;
            btnTopUp.FlatStyle = FlatStyle.Flat;
            btnTopUp.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTopUp.ForeColor = Color.White;
            btnTopUp.Location = new Point(415, 283);
            btnTopUp.Name = "btnTopUp";
            btnTopUp.Size = new Size(192, 40);
            btnTopUp.TabIndex = 5;
            btnTopUp.Text = "Top Up";
            btnTopUp.UseVisualStyleBackColor = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRefresh.BackColor = Color.FromArgb(60, 60, 60);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 10F);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(30, 385);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 40);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            // 
            // Wallet
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 28);
            Controls.Add(btnRefresh);
            Controls.Add(btnTopUp);
            Controls.Add(tbTopUp);
            Controls.Add(btnActivate);
            Controls.Add(lblWalletStatus);
            Controls.Add(lblBalance);
            Controls.Add(lblTitle);
            Name = "Wallet";
            Size = new Size(637, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblBalance;
        private Label lblWalletStatus;
        private Button btnActivate;
        private TextBox tbTopUp;
        private Button btnTopUp;
        private Button btnRefresh;
        private Panel pnlCard;
    }
}
