using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Libraries;

namespace GUI
{
    public partial class Library : UserControl
    {
        // ── State ──────────────────────────────────────────────────────────────
        private User _currentUser;
        private GameService _gameService;
        private List<Game> _allGames   = new();
        private List<Game> _shown      = new();
        private int _colCount          = 3;  // cards per row

        // ── Event ke MainForm ─────────────────────────────────────────────────
        /// <summary>Fired ketika user klik "Detail" pada sebuah card game.</summary>
        public event Action<Game, User>? GameDetailRequested;

        // ── Konstruktor ───────────────────────────────────────────────────────
        public Library(User user, GameService gs)
        {
            _currentUser = user;
            _gameService = gs;
            InitializeComponent();

            txtSearch.TextChanged += (s, e) => ApplyFilter();
            btnRefresh.Click      += (s, e) => RefreshData();
            // First-load layout: setelah InitializeComponent, ukuran sudah diset
            this.Load += (s, e) => { LayoutHeaderButtons(); RecalcColumns(); RenderCards(); };
            this.Resize += (s, e) => { LayoutHeaderButtons(); RecalcColumns(); RenderCards(); };

            RefreshData();
        }

        // ── Data ──────────────────────────────────────────────────────────────
        private void RefreshData()
        {
            try
            {
                _allGames = _gameService.GetOwnedGames(_currentUser.Id);
            }
            catch (Exception ex)
            {
                ShowToast($"⚠ Gagal memuat library: {ex.Message}");
                _allGames = new List<Game>();
            }

            ApplyFilter();
            UpdateStats();
        }

        private void ApplyFilter()
        {
            string kw = txtSearch.Text.Trim().ToLower();
            _shown = string.IsNullOrEmpty(kw)
                ? _allGames.ToList()
                : _allGames.Where(g => g.Name.ToLower().Contains(kw)).ToList();

            lblGameCount.Text = $"{_shown.Count} game ditemukan";
            RenderCards();
        }

        private void UpdateStats()
        {
            int total   = _allGames.Count;
            int owned   = _allGames.Count(g => g.Status == GameStatus.Owned);
            int refund  = _allGames.Count(g => g.Status == GameStatus.PendingRefund);
            lblStatTotal.Text  = $"📦  {total} Total";
            lblStatOwned.Text  = $"✅  {owned} Owned";
            lblStatRefund.Text = $"⏳  {refund} Refund";
        }

        // ── Layout ────────────────────────────────────────────────────────────
        private void RecalcColumns()
        {
            int availW = panelGames.Width - panelGames.Padding.Horizontal - SystemInformation.VerticalScrollBarWidth;
            // Target card width ~260 px, min 1 column
            _colCount = Math.Max(1, availW / 265);
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            LayoutHeaderButtons();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            LayoutHeaderButtons();
        }

        private void LayoutHeaderButtons()
        {
            if (panelHeader.Width == 0) return;
            int btnY = (panelHeader.Height - btnRefresh.Height) / 2;
            btnRefresh.Location = new Point(panelHeader.Width - btnRefresh.Width - 16, btnY);
        }

        // ── Rendering cards ───────────────────────────────────────────────────
        private void RenderCards()
        {
            RecalcColumns();

            panelGames.SuspendLayout();

            // Hapus semua kecuali lblEmpty
            var toRemove = panelGames.Controls.OfType<Panel>().ToList();
            foreach (var c in toRemove) { panelGames.Controls.Remove(c); c.Dispose(); }

            if (_shown.Count == 0)
            {
                lblEmpty.Text    = _allGames.Count == 0
                    ? "Kamu belum memiliki game apa pun.\nPergi ke Store untuk membeli game! 🎮"
                    : "Tidak ada game yang cocok dengan pencarianmu.";
                lblEmpty.Visible = true;
                panelGames.ResumeLayout();
                return;
            }

            lblEmpty.Visible = false;

            int padL  = panelGames.Padding.Left;
            int padT  = panelGames.Padding.Top;
            int gap   = 12;
            int availW = panelGames.Width - panelGames.Padding.Horizontal
                         - SystemInformation.VerticalScrollBarWidth;
            int cardW = (availW - gap * (_colCount - 1)) / _colCount;
            int cardH = 160;

            for (int i = 0; i < _shown.Count; i++)
            {
                int col = i % _colCount;
                int row = i / _colCount;
                int x   = padL + col * (cardW + gap);
                int y   = padT + row * (cardH + gap);

                var card = CreateCard(_shown[i], cardW, cardH);
                card.Location = new Point(x, y);
                panelGames.Controls.Add(card);
            }

            panelGames.ResumeLayout();
        }

