using System;
using System.Drawing;
using System.Windows.Forms;
using Libraries;

namespace GUI.Control
{
    /// <summary>
    /// Detail sebuah game — ditampilkan saat user klik card di Store.
    /// Menampilkan: nama game, harga (via CurrencyConverter), status,
    /// tombol Beli Langsung, Tambah ke Cart, dan Hapus dari Cart.
    /// </summary>
    public partial class GameDetail : UserControl
    {
        // ── State ─────────────────────────────────────────────────────────────────
        private User _currentUser;
        private Game? _game;
        private GameService _gameService;

        // ── Events ke MainForm ────────────────────────────────────────────────────
        public event Action<User>? BackToStoreRequested;

        public GameDetail(User user, GameService gameService)
        {
            _currentUser = user;
            _gameService = gameService;
            InitializeComponent();
        }

        // ── Load ─────────────────────────────────────────────────────────────────
        public void LoadDetail(Game game)
        {
            _game = game;
            RefreshView();
        }

        private void RefreshView()
        {
            if (_game == null) return;

            // Re-fetch agar status selalu terbaru dari DB
            _game = _gameService.GetGameById(_currentUser.Id, _game.Id) ?? _game;

            lblGameName.Text = _game.Name;

            // Harga menggunakan CurrencyConverter sesuai RuntimeConfig
            lblPrice.Text = CurrencyConverter.Format(_game.Price, RuntimeConfig.Instance.Currency);

            UpdateStatusBadge();
            UpdateActionButtons();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        // ── Status badge ──────────────────────────────────────────────────────────
        private void UpdateStatusBadge()
        {
            (string text, Color bg, Color fg) = _game!.Status switch
            {
                GameStatus.Owned => ("✓  Dimiliki", Color.FromArgb(20, 52, 25), Color.FromArgb(52, 199, 89)),
                GameStatus.Cart => ("🛒  Di Cart", Color.FromArgb(50, 40, 10), Color.FromArgb(255, 200, 50)),
                GameStatus.PendingRefund => ("⏳  Menunggu Refund", Color.FromArgb(50, 20, 10), Color.FromArgb(255, 100, 58)),
                _ => ("• Belum Dimiliki", Color.FromArgb(36, 36, 44), Color.FromArgb(180, 180, 190)),
            };

            lblStatus.Text = text;
            lblStatus.BackColor = bg;
            lblStatus.ForeColor = fg;
        }

        // ── Tombol aksi ───────────────────────────────────────────────────────────
        private void UpdateActionButtons()
        {
            btnBuyDirect.Visible = false;
            btnAddCart.Visible = false;
            btnRemoveCart.Visible = false;
            lblOwnedNote.Visible = false;
            lblRefundNote.Visible = false;

            switch (_game!.Status)
            {
                case GameStatus.NotOwned:
                    btnBuyDirect.Visible = true;
                    btnAddCart.Visible = true;
                    break;

                case GameStatus.Cart:
                    btnBuyDirect.Visible = true;   // bisa langsung beli dari cart
                    btnRemoveCart.Visible = true;
                    break;

                case GameStatus.Owned:
                    lblOwnedNote.Visible = true;
                    break;

                case GameStatus.PendingRefund:
                    lblRefundNote.Visible = true;
                    break;
            }
        }

        // ── Aksi tombol ───────────────────────────────────────────────────────────
        private void btnBuyDirect_Click(object sender, EventArgs e)
        {
            if (_game == null) return;
            ShowResult(_gameService.BuyGame(_currentUser.Id, _game.Id));
            RefreshView();
        }

        private void btnAddCart_Click(object sender, EventArgs e)
        {
            if (_game == null) return;
            ShowResult(_gameService.AddToCart(_currentUser.Id, _game.Id));
            RefreshView();
        }

        private void btnRemoveCart_Click(object sender, EventArgs e)
        {
            if (_game == null) return;
            ShowResult(_gameService.RemoveFromCart(_currentUser.Id, _game.Id));
            RefreshView();
        }

        private void btnBack_Click(object sender, EventArgs e) =>
            BackToStoreRequested?.Invoke(_currentUser);

        // ── Helper pesan ─────────────────────────────────────────────────────────
        private void ShowResult(string message)
        {
            bool success = !message.ToLower().Contains("tidak") &&
                           !message.ToLower().Contains("sudah") &&
                           !message.ToLower().Contains("harus") &&
                           !message.ToLower().Contains("gagal");

            lblResultMsg.Text = message;
            lblResultMsg.ForeColor = success
                ? Color.FromArgb(52, 199, 89)
                : Color.FromArgb(255, 100, 58);
            lblResultMsg.Visible = true;
            timerResult.Start();
        }

        private void timerResult_Tick(object sender, EventArgs e)
        {
            timerResult.Stop();
            lblResultMsg.Visible = false;
        }
    }
}
