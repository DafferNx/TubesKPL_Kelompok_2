namespace GUI.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            tbUsername = new TextBox();
            tbPassword = new TextBox();
            lblUsername = new Label();
            lblPassword = new Label();
            btnLogin = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(0, 150, 255);
            lblTitle.Location = new Point(122, 34);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(198, 74);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "SETIM";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbUsername
            // 
            tbUsername.BackColor = Color.FromArgb(35, 35, 35);
            tbUsername.BorderStyle = BorderStyle.FixedSingle;
            tbUsername.Font = new Font("Segoe UI", 11F);
            tbUsername.ForeColor = Color.White;
            tbUsername.Location = new Point(70, 190);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(320, 37);
            tbUsername.TabIndex = 2;
            // 
            // tbPassword
            // 
            tbPassword.BackColor = Color.FromArgb(35, 35, 35);
            tbPassword.BorderStyle = BorderStyle.FixedSingle;
            tbPassword.Font = new Font("Segoe UI", 11F);
            tbPassword.ForeColor = Color.White;
            tbPassword.Location = new Point(70, 280);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(320, 37);
            tbPassword.TabIndex = 4;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 10F);
            lblUsername.ForeColor = Color.FromArgb(192, 192, 192);
            lblUsername.Location = new Point(70, 160);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(99, 28);
            lblUsername.TabIndex = 1;
            lblUsername.Text = "Username";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10F);
            lblPassword.ForeColor = Color.FromArgb(192, 192, 192);
            lblPassword.Location = new Point(70, 250);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(93, 28);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 96, 160);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(140, 360);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(180, 48);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 28);
            ClientSize = new Size(460, 480);
            Controls.Add(btnLogin);
            Controls.Add(tbPassword);
            Controls.Add(lblPassword);
            Controls.Add(tbUsername);
            Controls.Add(lblUsername);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimumSize = new Size(460, 480);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SETIM - Login";
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private Label lblUsername;
        private TextBox tbUsername;
        private Label lblPassword;
        private TextBox tbPassword;
        private Button btnLogin;
    }
}
