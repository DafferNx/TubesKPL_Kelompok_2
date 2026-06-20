namespace GUI.Control
{
    partial class UserWalletManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle       = new Label();
            lblSubtitle    = new Label();
            pnlHeader      = new Panel();
            pnlHeaderAccent = new Panel();
            pnlButtons     = new Panel();
            btnBan         = new Button();
            btnUnban       = new Button();
            btnRefresh     = new Button();
            pnlContent     = new Panel();
            pnlTableCard   = new Panel();
            pnlTableHeader = new Panel();
            lblTableTitle  = new Label();
            lblStatusBadge = new Label();
            dgvUsers       = new DataGridView();

            pnlHeader.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlTableCard.SuspendLayout();
            pnlTableHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            SuspendLayout();

            // ── pnlHeader (90px — same as all pages) ──────────────
            pnlHeader.BackColor = Color.FromArgb(8, 8, 18);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(pnlHeaderAccent);
            pnlHeader.Dock     = DockStyle.Top;
            pnlHeader.Name     = "pnlHeader";
            pnlHeader.Size     = new Size(760, 90);
            pnlHeader.TabIndex = 5;

            pnlHeaderAccent.BackColor = Color.FromArgb(20, 184, 166);  // teal
            pnlHeaderAccent.Dock      = DockStyle.Bottom;
            pnlHeaderAccent.Name      = "pnlHeaderAccent";
            pnlHeaderAccent.Size      = new Size(760, 2);
            pnlHeaderAccent.TabIndex  = 0;

            lblTitle.AutoSize  = true;
            lblTitle.Font      = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location  = new Point(20, 8);
            lblTitle.Name      = "lblTitle";
            lblTitle.TabIndex  = 1;
            lblTitle.Text      = "💰  Wallet Management";

            // Subtitle at y=54 — clear of title, visible on all pages
            lblSubtitle.AutoSize  = true;
            lblSubtitle.Font      = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(20, 184, 166);  // teal
            lblSubtitle.Location  = new Point(23, 54);
            lblSubtitle.Name      = "lblSubtitle";
            lblSubtitle.TabIndex  = 2;
            lblSubtitle.Text      = "Kelola dan pantau status wallet pengguna";

            // ── pnlButtons (Dock=Bottom, 60px) ─────────────────────
            pnlButtons.BackColor = Color.FromArgb(8, 8, 18);
            pnlButtons.Controls.Add(btnBan);
            pnlButtons.Controls.Add(btnUnban);
            pnlButtons.Controls.Add(btnRefresh);
            pnlButtons.Dock     = DockStyle.Bottom;
            pnlButtons.Name     = "pnlButtons";
            pnlButtons.Padding  = new Padding(16, 10, 16, 10);
            pnlButtons.Size     = new Size(760, 60);
            pnlButtons.TabIndex = 8;

            SetupActionBtn(btnBan,     "🔒  Ban Wallet",   Color.FromArgb(127, 29, 29), Color.FromArgb(153, 40, 40),  Color.FromArgb(252, 165, 165), 0,   10, 140, 38);
            SetupActionBtn(btnUnban,   "🔓  Unban Wallet", Color.FromArgb(6,  78,  59), Color.FromArgb(10, 100, 78),  Color.FromArgb(52,  211, 153), 148, 10, 140, 38);
            SetupActionBtn(btnRefresh, "🔄  Refresh",      Color.FromArgb(30, 27,  75), Color.FromArgb(45,  40, 105), Color.FromArgb(167, 139, 250), 296, 10, 140, 38);
            btnBan.TabIndex     = 2;
            btnUnban.TabIndex   = 3;
            btnRefresh.TabIndex = 4;

            // ── pnlContent (Dock=Fill) ─────────────────────────────
            pnlContent.BackColor = Color.FromArgb(8, 8, 18);
            pnlContent.Controls.Add(pnlTableCard);
            pnlContent.Dock     = DockStyle.Fill;
            pnlContent.Name     = "pnlContent";
            pnlContent.Padding  = new Padding(16, 10, 16, 10);
            pnlContent.TabIndex = 15;

            // ── pnlTableCard (Dock=Fill) ───────────────────────────
            pnlTableCard.BackColor = Color.FromArgb(14, 14, 28);
            pnlTableCard.Controls.Add(dgvUsers);         // Fill, added first
            pnlTableCard.Controls.Add(pnlTableHeader);   // Top, added second → TOP
            pnlTableCard.Dock     = DockStyle.Fill;
            pnlTableCard.Name     = "pnlTableCard";
            pnlTableCard.TabIndex = 16;

            // ── pnlTableHeader (44px, Dock=Top) ────────────────────
            pnlTableHeader.BackColor = Color.FromArgb(8, 24, 22);   // dark teal
            pnlTableHeader.Controls.Add(lblTableTitle);   // Dock=Fill, added FIRST (docked last)
            pnlTableHeader.Controls.Add(lblStatusBadge);  // Dock=Right, added SECOND (docked first)
            pnlTableHeader.Dock     = DockStyle.Top;
            pnlTableHeader.Name     = "pnlTableHeader";
            pnlTableHeader.Size     = new Size(728, 44);
            pnlTableHeader.TabIndex = 0;

            lblStatusBadge.AutoSize  = false;
            lblStatusBadge.Dock      = DockStyle.Right;
            lblStatusBadge.Font      = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblStatusBadge.ForeColor = Color.FromArgb(20, 184, 166);
            lblStatusBadge.Name      = "lblStatusBadge";
            lblStatusBadge.Size      = new Size(72, 44);
            lblStatusBadge.TabIndex  = 1;
            lblStatusBadge.Text      = "● LIVE";
            lblStatusBadge.TextAlign = ContentAlignment.MiddleCenter;

            lblTableTitle.AutoSize  = false;
            lblTableTitle.Dock      = DockStyle.Fill;
            lblTableTitle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTableTitle.ForeColor = Color.FromArgb(94, 234, 212);
            lblTableTitle.Name      = "lblTableTitle";
            lblTableTitle.Padding   = new Padding(14, 0, 0, 0);
            lblTableTitle.TabIndex  = 2;
            lblTableTitle.Text      = "📋  DAFTAR PENGGUNA";
            lblTableTitle.TextAlign = ContentAlignment.MiddleLeft;

            // ── dgvUsers ───────────────────────────────────────────
            ConfigureDataGrid(dgvUsers,
                Color.FromArgb(8, 26, 24),     // header back (dark teal)
                Color.FromArgb(94, 234, 212),  // header fore (cyan)
                Color.FromArgb(10, 50, 46),    // selection back
                Color.FromArgb(94, 234, 212)); // selection fore
            dgvUsers.Name     = "dgvUsers";
            dgvUsers.TabIndex = 1;
            dgvUsers.Columns.Add("Id",       "ID");
            dgvUsers.Columns.Add("Username", "Username");
            dgvUsers.Columns.Add("Role",     "Role");
            dgvUsers.Columns.Add("Balance",  "Saldo (Rp)");
            dgvUsers.Columns.Add("State",    "Status Wallet");

            // ── UserWalletManagement ───────────────────────────────
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(8, 8, 18);
            Controls.Add(pnlContent);
            Controls.Add(pnlButtons);
            Controls.Add(pnlHeader);
            Name = "UserWalletManagement";
            Size = new Size(760, 580);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlButtons.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlTableCard.ResumeLayout(false);
            pnlTableHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            ResumeLayout(false);
        }

        private void SetupActionBtn(Button btn, string text,
            Color back, Color hover, Color fore,
            int x, int y, int w, int h)
        {
            btn.BackColor = back;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = hover;
            btn.FlatStyle  = FlatStyle.Flat;
            btn.Font       = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.ForeColor  = fore;
            btn.Location   = new Point(x, y);
            btn.Size       = new Size(w, h);
            btn.Text       = text;
            btn.UseVisualStyleBackColor = false;
        }

        private void ConfigureDataGrid(DataGridView dgv,
            Color headerBack, Color headerFore,
            Color selectionBack, Color selectionFore)
        {
            dgv.AllowUserToAddRows    = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode   = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor       = Color.FromArgb(12, 12, 24);
            dgv.BorderStyle           = BorderStyle.None;
            dgv.CellBorderStyle       = DataGridViewCellBorderStyle.None;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            var colH = new DataGridViewCellStyle
            {
                BackColor          = headerBack,
                ForeColor          = headerFore,
                Font               = new Font("Segoe UI", 8.5F, FontStyle.Bold),
                SelectionBackColor = headerBack,
                SelectionForeColor = headerFore,
                Alignment          = DataGridViewContentAlignment.MiddleLeft,
                Padding            = new Padding(10, 0, 0, 0)
            };
            dgv.ColumnHeadersDefaultCellStyle = colH;
            dgv.ColumnHeadersHeightSizeMode   = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.ColumnHeadersHeight           = 40;
            dgv.EnableHeadersVisualStyles     = false;

            var row = new DataGridViewCellStyle
            {
                BackColor          = Color.FromArgb(12, 12, 24),
                ForeColor          = Color.FromArgb(210, 210, 240),
                SelectionBackColor = selectionBack,
                SelectionForeColor = selectionFore,
                Font               = new Font("Segoe UI", 9.5F),
                Padding            = new Padding(10, 0, 0, 0)
            };
            dgv.DefaultCellStyle = row;

            var alt = new DataGridViewCellStyle
            {
                BackColor          = Color.FromArgb(16, 16, 32),
                ForeColor          = Color.FromArgb(210, 210, 240),
                SelectionBackColor = selectionBack,
                SelectionForeColor = selectionFore,
                Padding            = new Padding(10, 0, 0, 0)
            };
            dgv.AlternatingRowsDefaultCellStyle = alt;

            dgv.GridColor         = Color.FromArgb(22, 22, 42);
            dgv.Dock              = DockStyle.Fill;
            dgv.MultiSelect       = false;
            dgv.ReadOnly          = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 44;
            dgv.SelectionMode     = DataGridViewSelectionMode.FullRowSelect;
            dgv.ScrollBars        = ScrollBars.Vertical;
        }

        private Panel pnlHeader;
        private Panel pnlHeaderAccent;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel pnlContent;
        private Panel pnlTableCard;
        private Panel pnlTableHeader;
        private Label lblTableTitle;
        private Label lblStatusBadge;
        private DataGridView dgvUsers;
        private Panel pnlButtons;
        private Button btnBan;
        private Button btnUnban;
        private Button btnRefresh;
    }
}
