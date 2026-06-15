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
            StyleDataGridView();

            btnCheckout.Click += (s, e) => Checkout();
            btnRemove.Click += (s, e) => RemoveFromCart();
            btnRefresh.Click += (s, e) => LoadCart();

            LoadCart();
        }

        private void StyleDataGridView()
        {
            dgvCart.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.FromArgb(0, 150, 255),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(0, 5, 0, 5)
            };
            dgvCart.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(35, 35, 35),
                ForeColor = Color.FromArgb(220, 220, 220),
                Font = new Font("Segoe UI", 10F),
                SelectionBackColor = Color.FromArgb(0, 80, 160),
                SelectionForeColor = Color.White,
                Padding = new Padding(5, 3, 5, 3)
            };
            dgvCart.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(40, 40, 40)
            };
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
                lblTotal.Text = cartGames.Count == 0
                    ? "Cart kosong"
                    : $"Total: {CurrencyConverter.Format(total, RuntimeConfig.Currency)}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat cart: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Checkout()
        {
            var cartGames = gameService.getCartGames(currentUser.Id);
            if (cartGames.Count == 0)
            {
                MessageBox.Show("Cart kosong, tidak ada yang bisa di-checkout.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                $"Checkout semua game di cart?\nTotal: {CurrencyConverter.Format(gameService.getTotalCartPrice(currentUser.Id), RuntimeConfig.Currency)}",
                "Konfirmasi Checkout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            string result = gameService.checkoutCart(currentUser.Id);
            MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadCart();
        }

        private void RemoveFromCart()
        {
            if (dgvCart.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih game yang ingin dihapus dari cart!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string gameName = dgvCart.SelectedRows[0].Cells["Name"].Value?.ToString() ?? "";
            var confirm = MessageBox.Show(
                $"Hapus \"{gameName}\" dari cart?",
                "Konfirmasi Hapus",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            int gameId = (int)dgvCart.SelectedRows[0].Cells["Id"].Value;
            string result = gameService.removeFromCart(currentUser.Id, gameId);
            MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadCart();
        }
    }
}
