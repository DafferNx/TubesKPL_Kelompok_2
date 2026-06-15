using System;
using System.Windows.Forms;
using GUI.Control;

namespace GUI.Forms
{
    public partial class AdminForm : Form
    {
        private User currentUser;
        private AdminService adminService;
        private UserControl? currentControl;

        public AdminForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            adminService = new AdminService();
            Text = $"Admin - SETIM ({currentUser.Username})";

            btnGameManagement.Click += (s, e) => ShowControl(new GameManagement(adminService));
            btnRefundManagement.Click += (s, e) => ShowControl(new RefundManagement(adminService));
            btnWalletManagement.Click += (s, e) => ShowControl(new UserWalletManagement(adminService));
            btnLogout.Click += (s, e) => Logout();

            ShowControl(new GameManagement(adminService));
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
