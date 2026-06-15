using System;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class LoginForm : Form
    {
        private AuthService authService = new AuthService();

        public LoginForm()
        {
            InitializeComponent();
            btnLogin.Click += btnLogin_Click;
        }

        private void btnLogin_Click(object? sender, EventArgs e)
        {
            string username = tbUsername.Text.Trim();
            string password = tbPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Username dan password harus diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                User user = authService.Login(username, password);

                if (user.Role == UserRole.Admin)
                {
                    AdminForm adminForm = new AdminForm(user);
                    adminForm.Show();
                    Hide();
                }
                else
                {
                    MainForm mainForm = new MainForm(user);
                    mainForm.Show();
                    Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
