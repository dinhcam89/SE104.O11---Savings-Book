﻿namespace GUI.DashboardApp
{
    partial class ucQuanLyPhieu
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQuanLyPhieu));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnTimKiem = new Guna.UI2.WinForms.Guna2CircleButton();
            txtTimKiem = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            guna2Panel3 = new Guna.UI2.WinForms.Guna2Panel();
            label1 = new Label();
            lblLoaiTietKiem0 = new Label();
            lblMaPhieuTietKiem0 = new Label();
            lblTenKhachHang0 = new Label();
            guna2Panel2.SuspendLayout();
            guna2Panel3.SuspendLayout();
            SuspendLayout();
            // 
            // btnTimKiem
            // 
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.Transparent;
            btnTimKiem.DisabledState.BorderColor = Color.DarkGray;
            btnTimKiem.DisabledState.CustomBorderColor = Color.DarkGray;
            btnTimKiem.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnTimKiem.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnTimKiem.FillColor = Color.WhiteSmoke;
            btnTimKiem.Font = new Font("Segoe UI", 9F);
            btnTimKiem.ForeColor = Color.Transparent;
            btnTimKiem.Image = (Image)resources.GetObject("btnTimKiem.Image");
            btnTimKiem.ImageSize = new Size(30, 30);
            btnTimKiem.Location = new Point(967, 17);
            btnTimKiem.Margin = new Padding(3, 4, 3, 4);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges1;
            btnTimKiem.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            btnTimKiem.Size = new Size(57, 67);
            btnTimKiem.TabIndex = 1;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTimKiem.BackColor = Color.Transparent;
            txtTimKiem.BorderColor = Color.Transparent;
            txtTimKiem.BorderRadius = 26;
            txtTimKiem.CustomizableEdges = customizableEdges2;
            txtTimKiem.DefaultText = "";
            txtTimKiem.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtTimKiem.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtTimKiem.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtTimKiem.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtTimKiem.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtTimKiem.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtTimKiem.Location = new Point(32, 17);
            txtTimKiem.Margin = new Padding(5);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PasswordChar = '\0';
            txtTimKiem.PlaceholderText = "";
            txtTimKiem.SelectedText = "";
            txtTimKiem.ShadowDecoration.CustomizableEdges = customizableEdges3;
            txtTimKiem.Size = new Size(927, 67);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.TextOffset = new Point(10, 0);
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // guna2Panel2
            // 
            guna2Panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            guna2Panel2.BackColor = Color.White;
            guna2Panel2.Controls.Add(flowLayoutPanel1);
            guna2Panel2.Controls.Add(btnTimKiem);
            guna2Panel2.Controls.Add(txtTimKiem);
            guna2Panel2.Controls.Add(guna2Panel3);
            guna2Panel2.CustomizableEdges = customizableEdges6;
            guna2Panel2.Location = new Point(23, 23);
            guna2Panel2.Margin = new Padding(3, 4, 3, 4);
            guna2Panel2.Name = "guna2Panel2";
            guna2Panel2.ShadowDecoration.CustomizableEdges = customizableEdges7;
            guna2Panel2.Size = new Size(1055, 799);
            guna2Panel2.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Location = new Point(14, 172);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1026, 608);
            flowLayoutPanel1.TabIndex = 19;
            // 
            // guna2Panel3
            // 
            guna2Panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2Panel3.BorderColor = Color.Transparent;
            guna2Panel3.BorderRadius = 10;
            guna2Panel3.Controls.Add(label1);
            guna2Panel3.Controls.Add(lblLoaiTietKiem0);
            guna2Panel3.Controls.Add(lblMaPhieuTietKiem0);
            guna2Panel3.Controls.Add(lblTenKhachHang0);
            guna2Panel3.CustomizableEdges = customizableEdges4;
            guna2Panel3.FillColor = Color.AliceBlue;
            guna2Panel3.Location = new Point(32, 108);
            guna2Panel3.Margin = new Padding(3, 4, 3, 4);
            guna2Panel3.Name = "guna2Panel3";
            guna2Panel3.ShadowDecoration.CustomizableEdges = customizableEdges5;
            guna2Panel3.Size = new Size(992, 56);
            guna2Panel3.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(37, 10, 128);
            label1.Location = new Point(797, 13);
            label1.Name = "label1";
            label1.Size = new Size(91, 25);
            label1.TabIndex = 6;
            label1.Text = "Ngày gởi";
            // 
            // lblLoaiTietKiem0
            // 
            lblLoaiTietKiem0.AutoSize = true;
            lblLoaiTietKiem0.BackColor = Color.Transparent;
            lblLoaiTietKiem0.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoaiTietKiem0.ForeColor = Color.FromArgb(37, 10, 128);
            lblLoaiTietKiem0.Location = new Point(539, 13);
            lblLoaiTietKiem0.Name = "lblLoaiTietKiem0";
            lblLoaiTietKiem0.Size = new Size(128, 25);
            lblLoaiTietKiem0.TabIndex = 4;
            lblLoaiTietKiem0.Text = "Loại tiết kiệm";
            // 
            // lblMaPhieuTietKiem0
            // 
            lblMaPhieuTietKiem0.AutoSize = true;
            lblMaPhieuTietKiem0.BackColor = Color.Transparent;
            lblMaPhieuTietKiem0.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMaPhieuTietKiem0.ForeColor = Color.FromArgb(37, 10, 128);
            lblMaPhieuTietKiem0.Location = new Point(254, 13);
            lblMaPhieuTietKiem0.Name = "lblMaPhieuTietKiem0";
            lblMaPhieuTietKiem0.Size = new Size(189, 25);
            lblMaPhieuTietKiem0.TabIndex = 5;
            lblMaPhieuTietKiem0.Text = "Số tài khoản tiền gởi";
            // 
            // lblTenKhachHang0
            // 
            lblTenKhachHang0.AutoSize = true;
            lblTenKhachHang0.BackColor = Color.Transparent;
            lblTenKhachHang0.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTenKhachHang0.ForeColor = Color.FromArgb(37, 10, 128);
            lblTenKhachHang0.Location = new Point(31, 13);
            lblTenKhachHang0.Name = "lblTenKhachHang0";
            lblTenKhachHang0.Size = new Size(145, 25);
            lblTenKhachHang0.TabIndex = 4;
            lblTenKhachHang0.Text = "Tên khách hàng";
            // 
            // ucQuanLyPhieu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(guna2Panel2);
            ForeColor = Color.FromArgb(255, 87, 87);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucQuanLyPhieu";
            Size = new Size(1104, 845);
            Load += ucManageSavingBooks_Load;
            guna2Panel2.ResumeLayout(false);
            guna2Panel3.ResumeLayout(false);
            guna2Panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtTimKiem;
        private Guna.UI2.WinForms.Guna2CircleButton btnTimKiem;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel3;
        private Label lblMaPhieuTietKiem0;
        private Label lblTenKhachHang0;
        private Label lblLoaiTietKiem0;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
    }
}
