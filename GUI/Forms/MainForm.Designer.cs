namespace GUI.Forms
{
    partial class MainForm
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
            btnStore = new Button();
            btnLibrary = new Button();
            btnWallet = new Button();
            btnCart = new Button();
            btnLogout = new Button();
            PagePanel = new Panel();
            NavPanel.SuspendLayout();
            SuspendLayout();
            // 
            // NavPanel
            // 
            NavPanel.BackColor = Color.FromArgb(28, 28, 28);
            NavPanel.Controls.Add(btnStore);
            NavPanel.Controls.Add(btnLibrary);
            NavPanel.Controls.Add(btnWallet);
            NavPanel.Controls.Add(btnCart);
            NavPanel.Controls.Add(btnLogout);
            NavPanel.Dock = DockStyle.Left;
            NavPanel.Name = "NavPanel";
            NavPanel.Size = new Size(180, 520);
            NavPanel.TabIndex = 0;
            // 
            // btnStore
            // 
            btnStore.BackColor = Color.FromArgb(45, 45, 45);
            btnStore.FlatAppearance.BorderSize = 0;
            btnStore.FlatStyle = FlatStyle.Flat;
            btnStore.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnStore.ForeColor = Color.White;
            btnStore.Location = new Point(20, 25);
            btnStore.Name = "btnStore";
            btnStore.Size = new Size(140, 45);
            btnStore.TabIndex = 0;
            btnStore.Text = "Store";
            btnStore.UseVisualStyleBackColor = false;
            // 
            // btnLibrary
            // 
            btnLibrary.BackColor = Color.FromArgb(45, 45, 45);
            btnLibrary.FlatAppearance.BorderSize = 0;
            btnLibrary.FlatStyle = FlatStyle.Flat;
            btnLibrary.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLibrary.ForeColor = Color.White;
            btnLibrary.Location = new Point(20, 85);
            btnLibrary.Name = "btnLibrary";
            btnLibrary.Size = new Size(140, 45);
            btnLibrary.TabIndex = 1;
            btnLibrary.Text = "Library";
            btnLibrary.UseVisualStyleBackColor = false;
            // 
            // btnWallet
            // 
            btnWallet.BackColor = Color.FromArgb(45, 45, 45);
            btnWallet.FlatAppearance.BorderSize = 0;
            btnWallet.FlatStyle = FlatStyle.Flat;
            btnWallet.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnWallet.ForeColor = Color.White;
            btnWallet.Location = new Point(20, 145);
            btnWallet.Name = "btnWallet";
            btnWallet.Size = new Size(140, 45);
            btnWallet.TabIndex = 2;
            btnWallet.Text = "Wallet";
            btnWallet.UseVisualStyleBackColor = false;
            // 
            // btnCart
            // 
            btnCart.BackColor = Color.FromArgb(45, 45, 45);
            btnCart.FlatAppearance.BorderSize = 0;
            btnCart.FlatStyle = FlatStyle.Flat;
            btnCart.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnCart.ForeColor = Color.White;
            btnCart.Location = new Point(20, 205);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(140, 45);
            btnCart.TabIndex = 3;
            btnCart.Text = "Cart";
            btnCart.UseVisualStyleBackColor = false;
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
            btnLogout.TabIndex = 4;
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 28);
            ClientSize = new Size(800, 520);
            Controls.Add(PagePanel);
            Controls.Add(NavPanel);
            MinimumSize = new Size(640, 400);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SETIM";
            NavPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel NavPanel;
        private Button btnStore;
        private Button btnLibrary;
        private Button btnWallet;
        private Button btnCart;
        private Button btnLogout;
        private Panel PagePanel;
    }
}
