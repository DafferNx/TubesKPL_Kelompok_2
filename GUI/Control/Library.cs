using System;
using System.Windows.Forms;
using Libraries;

namespace GUI
{
    public partial class Library : UserControl
    {
        private User currentUser;
        private GameService gameService;

        public Library(User user, GameService gs)
        {
            currentUser = user;
            gameService = gs;

            InitializeComponent();

            btnRefund.Click += (s, e) => RequestRefund();
            btnRefresh.Click += (s, e) => LoadLibrary();

            LoadLibrary();
        }

        private void LoadLibrary()
        {
            try
            {
                var ownedGames = gameService.getOwnedGames(currentUser.Id);
                dgvLibrary.Rows.Clear();

                foreach (var game in ownedGames)
                {
                    dgvLibrary.Rows.Add(game.Id, game.Name, CurrencyConverter.Format(game.Price, RuntimeConfig.Currency), game.Status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading library: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RequestRefund()
        {
            if (dgvLibrary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih game terlebih dahulu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int gameId = (int)dgvLibrary.SelectedRows[0].Cells["Id"].Value;
            var result = MessageBox.Show("Ajukan refund untuk game ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string message = gameService.requestRefund(currentUser.Id, gameId);
                MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadLibrary();
            }
        }
    }
}
