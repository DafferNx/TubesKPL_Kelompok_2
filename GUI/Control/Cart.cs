using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Libraries;

namespace GUI
{
    public partial class Cart : UserControl
    {
        private User        currentUser;
        private GameService gameService;
        private AuthService authService;

        // list aktif yang ditampilkan
        private List<Game> _cartGames = new();

        // ── Konstruktor ───────────────────────────────────────────────────────
        public Cart(User user, GameService gs, AuthService auth)
        {
            currentUser  = user;
            gameService  = gs;
            authService  = auth;

            InitializeComponent();

            btnCheckout.Click += (s, e) => Checkout();
            btnRefresh.Click  += (s, e) => { LoadCart(); FlashRefresh(); };

            this.Load   += (s, e) => { LayoutHeader(); LayoutSummary(); CenterEmpty(); };
            this.Resize += (s, e) => { LayoutHeader(); LayoutSummary(); RenderCards(); CenterEmpty(); };

            LoadCart();
        }

        // ── Data ──────────────────────────────────────────────────────────────
        private void LoadCart()
        {
            try
            {
                _cartGames = gameService.getCartGames(currentUser.Id);
            }
            catch (Exception ex)
            {
                ShowToast($"⚠ Gagal memuat cart: {ex.Message}");
                _cartGames = new List<Game>();
            }

            RenderCards();
            UpdateSummary();
        }

        private void UpdateSummary()
        {
            int count = _cartGames.Count;
            int total = count > 0 ? gameService.getTotalCartPrice(currentUser.Id) : 0;

            lblItemCount.Text = $"{count} item";
            lblTotal.Text     = count == 0
                ? "Rp 0"
                : CurrencyConverter.Format(total, RuntimeConfig.Currency);

            // Tombol checkout hanya aktif jika ada item
            btnCheckout.Enabled   = count > 0;
            btnCheckout.BackColor = count > 0
                ? Color.FromArgb(0, 195, 107)
                : Color.FromArgb(40, 50, 40);
            btnCheckout.ForeColor = count > 0
                ? Color.White
                : Color.FromArgb(90, 110, 90);
        }

        // ── Render Cards ──────────────────────────────────────────────────────
        private void RenderCards()
        {
            if (panelItems.Width == 0) return;

            panelItems.SuspendLayout();

            // Hapus semua card (Panel) yang ada
            var toRemove = new List<System.Windows.Forms.Control>();
            foreach (System.Windows.Forms.Control c in panelItems.Controls)
                if (c is Panel p && p != panelEmpty) toRemove.Add(c);
            foreach (var c in toRemove) { panelItems.Controls.Remove(c); c.Dispose(); }

            if (_cartGames.Count == 0)
            {
                panelEmpty.Visible = true;
                CenterEmpty();
                panelItems.ResumeLayout();
                return;
            }

            panelEmpty.Visible = false;

            int cardW = panelItems.ClientSize.Width - panelItems.Padding.Horizontal - 4;
            cardW = Math.Max(200, cardW);
            int y = panelItems.Padding.Top;

            foreach (var game in _cartGames)
            {
                var card = CreateCartCard(game, cardW);
                card.Location = new Point(panelItems.Padding.Left, y);
                panelItems.Controls.Add(card);
                y += card.Height + 10;
            }

            panelItems.ResumeLayout();
        }

        private Panel CreateCartCard(Game game, int cardWidth)
        {
            // ── Outer card ──────────────────────────────────────────────────
            var card = new Panel
            {
                Size      = new Size(cardWidth, 80),
                BackColor = Color.FromArgb(26, 28, 44),
                Cursor    = Cursors.Default,
                Tag       = game
            };

            // Accent bar kiri (warna oranye = di cart)
            var accent = new Panel
            {
                Size      = new Size(5, 80),
                Location  = new Point(0, 0),
                BackColor = Color.FromArgb(255, 159, 10)
            };

            // Nomor urut / bullet
            var lblIndex = new Label
            {
                Text      = $"#{_cartGames.IndexOf(game) + 1}",
                Font      = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 159, 10),
                AutoSize  = true,
                Location  = new Point(20, 30)
            };

