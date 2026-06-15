using System.Windows.Forms;

namespace GUI.Control
{
    partial class GameDetail
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            panelHeader = new Panel();
            panelContent = new Panel();
            panelCard = new Panel();
            panelActions = new Panel();

            btnBack = new Button();
            lblBreadcrumb = new Label();

            lblGameName = new Label();
            lblPriceLabel = new Label();
            lblPrice = new Label();
            lblStatus = new Label();
            lblResultMsg = new Label();
            lblOwnedNote = new Label();
            lblRefundNote = new Label();

            btnBuyDirect = new Button();
            btnAddCart = new Button();
            btnRemoveCart = new Button();

            timerResult = new System.Windows.Forms.Timer(components);

            SuspendLayout();

            // ── panelHeader ─────────────────────────────────────────────
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 56;
            panelHeader.BackColor = System.Drawing.Color.FromArgb(22, 22, 28);
            panelHeader.Controls.Add(btnBack);
            panelHeader.Controls.Add(lblBreadcrumb);

            btnBack.Text = "← Kembali ke Store";
            btnBack.Size = new System.Drawing.Size(160, 34);
            btnBack.Location = new System.Drawing.Point(12, 11);
            btnBack.BackColor = System.Drawing.Color.FromArgb(40, 40, 50);
            btnBack.ForeColor = System.Drawing.Color.FromArgb(180, 180, 200);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            btnBack.Cursor = Cursors.Hand;
            btnBack.Click += new System.EventHandler(btnBack_Click);

            lblBreadcrumb.Text = "Store  ›  Detail Game";
            lblBreadcrumb.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            lblBreadcrumb.ForeColor = System.Drawing.Color.FromArgb(100, 100, 120);
            lblBreadcrumb.AutoSize = true;
            lblBreadcrumb.Location = new System.Drawing.Point(186, 18);

            // ── panelContent ────────────────────────────────────────────
            panelContent.Dock = DockStyle.Fill;
            panelContent.BackColor = System.Drawing.Color.FromArgb(26, 26, 32);
            panelContent.AutoScroll = true;
            panelContent.Controls.Add(panelCard);

            // ── panelCard ───────────────────────────────────────────────
            panelCard.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelCard.Location = new System.Drawing.Point(40, 36);
            panelCard.Size = new System.Drawing.Size(620, 340);
            panelCard.BackColor = System.Drawing.Color.FromArgb(30, 30, 38);
            panelCard.Controls.Add(lblGameName);
            panelCard.Controls.Add(lblPriceLabel);
            panelCard.Controls.Add(lblPrice);
            panelCard.Controls.Add(lblStatus);
            panelCard.Controls.Add(panelActions);
            panelCard.Controls.Add(lblResultMsg);
            panelCard.Controls.Add(lblOwnedNote);
            panelCard.Controls.Add(lblRefundNote);

            // Nama game — besar, di atas
            lblGameName.Text = "Game Name";
            lblGameName.Font = new System.Drawing.Font("Segoe UI", 22f, System.Drawing.FontStyle.Bold);
            lblGameName.ForeColor = System.Drawing.Color.White;
            lblGameName.AutoSize = false;
            lblGameName.Size = new System.Drawing.Size(580, 54);
            lblGameName.Location = new System.Drawing.Point(24, 24);

