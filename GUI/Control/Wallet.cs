using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Libraries;

namespace GUI
{
    public partial class Wallet : UserControl
    {
        private User        _currentUser;
        private AuthService _authService;

        private static readonly string _configPath =
            Path.Combine(AppContext.BaseDirectory, "Data", "currency_config.json");

        // ── Konstruktor ───────────────────────────────────────────────────────
        public Wallet(User user, AuthService auth)
        {
            _currentUser = user;
            _authService = auth;

            InitializeComponent();

            // Button events
            btnActivate.Click += (s, e) => ToggleWallet();
            btnTopUp.Click    += (s, e) => TopUp();
            btnRefresh.Click  += (s, e) => { UpdateDisplay(); FlashRefresh(); };
            btnIDR.Click      += (s, e) => SwitchCurrency("IDR");
            btnUSD.Click      += (s, e) => SwitchCurrency("USD");

            // Hover efek pada balance card
            ApplyCardHover(panelCard, Color.FromArgb(26, 28, 44), Color.FromArgb(32, 34, 54));

            // Layout
            this.Load   += (s, e) => { LayoutHeader(); LayoutBody(); };
            this.Resize += (s, e) => { LayoutHeader(); LayoutBody(); };

            UpdateDisplay();
        }

        // ── Display ───────────────────────────────────────────────────────────
        private void UpdateDisplay()
        {
            _currentUser = _authService.GetUserById(_currentUser.Id);

            // Saldo
            lblBalanceValue.Text  = CurrencyConverter.Format(
                _currentUser.Wallet.Balance, RuntimeConfig.Currency);
            lblCurrencyBadge.Text = RuntimeConfig.Currency;

            // Status wallet
            bool isActive = _currentUser.Wallet.CurrentState == WalletState.Active;
            if (isActive)
            {
                lblWalletStatus.Text      = "✅  Wallet Aktif";
                lblWalletStatus.ForeColor = Color.FromArgb(52, 199, 89);
                panelCardAccent.BackColor = Color.FromArgb(0, 122, 255);
                btnActivate.Text          = "⛔  Nonaktifkan";
                btnActivate.BackColor     = Color.FromArgb(70, 22, 22);
                btnActivate.ForeColor     = Color.FromArgb(255, 100, 80);
            }
            else
            {
                lblWalletStatus.Text      = "⛔  Wallet Tidak Aktif";
                lblWalletStatus.ForeColor = Color.FromArgb(255, 80, 70);
                panelCardAccent.BackColor = Color.FromArgb(160, 30, 30);
                btnActivate.Text          = "✅  Aktifkan";
                btnActivate.BackColor     = Color.FromArgb(0, 122, 255);
                btnActivate.ForeColor     = Color.White;
            }

            RefreshCurrencyToggle();
        }

        // ── Wallet Actions ────────────────────────────────────────────────────
        private void ToggleWallet()
        {
            string result = _currentUser.Wallet.CurrentState == WalletState.Active
                ? _authService.DeactivateWallet(_currentUser)
                : _authService.ActivateWallet(_currentUser);

            MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateDisplay();
        }

