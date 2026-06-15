namespace GUI.Forms
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            NavPanel = new Panel();
            btnGameManagement = new Button();
            btnRefundManagement = new Button();
            btnWalletManagement = new Button();
            btnLogout = new Button();
            PagePanel = new Panel();
            NavPanel.SuspendLayout();
            SuspendLayout();
            // 
            // NavPanel
            // 
            NavPanel.BackColor = Color.FromArgb(28, 28, 28);
            NavPanel.Controls.Add(btnGameManagement);
            NavPanel.Controls.Add(btnRefundManagement);
            NavPanel.Controls.Add(btnWalletManagement);
            NavPanel.Controls.Add(btnLogout);
            NavPanel.Dock = DockStyle.Left;
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(180, 520);
            NavPanel.TabIndex = 0;
            // 
            // btnGameManagement
            // 
            btnGameManagement.BackColor = Color.FromArgb(45, 45, 45);
            btnGameManagement.FlatAppearance.BorderSize = 0;
            btnGameManagement.FlatStyle = FlatStyle.Flat;
            btnGameManagement.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnGameManagement.ForeColor = Color.White;
            btnGameManagement.Location = new Point(20, 25);
            btnGameManagement.Name = "btnGameManagement";
            btnGameManagement.Size = new Size(140, 45);
            btnGameManagement.TabIndex = 0;
            btnGameManagement.Text = "Game";
            btnGameManagement.UseVisualStyleBackColor = false;
            // 
            // btnRefundManagement
            // 
            btnRefundManagement.BackColor = Color.FromArgb(45, 45, 45);
            btnRefundManagement.FlatAppearance.BorderSize = 0;
            btnRefundManagement.FlatStyle = FlatStyle.Flat;
            btnRefundManagement.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnRefundManagement.ForeColor = Color.White;
            btnRefundManagement.Location = new Point(20, 85);
            btnRefundManagement.Name = "btnRefundManagement";
            btnRefundManagement.Size = new Size(140, 45);
            btnRefundManagement.TabIndex = 1;
            btnRefundManagement.Text = "Refund";
            btnRefundManagement.UseVisualStyleBackColor = false;
            // 
            // btnWalletManagement
            // 
            btnWalletManagement.BackColor = Color.FromArgb(45, 45, 45);
            btnWalletManagement.FlatAppearance.BorderSize = 0;
            btnWalletManagement.FlatStyle = FlatStyle.Flat;
            btnWalletManagement.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnWalletManagement.ForeColor = Color.White;
            btnWalletManagement.Location = new Point(20, 145);
            btnWalletManagement.Name = "btnWalletManagement";
            btnWalletManagement.Size = new Size(140, 45);
            btnWalletManagement.TabIndex = 2;
            btnWalletManagement.Text = "Wallet";
            btnWalletManagement.UseVisualStyleBackColor = false;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnLogout.BackColor = Color.FromArgb(60, 60, 60);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogout.ForeColor = Color.FromArgb(200, 200, 200);
            btnLogout.Location = new Point(20, 450);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(140, 45);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // PagePanel
            // 
            PagePanel.BackColor = Color.FromArgb(28, 28, 28);
            PagePanel.Dock = DockStyle.Fill;
            PagePanel.Name = "PagePanel";
            PagePanel.Size = new Size(620, 520);
            PagePanel.TabIndex = 1;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 28);
            ClientSize = new Size(800, 520);
            Controls.Add(PagePanel);
            Controls.Add(NavPanel);
            MinimumSize = new Size(640, 400);
            Name = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SETIM - Admin";
            NavPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel NavPanel;
        private Button btnGameManagement;
        private Button btnRefundManagement;
        private Button btnWalletManagement;
        private Button btnLogout;
        private Panel PagePanel;
    }
}
