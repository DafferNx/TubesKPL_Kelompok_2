using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Libraries;

namespace GUI.Control
{
    public partial class Store : UserControl
    {
        // ── State ─────────────────────────────────────────────────────────────────
        private User _currentUser;
        private GameService _gameService;
        private AuthService _authService;
        private List<Game> _allGames = new();
        private List<Game> _filteredGames = new();

        // ── Event ke MainForm ────────────────────────────────────────────────────
        public event Action<Game, User>? GameDetailRequested;

        public Store(User user, GameService gameService, AuthService authService)
        {
            _currentUser = user;
            _gameService = gameService;
            _authService = authService;
            InitializeComponent();
            this.Load += (s, e) => { LayoutHeaderButtons(); LayoutSearchBar(); };
            RefreshData();
        }

        // ── Init ─────────────────────────────────────────────────────────────────
        private void RefreshData()
        {
            _allGames = _gameService.getAllGames(_currentUser.Id);
            ApplyFilter();
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            LayoutHeaderButtons();
            LayoutSearchBar();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            LayoutHeaderButtons();
            LayoutSearchBar();
            RenderGameList();
        }

        private void LayoutHeaderButtons()
        {
            if (panelHeader.Width == 0) return;
            int btnY = (panelHeader.Height - btnRefresh.Height) / 2;
            btnRefresh.Location = new Point(panelHeader.Width - btnRefresh.Width - 12, btnY);
        }

        /// <summary>Menyesuaikan posisi elemen search bar saat window di-resize.</summary>
        private void LayoutSearchBar()
        {
            if (panelSearch.Width == 0) return;

            const int padL    = 16;
            const int gap     = 8;
            const int filterW = 150;
            const int countW  = 130;
            int padR = padL;

            // txtSearch memenuhi sisa ruang antara left-pad dan cmbFilter
            int searchW = panelSearch.Width - padL - gap - filterW - gap - countW - padR;
            searchW = Math.Max(80, searchW);

            txtSearch.Location = new Point(padL, (panelSearch.Height - txtSearch.Height) / 2);
            txtSearch.Width    = searchW;

            cmbFilter.Location = new Point(txtSearch.Right + gap, (panelSearch.Height - cmbFilter.Height) / 2);
            cmbFilter.Width    = filterW;

            lblGameCount.Location = new Point(cmbFilter.Right + gap, (panelSearch.Height - lblGameCount.PreferredHeight) / 2);
        }

        // ── Search & Filter ───────────────────────────────────────────────────────
        private void txtSearch_TextChanged(object sender, EventArgs e) => ApplyFilter();
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();
        private void btnRefresh_Click(object sender, EventArgs e) => RefreshData();

        private void ApplyFilter()
        {
            string keyword = txtSearch.Text.Trim().ToLower();
            string filter = cmbFilter.SelectedItem?.ToString() ?? "Semua";

            _filteredGames = _allGames.Where(g =>
            {
                bool matchName = string.IsNullOrEmpty(keyword) || g.Name.ToLower().Contains(keyword);
                bool matchStatus = filter switch
                {
                    "Belum Dimiliki" => g.Status == GameStatus.NotOwned,
                    "Di Cart" => g.Status == GameStatus.Cart,
                    "Dimiliki" => g.Status == GameStatus.Owned,
                    _ => true
                };
                return matchName && matchStatus;
            }).ToList();

            RenderGameList();
        }

        // ── Render game cards ─────────────────────────────────────────────────────
        private void RenderGameList()
        {
            if (panelGames.Width == 0) return; // belum siap

            panelGames.SuspendLayout();
            panelGames.Controls.Clear();
            lblGameCount.Text = $"{_filteredGames.Count} game ditemukan";

            int cardWidth = panelGames.ClientSize.Width - panelGames.Padding.Horizontal - 16;
            cardWidth = Math.Max(200, cardWidth);

            if (_filteredGames.Count == 0)
            {
                panelGames.Controls.Add(new Label
                {
                    Text = "Tidak ada game yang cocok dengan filter.",
                    ForeColor = Color.FromArgb(120, 120, 128),
                    Font = new Font("Segoe UI", 10),
                    AutoSize = false,
                    Size = new Size(cardWidth, 40),
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(0, 20)
                });
                panelGames.ResumeLayout();
                return;
            }

            int y = 0;
            foreach (var game in _filteredGames)
            {
                var card = CreateGameCard(game, cardWidth);
                card.Location = new Point(0, y);
                panelGames.Controls.Add(card);
                y += card.Height + 8;
            }

            panelGames.ResumeLayout();
        }

