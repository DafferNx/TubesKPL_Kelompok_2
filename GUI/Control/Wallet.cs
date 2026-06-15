using System;
using System.Windows.Forms;
using Libraries;

namespace GUI
{
    public partial class Wallet : UserControl
    {
        private User currentUser;
        private AuthService authService;

        public Wallet(User user, AuthService auth)
        {
            currentUser = user;
            authService = auth;

            InitializeComponent();

            btnActivate.Click += (s, e) => ToggleWallet();
            btnTopUp.Click += (s, e) => TopUp();
            btnRefresh.Click += (s, e) => UpdateDisplay();

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            currentUser = authService.GetUserById(currentUser.Id);
            lblBalance.Text = $"Balance: {CurrencyConverter.Format(currentUser.Wallet.Balance, RuntimeConfig.Currency)}";
            lblState.Text = $"State: {currentUser.Wallet.CurrentState}";

            btnActivate.Text = currentUser.Wallet.CurrentState == WalletState.Active
                ? "Nonaktifkan Wallet"
                : "Aktifkan Wallet";
        }

        private void ToggleWallet()
        {
            string result;
            if (currentUser.Wallet.CurrentState == WalletState.Active)
                result = authService.DeactivateWallet(currentUser);
            else
                result = authService.ActivateWallet(currentUser);

            MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateDisplay();
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
            UpdateDisplay();
        }
    }
}
