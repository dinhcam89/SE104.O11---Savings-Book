namespace GUI
{
    partial class ChiTietRutTien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            lblSoTienRut0 = new Label();
            lblNgayRut0 = new Label();
            panel2 = new Panel();
            lblSoTienGocCopy = new Label();
            lblSoTienGoc = new Label();
            lbMaPhieu = new Label();
            lblTenKhachHang = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel1.SuspendLayout();
            guna2Panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(guna2Panel3);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1169, 716);
            panel1.TabIndex = 0;
            // 
            // guna2Panel3
            // 
            guna2Panel3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            guna2Panel3.BorderColor = Color.Transparent;
            guna2Panel3.BorderRadius = 10;
            guna2Panel3.Controls.Add(lblSoTienRut0);
            guna2Panel3.Controls.Add(lblNgayRut0);
            guna2Panel3.CustomizableEdges = customizableEdges1;
            guna2Panel3.FillColor = Color.AliceBlue;
            guna2Panel3.Location = new Point(29, 176);
            guna2Panel3.Margin = new Padding(3, 4, 3, 4);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2Panel3.Size = new Size(1104, 56);
            guna2Panel3.TabIndex = 19;
            // 
            // lblSoTienRut0
            // 
            lblSoTienRut0.AutoSize = true;
            lblSoTienRut0.BackColor = Color.Transparent;
            lblSoTienRut0.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSoTienRut0.ForeColor = Color.FromArgb(37, 10, 128);
            lblSoTienRut0.Location = new Point(284, 13);
            lblSoTienRut0.Name = "lblSoTienRut0";
            lblSoTienRut0.Size = new Size(101, 25);
            lblSoTienRut0.TabIndex = 5;
            lblSoTienRut0.Text = "Số tiền rút";
            // 
            // lblNgayRut0
            // 
            lblNgayRut0.AutoSize = true;
            lblNgayRut0.BackColor = Color.Transparent;
            lblNgayRut0.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNgayRut0.ForeColor = Color.FromArgb(37, 10, 128);
            lblNgayRut0.Location = new Point(33, 13);
            lblNgayRut0.Name = "lblNgayRut0";
            lblNgayRut0.Size = new Size(88, 25);
            lblNgayRut0.TabIndex = 4;
            lblNgayRut0.Text = "Ngày rút";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(lblSoTienGocCopy);
            panel2.Controls.Add(lblSoTienGoc);
            panel2.Controls.Add(lbMaPhieu);
            panel2.Controls.Add(lblTenKhachHang);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1169, 168);
            panel2.TabIndex = 1;
            // 
            // lblSoTienGocCopy
            // 
            lblSoTienGocCopy.BackColor = Color.Transparent;
            lblSoTienGocCopy.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSoTienGocCopy.ForeColor = Color.FromArgb(37, 10, 128);
            lblSoTienGocCopy.Location = new Point(880, 128);
            lblSoTienGocCopy.Name = "lblSoTienGocCopy";
            lblSoTienGocCopy.Size = new Size(253, 25);
            lblSoTienGocCopy.TabIndex = 11;
            lblSoTienGocCopy.Text = "CRT0000001";
            lblSoTienGocCopy.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSoTienGoc
            // 
            lblSoTienGoc.AutoSize = true;
            lblSoTienGoc.BackColor = Color.Transparent;
            lblSoTienGoc.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSoTienGoc.ForeColor = Color.FromArgb(37, 10, 128);
            lblSoTienGoc.Location = new Point(1198, 171);
            lblSoTienGoc.Name = "lblSoTienGoc";
            lblSoTienGoc.Size = new Size(107, 25);
            lblSoTienGoc.TabIndex = 10;
            lblSoTienGoc.Text = "10.000.000";
            // 
            // lbMaPhieu
            // 
            lbMaPhieu.BackColor = Color.Transparent;
            lbMaPhieu.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbMaPhieu.ForeColor = Color.FromArgb(37, 10, 128);
            lbMaPhieu.Location = new Point(880, 76);
            lbMaPhieu.Name = "lbMaPhieu";
            lbMaPhieu.Size = new Size(253, 25);
            lbMaPhieu.TabIndex = 9;
            lbMaPhieu.Text = "CRT0000001";
            lbMaPhieu.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTenKhachHang
            // 
            lblTenKhachHang.BackColor = Color.Transparent;
            lblTenKhachHang.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenKhachHang.ForeColor = Color.FromArgb(37, 10, 128);
            lblTenKhachHang.Location = new Point(793, 24);
            lblTenKhachHang.Name = "lblTenKhachHang";
            lblTenKhachHang.Size = new Size(340, 27);
            lblTenKhachHang.TabIndex = 8;
            lblTenKhachHang.Text = "Nguyễn Lương Huỳnh Đăng";
            lblTenKhachHang.TextAlign = ContentAlignment.TopRight;
            lblTenKhachHang.Click += lblTenKhachHang_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(37, 10, 128);
            label3.Location = new Point(29, 128);
            label3.Name = "label3";
            label3.Size = new Size(107, 25);
            label3.TabIndex = 7;
            label3.Text = "Số tiền gốc";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(37, 10, 128);
            label2.Location = new Point(29, 76);
            label2.Name = "label2";
            label2.Size = new Size(93, 25);
            label2.TabIndex = 6;
            label2.Text = "Mã phiếu";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(37, 10, 128);
            label1.Location = new Point(29, 24);
            label1.Name = "label1";
            label1.Size = new Size(145, 25);
            label1.TabIndex = 5;
            label1.Text = "Tên khách hàng";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 240);
            flowLayoutPanel1.Margin = new Padding(11, 4, 11, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(11, 0, 11, 0);
            flowLayoutPanel1.Size = new Size(1169, 476);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // ChiTietRutTien
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1169, 716);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChiTietRutTien";
            Text = "Chitietruttien";
            Load += ChiTietRutTien_Load;
            panel1.ResumeLayout(false);
            guna2Panel3.ResumeLayout(false);
            guna2Panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Label lblLoaiTietKiem0;
        private Label lblSoTienRut0;
        private Label lblNgayRut0;
        private Label lblSoTienGoc;

        private Label lbMaPhieu;
        private Label lblTenKhachHang;

        private Label label3;
        private Label label2;
        private Label label1;
        public Label lb_MaPhieu;
        private Label lblSoTienGocCopy;
    }
}