            // Nama game
            var lblName = new Label
            {
                Text      = game.Name,
                Font      = new Font("Segoe UI Semibold", 11f, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize  = true,
                Location  = new Point(56, 14)
            };

            // Harga
            var lblPrice = new Label
            {
                Text      = CurrencyConverter.Format(game.Price, RuntimeConfig.Currency),
                Font      = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(170, 170, 190),
                AutoSize  = true,
                Location  = new Point(58, 42)
            };

            // Status badge
            var lblBadge = new Label
            {
                Text      = "🛒 Di Cart",
                Font      = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 159, 10),
                BackColor = Color.FromArgb(60, 40, 10),
                AutoSize  = false,
                Size      = new Size(76, 22),
                TextAlign = ContentAlignment.MiddleCenter,
                Location  = new Point(cardWidth - 200, 28)
            };
            lblBadge.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // Tombol Remove
            var btnDel = new Button
            {
                Text      = "✕ Hapus",
                Size      = new Size(90, 34),
                Anchor    = AnchorStyles.Top | AnchorStyles.Right,
                Location  = new Point(cardWidth - 106, 23),
                BackColor = Color.FromArgb(60, 22, 22),
                ForeColor = Color.FromArgb(255, 90, 80),
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 8.5f, FontStyle.Bold),
                Cursor    = Cursors.Hand,
                Tag       = game
            };
            btnDel.FlatAppearance.BorderSize  = 1;
            btnDel.FlatAppearance.BorderColor = Color.FromArgb(100, 30, 30);
            btnDel.Click += (s, e) => RemoveGame(game);

            // Hover effect
            Color normalBg = Color.FromArgb(26, 28, 44);
            Color hoverBg  = Color.FromArgb(32, 34, 54);
            card.MouseEnter += (s, e) => card.BackColor = hoverBg;
            card.MouseLeave += (s, e) => card.BackColor = normalBg;
            foreach (System.Windows.Forms.Control child in new System.Windows.Forms.Control[]
                { accent, lblIndex, lblName, lblPrice })
            {
                child.MouseEnter += (s, e) => card.BackColor = hoverBg;
                child.MouseLeave += (s, e) => card.BackColor = normalBg;
            }

            card.Controls.Add(accent);
            card.Controls.Add(lblIndex);
            card.Controls.Add(lblName);
            card.Controls.Add(lblPrice);
            card.Controls.Add(lblBadge);
            card.Controls.Add(btnDel);

            return card;
        }

        // ── Actions ───────────────────────────────────────────────────────────
        private void Checkout()
        {
            if (_cartGames.Count == 0)
            {
                ShowToast("⚠ Cart masih kosong!");
                return;
            }

            int total = gameService.getTotalCartPrice(currentUser.Id);
            var confirm = MessageBox.Show(
                $"Checkout {_cartGames.Count} game?\nTotal: {CurrencyConverter.Format(total, RuntimeConfig.Currency)}",
                "Konfirmasi Checkout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            string result = gameService.checkoutCart(currentUser.Id);
            ShowToast($"✅ {result}");
            LoadCart();
        }

        private void RemoveGame(Game game)
        {
            var confirm = MessageBox.Show(
                $"Hapus \"{game.Name}\" dari cart?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            string result = gameService.removeFromCart(currentUser.Id, game.Id);
            ShowToast($"🗑  {result}");
            LoadCart();
        }

        // ── Layout ────────────────────────────────────────────────────────────
        private void LayoutHeader()
        {
            if (panelHeader.Width == 0) return;
            int btnY = (panelHeader.Height - btnRefresh.Height) / 2;
            btnRefresh.Location = new Point(panelHeader.Width - btnRefresh.Width - 16, btnY);
        }

        private void LayoutSummary()
        {
            if (panelSummary.Width == 0) return;
            btnCheckout.Location = new Point(
                panelSummary.Width - btnCheckout.Width - 20,
                (panelSummary.Height - btnCheckout.Height) / 2);
        }

        private void CenterEmpty()
        {
            if (panelItems.Width == 0) return;
            panelEmpty.Location = new Point(
                (panelItems.ClientSize.Width  - panelEmpty.Width)  / 2,
                (panelItems.ClientSize.Height - panelEmpty.Height) / 2);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            LayoutHeader();
            LayoutSummary();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            LayoutHeader();
            LayoutSummary();
        }

        // ── Toast ─────────────────────────────────────────────────────────────
        private void ShowToast(string message)
        {
            lblSubtitle.Text      = message;
            lblSubtitle.ForeColor = message.StartsWith("✅")
                ? Color.FromArgb(52, 199, 89)
                : message.StartsWith("⚠")
                    ? Color.FromArgb(255, 159, 10)
                    : Color.FromArgb(0, 180, 255);
            timerToast.Stop();
            timerToast.Start();
        }

        private void timerToast_Tick(object sender, EventArgs e)
        {
            timerToast.Stop();
            lblSubtitle.Text      = "Game yang siap di-checkout";
            lblSubtitle.ForeColor = Color.FromArgb(100, 100, 125);
        }

        // ── Flash Refresh ─────────────────────────────────────────────────────
        private void FlashRefresh()
        {
            btnRefresh.ForeColor = Color.FromArgb(52, 199, 89);
            var t = new System.Windows.Forms.Timer { Interval = 600 };
            t.Tick += (s, e) => { t.Stop(); btnRefresh.ForeColor = Color.FromArgb(140, 140, 180); t.Dispose(); };
            t.Start();
        }
    }
}
