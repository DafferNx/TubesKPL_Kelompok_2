using System;
using System.Windows.Forms;
using Libraries;

namespace GUI.Control
{
    public partial class RefundManagement : UserControl
    {
        private AdminService adminService;

        public RefundManagement(AdminService admin)
        {
            adminService = admin;

            InitializeComponent();

            btnApprove.Click += (s, e) => ProcessRefund(true);
            btnReject.Click += (s, e) => ProcessRefund(false);
            btnRefresh.Click += (s, e) => LoadRefunds();

            LoadRefunds();
        }

        private void LoadRefunds()
        {
            try
            {
                var refunds = adminService.GetPendingRefundGames();
                dgvRefunds.Rows.Clear();

                foreach (var game in refunds)
                {
                    dgvRefunds.Rows.Add(game.UserId, game.Id, game.Name, CurrencyConverter.Format(game.Price, RuntimeConfig.Instance.Currency));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessRefund(bool approve)
        {
            if (dgvRefunds.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih refund request terlebih dahulu!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int userId = (int)dgvRefunds.SelectedRows[0].Cells["UserId"].Value;
            int gameId = (int)dgvRefunds.SelectedRows[0].Cells["Id"].Value;

            string action = approve ? "Approve" : "Reject";
            var confirm = MessageBox.Show($"{action} refund ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                string result = adminService.ProcessRefund(userId, gameId, approve);
                MessageBox.Show(result, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadRefunds();
            }
        }
    }
}
