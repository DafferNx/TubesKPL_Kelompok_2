using System;
using System.Windows.Forms;

namespace GUI.Forms
{
    public partial class MainForm : Form
    {
        private User currentUser;
        private GameService gameService;
        private AuthService authService;
        private UserControl? currentControl;

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            gameService = new GameService();
            authService = new AuthService();
            Text = $"SETIM - {currentUser.Username}";

            btnStore.Click += (s, e) => ShowControl(new Store(currentUser, gameService, authService));
            btnLibrary.Click += (s, e) => ShowControl(new Library(currentUser, gameService));
            btnWallet.Click += (s, e) => ShowControl(new Wallet(currentUser, authService));
            btnCart.Click += (s, e) => ShowControl(new Cart(currentUser, gameService, authService));
            btnLogout.Click += (s, e) => Logout();

            ShowControl(new Store(currentUser, gameService, authService));
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