        // ── Single card builder ───────────────────────────────────────────────
        private Panel CreateCard(Game game, int w, int h)
        {
            // Warna berdasarkan status
            (Color accent, string statusEmoji, string statusText) = game.Status switch
            {
                GameStatus.Owned         => (Color.FromArgb(52, 199, 89),   "✅", "Dimiliki"),
                GameStatus.PendingRefund => (Color.FromArgb(255, 149, 0),   "⏳", "Proses Refund"),
                _                        => (Color.FromArgb(120, 120, 140), "•",  game.Status.ToString()),
            };

            // Card utama
            var card = new Panel
            {
                Size      = new Size(w, h),
                BackColor = Color.FromArgb(30, 30, 40),
                Cursor    = Cursors.Hand,
                Tag       = game
            };

            // Garis accent kiri
            var accentBar = new Panel
            {
                Size      = new Size(4, h),
                Location  = new Point(0, 0),
                BackColor = accent
            };

            // Thumbnail placeholder (warna gradient simulasi)
            var thumb = new Panel
            {
                Size      = new Size(w - 4, 72),
                Location  = new Point(4, 0),
                BackColor = DarkenColor(accent, 0.18f)
            };

            // Inisial nama game sebagai "cover"
            string initials = GetInitials(game.Name);
            var lblInitials = new Label
            {
                Text      = initials,
                Font      = new Font("Segoe UI", 18f, FontStyle.Bold),
                ForeColor = Color.FromArgb(180, 255, 255, 255),
                AutoSize  = false,
                Size      = thumb.Size,
                TextAlign = ContentAlignment.MiddleCenter
            };
            thumb.Controls.Add(lblInitials);

            // Status badge di pojok kanan atas thumb
            var badge = new Label
            {
                Text      = $"{statusEmoji} {statusText}",
                Font      = new Font("Segoe UI", 7.5f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(180, 0, 0, 0),
                AutoSize  = false,
                Size      = new Size(110, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Location  = new Point(thumb.Width - 114, 4)
            };
            thumb.Controls.Add(badge);

            // Area info bawah
            var infoArea = new Panel
            {
                Size      = new Size(w - 4, h - 72),
                Location  = new Point(4, 72),
                BackColor = Color.FromArgb(30, 30, 40)
            };

            var lblName = new Label
            {
                Text      = game.Name,
                Font      = new Font("Segoe UI Semibold", 9.5f, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize  = false,
                Size      = new Size(infoArea.Width - 16, 24),
                Location  = new Point(10, 6),
                TextAlign = ContentAlignment.MiddleLeft
            };

            var lblPrice = new Label
            {
                Text      = CurrencyConverter.Format(game.Price, RuntimeConfig.Instance.Currency),
                Font      = new Font("Segoe UI", 8.5f),
                ForeColor = Color.FromArgb(140, 140, 165),
                AutoSize  = false,
                Size      = new Size(infoArea.Width - 16, 18),
                Location  = new Point(10, 28),
                TextAlign = ContentAlignment.MiddleLeft
            };

            // Tombol Detail
            var btnDetail = new Button
            {
                Text      = "Detail  →",
                Size      = new Size(82, 26),
                Location  = new Point(infoArea.Width - 92, infoArea.Height - 32),
                BackColor = Color.FromArgb(0, 122, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font      = new Font("Segoe UI", 8f, FontStyle.Bold),
                Cursor    = Cursors.Hand,
                Tag       = game
            };
            btnDetail.FlatAppearance.BorderSize = 0;

            // Tombol Refund (hanya jika belum refund)
            if (game.Status == GameStatus.Owned)
            {
                var btnRefund = new Button
                {
                    Text      = "Refund",
                    Size      = new Size(68, 26),
                    Location  = new Point(10, infoArea.Height - 32),
                    BackColor = Color.FromArgb(60, 30, 30),
                    ForeColor = Color.FromArgb(255, 100, 80),
                    FlatStyle = FlatStyle.Flat,
                    Font      = new Font("Segoe UI", 8f, FontStyle.Bold),
                    Cursor    = Cursors.Hand,
                    Tag       = game
                };
                btnRefund.FlatAppearance.BorderSize  = 1;
                btnRefund.FlatAppearance.BorderColor = Color.FromArgb(120, 50, 50);
                btnRefund.Click += (s, e) => RequestRefund(game);
                infoArea.Controls.Add(btnRefund);
            }
            else if (game.Status == GameStatus.PendingRefund)
            {
                var lblRefundBadge = new Label
                {
                    Text      = "⏳ Sedang Diproses",
                    Font      = new Font("Segoe UI", 7.5f, FontStyle.Italic),
                    ForeColor = Color.FromArgb(255, 149, 0),
                    AutoSize  = false,
                    Size      = new Size(130, 26),
                    Location  = new Point(8, infoArea.Height - 32),
                    TextAlign = ContentAlignment.MiddleLeft
                };
                infoArea.Controls.Add(lblRefundBadge);
            }

            infoArea.Controls.Add(lblName);
            infoArea.Controls.Add(lblPrice);
            infoArea.Controls.Add(btnDetail);

            // ── Hover effect ──────────────────────────────────────────────────
            Color normalBg = Color.FromArgb(30, 30, 40);
            Color hoverBg  = Color.FromArgb(42, 42, 55);

            Action<bool> applyHover = (isHover) =>
            {
                card.BackColor     = isHover ? hoverBg : normalBg;
                infoArea.BackColor = isHover ? hoverBg : normalBg;
            };

            EventHandler onEnter = (s, e) => applyHover(true);
            EventHandler onLeave = (s, e) => applyHover(false);

            EventHandler openDetail = (s, e) => GameDetailRequested?.Invoke(game, _currentUser);
            btnDetail.Click        += openDetail;
            card.Click             += openDetail;
            lblName.Click          += openDetail;
            thumb.Click            += openDetail;
            lblInitials.Click      += openDetail;

            card.MouseEnter        += onEnter;
            card.MouseLeave        += onLeave;
            thumb.MouseEnter       += onEnter;
            thumb.MouseLeave       += onLeave;
            lblName.MouseEnter     += onEnter;
            lblName.MouseLeave     += onLeave;
            infoArea.MouseEnter    += onEnter;
            infoArea.MouseLeave    += onLeave;

            card.Controls.Add(accentBar);
            card.Controls.Add(thumb);
            card.Controls.Add(infoArea);

            return card;
        }

        // ── Refund ────────────────────────────────────────────────────────────
        private void RequestRefund(Game game)
        {
            var result = MessageBox.Show(
                $"Ajukan refund untuk \"{game.Name}\"?",
                "Konfirmasi Refund",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string msg = _gameService.RequestRefund(_currentUser.Id, game.Id);
                ShowToast(msg);
                RefreshData();
            }
        }

        // ── Toast ─────────────────────────────────────────────────────────────
        private void ShowToast(string message)
        {
            lblToast.Text      = message;
            panelToast.Height  = 36;
            timerToast.Start();
        }

        private void timerToast_Tick(object sender, EventArgs e)
        {
            timerToast.Stop();
            panelToast.Height = 0;
        }

        // ── Utilities ─────────────────────────────────────────────────────────
        private static string GetInitials(string name)
        {
            var words = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (words.Length == 1) return name.Length > 2 ? name[..2].ToUpper() : name.ToUpper();
            return string.Concat(words.Take(2).Select(w => w[0])).ToUpper();
        }

        private static Color DarkenColor(Color c, float factor)
        {
            return Color.FromArgb(
                c.A,
                Math.Clamp((int)(c.R * factor), 0, 255),
                Math.Clamp((int)(c.G * factor), 0, 255),
                Math.Clamp((int)(c.B * factor), 0, 255));
        }
    }
}
