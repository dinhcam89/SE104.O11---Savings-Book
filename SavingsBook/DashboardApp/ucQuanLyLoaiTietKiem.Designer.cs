namespace GUI.DashboardApp
{
    partial class ucQuanLyLoaiTietKiem
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucQuanLyLoaiTietKiem));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btnAdd = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2Panel5 = new Guna.UI2.WinForms.Guna2Panel();
            lblLaiSuat0 = new Label();
            lblSoTienGoi0 = new Label();
            lblLoaiTietKiem0 = new Label();
            panel1.SuspendLayout();
            guna2Panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(btnAdd);
            panel1.Controls.Add(guna2Panel5);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1191, 936);
            panel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Location = new Point(26, 93);
            flowLayoutPanel1.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1143, 737);
            flowLayoutPanel1.TabIndex = 26;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAdd.BorderRadius = 10;
            btnAdd.CustomizableEdges = customizableEdges1;
            btnAdd.DisabledState.BorderColor = Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = Color.DarkGray;
            btnAdd.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnAdd.FillColor = Color.AliceBlue;
            btnAdd.FillColor2 = Color.AliceBlue;
            btnAdd.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnAdd.ForeColor = Color.FromArgb(39, 20, 85);
            btnAdd.Image = (Image)resources.GetObject("btnAdd.Image");
            btnAdd.ImageOffset = new Point(40, 0);
            btnAdd.ImageSize = new Size(30, 30);
            btnAdd.Location = new Point(39, 839);
            btnAdd.Margin = new Padding(3, 4, 3, 4);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnAdd.Size = new Size(1114, 57);
            btnAdd.TabIndex = 25;
            btnAdd.Text = "Thêm mới";
            btnAdd.TextOffset = new Point(-20, 0);
            btnAdd.Click += btnAdd_Click;
            // 
            // guna2Panel5
            // 
            guna2Panel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            guna2Panel5.BorderColor = Color.Transparent;
            guna2Panel5.BorderRadius = 10;
            guna2Panel5.Controls.Add(lblLaiSuat0);
            guna2Panel5.Controls.Add(lblSoTienGoi0);
            guna2Panel5.Controls.Add(lblLoaiTietKiem0);
            guna2Panel5.CustomizableEdges = customizableEdges3;
            guna2Panel5.FillColor = Color.AliceBlue;
            guna2Panel5.Location = new Point(39, 29);
            guna2Panel5.Margin = new Padding(3, 4, 3, 4);
            guna2Panel5.Name = "guna2Panel5";
            guna2Panel5.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2Panel5.Size = new Size(1114, 56);
            guna2Panel5.TabIndex = 23;
            // 
            // lblLaiSuat0
            // 
            lblLaiSuat0.AutoSize = true;
            lblLaiSuat0.BackColor = Color.Transparent;
            lblLaiSuat0.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLaiSuat0.ForeColor = Color.FromArgb(37, 10, 128);
            lblLaiSuat0.Location = new Point(504, 15);
            lblLaiSuat0.Name = "lblLaiSuat0";
            lblLaiSuat0.Size = new Size(77, 25);
            lblLaiSuat0.TabIndex = 5;
            lblLaiSuat0.Text = "Lãi suất";
            // 
            // lblSoTienGoi0
            // 
            lblSoTienGoi0.AutoSize = true;
            lblSoTienGoi0.BackColor = Color.Transparent;
            lblSoTienGoi0.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSoTienGoi0.ForeColor = Color.FromArgb(37, 10, 128);
            lblSoTienGoi0.Location = new Point(267, 15);
            lblSoTienGoi0.Name = "lblSoTienGoi0";
            lblSoTienGoi0.Size = new Size(104, 25);
            lblSoTienGoi0.TabIndex = 4;
            lblSoTienGoi0.Text = "Số tiền gởi";
            // 
            // lblLoaiTietKiem0
            // 
            lblLoaiTietKiem0.AutoSize = true;
            lblLoaiTietKiem0.BackColor = Color.Transparent;
            lblLoaiTietKiem0.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoaiTietKiem0.ForeColor = Color.FromArgb(37, 10, 128);
            lblLoaiTietKiem0.Location = new Point(33, 15);
            lblLoaiTietKiem0.Name = "lblLoaiTietKiem0";
            lblLoaiTietKiem0.Size = new Size(128, 25);
            lblLoaiTietKiem0.TabIndex = 4;
            lblLoaiTietKiem0.Text = "Loại tiết kiệm";
            // 
            // ucQuanLyLoaiTietKiem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ucQuanLyLoaiTietKiem";
            Size = new Size(1191, 936);
            Load += ucEditAdjustRate_Load;
            Layout += ucQuanLyLoaiTietKiem_Layout;
            panel1.ResumeLayout(false);
            guna2Panel5.ResumeLayout(false);
            guna2Panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Guna.UI2.WinForms.Guna2GradientButton btnAdd;
        private Guna.UI2.WinForms.Guna2Panel guna2Panel5;
        private Label lblSoTienGoi0;
        private Label lblLoaiTietKiem0;
        private Label lblLaiSuat0;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}