            // Status badge
            lblStatus.Text = "• Belum Dimiliki";
            lblStatus.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold);
            lblStatus.AutoSize = false;
            lblStatus.Size = new System.Drawing.Size(220, 28);
            lblStatus.Location = new System.Drawing.Point(24, 84);
            lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblStatus.Padding = new Padding(8, 0, 0, 0);

            // Label "HARGA" kecil
            lblPriceLabel.Text = "HARGA";
            lblPriceLabel.Font = new System.Drawing.Font("Segoe UI", 8f, System.Drawing.FontStyle.Bold);
            lblPriceLabel.ForeColor = System.Drawing.Color.FromArgb(120, 120, 128);
            lblPriceLabel.AutoSize = true;
            lblPriceLabel.Location = new System.Drawing.Point(24, 132);

            // Harga — besar, hijau (teks diisi saat runtime via CurrencyConverter)
            lblPrice.Text = "";
            lblPrice.Font = new System.Drawing.Font("Segoe UI", 26f, System.Drawing.FontStyle.Bold);
            lblPrice.ForeColor = System.Drawing.Color.FromArgb(0, 210, 110);
            lblPrice.AutoSize = true;
            lblPrice.Location = new System.Drawing.Point(24, 152);

            // Panel tombol aksi
            panelActions.Size = new System.Drawing.Size(580, 56);
            panelActions.Location = new System.Drawing.Point(24, 228);
            panelActions.BackColor = System.Drawing.Color.Transparent;
            panelActions.Controls.Add(btnBuyDirect);
            panelActions.Controls.Add(btnAddCart);
            panelActions.Controls.Add(btnRemoveCart);

            // Tombol "Beli Langsung"
            btnBuyDirect.Text = "💳 Beli Langsung";
            btnBuyDirect.Size = new System.Drawing.Size(190, 46);
            btnBuyDirect.Location = new System.Drawing.Point(0, 5);
            btnBuyDirect.BackColor = System.Drawing.Color.FromArgb(0, 122, 255);
            btnBuyDirect.ForeColor = System.Drawing.Color.White;
            btnBuyDirect.FlatStyle = FlatStyle.Flat;
            btnBuyDirect.FlatAppearance.BorderSize = 0;
            btnBuyDirect.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            btnBuyDirect.Cursor = Cursors.Hand;
            btnBuyDirect.Click += new System.EventHandler(btnBuyDirect_Click);

            // Tombol "+ Tambah ke Cart"
            btnAddCart.Text = "🛒 + Tambah ke Cart";
            btnAddCart.Size = new System.Drawing.Size(190, 46);
            btnAddCart.Location = new System.Drawing.Point(202, 5);
            btnAddCart.BackColor = System.Drawing.Color.FromArgb(44, 44, 54);
            btnAddCart.ForeColor = System.Drawing.Color.FromArgb(200, 200, 210);
            btnAddCart.FlatStyle = FlatStyle.Flat;
            btnAddCart.FlatAppearance.BorderSize = 1;
            btnAddCart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(60, 60, 72);
            btnAddCart.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            btnAddCart.Cursor = Cursors.Hand;
            btnAddCart.Click += new System.EventHandler(btnAddCart_Click);

            // Tombol "- Hapus dari Cart"
            btnRemoveCart.Text = "✕ Hapus dari Cart";
            btnRemoveCart.Size = new System.Drawing.Size(190, 46);
            btnRemoveCart.Location = new System.Drawing.Point(202, 5);
            btnRemoveCart.BackColor = System.Drawing.Color.FromArgb(60, 30, 30);
            btnRemoveCart.ForeColor = System.Drawing.Color.FromArgb(255, 100, 80);
            btnRemoveCart.FlatStyle = FlatStyle.Flat;
            btnRemoveCart.FlatAppearance.BorderSize = 1;
            btnRemoveCart.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(120, 50, 50);
            btnRemoveCart.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            btnRemoveCart.Cursor = Cursors.Hand;
            btnRemoveCart.Visible = false;
            btnRemoveCart.Click += new System.EventHandler(btnRemoveCart_Click);

            // Pesan hasil aksi
            lblResultMsg.Text = "";
            lblResultMsg.Font = new System.Drawing.Font("Segoe UI", 9.5f);
            lblResultMsg.ForeColor = System.Drawing.Color.FromArgb(52, 199, 89);
            lblResultMsg.AutoSize = false;
            lblResultMsg.Size = new System.Drawing.Size(580, 26);
            lblResultMsg.Location = new System.Drawing.Point(24, 296);
            lblResultMsg.Visible = false;

            // Note: sudah dimiliki
            lblOwnedNote.Text = "✓  Kamu sudah memiliki game ini.";
            lblOwnedNote.Font = new System.Drawing.Font("Segoe UI", 10f);
            lblOwnedNote.ForeColor = System.Drawing.Color.FromArgb(52, 199, 89);
            lblOwnedNote.AutoSize = false;
            lblOwnedNote.Size = new System.Drawing.Size(580, 46);
            lblOwnedNote.Location = new System.Drawing.Point(24, 228);
            lblOwnedNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblOwnedNote.Visible = false;

            // Note: sedang refund
            lblRefundNote.Text = "⏳  Game ini sedang dalam proses refund.";
            lblRefundNote.Font = new System.Drawing.Font("Segoe UI", 10f);
            lblRefundNote.ForeColor = System.Drawing.Color.FromArgb(255, 150, 58);
            lblRefundNote.AutoSize = false;
            lblRefundNote.Size = new System.Drawing.Size(580, 46);
            lblRefundNote.Location = new System.Drawing.Point(24, 228);
            lblRefundNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            lblRefundNote.Visible = false;

            timerResult.Interval = 3000;
            timerResult.Tick += new System.EventHandler(timerResult_Tick);

            // ── GameDetail UserControl ───────────────────────────────────
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(26, 26, 32);
            Size = new System.Drawing.Size(900, 600);
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Name = "GameDetail";

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panelHeader;
        private Panel panelContent;
        private Panel panelCard;
        private Panel panelActions;
        private Button btnBack;
        private Label lblBreadcrumb;
        private Label lblGameName;
        private Label lblPriceLabel;
        private Label lblPrice;
        private Label lblStatus;
        private Label lblResultMsg;
        private Label lblOwnedNote;
        private Label lblRefundNote;
        private Button btnBuyDirect;
        private Button btnAddCart;
        private Button btnRemoveCart;
        private System.Windows.Forms.Timer timerResult;
    }
}
