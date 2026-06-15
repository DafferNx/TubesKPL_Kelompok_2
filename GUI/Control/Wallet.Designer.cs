using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace GUI
{
    partial class Wallet
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
            panelBody = new Panel();
            panelCard = new Panel();
            panelCardAccent = new Panel();
            panelTopUp = new Panel();
            panelCurrency = new Panel();
            panelCurrencyToggle = new Panel();

            lblTitle = new Label();
            lblSubtitle = new Label();
            lblBalanceLabel = new Label();
            lblBalanceValue = new Label();
            lblCurrencyBadge = new Label();
            lblWalletStatus = new Label();
            lblTopUpTitle = new Label();
            lblCurrencyTitle = new Label();
            lblCurrencyDesc = new Label();

            tbTopUp = new TextBox();
            btnTopUp = new Button();
            btnActivate = new Button();
            btnRefresh = new Button();
            btnIDR = new Button();
            btnUSD = new Button();

            timerFeedback = new Timer(components) { Interval = 2200 };

            SuspendLayout();

            // ══════════════════════════════════════════════════════════════════
            // panelHeader  ── 90px tinggi sehingga title + subtitle tidak terpotong
            // ══════════════════════════════════════════════════════════════════
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 90;
            panelHeader.BackColor = System.Drawing.Color.FromArgb(14, 14, 20);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(btnRefresh);

            lblTitle.Text = "💳  Wallet";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 17f, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(22, 8);

            lblSubtitle.Text = "Saldo & pengaturan mata uang";
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9f);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 125);
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new System.Drawing.Point(24, 56);

            // Refresh button — posisi X diset LayoutHeader() saat Load/Resize
            btnRefresh.Text = "↻";
            btnRefresh.Size = new System.Drawing.Size(38, 38);
            btnRefresh.Anchor = AnchorStyles.None;
            btnRefresh.Location = new System.Drawing.Point(0, 26);
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(32, 32, 44);
            btnRefresh.ForeColor = System.Drawing.Color.FromArgb(140, 140, 180);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 1;
            btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(50, 50, 68);
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 14f);
            btnRefresh.Cursor = Cursors.Hand;

            // ══════════════════════════════════════════════════════════════════
            // panelBody  ── scrollable content
            // ══════════════════════════════════════════════════════════════════
            panelBody.Dock = DockStyle.Fill;
            panelBody.AutoScroll = true;
            panelBody.BackColor = System.Drawing.Color.FromArgb(20, 20, 28);
            panelBody.Padding = new Padding(26, 22, 26, 26);

            // ── Balance Card ──────────────────────────────────────────────────
            panelCard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelCard.Location = new System.Drawing.Point(26, 22);
            panelCard.Size = new System.Drawing.Size(700, 158);
            panelCard.BackColor = System.Drawing.Color.FromArgb(26, 28, 44);
            panelCard.Controls.Add(panelCardAccent);
            panelCard.Controls.Add(lblCurrencyBadge);
            panelCard.Controls.Add(lblBalanceLabel);
            panelCard.Controls.Add(lblBalanceValue);
            panelCard.Controls.Add(lblWalletStatus);
            panelCard.Controls.Add(btnActivate);

            panelCardAccent.Size = new System.Drawing.Size(5, 158);
            panelCardAccent.Location = new System.Drawing.Point(0, 0);
            panelCardAccent.BackColor = System.Drawing.Color.FromArgb(0, 122, 255);

            lblCurrencyBadge.Text = "IDR";
            lblCurrencyBadge.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            lblCurrencyBadge.ForeColor = System.Drawing.Color.FromArgb(0, 180, 255);
            lblCurrencyBadge.BackColor = System.Drawing.Color.FromArgb(0, 55, 95);
            lblCurrencyBadge.AutoSize = false;
            lblCurrencyBadge.Size = new System.Drawing.Size(44, 22);
            lblCurrencyBadge.Location = new System.Drawing.Point(640, 14);
            lblCurrencyBadge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblCurrencyBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            lblBalanceLabel.Text = "TOTAL SALDO";
            lblBalanceLabel.Font = new System.Drawing.Font("Segoe UI", 7.5f, System.Drawing.FontStyle.Bold);
            lblBalanceLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 130);
            lblBalanceLabel.AutoSize = true;
            lblBalanceLabel.Location = new System.Drawing.Point(22, 16);

            lblBalanceValue.Text = "Rp 0";
            lblBalanceValue.Font = new System.Drawing.Font("Segoe UI", 26f, System.Drawing.FontStyle.Bold);
            lblBalanceValue.ForeColor = System.Drawing.Color.FromArgb(0, 215, 125);
            lblBalanceValue.AutoSize = true;
            lblBalanceValue.Location = new System.Drawing.Point(18, 34);

            lblWalletStatus.Text = "⛔  Wallet Tidak Aktif";
            lblWalletStatus.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            lblWalletStatus.ForeColor = System.Drawing.Color.FromArgb(255, 80, 70);
            lblWalletStatus.AutoSize = true;
            lblWalletStatus.Location = new System.Drawing.Point(22, 104);

            btnActivate.Text = "Aktifkan";
            btnActivate.Size = new System.Drawing.Size(148, 36);
            btnActivate.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnActivate.Location = new System.Drawing.Point(536, 112);
            btnActivate.BackColor = System.Drawing.Color.FromArgb(0, 122, 255);
            btnActivate.ForeColor = System.Drawing.Color.White;
            btnActivate.FlatStyle = FlatStyle.Flat;
            btnActivate.FlatAppearance.BorderSize = 0;
            btnActivate.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            btnActivate.Cursor = Cursors.Hand;

            // ── Top Up Panel ──────────────────────────────────────────────────
            panelTopUp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelTopUp.Location = new System.Drawing.Point(26, 198);
            panelTopUp.Size = new System.Drawing.Size(700, 98);
            panelTopUp.BackColor = System.Drawing.Color.FromArgb(22, 22, 32);
            panelTopUp.Controls.Add(lblTopUpTitle);
            panelTopUp.Controls.Add(tbTopUp);
            panelTopUp.Controls.Add(btnTopUp);

            lblTopUpTitle.Text = "💰  Top Up Saldo";
            lblTopUpTitle.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            lblTopUpTitle.ForeColor = System.Drawing.Color.FromArgb(195, 195, 215);
            lblTopUpTitle.AutoSize = true;
            lblTopUpTitle.Location = new System.Drawing.Point(0, 0);

            tbTopUp.PlaceholderText = "Jumlah top up (contoh: 50000)";
            tbTopUp.Font = new System.Drawing.Font("Segoe UI", 10.5f);
            tbTopUp.BackColor = System.Drawing.Color.FromArgb(30, 30, 42);
            tbTopUp.ForeColor = System.Drawing.Color.White;
            tbTopUp.BorderStyle = BorderStyle.FixedSingle;
            tbTopUp.Location = new System.Drawing.Point(0, 30);
            tbTopUp.Size = new System.Drawing.Size(540, 32);
            tbTopUp.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            btnTopUp.Text = "Top Up  →";
            btnTopUp.Size = new System.Drawing.Size(140, 34);
            btnTopUp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTopUp.Location = new System.Drawing.Point(550, 28);
            btnTopUp.BackColor = System.Drawing.Color.FromArgb(0, 195, 107);
            btnTopUp.ForeColor = System.Drawing.Color.White;
            btnTopUp.FlatStyle = FlatStyle.Flat;
            btnTopUp.FlatAppearance.BorderSize = 0;
            btnTopUp.Font = new System.Drawing.Font("Segoe UI", 9.5f, System.Drawing.FontStyle.Bold);
            btnTopUp.Cursor = Cursors.Hand;

            // ══════════════════════════════════════════════════════════════════
            // panelCurrency  ── Currency Switcher dengan pill toggle
            // ══════════════════════════════════════════════════════════════════
            panelCurrency.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelCurrency.Location = new System.Drawing.Point(26, 314);
            panelCurrency.Size = new System.Drawing.Size(700, 145);
            panelCurrency.BackColor = System.Drawing.Color.FromArgb(22, 22, 32);
            panelCurrency.Controls.Add(lblCurrencyTitle);
            panelCurrency.Controls.Add(lblCurrencyDesc);
            panelCurrency.Controls.Add(panelCurrencyToggle);

            lblCurrencyTitle.Text = "💱  Mata Uang Tampilan";
            lblCurrencyTitle.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            lblCurrencyTitle.ForeColor = System.Drawing.Color.FromArgb(195, 195, 215);
            lblCurrencyTitle.AutoSize = true;
            lblCurrencyTitle.Location = new System.Drawing.Point(0, 0);

            lblCurrencyDesc.Text = "Semua harga di Store, Library, dan Cart akan tampil dalam mata uang yang dipilih.";
            lblCurrencyDesc.Font = new System.Drawing.Font("Segoe UI", 8.5f);
            lblCurrencyDesc.ForeColor = System.Drawing.Color.FromArgb(95, 95, 120);
            lblCurrencyDesc.AutoSize = false;
            lblCurrencyDesc.Size = new System.Drawing.Size(680, 18);
            lblCurrencyDesc.Location = new System.Drawing.Point(0, 26);

            // ── Pill Toggle ──────────────────────────────────────────────────
            // Track berwarna gelap, dua tombol di dalamnya bersisian
            panelCurrencyToggle.Location = new System.Drawing.Point(0, 56);
            panelCurrencyToggle.Size = new System.Drawing.Size(360, 62);
            panelCurrencyToggle.BackColor = System.Drawing.Color.FromArgb(30, 30, 44);

            // Tombol IDR (kiri)
            btnIDR.Text = "🇮🇩   IDR  –  Rupiah";
            btnIDR.Name = "btnIDR";
            btnIDR.Size = new System.Drawing.Size(176, 54);
            btnIDR.Location = new System.Drawing.Point(4, 4);
            btnIDR.BackColor = System.Drawing.Color.FromArgb(0, 122, 255);
            btnIDR.ForeColor = System.Drawing.Color.White;
            btnIDR.FlatStyle = FlatStyle.Flat;
            btnIDR.FlatAppearance.BorderSize = 0;
            btnIDR.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            btnIDR.Cursor = Cursors.Hand;
            btnIDR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // Tombol USD (kanan)
            btnUSD.Text = "🇺🇸   USD  –  Dollar";
            btnUSD.Name = "btnUSD";
            btnUSD.Size = new System.Drawing.Size(176, 54);
            btnUSD.Location = new System.Drawing.Point(180, 4);
            btnUSD.BackColor = System.Drawing.Color.Transparent;
            btnUSD.ForeColor = System.Drawing.Color.FromArgb(130, 130, 158);
            btnUSD.FlatStyle = FlatStyle.Flat;
            btnUSD.FlatAppearance.BorderSize = 0;
            btnUSD.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            btnUSD.Cursor = Cursors.Hand;
            btnUSD.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            panelCurrencyToggle.Controls.Add(btnIDR);
            panelCurrencyToggle.Controls.Add(btnUSD);

            // Timer feedback di subtitle
            timerFeedback.Tick += new System.EventHandler(timerFeedback_Tick);

            // Tambah panels ke body
            panelBody.Controls.Add(panelCurrency);
            panelBody.Controls.Add(panelTopUp);
            panelBody.Controls.Add(panelCard);

            // ── UserControl root ─────────────────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 28);
            Size = new System.Drawing.Size(900, 600);
            Controls.Add(panelBody);
            Controls.Add(panelHeader);
            Name = "Wallet";

            ResumeLayout(false);
            PerformLayout();
        }

        private Panel panelHeader;
        private Panel panelBody;
        private Panel panelCard;
        private Panel panelCardAccent;
        private Panel panelTopUp;
        private Panel panelCurrency;
        private Panel panelCurrencyToggle;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblBalanceLabel;
        private Label lblBalanceValue;
        private Label lblCurrencyBadge;
        private Label lblWalletStatus;
        private Label lblTopUpTitle;
        private Label lblCurrencyTitle;
        private Label lblCurrencyDesc;
        private TextBox tbTopUp;
        private Button btnTopUp;
        private Button btnActivate;
        private Button btnRefresh;
        private Button btnIDR;
        private Button btnUSD;
        private Timer timerFeedback;

        // Kept for compat with any old references
        private Panel pnlCard => panelCard;
        private Label lblBalance => lblBalanceValue;
    }
}
