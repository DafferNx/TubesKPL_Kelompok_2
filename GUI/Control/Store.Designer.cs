using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace GUI.Control
{
    partial class Store
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            panelHeader = new Panel();
            panelSearch = new Panel();
            panelGames = new Panel();
            panelToast = new Panel();

            lblStoreTitle = new Label();
            lblGameCount = new Label();
            lblToast = new Label();

            txtSearch = new TextBox();
            cmbFilter = new ComboBox();
            btnRefresh = new Button();

            timerToast = new Timer(components);

            SuspendLayout();

            // ── panelHeader ─────────────────────────────────────────────
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 60;
            panelHeader.BackColor = System.Drawing.Color.FromArgb(22, 22, 28);
            panelHeader.Controls.Add(lblStoreTitle);
            panelHeader.Controls.Add(btnRefresh);

            lblStoreTitle.Text = "🏪 Store";
            lblStoreTitle.Font = new System.Drawing.Font("Segoe UI", 16f, System.Drawing.FontStyle.Bold);
            lblStoreTitle.ForeColor = System.Drawing.Color.White;
            lblStoreTitle.AutoSize = true;
            lblStoreTitle.Location = new System.Drawing.Point(20, 14);

            btnRefresh.Text = "↻";
            btnRefresh.Size = new System.Drawing.Size(36, 36);
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(40, 40, 48);
            btnRefresh.ForeColor = System.Drawing.Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 13f);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.Click += new System.EventHandler(btnRefresh_Click);

            // ── panelSearch ─────────────────────────────────────────────
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Height = 48;
            panelSearch.BackColor = System.Drawing.Color.FromArgb(18, 18, 22);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(cmbFilter);
            panelSearch.Controls.Add(lblGameCount);

            txtSearch.PlaceholderText = "Cari game...";
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 10f);
            txtSearch.BackColor = System.Drawing.Color.FromArgb(36, 36, 44);
            txtSearch.ForeColor = System.Drawing.Color.White;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location = new System.Drawing.Point(16, 10);
            txtSearch.Size = new System.Drawing.Size(240, 28);
            txtSearch.TextChanged += new System.EventHandler(txtSearch_TextChanged);

            cmbFilter.Items.AddRange(new object[] { "Semua", "Belum Dimiliki", "Di Cart", "Dimiliki" });
            cmbFilter.SelectedIndex = 0;
            cmbFilter.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            cmbFilter.BackColor = System.Drawing.Color.FromArgb(36, 36, 44);
            cmbFilter.ForeColor = System.Drawing.Color.White;
            cmbFilter.FlatStyle = FlatStyle.Flat;
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Location = new System.Drawing.Point(268, 10);
            cmbFilter.Size = new System.Drawing.Size(160, 28);
            cmbFilter.SelectedIndexChanged += new System.EventHandler(cmbFilter_SelectedIndexChanged);

            lblGameCount.Text = "";
            lblGameCount.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            lblGameCount.ForeColor = System.Drawing.Color.FromArgb(120, 120, 128);
            lblGameCount.AutoSize = true;
            lblGameCount.Location = new System.Drawing.Point(444, 15);

            // ── panelGames ──────────────────────────────────────────────
            panelGames.AutoScroll = true;
            panelGames.Dock = DockStyle.Fill;
            panelGames.BackColor = System.Drawing.Color.FromArgb(26, 26, 32);
            panelGames.Padding = new Padding(16, 12, 16, 12);

            // ── panelToast ──────────────────────────────────────────────
            panelToast.Dock = DockStyle.Bottom;
            panelToast.Height = 0;
            panelToast.BackColor = System.Drawing.Color.FromArgb(44, 44, 54);
            panelToast.Controls.Add(lblToast);

            lblToast.Text = "";
            lblToast.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            lblToast.ForeColor = System.Drawing.Color.White;
            lblToast.AutoSize = false;
            lblToast.Dock = DockStyle.Fill;
            lblToast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            timerToast.Interval = 2500;
            timerToast.Tick += new System.EventHandler(timerToast_Tick);

            // ── Store UserControl ────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(26, 26, 32);
            Size = new System.Drawing.Size(900, 600);
            Controls.Add(panelGames);
            Controls.Add(panelToast);
            Controls.Add(panelSearch);
            Controls.Add(panelHeader);
            Name = "Store";

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Panel panelSearch;
        private Panel panelGames;
        private Panel panelToast;
        private Label lblStoreTitle;
        private Label lblGameCount;
        private Label lblToast;
        private TextBox txtSearch;
        private ComboBox cmbFilter;
        private Button btnRefresh;
        private Timer timerToast;
    }
}
