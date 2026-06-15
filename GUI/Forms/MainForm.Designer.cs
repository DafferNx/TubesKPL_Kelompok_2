namespace GUI.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NavPanel = new Panel();
            PagePanel = new Panel();
            btnStore = new Button();
            btnLibrary = new Button();
            btnWallet = new Button();
            btnCart = new Button();
            btnLogout = new Button();
            NavPanel.SuspendLayout();
            SuspendLayout();
            // 
            // NavPanel
            // 
            NavPanel.Controls.Add(btnLogout);
            NavPanel.Controls.Add(btnCart);
            NavPanel.Controls.Add(btnWallet);
            NavPanel.Controls.Add(btnLibrary);
            NavPanel.Controls.Add(btnStore);
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
            // btnStore
            // 
            btnStore.Location = new Point(24, 22);
            btnStore.Name = "btnStore";
            btnStore.Size = new Size(112, 34);
            btnStore.TabIndex = 0;
            btnStore.Text = "Store";
            btnStore.UseVisualStyleBackColor = true;
            // 
            // btnLibrary
            // 
            btnLibrary.Location = new Point(24, 78);
            btnLibrary.Name = "btnLibrary";
            btnLibrary.Size = new Size(112, 34);
            btnLibrary.TabIndex = 1;
            btnLibrary.Text = "Library";
            btnLibrary.UseVisualStyleBackColor = true;
            // 
            // btnWallet
            // 
            btnWallet.Location = new Point(24, 141);
            btnWallet.Name = "btnWallet";
            btnWallet.Size = new Size(112, 34);
            btnWallet.TabIndex = 2;
            btnWallet.Text = "Wallet";
            btnWallet.UseVisualStyleBackColor = true;
            // 
            // btnCart
            // 
            btnCart.Location = new Point(24, 203);
            btnCart.Name = "btnCart";
            btnCart.Size = new Size(112, 34);
            btnCart.TabIndex = 3;
            btnCart.Text = "Cart";
            btnCart.UseVisualStyleBackColor = true;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(24, 360);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(112, 34);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PagePanel);
            Controls.Add(NavPanel);
            Name = "MainForm";
            Text = "MainForm";
            NavPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel NavPanel;
        private Button btnLogout;
        private Button btnCart;
        private Button btnWallet;
        private Button btnLibrary;
        private Button btnStore;
        private Panel PagePanel;
    }
}