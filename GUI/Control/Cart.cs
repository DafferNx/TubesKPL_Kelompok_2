using System;
using System.Windows.Forms;
using Libraries;

namespace GUI
{
    public partial class Cart : UserControl
    {
        private User currentUser;
        private GameService gameService;
        private AuthService authService;

        public Cart(User user, GameService gs, AuthService auth)
        {
            currentUser = user;
            gameService = gs;
            authService = auth;

            InitializeComponent();

            btnCheckout.Click += (s, e) => Checkout();
            btnRemove.Click += (s, e) => RemoveFromCart();
            btnRefresh.Click += (s, e) => LoadCart();

            LoadCart();
        }

        private void LoadCart()
        {
            try
            {
                var cartGames = gameService.getCartGames(currentUser.Id);
                dgvCart.Rows.Clear();

                foreach (var game in cartGames)
                {
                    dgvCart.Rows.Add(game.Id, game.Name, CurrencyConverter.Format(game.Price, RuntimeConfig.Currency));
                }

                int total = gameService.getTotalCartPrice(currentUser.Id);
                lblTotal.Text = $"Total: {CurrencyConverter.Format(total, RuntimeConfig.Currency)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Checkout()
        {
            string result = gameService.checkoutCart(currentUser.Id);
            MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadCart();
        }

        private void RemoveFromCart()
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih game terlebih dahulu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int gameId = (int)dgvCart.SelectedRows[0].Cells["Id"].Value;
            string result = gameService.removeFromCart(currentUser.Id, gameId);
            MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadCart();
        }
    }
}
