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
            lbName = new Label();
            lbBirthday = new Label();
            tbId = new TextBox();
            tbName = new TextBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            dtpBirthday = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(603, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(496, 564);
            dataGridView.TabIndex = 0;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(57, 59);
            lbId.Name = "lbId";
            lbId.Size = new Size(22, 20);
            lbId.TabIndex = 1;
            lbId.Text = "Id";
            // 
            // lbName
            // 
            lbName.AutoSize = true;
            lbName.Location = new Point(57, 137);
            lbName.Name = "lbName";
            lbName.Size = new Size(54, 20);
            lbName.TabIndex = 2;
            lbName.Text = "Họ tên";
            // 
            // lbBirthday
            // 
            lbBirthday.AutoSize = true;
            lbBirthday.Location = new Point(57, 215);
            lbBirthday.Name = "lbBirthday";
            lbBirthday.Size = new Size(74, 20);
            lbBirthday.TabIndex = 3;
            lbBirthday.Text = "Ngày sinh";
            // 
            // tbId
            // 
            tbId.Location = new Point(137, 56);
            tbId.Name = "tbId";
            tbId.Size = new Size(448, 27);
            tbId.TabIndex = 4;
            // 
            // tbName
            // 
            tbName.Location = new Point(137, 134);
            tbName.Name = "tbName";
            tbName.Size = new Size(448, 27);
            tbName.TabIndex = 5;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(57, 288);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(141, 29);
            btnAdd.TabIndex = 7;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(254, 288);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(141, 29);
            btnUpdate.TabIndex = 8;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(444, 288);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(141, 29);
            btnDelete.TabIndex = 9;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // dtpBirthday
            // 
            dtpBirthday.Location = new Point(137, 210);
            dtpBirthday.Name = "dtpBirthday";
            dtpBirthday.Size = new Size(448, 27);
            dtpBirthday.TabIndex = 10;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1111, 588);
            Controls.Add(dtpBirthday);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(tbName);
            Controls.Add(tbId);
            Controls.Add(lbBirthday);
            Controls.Add(lbName);
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
        private Label lbName;
        private Label lbBirthday;
        private TextBox tbId;
        private TextBox tbName;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private DateTimePicker dtpBirthday;
    }
}
