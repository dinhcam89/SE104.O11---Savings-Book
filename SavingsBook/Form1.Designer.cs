namespace SavingsBook
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            dataGridView = new DataGridView();
            lbId = new Label();
            lbAddress = new Label();
            lbDeposit = new Label();
            tbId = new TextBox();
            tbAddress = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            tbDeposit = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(478, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(621, 564);
            dataGridView.TabIndex = 0;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(37, 55);
            lbId.Name = "lbId";
            lbId.Size = new Size(22, 20);
            lbId.TabIndex = 1;
            lbId.Text = "Id";
            // 
            // lbAddress
            // 
            lbAddress.AutoSize = true;
            lbAddress.Location = new Point(37, 133);
            lbAddress.Name = "lbAddress";
            lbAddress.Size = new Size(55, 20);
            lbAddress.TabIndex = 2;
            lbAddress.Text = "Địa chỉ";
            // 
            // lbDeposit
            // 
            lbDeposit.AutoSize = true;
            lbDeposit.Location = new Point(37, 211);
            lbDeposit.Name = "lbDeposit";
            lbDeposit.Size = new Size(87, 20);
            lbDeposit.TabIndex = 3;
            lbDeposit.Text = "Số tiền gởi*";
            // 
            // tbId
            // 
            tbId.Location = new Point(124, 52);
            tbId.Name = "tbId";
            tbId.Size = new Size(348, 27);
            tbId.TabIndex = 4;
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(124, 130);
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(348, 27);
            tbAddress.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(37, 284);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(141, 29);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(184, 284);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(141, 29);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(331, 284);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(141, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // tbDeposit
            // 
            tbDeposit.Location = new Point(124, 208);
            tbDeposit.Name = "tbDeposit";
            tbDeposit.Size = new Size(348, 27);
            tbDeposit.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Highlight;
            label1.Location = new Point(124, 82);
            label1.Name = "label1";
            label1.Size = new Size(266, 20);
            label1.TabIndex = 11;
            label1.Text = "Mã số được tạo tự động khi thêm mới";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1111, 588);
            Controls.Add(label1);
            Controls.Add(tbDeposit);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(tbAddress);
            Controls.Add(tbId);
            Controls.Add(lbDeposit);
            Controls.Add(lbAddress);
            Controls.Add(lbId);
            Controls.Add(dataGridView);
            Name = "Form1";
            Text = "CRUD SQL Server";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Label lbId;
        private Label lbAddress;
        private Label lbDeposit;
        private TextBox tbId;
        private TextBox tbAddress;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox tbDeposit;
        private Label label1;
    }
}
