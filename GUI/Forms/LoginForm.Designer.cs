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
            label1 = new Label();
            tbUsername = new TextBox();
            label2 = new Label();
            label3 = new Label();
            tbPassword = new TextBox();
            btnLogin = new Button();
            panelLogin = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 150, 255);
            label1.Location = new Point(160, 40);
            label1.Name = "label1";
            label1.Size = new Size(198, 74);
            label1.TabIndex = 0;
            label1.Text = "SETIM";
            // 
            // tbUsername
            // 
            tbUsername.BackColor = Color.FromArgb(35, 35, 35);
            tbUsername.BorderStyle = BorderStyle.FixedSingle;
            tbUsername.Font = new Font("Segoe UI", 11F);
            tbUsername.ForeColor = Color.White;
            tbUsername.Location = new Point(70, 190);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(340, 37);
            tbUsername.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = Color.FromArgb(192, 192, 192);
            label2.Location = new Point(70, 160);
            label2.Name = "label2";
            label2.Size = new Size(99, 28);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = Color.FromArgb(192, 192, 192);
            label3.Location = new Point(70, 250);
            label3.Name = "label3";
            label3.Size = new Size(93, 28);
            label3.TabIndex = 3;
            label3.Text = "Password";
            // 
            // tbPassword
            // 
            tbPassword.BackColor = Color.FromArgb(35, 35, 35);
            tbPassword.BorderStyle = BorderStyle.FixedSingle;
            tbPassword.Font = new Font("Segoe UI", 11F);
            tbPassword.ForeColor = Color.White;
            tbPassword.Location = new Point(70, 280);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(340, 37);
            tbPassword.TabIndex = 4;
            tbPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(0, 96, 160);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(150, 365);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(180, 48);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click_1;
            // 
            // panelLogin
            // 
            panelLogin.Location = new Point(0, 0);
            panelLogin.Name = "panelLogin";
            panelLogin.Size = new Size(480, 480);
            panelLogin.TabIndex = 6;
            // 
            // LoginForm
            // 
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 28, 28);
            ClientSize = new Size(480, 480);
            Controls.Add(btnLogin);
            Controls.Add(tbPassword);
            Controls.Add(label3);
            Controls.Add(tbUsername);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SETIM - Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private TextBox tbUsername;
        private Label label2;
        private Label label3;
        private TextBox tbPassword;
        private Button btnLogin;
        private Panel panelLogin;
    }
}
