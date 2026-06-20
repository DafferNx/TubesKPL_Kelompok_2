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
            // ── Declare all controls ───────────────────────────────
            pnlAccentBar        = new Panel();
            NavPanel            = new Panel();
            PagePanel           = new Panel();
            pnlBrand            = new Panel();
            pnlBrandLeft        = new Panel();
            lblBrandIcon        = new Label();
            pnlBrandRight       = new Panel();
            lblBrandName        = new Label();
            lblBrandSub         = new Label();
            pnlNavDivider       = new Panel();
            pnlNavButtons       = new Panel();
            btnGameManagement   = new Button();
            btnRefundManagement = new Button();
            btnWalletManagement = new Button();
            pnlNavBottom        = new Panel();
            btnLogout           = new Button();

            pnlBrandLeft.SuspendLayout();
            pnlBrandRight.SuspendLayout();
            pnlBrand.SuspendLayout();
            NavPanel.SuspendLayout();
            pnlNavButtons.SuspendLayout();
            pnlNavBottom.SuspendLayout();
            SuspendLayout();

            // ════════════════════════════════════════════════════════
            // pnlAccentBar — SIBLING of NavPanel in AdminForm (NOT inside NavPanel)
            // This guarantees it never interferes with NavPanel's internal layout.
            // ════════════════════════════════════════════════════════
            pnlAccentBar.BackColor = Color.FromArgb(99, 102, 241);
            pnlAccentBar.Dock      = DockStyle.Left;
            pnlAccentBar.Name      = "pnlAccentBar";
            pnlAccentBar.Size      = new Size(4, 580);
            pnlAccentBar.TabIndex  = 2;

            // ════════════════════════════════════════════════════════
            // NavPanel — 206px wide (accent bar is now outside, so no offset needed)
            // Internal children ALL use Dock → no fixed positions, no clipping risk
            // ════════════════════════════════════════════════════════
            NavPanel.BackColor = Color.FromArgb(10, 10, 20);
            NavPanel.Dock      = DockStyle.Left;
            NavPanel.Name      = "NavPanel";
            NavPanel.Size      = new Size(206, 580);
            NavPanel.TabIndex  = 0;

            // ── pnlBrand (Dock=Top, 90px) ──────────────────────────
            pnlBrand.BackColor = Color.FromArgb(10, 10, 20);
            pnlBrand.Dock      = DockStyle.Top;
            pnlBrand.Name      = "pnlBrand";
            pnlBrand.Size      = new Size(206, 90);
            pnlBrand.TabIndex  = 0;

            // ── pnlBrandLeft: icon cell, Dock=Left, 54px ───────────
            pnlBrandLeft.BackColor = Color.FromArgb(10, 10, 20);
            pnlBrandLeft.Controls.Add(lblBrandIcon);
            pnlBrandLeft.Dock      = DockStyle.Left;
            pnlBrandLeft.Name      = "pnlBrandLeft";
            pnlBrandLeft.Size      = new Size(54, 90);
            pnlBrandLeft.TabIndex  = 0;

            lblBrandIcon.AutoSize  = false;
            lblBrandIcon.Dock      = DockStyle.Fill;
            lblBrandIcon.Font      = new Font("Segoe UI Emoji", 20F);
            lblBrandIcon.ForeColor = Color.FromArgb(129, 140, 248);
            lblBrandIcon.Name      = "lblBrandIcon";
            lblBrandIcon.TabIndex  = 0;
            lblBrandIcon.Text      = "⚡";
            lblBrandIcon.TextAlign = ContentAlignment.MiddleCenter;

            // ── pnlBrandRight: text cell, Dock=Fill ────────────────
            // Width = NavPanel(206) - pnlBrandLeft(54) = 152px  →  plenty for "SETIM"
            // Uses Padding to add breathing room around text
            pnlBrandRight.BackColor = Color.FromArgb(10, 10, 20);
            pnlBrandRight.Dock      = DockStyle.Fill;
            pnlBrandRight.Name      = "pnlBrandRight";
            pnlBrandRight.Padding   = new Padding(2, 16, 8, 14);
            pnlBrandRight.TabIndex  = 1;

            // "SETIM" — Dock=Top, height=30px
            lblBrandName.AutoSize  = false;
            lblBrandName.Dock      = DockStyle.Top;
            lblBrandName.Font      = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblBrandName.ForeColor = Color.White;
            lblBrandName.Name      = "lblBrandName";
            lblBrandName.Size      = new Size(140, 30);   // height from Dock=Top Size
            lblBrandName.TabIndex  = 0;
            lblBrandName.Text      = "SETIM";
            lblBrandName.TextAlign = ContentAlignment.MiddleLeft;

            // "ADMIN PANEL" — Dock=Fill (takes remainder of pnlBrandRight)
            lblBrandSub.AutoSize  = false;
            lblBrandSub.Dock      = DockStyle.Fill;
            lblBrandSub.Font      = new Font("Segoe UI", 7.5F, FontStyle.Bold);
            lblBrandSub.ForeColor = Color.FromArgb(99, 102, 241);
            lblBrandSub.Name      = "lblBrandSub";
            lblBrandSub.TabIndex  = 1;
            lblBrandSub.Text      = "ADMIN PANEL";
            lblBrandSub.TextAlign = ContentAlignment.TopLeft;

            // Build pnlBrandRight: Name first (→ top), Sub fills rest
            pnlBrandRight.Controls.Add(lblBrandSub);
            pnlBrandRight.Controls.Add(lblBrandName);

            // Build pnlBrand: Right fills rest, Left panel first (→ leftmost)
            pnlBrand.Controls.Add(pnlBrandRight);
            pnlBrand.Controls.Add(pnlBrandLeft);

            // ── pnlNavDivider ──────────────────────────────────────
            pnlNavDivider.BackColor = Color.FromArgb(28, 28, 52);
            pnlNavDivider.Dock      = DockStyle.Top;
            pnlNavDivider.Name      = "pnlNavDivider";
            pnlNavDivider.Size      = new Size(206, 1);
            pnlNavDivider.TabIndex  = 9;

            // ── pnlNavButtons ──────────────────────────────────────
            pnlNavButtons.BackColor = Color.FromArgb(10, 10, 20);
            pnlNavButtons.Controls.Add(btnGameManagement);
            pnlNavButtons.Controls.Add(btnRefundManagement);
            pnlNavButtons.Controls.Add(btnWalletManagement);
            pnlNavButtons.Dock     = DockStyle.Top;
            pnlNavButtons.Name     = "pnlNavButtons";
            pnlNavButtons.Size     = new Size(206, 186);
            pnlNavButtons.TabIndex = 1;

            SetupNavBtn(btnGameManagement,   "  🎮   Game",   0,  8);
            SetupNavBtn(btnRefundManagement, "  💸   Refund", 1, 62);
            SetupNavBtn(btnWalletManagement, "  💰   Wallet", 2, 116);

            // ── pnlNavBottom ───────────────────────────────────────
            pnlNavBottom.BackColor = Color.FromArgb(12, 12, 22);
            pnlNavBottom.Controls.Add(btnLogout);
            pnlNavBottom.Dock      = DockStyle.Bottom;
            pnlNavBottom.Name      = "pnlNavBottom";
            pnlNavBottom.Padding   = new Padding(8, 10, 8, 10);
            pnlNavBottom.Size      = new Size(206, 60);
            pnlNavBottom.TabIndex  = 2;

            btnLogout.BackColor = Color.FromArgb(35, 10, 10);
            btnLogout.FlatAppearance.BorderColor        = Color.FromArgb(90, 25, 25);
            btnLogout.FlatAppearance.BorderSize         = 1;
            btnLogout.FlatAppearance.MouseOverBackColor = Color.FromArgb(65, 18, 18);
            btnLogout.FlatStyle  = FlatStyle.Flat;
            btnLogout.Font       = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogout.ForeColor  = Color.FromArgb(240, 100, 100);
            btnLogout.Dock       = DockStyle.Fill;
            btnLogout.Name       = "btnLogout";
            btnLogout.Padding    = new Padding(10, 0, 0, 0);
            btnLogout.TabIndex   = 3;
            btnLogout.Text       = "  🚪   Logout";
            btnLogout.TextAlign  = ContentAlignment.MiddleLeft;
            btnLogout.UseVisualStyleBackColor = false;

            // Build NavPanel — add in this order so Dock layout is correct:
            //   pnlBrand first      → Dock=Top → topmost   ✓
            //   pnlNavDivider       → Dock=Top → below brand
            //   pnlNavButtons       → Dock=Top → below divider
            //   pnlNavBottom last   → Dock=Bottom → bottom  ✓
            NavPanel.Controls.Add(pnlNavBottom);
            NavPanel.Controls.Add(pnlNavButtons);
            NavPanel.Controls.Add(pnlNavDivider);
            NavPanel.Controls.Add(pnlBrand);

            // ── PagePanel ─────────────────────────────────────────
            PagePanel.BackColor = Color.FromArgb(8, 8, 18);
            PagePanel.Dock      = DockStyle.Fill;
            PagePanel.Name      = "PagePanel";
            PagePanel.TabIndex  = 1;

            // ════════════════════════════════════════════════════════
            // AdminForm — Controls added in this exact order:
            //   pnlAccentBar FIRST  → Dock=Left → leftmost 4px  ✓
            //   NavPanel SECOND     → Dock=Left → next 206px    ✓
            //   PagePanel THIRD     → Dock=Fill → remainder      ✓
            // ════════════════════════════════════════════════════════
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(8, 8, 18);
            ClientSize          = new Size(960, 580);
            Controls.Add(PagePanel);
            Controls.Add(NavPanel);
            Controls.Add(pnlAccentBar);
            MinimumSize   = new Size(820, 500);
            Name          = "AdminForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text          = "SETIM — Admin Panel";

            pnlBrandLeft.ResumeLayout(false);
            pnlBrandRight.ResumeLayout(false);
            pnlBrand.ResumeLayout(false);
            NavPanel.ResumeLayout(false);
            pnlNavButtons.ResumeLayout(false);
            pnlNavBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void SetupNavBtn(Button btn, string text, int tabIndex, int y)
        {
            btn.BackColor = Color.FromArgb(10, 10, 20);
            btn.FlatAppearance.BorderSize         = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 90);
            btn.FlatStyle  = FlatStyle.Flat;
            btn.Font       = new Font("Segoe UI", 10F, FontStyle.Bold);
            btn.ForeColor  = Color.FromArgb(130, 130, 170);
            btn.Location   = new Point(8, y);
            btn.Padding    = new Padding(10, 0, 0, 0);
            btn.Size       = new Size(190, 50);
            btn.TabIndex   = tabIndex;
            btn.Text       = text;
            btn.TextAlign  = ContentAlignment.MiddleLeft;
            btn.UseVisualStyleBackColor = false;
        }

        private Panel  pnlAccentBar;
        private Panel  NavPanel;
        private Panel  PagePanel;
        private Panel  pnlBrand;
        private Panel  pnlBrandLeft;
        private Label  lblBrandIcon;
        private Panel  pnlBrandRight;
        private Label  lblBrandName;
        private Label  lblBrandSub;
        private Panel  pnlNavDivider;
        private Panel  pnlNavButtons;
        private Button btnGameManagement;
        private Button btnRefundManagement;
        private Button btnWalletManagement;
        private Panel  pnlNavBottom;
        private Button btnLogout;
    }
}
