using System;
using System.Windows.Forms;

namespace GUI.Control
{
    public partial class UserWalletManagement : UserControl
    {
        private AdminService adminService;

        public UserWalletManagement(AdminService admin)
        {
            adminService = admin;

            InitializeComponent();

            btnBan.Click += (s, e) => BanWallet();
            btnUnban.Click += (s, e) => UnbanWallet();
            btnRefresh.Click += (s, e) => LoadUsers();

            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                var users = adminService.GetAllUsers();
                dgvUsers.Rows.Clear();

                foreach (var user in users)
                {
                    dgvUsers.Rows.Add(user.Id, user.Username, user.Role, user.Wallet.Balance, user.Wallet.CurrentState);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BanWallet()
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih user terlebih dahulu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = (int)dgvUsers.SelectedRows[0].Cells["Id"].Value;
            var confirm = MessageBox.Show("Ban wallet user ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string result = adminService.BanWallet(userId);
                MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
        }

        private void UnbanWallet()
        {
            if (dgvUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih user terlebih dahulu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = (int)dgvUsers.SelectedRows[0].Cells["Id"].Value;
            var confirm = MessageBox.Show("Unban wallet user ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string result = adminService.UnbanWallet(userId);
                MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
        }
    }
}
