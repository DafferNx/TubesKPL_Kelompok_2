namespace GUI.Control
{
    partial class GameManagement
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new Label();
            dgvGames = new DataGridView();
            lblName = new Label();
            tbName = new TextBox();
            lblPrice = new Label();
            tbPrice = new TextBox();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnRefresh = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(297, 45);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "GAME MANAGEMENT";
            // 
            // dgvGames
            // 
            dgvGames.AllowUserToAddRows = false;
            dgvGames.AllowUserToDeleteRows = false;
            dgvGames.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvGames.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvGames.Location = new Point(20, 55);
            dgvGames.MultiSelect = false;
            dgvGames.Name = "dgvGames";
            dgvGames.ReadOnly = true;
            dgvGames.RowHeadersVisible = false;
            dgvGames.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvGames.Size = new Size(580, 200);
            dgvGames.TabIndex = 1;
            dgvGames.Columns.Add("Id", "ID");
            dgvGames.Columns.Add("Name", "Nama");
            dgvGames.Columns.Add("Price", "Harga");
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(20, 270);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 25);
            lblName.TabIndex = 2;
            lblName.Text = "Nama:";
            // 
            // tbName
            // 
            tbName.Location = new Point(80, 267);
            tbName.Name = "tbName";
            tbName.Size = new Size(200, 31);
            tbName.TabIndex = 3;
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(20, 310);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(56, 25);
            lblPrice.TabIndex = 4;
            lblPrice.Text = "Harga:";
            // 
            // tbPrice
            // 
            tbPrice.Location = new Point(80, 307);
            tbPrice.Name = "tbPrice";
            tbPrice.Size = new Size(200, 31);
            tbPrice.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(20, 360);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Tambah";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(130, 360);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 35);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(240, 360);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Hapus";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(350, 360);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(100, 35);
            btnRefresh.TabIndex = 9;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = true;
            // 
            // GameManagement
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnRefresh);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(tbPrice);
            Controls.Add(lblPrice);
            Controls.Add(tbName);
            Controls.Add(lblName);
            Controls.Add(dgvGames);
            Controls.Add(lblTitle);
            Name = "GameManagement";
            Size = new Size(637, 450);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitle;
        private DataGridView dgvGames;
        private Label lblName;
        private TextBox tbName;
        private Label lblPrice;
        private TextBox tbPrice;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
    }
}
