namespace GUI.Control
{
    partial class GameManagement
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
            pnlBottom      = new Panel();
            pnlFormCard    = new Panel();
            lblFormTitle   = new Label();
            lblName        = new Label();
            tbName         = new TextBox();
            lblPrice       = new Label();
            tbPrice        = new TextBox();
            pnlButtons     = new Panel();
            btnAdd         = new Button();
            btnEdit        = new Button();
            btnDelete      = new Button();
            btnRefresh     = new Button();
            pnlContent     = new Panel();
            pnlTableCard   = new Panel();
            pnlTableHeader = new Panel();
            lblTableTitle  = new Label();
            lblTableCount  = new Label();
            dgvGames       = new DataGridView();

            pnlHeader.SuspendLayout();
            pnlBottom.SuspendLayout();
            pnlFormCard.SuspendLayout();
            pnlButtons.SuspendLayout();
            pnlContent.SuspendLayout();
            pnlTableCard.SuspendLayout();
            pnlTableHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvGames).BeginInit();
            SuspendLayout();

            // ── pnlHeader (Dock=Top, 90px) ─────────────────────────
            pnlHeader.BackColor = Color.FromArgb(8, 8, 18);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(pnlHeaderAccent);
            pnlHeader.Dock     = DockStyle.Top;
            pnlHeader.Name     = "pnlHeader";
            pnlHeader.Size     = new Size(750, 90);
            pnlHeader.TabIndex = 10;

            pnlHeaderAccent.BackColor = Color.FromArgb(99, 102, 241);
            pnlHeaderAccent.Dock      = DockStyle.Bottom;
            pnlHeaderAccent.Size      = new Size(750, 2);
            pnlHeaderAccent.Name      = "pnlHeaderAccent";
            pnlHeaderAccent.TabIndex  = 0;

            lblTitle.AutoSize  = true;
            lblTitle.Font      = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location  = new Point(20, 8);
            lblTitle.Name      = "lblTitle";
            lblTitle.TabIndex  = 1;
            lblTitle.Text      = "🎮  Game Management";

            // y=54 → safe gap below 18F title (~36px tall ending at y~44)
            lblSubtitle.AutoSize  = true;
            lblSubtitle.Font      = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.FromArgb(99, 102, 241);
            lblSubtitle.Location  = new Point(23, 54);
            lblSubtitle.Name      = "lblSubtitle";
            lblSubtitle.TabIndex  = 2;
            lblSubtitle.Text      = "Kelola daftar game yang tersedia di platform";

            // ────────────────────────────────────────────────────────
            // pnlBottom (Dock=Bottom, 160px)
            //   Layout budget:  topPad(8) + formCard(94) + gap(4) + buttons(42) + botPad(12) = 160
            // ────────────────────────────────────────────────────────
            pnlBottom.BackColor = Color.FromArgb(8, 8, 18);
            pnlBottom.Controls.Add(pnlFormCard);   // Dock=Top
            pnlBottom.Controls.Add(pnlButtons);    // Dock=Bottom
            pnlBottom.Dock     = DockStyle.Bottom;
            pnlBottom.Name     = "pnlBottom";
            pnlBottom.Padding  = new Padding(16, 8, 16, 12);
            pnlBottom.Size     = new Size(750, 160);
            pnlBottom.TabIndex = 17;

            // ── pnlFormCard (Dock=Top inside pnlBottom, 94px) ──────
            //   Content layout (all coords are WITHIN pnlFormCard):
            //   y=8   lblFormTitle  (~16px tall → bottom ≈ y=24)
            //   y=30  lblName / lblPrice  (~14px tall → bottom ≈ y=44)
            //   y=50  tbName / tbPrice    (height=32 → bottom ≈ y=82)
            //   Margin at bottom: 94 - 82 = 12px ✓
            pnlFormCard.BackColor = Color.FromArgb(14, 14, 28);
            pnlFormCard.Controls.Add(lblFormTitle);
            pnlFormCard.Controls.Add(lblName);
            pnlFormCard.Controls.Add(tbName);
            pnlFormCard.Controls.Add(lblPrice);
            pnlFormCard.Controls.Add(tbPrice);
            pnlFormCard.Dock     = DockStyle.Top;
            pnlFormCard.Name     = "pnlFormCard";
            pnlFormCard.Size     = new Size(718, 94);   // width auto-fills pnlBottom inner
            pnlFormCard.TabIndex = 13;

            lblFormTitle.AutoSize  = true;
            lblFormTitle.Font      = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblFormTitle.ForeColor = Color.FromArgb(99, 102, 241);
            lblFormTitle.Location  = new Point(16, 8);
            lblFormTitle.Name      = "lblFormTitle";
            lblFormTitle.TabIndex  = 10;
            lblFormTitle.Text      = "✏  INPUT DATA GAME";

            // ── Nama Game ──────────────────────────────────────────
            lblName.AutoSize  = true;
            lblName.Font      = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(140, 140, 190);
            lblName.Location  = new Point(16, 30);   // y=30: well below lblFormTitle
            lblName.Name      = "lblName";
            lblName.TabIndex  = 2;
            lblName.Text      = "Nama Game";

            tbName.BackColor   = Color.FromArgb(20, 20, 40);
            tbName.BorderStyle = BorderStyle.FixedSingle;
            tbName.Font        = new Font("Segoe UI", 10F);
            tbName.ForeColor   = Color.White;
            tbName.Location    = new Point(16, 56);   // y=56: clear of the label at y=30
            tbName.Name        = "tbName";
            tbName.Size        = new Size(270, 32);
            tbName.TabIndex    = 3;

            // ── Harga (Rp) ─────────────────────────────────────────
            lblPrice.AutoSize  = true;
            lblPrice.Font      = new Font("Segoe UI", 8.5F, FontStyle.Bold);
            lblPrice.ForeColor = Color.FromArgb(140, 140, 190);
            lblPrice.Location  = new Point(302, 30);  // same y=30 as lblName
            lblPrice.Name      = "lblPrice";
            lblPrice.TabIndex  = 4;
            lblPrice.Text      = "Harga (Rp)";

            tbPrice.BackColor   = Color.FromArgb(20, 20, 40);
            tbPrice.BorderStyle = BorderStyle.FixedSingle;
            tbPrice.Font        = new Font("Segoe UI", 10F);
            tbPrice.ForeColor   = Color.White;
            tbPrice.Location    = new Point(302, 56); // same y=56 as tbName
            tbPrice.Name        = "tbPrice";
            tbPrice.Size        = new Size(210, 32);
            tbPrice.TabIndex    = 5;

            // ── pnlButtons (Dock=Bottom, 42px) ─────────────────────
            pnlButtons.BackColor = Color.FromArgb(8, 8, 18);
            pnlButtons.Controls.Add(btnAdd);
            pnlButtons.Controls.Add(btnEdit);
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Controls.Add(btnRefresh);
            pnlButtons.Dock     = DockStyle.Bottom;
            pnlButtons.Name     = "pnlButtons";
            pnlButtons.Size     = new Size(718, 42);
            pnlButtons.TabIndex = 14;

            SetupActionBtn(btnAdd,     "➕  Tambah",  Color.FromArgb(22, 101, 52),  Color.FromArgb(30, 130, 70),  Color.FromArgb(134, 239, 172), 0,   2, 118, 38);
            SetupActionBtn(btnEdit,    "✏️  Edit",    Color.FromArgb(30,  58, 138), Color.FromArgb(42,  74, 168), Color.FromArgb(147, 197, 253), 126, 2, 118, 38);
            SetupActionBtn(btnDelete,  "🗑  Hapus",   Color.FromArgb(127, 29,  29), Color.FromArgb(153, 40,  40), Color.FromArgb(252, 165, 165), 252, 2, 118, 38);
            SetupActionBtn(btnRefresh, "🔄  Refresh", Color.FromArgb(30,  27,  75), Color.FromArgb(45,  40, 105), Color.FromArgb(167, 139, 250), 378, 2, 118, 38);
            btnAdd.TabIndex     = 6;
            btnEdit.TabIndex    = 7;
            btnDelete.TabIndex  = 8;
            btnRefresh.TabIndex = 9;

            // ── pnlContent (Dock=Fill, table zone) ─────────────────
            pnlContent.BackColor = Color.FromArgb(8, 8, 18);
            pnlContent.Controls.Add(pnlTableCard);
            pnlContent.Dock     = DockStyle.Fill;
            pnlContent.Name     = "pnlContent";
            pnlContent.Padding  = new Padding(16, 10, 16, 10);
            pnlContent.TabIndex = 15;

            // ── pnlTableCard (Dock=Fill inside pnlContent) ─────────
            pnlTableCard.BackColor = Color.FromArgb(14, 14, 28);
            pnlTableCard.Controls.Add(dgvGames);        // Dock=Fill, added first
            pnlTableCard.Controls.Add(pnlTableHeader);  // Dock=Top,  added second → TOP
            pnlTableCard.Dock     = DockStyle.Fill;
            pnlTableCard.Name     = "pnlTableCard";
            pnlTableCard.TabIndex = 16;

            // ── pnlTableHeader (Dock=Top, 44px) ────────────────────
            pnlTableHeader.BackColor = Color.FromArgb(20, 18, 45);
            pnlTableHeader.Controls.Add(lblTableTitle);  // Dock=Fill, added FIRST (docked last)
            pnlTableHeader.Controls.Add(lblTableCount);  // Dock=Right, added SECOND (docked first)
            pnlTableHeader.Dock     = DockStyle.Top;
            pnlTableHeader.Name     = "pnlTableHeader";
            pnlTableHeader.Size     = new Size(718, 44);
            pnlTableHeader.TabIndex = 0;

            lblTableCount.AutoSize  = false;
            lblTableCount.Dock      = DockStyle.Right;
            lblTableCount.Font      = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblTableCount.ForeColor = Color.FromArgb(99, 102, 241);
            lblTableCount.Name      = "lblTableCount";
            lblTableCount.Size      = new Size(72, 44);
            lblTableCount.TabIndex  = 1;
            lblTableCount.Text      = "● LIVE";
            lblTableCount.TextAlign = ContentAlignment.MiddleCenter;

            lblTableTitle.AutoSize  = false;
            lblTableTitle.Dock      = DockStyle.Fill;
            lblTableTitle.Font      = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTableTitle.ForeColor = Color.FromArgb(160, 160, 220);
            lblTableTitle.Name      = "lblTableTitle";
            lblTableTitle.Padding   = new Padding(14, 0, 0, 0);
            lblTableTitle.TabIndex  = 2;
            lblTableTitle.Text      = "📋  DAFTAR GAME";
            lblTableTitle.TextAlign = ContentAlignment.MiddleLeft;

            // ── dgvGames ───────────────────────────────────────────
            ConfigureDataGrid(dgvGames,
                Color.FromArgb(25, 23, 60),    // header back
                Color.FromArgb(129, 140, 248), // header fore (indigo)
                Color.FromArgb(45, 42, 100),   // selection back
                Color.White);                  // selection fore
            dgvGames.Name     = "dgvGames";
            dgvGames.TabIndex = 1;
            dgvGames.Columns.Add("Id",    "ID");
            dgvGames.Columns.Add("Name",  "Nama Game");
            dgvGames.Columns.Add("Price", "Harga (Rp)");

            // ── GameManagement (control root) ──────────────────────
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode       = AutoScaleMode.Font;
            BackColor           = Color.FromArgb(8, 8, 18);
            // Add order: pnlContent Fill (last), pnlBottom Bottom, pnlHeader Top
            Controls.Add(pnlContent);
            Controls.Add(pnlBottom);
            Controls.Add(pnlHeader);
            Name = "GameManagement";
            Size = new Size(750, 580);

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlBottom.ResumeLayout(false);
            pnlFormCard.ResumeLayout(false);
            pnlFormCard.PerformLayout();
            pnlButtons.ResumeLayout(false);
            pnlContent.ResumeLayout(false);
            pnlTableCard.ResumeLayout(false);
            pnlTableHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvGames).EndInit();
            ResumeLayout(false);
        }

        private void SetupActionBtn(Button btn, string text,
            Color back, Color hover, Color fore,
            int x, int y, int w, int h)
        {
            btn.BackColor = back;
            btn.FlatAppearance.BorderSize         = 0;
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

        private Panel       pnlHeader;
        private Panel       pnlHeaderAccent;
        private Label       lblTitle;
        private Label       lblSubtitle;
        private Panel       pnlContent;
        private Panel       pnlTableCard;
        private Panel       pnlTableHeader;
        private Label       lblTableTitle;
        private Label       lblTableCount;
        private DataGridView dgvGames;
        private Panel       pnlBottom;
        private Panel       pnlFormCard;
        private Label       lblFormTitle;
        private Label       lblName;
        private TextBox     tbName;
        private Label       lblPrice;
        private TextBox     tbPrice;
        private Panel       pnlButtons;
        private Button      btnAdd;
        private Button      btnEdit;
        private Button      btnDelete;
        private Button      btnRefresh;
    }
}