        private Panel CreateGameCard(Game game, int cardWidth)
        {
            Color statusColor = game.Status switch
            {
                GameStatus.Owned => Color.FromArgb(52, 199, 89),
                GameStatus.Cart => Color.FromArgb(255, 159, 10),
                GameStatus.PendingRefund => Color.FromArgb(255, 69, 58),
                _ => Color.FromArgb(120, 120, 128)
            };

            string statusText = game.Status switch
            {
                GameStatus.Owned => "✓ Dimiliki",
                GameStatus.Cart => "🛒 Di Cart",
                GameStatus.PendingRefund => "⏳ Refund",
                _ => "• Tersedia"
            };

            var card = new Panel
            {
                Size = new Size(cardWidth, 72),
                BackColor = Color.FromArgb(30, 30, 35),
                Cursor = Cursors.Hand,
                Tag = game
            };

            var accent = new Panel
            {
                Size = new Size(4, 72),
                Location = new Point(0, 0),
                BackColor = statusColor
            };

            var lblName = new Label
            {
                Text = game.Name,
                Font = new Font("Segoe UI Semibold", 10.5f, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(18, 12),
                AutoSize = true
            };

            // Harga menggunakan CurrencyConverter sesuai RuntimeConfig
            var lblPrice = new Label
            {
                Text = CurrencyConverter.Format(game.Price, RuntimeConfig.Currency),
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(180, 180, 180),
                Location = new Point(18, 38),
                AutoSize = true
            };

            var lblStatus = new Label
            {
                Text = statusText,
                Font = new Font("Segoe UI", 9f, FontStyle.Bold),
                ForeColor = statusColor,
                AutoSize = true
            };

            var btnDetail = new Button
            {
                Text = "Detail →",
                Size = new Size(80, 30),
                BackColor = Color.FromArgb(44, 44, 54),
                ForeColor = Color.FromArgb(200, 200, 210),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 8.5f),
                Cursor = Cursors.Hand,
                Tag = game
            };
            btnDetail.FlatAppearance.BorderSize = 1;
            btnDetail.FlatAppearance.BorderColor = Color.FromArgb(60, 60, 72);
            btnDetail.Location = new Point(cardWidth - btnDetail.Width - 14, 21);
            lblStatus.Location = new Point(cardWidth - btnDetail.Width - lblStatus.PreferredWidth - 26, 24);

            EventHandler openDetail = (s, e) => GameDetailRequested?.Invoke(game, _currentUser);
            card.Click += openDetail;
            lblName.Click += openDetail;
            lblPrice.Click += openDetail;
            accent.Click += openDetail;
            btnDetail.Click += openDetail;

            card.MouseEnter += (s, e) => card.BackColor = Color.FromArgb(40, 40, 48);
            card.MouseLeave += (s, e) => card.BackColor = Color.FromArgb(30, 30, 35);

            card.Controls.Add(accent);
            card.Controls.Add(lblName);
            card.Controls.Add(lblPrice);
            card.Controls.Add(lblStatus);
            card.Controls.Add(btnDetail);

            return card;
        }

        // ── Toast ─────────────────────────────────────────────────────────────────
        private void ShowToast(string message)
        {
            lblToast.Text = message;
            panelToast.Height = 34;
            timerToast.Start();
        }

        private void timerToast_Tick(object sender, EventArgs e)
        {
            timerToast.Stop();
            panelToast.Height = 0;
        }
    }
}
