using System;
using System.Windows.Forms;
using Libraries;

namespace GUI.Control
{
    public partial class GameManagement : UserControl
    {
        private AdminService adminService;

        public GameManagement(AdminService admin)
        {
            adminService = admin;

            InitializeComponent();

            dgvGames.SelectionChanged += (s, e) => FillFormFromSelected();
            btnAdd.Click += (s, e) => AddGame();
            btnEdit.Click += (s, e) => EditGame();
            btnDelete.Click += (s, e) => DeleteGame();
            btnRefresh.Click += (s, e) => LoadGames();

            LoadGames();
        }

        private void LoadGames()
        {
            try
            {
                var games = adminService.GetAllGames();
                dgvGames.Rows.Clear();

                foreach (var game in games)
                {
                    dgvGames.Rows.Add(game.Id, game.Name, CurrencyConverter.Format(game.Price, RuntimeConfig.Currency));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FillFormFromSelected()
        {
            if (dgvGames.SelectedRows.Count > 0)
            {
                tbName.Text = dgvGames.SelectedRows[0].Cells["Name"].Value?.ToString() ?? "";
                tbPrice.Text = dgvGames.SelectedRows[0].Cells["Price"].Value?.ToString()?.Replace("Rp", "").Replace("$", "").Trim() ?? "";
            }
        }

        private void AddGame()
        {
            string name = tbName.Text.Trim();
            if (!int.TryParse(tbPrice.Text.Trim(), out int price) || price <= 0)
            {
                MessageBox.Show("Harga harus berupa angka positif!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string result = adminService.AddGame(name, price);
            MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbName.Clear();
            tbPrice.Clear();
            LoadGames();
        }

        private void EditGame()
        {
            if (dgvGames.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih game terlebih dahulu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int gameId = (int)dgvGames.SelectedRows[0].Cells["Id"].Value;
            string name = tbName.Text.Trim();
            if (!int.TryParse(tbPrice.Text.Trim(), out int price) || price <= 0)
            {
                MessageBox.Show("Harga harus berupa angka positif!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string result = adminService.EditGame(gameId, name, price);
            MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadGames();
        }

        private void DeleteGame()
        {
            if (dgvGames.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih game terlebih dahulu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int gameId = (int)dgvGames.SelectedRows[0].Cells["Id"].Value;
            var result = MessageBox.Show("Hapus game ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                string message = adminService.DeleteGame(gameId);
                MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadGames();
            }
        }
    }
}
