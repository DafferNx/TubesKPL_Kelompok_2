namespace GUI.Control
{
    partial class RefundManagement
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
            btnApprove     = new Button();
            btnReject      = new Button();
            btnRefresh     = new Button();
            pnlContent     = new Panel();
            pnlTableCard   = new Panel();
            pnlTableHeader = new Panel();
            lblTableTitle  = new Label();
            lblStatusBadge = new Label();
            dgvRefunds     = new DataGridView();

            pnlHeader.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlTableCard.SuspendLayout();
            pnlTableHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRefunds).BeginInit();
            SuspendLayout();

            // ── pnlHeader (90px, same as all pages) ───────────────
            pnlHeader.BackColor = Color.FromArgb(8, 8, 18);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(pnlHeaderAccent);
            pnlHeader.Dock     = DockStyle.Top;
            pnlHeader.Name     = "pnlHeader";
            pnlHeader.Size     = new Size(760, 90);
            pnlHeader.TabIndex = 5;

            pnlHeaderAccent.BackColor = Color.FromArgb(234, 179, 8);  // amber
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
            lblTitle.Text      = "💸  Refund Management";

            // Subtitle at y=54 — guaranteed clear of title text
            lblSubtitle.AutoSize  = true;
            lblSubtitle.Font      = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(202, 138, 4);  // amber
            lblSubtitle.Location  = new Point(23, 54);
            lblSubtitle.Name      = "lblSubtitle";
            lblSubtitle.TabIndex  = 2;
            lblSubtitle.Text      = "Kelola dan tinjau permintaan refund pengguna";

            // ── pnlButtons (Dock=Bottom, 60px) ─────────────────────
            pnlButtons.BackColor = Color.FromArgb(8, 8, 18);
            pnlButtons.Controls.Add(btnApprove);
            pnlButtons.Controls.Add(btnReject);
            pnlButtons.Controls.Add(btnRefresh);
            pnlButtons.Dock     = DockStyle.Bottom;
            pnlButtons.Name     = "pnlButtons";
            pnlButtons.Padding  = new Padding(16, 10, 16, 10);
            pnlButtons.Size     = new Size(760, 60);
            pnlButtons.TabIndex = 8;

            SetupActionBtn(btnApprove, "✔  Approve", Color.FromArgb(22, 101, 52), Color.FromArgb(30, 130, 70),  Color.FromArgb(134, 239, 172), 0,   10, 130, 38);
            SetupActionBtn(btnReject,  "✖  Reject",  Color.FromArgb(127, 29, 29), Color.FromArgb(153, 40, 40),  Color.FromArgb(252, 165, 165), 138, 10, 130, 38);
            SetupActionBtn(btnRefresh, "🔄  Refresh", Color.FromArgb(30, 27, 75),  Color.FromArgb(45, 40, 105),  Color.FromArgb(167, 139, 250), 276, 10, 130, 38);
            btnApprove.TabIndex = 2;
            btnReject.TabIndex  = 3;
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
            pnlTableCard.Controls.Add(dgvRefunds);       // Fill, added first
            pnlTableCard.Controls.Add(pnlTableHeader);   // Top, added second → docks TOP
            pnlTableCard.Dock     = DockStyle.Fill;
            pnlTableCard.Name     = "pnlTableCard";
            pnlTableCard.TabIndex = 16;

            // ── pnlTableHeader (44px, Dock=Top) ────────────────────
            pnlTableHeader.BackColor = Color.FromArgb(26, 22, 10);  // dark amber
            pnlTableHeader.Controls.Add(lblTableTitle);   // Dock=Fill, added FIRST (docked last)
            pnlTableHeader.Controls.Add(lblStatusBadge);  // Dock=Right, added SECOND (docked first)
            pnlTableHeader.Dock     = DockStyle.Top;
            pnlTableHeader.Name     = "pnlTableHeader";
            pnlTableHeader.Size     = new Size(728, 44);
            pnlTableHeader.TabIndex = 0;

            lblStatusBadge.AutoSize  = false;
            lblStatusBadge.Dock      = DockStyle.Right;
            lblStatusBadge.Font      = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblStatusBadge.ForeColor = Color.FromArgb(234, 179, 8);
            lblStatusBadge.Name      = "lblStatusBadge";
            lblStatusBadge.Size      = new Size(72, 44);
            lblStatusBadge.TabIndex  = 1;
            lblStatusBadge.Text      = "● LIVE";
            lblStatusBadge.TextAlign = ContentAlignment.MiddleCenter;

            lblTableTitle.AutoSize  = false;
            lblTableTitle.Dock      = DockStyle.Fill;
            lblTableTitle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTableTitle.ForeColor = Color.FromArgb(253, 224, 71);
            lblTableTitle.Name      = "lblTableTitle";
            lblTableTitle.Padding   = new Padding(14, 0, 0, 0);
            lblTableTitle.TabIndex  = 2;
            lblTableTitle.Text      = "📋  PENDING REFUNDS";
            lblTableTitle.TextAlign = ContentAlignment.MiddleLeft;

            // ── dgvRefunds ─────────────────────────────────────────
            ConfigureDataGrid(dgvRefunds,
                Color.FromArgb(28, 24, 8),     // header back
                Color.FromArgb(253, 224, 71),  // header fore (amber)
                Color.FromArgb(60, 50, 10),    // selection back
                Color.FromArgb(253, 224, 71)); // selection fore
            dgvRefunds.Name     = "dgvRefunds";
            dgvRefunds.TabIndex = 1;
            dgvRefunds.Columns.Add("UserId", "User ID");
            dgvRefunds.Columns.Add("Id",     "Game ID");
            dgvRefunds.Columns.Add("Name",   "Nama Game");
            dgvRefunds.Columns.Add("Price",  "Harga (Rp)");

            // ── RefundManagement ───────────────────────────────────
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(8, 8, 18);
            Controls.Add(pnlContent);
            Controls.Add(pnlButtons);
            Controls.Add(pnlHeader);
            Name = "RefundManagement";
            Size = new Size(760, 580);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlButtons.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlTableCard.ResumeLayout(false);
            pnlTableHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvRefunds).EndInit();
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
        private DataGridView dgvRefunds;
        private Panel pnlButtons;
        private Button btnApprove;
        private Button btnReject;
        private Button btnRefresh;
    }
}
