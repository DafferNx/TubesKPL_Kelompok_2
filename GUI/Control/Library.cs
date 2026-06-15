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
            StyleDataGridView();

            btnRefund.Click += (s, e) => RequestRefund();
            btnRefresh.Click += (s, e) => LoadLibrary();

            LoadLibrary();
        }

        private void StyleDataGridView()
        {
            dgvLibrary.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.FromArgb(0, 150, 255),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(0, 5, 0, 5)
            };
            dgvLibrary.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(35, 35, 35),
                ForeColor = Color.FromArgb(220, 220, 220),
                Font = new Font("Segoe UI", 10F),
                SelectionBackColor = Color.FromArgb(0, 80, 160),
                SelectionForeColor = Color.White,
                Padding = new Padding(5, 3, 5, 3)
            };
            dgvLibrary.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(40, 40, 40)
            };
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
