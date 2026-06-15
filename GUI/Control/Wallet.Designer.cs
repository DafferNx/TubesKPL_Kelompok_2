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
            lblState = new Label();
            btnActivate = new Button();
            tbTopUp = new TextBox();
            btnTopUp = new Button();
            btnRefresh = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(122, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "WALLET";
            // 
            // lblBalance
            // 
            lblBalance.AutoSize = true;
            lblBalance.Font = new Font("Segoe UI", 12F);
            lblBalance.ForeColor = Color.White;
            lblBalance.Location = new Point(20, 60);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(92, 32);
            lblBalance.TabIndex = 1;
            lblBalance.Text = "Balance:";
            // 
            // lblState
            // 
            lblState.AutoSize = true;
            lblState.Font = new Font("Segoe UI", 12F);
            lblState.ForeColor = Color.White;
            lblState.Location = new Point(20, 100);
            lblState.Name = "lblState";
            lblState.Size = new Size(66, 32);
            lblState.TabIndex = 2;
            lblState.Text = "State:";
            // 
            // btnActivate
            // 
            btnActivate.Location = new Point(20, 150);
            btnActivate.Name = "btnActivate";
            btnActivate.Size = new Size(160, 35);
            btnActivate.TabIndex = 3;
            btnActivate.UseVisualStyleBackColor = true;
            // 
            // tbTopUp
            // 
            tbTopUp.Location = new Point(20, 210);
            tbTopUp.Name = "tbTopUp";
            tbTopUp.PlaceholderText = "Jumlah";
            tbTopUp.Size = new Size(120, 31);
            tbTopUp.TabIndex = 4;
            // 
            // btnTopUp
            // 
            btnTopUp.Location = new Point(150, 208);
            btnTopUp.Name = "btnTopUp";
            btnTopUp.Size = new Size(100, 35);
            btnTopUp.TabIndex = 5;
            btnTopUp.Text = "Top Up";
            btnTopUp.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(20, 260);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.TabIndex = 6;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // Wallet
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            Controls.Add(btnRefresh);
            Controls.Add(btnTopUp);
            Controls.Add(tbTopUp);
            Controls.Add(btnActivate);
            Controls.Add(lblState);
            Controls.Add(lblBalance);
            Controls.Add(lblTitle);
            Name = "Wallet";
            Size = new Size(637, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblBalance;
        private Label lblState;
        private Button btnActivate;
        private TextBox tbTopUp;
        private Button btnTopUp;
        private Button btnRefresh;
    }
}
