using System;
using System.Windows.Forms;
using Libraries;

namespace GUI
{
    public partial class Store : UserControl
    {
        private User currentUser;
        private GameService gameService;
        private AuthService authService;

        public Store(User user, GameService gs, AuthService auth)
        {
            currentUser = user;
            gameService = gs;
            authService = auth;

            InitializeComponent();

            btnBuy.Click += (s, e) => BuyGame();
            btnAddToCart.Click += (s, e) => AddToCart();
            btnRefresh.Click += (s, e) => LoadGames();
            btnToggleWallet.Click += (s, e) => ToggleWallet();
            btnTopUp.Click += (s, e) => TopUp();

            UpdateToggleButton();
            LoadGames();
        }

        private void UpdateToggleButton()
        {
            btnToggleWallet.Text = currentUser.Wallet.CurrentState == WalletState.Active
                ? "Nonaktifkan Wallet"
                : "Aktifkan Wallet";
        }

        private void LoadGames()
        {
            try
            {
                var games = gameService.getAllGames(currentUser.Id);
                dgvGames.Rows.Clear();

                foreach (var game in games)
                {
                    if (game.Status == GameStatus.Owned || game.Status == GameStatus.PendingRefund) continue;
                    dgvGames.Rows.Add(game.Id, game.Name, CurrencyConverter.Format(game.Price, RuntimeConfig.Currency));
                }

                UpdateWalletDisplay();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading games: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateWalletDisplay()
        {
            currentUser = authService.GetUserById(currentUser.Id);
            lblWallet.Text = $"User: {currentUser.Username} | Wallet: {currentUser.Wallet.CurrentState} | Balance: {CurrencyConverter.Format(currentUser.Wallet.Balance, RuntimeConfig.Currency)}";
            UpdateToggleButton();
        }

        private void BuyGame()
        {
            if (dgvGames.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih game terlebih dahulu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int gameId = (int)dgvGames.SelectedRows[0].Cells["Id"].Value;
            string result = gameService.buyGame(currentUser.Id, gameId);
            MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGames();
        }

        private void AddToCart()
        {
            if (dgvGames.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih game terlebih dahulu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int gameId = (int)dgvGames.SelectedRows[0].Cells["Id"].Value;
            string result = gameService.addToCart(currentUser.Id, gameId);
            MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGames();
        }

        private void ToggleWallet()
        {
            string result;
            if (currentUser.Wallet.CurrentState == WalletState.Active)
                result = authService.DeactivateWallet(currentUser);
            else
                result = authService.ActivateWallet(currentUser);

            MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGames();
        }

        private void TopUp()
        {
            if (!int.TryParse(tbTopUp.Text.Trim(), out int amount) || amount <= 0)
            {
                MessageBox.Show("Masukkan jumlah top up yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string result = authService.TopUpWallet(currentUser, amount);
            MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbTopUp.Clear();
            LoadGames();
        }
    }
}
