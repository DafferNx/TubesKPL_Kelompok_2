namespace GUI.Forms
{
    partial class AdminForm
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
            NavPanel = new Panel();
            PagePanel = new Panel();
            btnGameManagement = new Button();
            btnRefundManagement = new Button();
            btnWalletManagement = new Button();
            btnLogout = new Button();
            NavPanel.SuspendLayout();
            SuspendLayout();
            // 
            // NavPanel
            // 
            NavPanel.Controls.Add(btnLogout);
            NavPanel.Controls.Add(btnWalletManagement);
            NavPanel.Controls.Add(btnRefundManagement);
            NavPanel.Controls.Add(btnGameManagement);
            NavPanel.Dock = DockStyle.Left;
            NavPanel.Location = new Point(0, 0);
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(163, 450);
            NavPanel.TabIndex = 0;
            // 
            // PagePanel
            // 
            PagePanel.Dock = DockStyle.Fill;
            PagePanel.Location = new Point(163, 0);
            PagePanel.Name = "PagePanel";
            PagePanel.Size = new Size(637, 450);
            PagePanel.TabIndex = 1;
            // 
            // btnGameManagement
            // 
            btnGameManagement.Location = new Point(24, 22);
            btnGameManagement.Name = "btnGameManagement";
            btnGameManagement.Size = new Size(112, 34);
            btnGameManagement.TabIndex = 0;
            btnGameManagement.Text = "Game";
            btnGameManagement.UseVisualStyleBackColor = true;
            // 
            // btnRefundManagement
            // 
            btnRefundManagement.Location = new Point(24, 78);
            btnRefundManagement.Name = "btnRefundManagement";
            btnRefundManagement.Size = new Size(112, 34);
            btnRefundManagement.TabIndex = 1;
            btnRefundManagement.Text = "Refund";
            btnRefundManagement.UseVisualStyleBackColor = true;
            // 
            // btnWalletManagement
            // 
            btnWalletManagement.Location = new Point(24, 141);
            btnWalletManagement.Name = "btnWalletManagement";
            btnWalletManagement.Size = new Size(112, 34);
            btnWalletManagement.TabIndex = 2;
            btnWalletManagement.Text = "Wallet";
            btnWalletManagement.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(24, 360);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PagePanel);
            Controls.Add(NavPanel);
            Name = "AdminForm";
            Text = "AdminForm";
            NavPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel NavPanel;
        private Button btnLogout;
        private Button btnWalletManagement;
        private Button btnRefundManagement;
        private Button btnGameManagement;
        private Panel PagePanel;
    }
}