        private void TopUp()
        {
            if (!int.TryParse(tbTopUp.Text.Trim(), out int amount) || amount <= 0)
            {
                MessageBox.Show("Masukkan jumlah top up yang valid!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string result = _authService.TopUpWallet(_currentUser, amount);
            tbTopUp.Clear();
            UpdateDisplay();
            ShowSubtitleFeedback($"✅  Top up berhasil!", Color.FromArgb(52, 199, 89));
        }

        // ── Currency Switcher ─────────────────────────────────────────────────
        private void SwitchCurrency(string code)
        {
            if (RuntimeConfig.Currency == code) return;

            RuntimeConfig.SetCurrency(code);
            RuntimeConfig.Save(_configPath);

            lblBalanceValue.Text  = CurrencyConverter.Format(
                _currentUser.Wallet.Balance, RuntimeConfig.Currency);
            lblCurrencyBadge.Text = RuntimeConfig.Currency;

            RefreshCurrencyToggle();
            ShowSubtitleFeedback($"💱  Mata uang diubah ke {code}", Color.FromArgb(0, 180, 255));
        }

        private void RefreshCurrencyToggle()
        {
            bool isIDR = RuntimeConfig.Currency == "IDR";

            btnIDR.BackColor = isIDR ? Color.FromArgb(0, 122, 255) : Color.Transparent;
            btnIDR.ForeColor = isIDR ? Color.White : Color.FromArgb(130, 130, 158);

            btnUSD.BackColor = !isIDR ? Color.FromArgb(0, 122, 255) : Color.Transparent;
            btnUSD.ForeColor = !isIDR ? Color.White : Color.FromArgb(130, 130, 158);
        }

        // ── Subtitle Feedback ─────────────────────────────────────────────────
        private void ShowSubtitleFeedback(string message, Color color)
        {
            timerFeedback.Stop();
            lblSubtitle.Text      = message;
            lblSubtitle.ForeColor = color;
            timerFeedback.Start();
        }

        // Tick dipanggil dari timerFeedback (kabel di Designer via timerFeedback_Tick)
        private void timerFeedback_Tick(object sender, EventArgs e)
        {
            timerFeedback.Stop();
            lblSubtitle.Text      = "Saldo & pengaturan mata uang";
            lblSubtitle.ForeColor = Color.FromArgb(100, 100, 125);
        }

        // ── Layout Responsif ──────────────────────────────────────────────────
        private void LayoutHeader()
        {
            if (panelHeader.Width == 0) return;
            int btnY = (panelHeader.Height - btnRefresh.Height) / 2;
            btnRefresh.Location = new Point(panelHeader.Width - btnRefresh.Width - 16, btnY);
        }

        private void LayoutBody()
        {
            if (panelBody.Width == 0) return;

            int w    = panelBody.ClientSize.Width - panelBody.Padding.Horizontal;
            int padL = panelBody.Padding.Left;
            int gap  = 16;

            // Balance card
            panelCard.Location        = new Point(padL, 22);
            panelCard.Width           = w;
            panelCardAccent.Height    = panelCard.Height;
            lblCurrencyBadge.Location = new Point(panelCard.Width - lblCurrencyBadge.Width - 14, 14);
            btnActivate.Location      = new Point(panelCard.Width - btnActivate.Width - 14,
                                                   panelCard.Height - btnActivate.Height - 12);

            // Top up panel
            panelTopUp.Location  = new Point(padL, panelCard.Bottom + gap);
            panelTopUp.Width     = w;
            int topupBtnW        = btnTopUp.Width;
            tbTopUp.Width        = panelTopUp.Width - topupBtnW - 10;
            btnTopUp.Location    = new Point(panelTopUp.Width - topupBtnW, 28);

            // Currency panel
            panelCurrency.Location  = new Point(padL, panelTopUp.Bottom + gap);
            panelCurrency.Width     = w;
            lblCurrencyDesc.Width   = panelCurrency.Width;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            LayoutHeader();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            LayoutHeader();
            LayoutBody();
        }

        // ── Hover Helper ──────────────────────────────────────────────────────
        /// <summary>Warnai panel saat mouse enter/leave tanpa memakai 'Control' sebagai tipe.</summary>
        private static void ApplyCardHover(Panel card, Color normalColor, Color hoverColor)
        {
            card.MouseEnter += (s, e) => card.BackColor = hoverColor;
            card.MouseLeave += (s, e) => card.BackColor = normalColor;

            // Terapkan ke semua child agar hover tetap aktif saat hover di label/button
            foreach (System.Windows.Forms.Control child in card.Controls)
            {
                child.MouseEnter += (s, e) => card.BackColor = hoverColor;
                child.MouseLeave += (s, e) => card.BackColor = normalColor;
            }
        }

        // ── Flash Refresh Button ──────────────────────────────────────────────
        private void FlashRefresh()
        {
            btnRefresh.ForeColor = Color.FromArgb(52, 199, 89);
            var t = new System.Windows.Forms.Timer { Interval = 600 };
            t.Tick += (s, e) =>
            {
                t.Stop();
                btnRefresh.ForeColor = Color.FromArgb(140, 140, 180);
                t.Dispose();
            };
            t.Start();
        }
    }
}
