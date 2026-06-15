using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace GUI
{
    partial class Cart
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            panelHeader = new Panel();
            panelSummary = new Panel();  // sticky bottom summary bar
            panelItems = new Panel();  // scrollable card list
            panelEmpty = new Panel();  // empty state

            lblTitle = new Label();
            lblSubtitle = new Label();
            lblItemCount = new Label();
            lblTotalLabel = new Label();
            lblTotal = new Label();
            lblEmpty = new Label();

            btnRefresh = new Button();
            btnCheckout = new Button();

            timerToast = new Timer(components) { Interval = 2500 };

            SuspendLayout();

            // ══════════════════════════════════════════════════════════════════
            // panelHeader  (90px — cukup untuk title + subtitle)
            // ══════════════════════════════════════════════════════════════════
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Height = 90;
            panelHeader.BackColor = System.Drawing.Color.FromArgb(14, 14, 20);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(lblSubtitle);
            panelHeader.Controls.Add(lblItemCount);
            panelHeader.Controls.Add(btnRefresh);

            lblTitle.Text = "🛒  Cart";
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 17f, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.AutoSize = true;
            lblTitle.Location = new System.Drawing.Point(22, 8);

            lblSubtitle.Text = "Game yang siap di-checkout";
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9f);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 100, 125);
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new System.Drawing.Point(24, 56);

            lblItemCount.Text = "0 item";
            lblItemCount.Font = new System.Drawing.Font("Segoe UI", 8.5f, System.Drawing.FontStyle.Bold);
            lblItemCount.ForeColor = System.Drawing.Color.FromArgb(0, 150, 255);
            lblItemCount.BackColor = System.Drawing.Color.FromArgb(0, 45, 90);
            lblItemCount.AutoSize = false;
            lblItemCount.Size = new System.Drawing.Size(54, 22);
            lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblItemCount.Location = new System.Drawing.Point(110, 13);

            // Refresh button — posisi X via LayoutHeader()
            btnRefresh.Text = "↻";
            btnRefresh.Size = new System.Drawing.Size(38, 38);
            btnRefresh.Anchor = AnchorStyles.None;
            btnRefresh.Location = new System.Drawing.Point(0, 26);
            btnRefresh.BackColor = System.Drawing.Color.FromArgb(32, 32, 44);
            btnRefresh.ForeColor = System.Drawing.Color.FromArgb(140, 140, 180);
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 1;
            btnRefresh.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(50, 50, 68);
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 14f);
            btnRefresh.Cursor = Cursors.Hand;

            // ══════════════════════════════════════════════════════════════════
            // panelSummary  (sticky bottom, checkout bar)
            // ══════════════════════════════════════════════════════════════════
            panelSummary.Dock = DockStyle.Bottom;
            panelSummary.Height = 72;
            panelSummary.BackColor = System.Drawing.Color.FromArgb(18, 18, 26);
            panelSummary.Controls.Add(lblTotalLabel);
            panelSummary.Controls.Add(lblTotal);
            panelSummary.Controls.Add(btnCheckout);

            lblTotalLabel.Text = "TOTAL";
            lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 7.5f, System.Drawing.FontStyle.Bold);
            lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(100, 100, 130);
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Location = new System.Drawing.Point(22, 10);

            lblTotal.Text = "Rp 0";
            lblTotal.Font = new System.Drawing.Font("Segoe UI", 18f, System.Drawing.FontStyle.Bold);
            lblTotal.ForeColor = System.Drawing.Color.FromArgb(0, 215, 125);
            lblTotal.AutoSize = true;
            lblTotal.Location = new System.Drawing.Point(18, 26);

            btnCheckout.Text = "✔  Checkout Semua";
            btnCheckout.Size = new System.Drawing.Size(190, 44);
            btnCheckout.Anchor = AnchorStyles.Right | AnchorStyles.Top;
            btnCheckout.Location = new System.Drawing.Point(690, 14);
            btnCheckout.BackColor = System.Drawing.Color.FromArgb(0, 195, 107);
            btnCheckout.ForeColor = System.Drawing.Color.White;
            btnCheckout.FlatStyle = FlatStyle.Flat;
            btnCheckout.FlatAppearance.BorderSize = 0;
            btnCheckout.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);
            btnCheckout.Cursor = Cursors.Hand;

            // ══════════════════════════════════════════════════════════════════
            // panelItems  (scrollable card list)
            // ══════════════════════════════════════════════════════════════════
            panelItems.Dock = DockStyle.Fill;
            panelItems.AutoScroll = true;
            panelItems.BackColor = System.Drawing.Color.FromArgb(20, 20, 28);
            panelItems.Padding = new Padding(22, 16, 22, 16);

            // ── Empty state ────────────────────────────────────────────────────
            panelEmpty.Anchor = AnchorStyles.None;
            panelEmpty.Size = new System.Drawing.Size(340, 130);
            panelEmpty.BackColor = System.Drawing.Color.Transparent;
            panelEmpty.Visible = false;
            panelEmpty.Controls.Add(lblEmpty);

            lblEmpty.Text = "🛒\n\nCart kamu masih kosong.\nTambah game dari Store!";
            lblEmpty.Font = new System.Drawing.Font("Segoe UI", 11f);
            lblEmpty.ForeColor = System.Drawing.Color.FromArgb(80, 80, 105);
            lblEmpty.AutoSize = false;
            lblEmpty.Dock = DockStyle.Fill;
            lblEmpty.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            panelItems.Controls.Add(panelEmpty);

            // Timer toast feedback
            timerToast.Tick += new System.EventHandler(timerToast_Tick);

            // Root layout
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 28);
            Size = new System.Drawing.Size(900, 600);
            Controls.Add(panelItems);
            Controls.Add(panelSummary);
            Controls.Add(panelHeader);
            Name = "Cart";

            ResumeLayout(false);
            PerformLayout();
        }

        private Panel panelHeader;
        private Panel panelSummary;
        private Panel panelItems;
        private Panel panelEmpty;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblItemCount;
        private Label lblTotalLabel;
        private Label lblTotal;
        private Label lblEmpty;
        private Button btnRefresh;
        private Button btnCheckout;
        private Timer timerToast;

        // Kept for compat — old Cart.cs used dgvCart but we no longer need it
        private System.Windows.Forms.DataGridView dgvCart = new System.Windows.Forms.DataGridView();
        private Button btnRemove = new Button();
    }
}
