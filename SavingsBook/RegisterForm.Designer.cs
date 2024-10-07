namespace GUI
{
    partial class RegisterForm
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            lblRegister = new Label();
            lblEmail = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            txtSdt = new Guna.UI2.WinForms.Guna2TextBox();
            lblSdt = new Label();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            lblPassword = new Label();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            lblRePassword = new Label();
            btnRegister = new Guna.UI2.WinForms.Guna2GradientButton();
            btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            SuspendLayout();
            // 
            // lblRegister
            // 
            lblRegister.AutoSize = true;
            lblRegister.BackColor = Color.Transparent;
            lblRegister.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRegister.ForeColor = Color.White;
            lblRegister.Location = new Point(357, 48);
            lblRegister.Name = "lblRegister";
            lblRegister.Size = new Size(191, 50);
            lblRegister.TabIndex = 0;
            lblRegister.Text = "REGISTER";
            lblRegister.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblEmail.ForeColor = Color.Coral;
            lblEmail.Location = new Point(179, 140);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            lblEmail.Click += lblEmail_Click;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.Transparent;
            txtEmail.BorderColor = Color.Transparent;
            txtEmail.BorderRadius = 10;
            txtEmail.CustomizableEdges = customizableEdges1;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Font = new Font("Segoe UI", 9F);
            txtEmail.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtEmail.Location = new Point(179, 163);
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PlaceholderText = "";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtEmail.Size = new Size(543, 41);
            txtEmail.TabIndex = 2;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // txtSdt
            // 
            txtSdt.BackColor = Color.Transparent;
            txtSdt.BorderColor = Color.Transparent;
            txtSdt.BorderRadius = 10;
            txtSdt.CustomizableEdges = customizableEdges3;
            txtSdt.DefaultText = "";
            txtSdt.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSdt.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSdt.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSdt.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSdt.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSdt.Font = new Font("Segoe UI", 9F);
            txtSdt.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSdt.Location = new Point(179, 238);
            txtSdt.Name = "txtSdt";
            txtSdt.PasswordChar = '\0';
            txtSdt.PlaceholderText = "";
            txtSdt.SelectedText = "";
            txtSdt.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtSdt.Size = new Size(543, 41);
            txtSdt.TabIndex = 4;
            // 
            // lblSdt
            // 
            lblSdt.AutoSize = true;
            lblSdt.BackColor = Color.Transparent;
            lblSdt.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblSdt.ForeColor = Color.Coral;
            lblSdt.Location = new Point(179, 215);
            lblSdt.Name = "lblSdt";
            lblSdt.Size = new Size(36, 20);
            lblSdt.TabIndex = 3;
            lblSdt.Text = "SĐT";
            lblSdt.Click += label1_Click;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.Transparent;
            txtPassword.BorderColor = Color.Transparent;
            txtPassword.BorderRadius = 10;
            txtPassword.CustomizableEdges = customizableEdges5;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPassword.ImeMode = ImeMode.On;
            txtPassword.Location = new Point(179, 314);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '\0';
            txtPassword.PlaceholderText = "";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtPassword.Size = new Size(543, 41);
            txtPassword.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblPassword.ForeColor = Color.Coral;
            lblPassword.Location = new Point(179, 291);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(73, 20);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BackColor = Color.Transparent;
            guna2TextBox1.BorderColor = Color.Transparent;
            guna2TextBox1.BorderRadius = 10;
            guna2TextBox1.CustomizableEdges = customizableEdges7;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 9F);
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.ImeMode = ImeMode.On;
            guna2TextBox1.Location = new Point(179, 392);
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges8;
            guna2TextBox1.Size = new Size(543, 41);
            guna2TextBox1.TabIndex = 8;
            // 
            // lblRePassword
            // 
            lblRePassword.AutoSize = true;
            lblRePassword.BackColor = Color.Transparent;
            lblRePassword.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblRePassword.ForeColor = Color.Coral;
            lblRePassword.Location = new Point(179, 369);
            lblRePassword.Name = "lblRePassword";
            lblRePassword.Size = new Size(136, 20);
            lblRePassword.TabIndex = 7;
            lblRePassword.Text = "Re-enter Password";
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.Transparent;
            btnRegister.BorderRadius = 15;
            btnRegister.CustomizableEdges = customizableEdges9;
            btnRegister.DisabledState.BorderColor = Color.DarkGray;
            btnRegister.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRegister.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRegister.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnRegister.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRegister.FillColor = Color.FromArgb(255, 87, 87);
            btnRegister.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.ImeMode = ImeMode.Off;
            btnRegister.Location = new Point(230, 466);
            btnRegister.Name = "btnRegister";
            btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnRegister.Size = new Size(180, 45);
            btnRegister.TabIndex = 9;
            btnRegister.Text = "Register";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Transparent;
            btnLogin.BorderRadius = 15;
            btnLogin.CustomizableEdges = customizableEdges11;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.FromArgb(255, 77, 165);
            btnLogin.FillColor2 = Color.FromArgb(140, 82, 255);
            btnLogin.Font = new Font("Segoe UI Semibold", 13F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.ImeMode = ImeMode.Off;
            btnLogin.Location = new Point(485, 466);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges12;
            btnLogin.Size = new Size(180, 45);
            btnLogin.TabIndex = 10;
            btnLogin.Text = "Login";
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(224, 224, 224);
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(900, 600);
            Controls.Add(btnLogin);
            Controls.Add(btnRegister);
            Controls.Add(guna2TextBox1);
            Controls.Add(lblRePassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtSdt);
            Controls.Add(lblSdt);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(lblRegister);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegisterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegisterForm";
            Load += RegisterForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblRegister;
        private Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtSdt;
        private Label lblSdt;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Label lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Label lblRePassword;
        private Guna.UI2.WinForms.Guna2GradientButton btnRegister;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin;
    }
}