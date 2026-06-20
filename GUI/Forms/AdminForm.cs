using System;
using System.Drawing;
using System.Windows.Forms;
using GUI.Control;

namespace GUI.Forms
{
    public partial class AdminForm : Form
    {
        private User currentUser;
        private AdminService adminService;
        private UserControl? currentControl;
        private Button? activeNavBtn;

        public AdminForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            adminService = new AdminService();
            Text = $"SETIM — Admin ({currentUser.Username})";

            btnGameManagement.Click += (s, e) =>
            {
                SetActiveNav(btnGameManagement);
                ShowControl(new GameManagement(adminService));
            };
            btnRefundManagement.Click += (s, e) =>
            {
                SetActiveNav(btnRefundManagement);
                ShowControl(new RefundManagement(adminService));
            };
            btnWalletManagement.Click += (s, e) =>
            {
                SetActiveNav(btnWalletManagement);
                ShowControl(new UserWalletManagement(adminService));
            };
            btnLogout.Click += (s, e) => Logout();

            // Start on Game page
            SetActiveNav(btnGameManagement);
            ShowControl(new GameManagement(adminService));
        }

        private void SetActiveNav(Button btn)
        {
            // Reset all nav buttons to inactive style
            foreach (Button b in new[] { btnGameManagement, btnRefundManagement, btnWalletManagement })
            {
                b.BackColor = Color.Transparent;
                b.ForeColor = Color.FromArgb(140, 140, 180);
                b.FlatAppearance.BorderSize = 0;
            }

            // Highlight the active one
            btn.BackColor = Color.FromArgb(40, 38, 90);
            btn.ForeColor = Color.FromArgb(200, 200, 255);
            btn.FlatAppearance.BorderSize = 0;

            activeNavBtn = btn;
        }

        private void ShowControl(UserControl control)
        {
            if (currentControl != null)
            {
                PagePanel.Controls.Remove(currentControl);
                currentControl.Dispose();
            }

            control.Dock = DockStyle.Fill;
            PagePanel.Controls.Add(control);
            currentControl = control;
        }

        private void Logout()
        {
            var loginForm = new LoginForm();
            loginForm.Show();
            Close();
        }
    }
}
