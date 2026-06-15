using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace GUI
{
    partial class Library
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            panelHeader = new Panel();
            panelStats = new Panel();
            panelSearch = new Panel();
            panelGames = new Panel();
            panelToast = new Panel();

            lblTitle = new Label();
            lblSubtitle = new Label();
            lblStatTotal = new Label();
            lblStatOwned = new Label();
            lblStatRefund = new Label();
            lblGameCount = new Label();
            lblToast = new Label();
            lblEmpty = new Label();

            txtSearch = new TextBox();
            btnRefresh = new Button();

            timerToast = new Timer(components);

            SuspendLayout();

            // ── panelHeader ─────────────────────────────────────────────────
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 90;
            panelHeader.BackColor = System.Drawing.Color.FromArgb(18, 18, 24);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(btnRefresh);

            lblTitle.Text = "📚 My Library";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 17f, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(22, 8);

            lblSubtitle.Text = "Game yang kamu miliki";
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9f);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(110, 110, 130);
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new System.Drawing.Point(24, 58);

            btnRefresh.Text = "↻";
            btnRefresh.Size = new System.Drawing.Size(38, 38);
            // Posisi x akan diset oleh LayoutHeaderButtons() saat Load/Resize
            btnRefresh.Anchor = AnchorStyles.None;
            btnRefresh.Location = new System.Drawing.Point(0, 26);
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(38, 38, 48);
            btnRefresh.ForeColor = System.Drawing.Color.FromArgb(160, 160, 200);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 1;
            btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(55, 55, 70);
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 14f);
            btnRefresh.Cursor = Cursors.Hand;

            // ── panelStats ──────────────────────────────────────────────────
            panelStats.Dock = DockStyle.Top;
            panelStats.Height = 56;
            panelStats.BackColor = System.Drawing.Color.FromArgb(22, 22, 30);
            panelStats.Controls.Add(lblStatTotal);
            panelStats.Controls.Add(lblStatOwned);
            panelStats.Controls.Add(lblStatRefund);

            lblStatTotal.Text = "📦  0 Total";
            lblStatTotal.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            lblStatTotal.ForeColor = System.Drawing.Color.FromArgb(160, 160, 180);
            lblStatTotal.AutoSize = true;
            lblStatTotal.Location = new System.Drawing.Point(22, 18);

            lblStatOwned.Text = "✅  0 Owned";
            lblStatOwned.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            lblStatOwned.ForeColor = System.Drawing.Color.FromArgb(52, 199, 89);
            lblStatOwned.AutoSize = true;
            lblStatOwned.Location = new System.Drawing.Point(140, 18);

            lblStatRefund.Text = "⏳  0 Refund";
            lblStatRefund.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            lblStatRefund.ForeColor = System.Drawing.Color.FromArgb(255, 149, 0);
            lblStatRefund.AutoSize = true;
            lblStatRefund.Location = new System.Drawing.Point(268, 18);

            // ── panelSearch ─────────────────────────────────────────────────
            panelSearch.Dock = DockStyle.Top;
            panelSearch.Height = 48;
            panelSearch.BackColor = System.Drawing.Color.FromArgb(18, 18, 22);
            panelSearch.Controls.Add(txtSearch);
            panelSearch.Controls.Add(lblGameCount);

            txtSearch.PlaceholderText = "🔍  Cari game di library...";
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 10f);
            txtSearch.BackColor = System.Drawing.Color.FromArgb(32, 32, 42);
            txtSearch.ForeColor = System.Drawing.Color.White;
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            txtSearch.Location = new System.Drawing.Point(16, 10);
            txtSearch.Size = new System.Drawing.Size(280, 28);

            lblGameCount.Text = "";
            lblGameCount.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            lblGameCount.ForeColor = System.Drawing.Color.FromArgb(110, 110, 128);
            lblGameCount.AutoSize = true;
            lblGameCount.Location = new System.Drawing.Point(310, 15);

            // ── panelGames ──────────────────────────────────────────────────
            panelGames.AutoScroll = true;
            panelGames.Dock = DockStyle.Fill;
            panelGames.BackColor = System.Drawing.Color.FromArgb(22, 22, 30);
            panelGames.Padding = new Padding(18, 14, 18, 18);

            // ── lblEmpty ───────────────────────────────────────────────────
            lblEmpty.Text = "Kamu belum memiliki game apa pun.\nPergi ke Store untuk membeli game! 🎮";
            lblEmpty.Font = new System.Drawing.Font("Segoe UI", 11f);
            lblEmpty.ForeColor = System.Drawing.Color.FromArgb(90, 90, 110);
            lblEmpty.AutoSize = false;
            lblEmpty.Size = new System.Drawing.Size(500, 80);
            lblEmpty.Location = new System.Drawing.Point(60, 60);
            lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblEmpty.Visible = false;
            panelGames.Controls.Add(lblEmpty);

            // ── panelToast ──────────────────────────────────────────────────
            panelToast.Dock = DockStyle.Bottom;
            panelToast.Height = 0;
            panelToast.BackColor = System.Drawing.Color.FromArgb(44, 44, 58);
            panelToast.Controls.Add(lblToast);

            lblToast.Text = "";
            lblToast.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            lblToast.ForeColor = System.Drawing.Color.White;
            lblToast.AutoSize = false;
            lblToast.Dock = DockStyle.Fill;
            lblToast.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            timerToast.Interval = 2500;
            timerToast.Tick += new System.EventHandler(timerToast_Tick);

            // ── Library UserControl ─────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(22, 22, 30);
            Size = new System.Drawing.Size(900, 600);
            Controls.Add(panelGames);
            Controls.Add(panelToast);
            Controls.Add(panelSearch);
            Controls.Add(panelStats);
            Controls.Add(panelHeader);
            Name = "Library";

            ResumeLayout(false);
            PerformLayout();
        }

        private Panel panelHeader;
        private Panel panelStats;
        private Panel panelSearch;
        private Panel panelGames;
        private Panel panelToast;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblStatTotal;
        private Label lblStatOwned;
        private Label lblStatRefund;
        private Label lblGameCount;
        private Label lblToast;
        private Label lblEmpty;
        private TextBox txtSearch;
        private Button btnRefresh;
        private Timer timerToast;
    }
}
