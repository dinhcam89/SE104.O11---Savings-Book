using MySql.Data.MySqlClient;

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
            btnAdd = new Button();
            lbFullname = new Label();
            lbBirthday = new Label();
            tbNameAdd = new TextBox();
            tbNameUpdate = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnUpdate = new Button();
            btnDelete = new Button();
            tbIdDelete = new TextBox();
            lbId = new Label();
            tbIdUpdate = new TextBox();
            label3 = new Label();
            dtpAdd = new DateTimePicker();
            dtpUpdate = new DateTimePicker();
            tbIdAdd = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(392, 12);
            dataGridView.Name = "dataGridView";
            dataGridView.RowHeadersWidth = 51;
            dataGridView.Size = new Size(539, 574);
            dataGridView.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(270, 200);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(94, 29);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // lbFullname
            // 
            lbFullname.AutoSize = true;
            lbFullname.Location = new Point(34, 92);
            lbFullname.Name = "lbFullname";
            lbFullname.Size = new Size(54, 20);
            lbFullname.TabIndex = 2;
            lbFullname.Text = "Họ tên";
            // 
            // lbBirthday
            // 
            lbBirthday.AutoSize = true;
            lbBirthday.Location = new Point(34, 155);
            lbBirthday.Name = "lbBirthday";
            lbBirthday.Size = new Size(74, 20);
            lbBirthday.TabIndex = 3;
            lbBirthday.Text = "Ngày sinh";
            // 
            // tbNameAdd
            // 
            tbNameAdd.Location = new Point(114, 89);
            tbNameAdd.Name = "tbNameAdd";
            tbNameAdd.Size = new Size(250, 27);
            tbNameAdd.TabIndex = 5;
            tbNameAdd.TextChanged += textBox1_TextChanged;
            // 
            // tbNameUpdate
            // 
            tbNameUpdate.Location = new Point(114, 318);
            tbNameUpdate.Name = "tbNameUpdate";
            tbNameUpdate.Size = new Size(250, 27);
            tbNameUpdate.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 384);
            label1.Name = "label1";
            label1.Size = new Size(74, 20);
            label1.TabIndex = 8;
            label1.Text = "Ngày sinh";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 321);
            label2.Name = "label2";
            label2.Size = new Size(54, 20);
            label2.TabIndex = 7;
            label2.Text = "Họ tên";
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(270, 437);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(94, 29);
            btnUpdate.TabIndex = 11;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(270, 550);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // tbIdDelete
            // 
            tbIdDelete.Location = new Point(114, 493);
            tbIdDelete.Name = "tbIdDelete";
            tbIdDelete.Size = new Size(250, 27);
            tbIdDelete.TabIndex = 14;
            // 
            // lbId
            // 
            lbId.AutoSize = true;
            lbId.Location = new Point(34, 496);
            lbId.Name = "lbId";
            lbId.Size = new Size(22, 20);
            lbId.TabIndex = 12;
            lbId.Text = "Id";
            lbId.Click += label4_Click;
            // 
            // tbIdUpdate
            // 
            tbIdUpdate.Location = new Point(114, 258);
            tbIdUpdate.Name = "tbIdUpdate";
            tbIdUpdate.Size = new Size(250, 27);
            tbIdUpdate.TabIndex = 18;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 261);
            label3.Name = "label3";
            label3.Size = new Size(22, 20);
            label3.TabIndex = 17;
            label3.Text = "Id";
            // 
            // dtpAdd
            // 
            dtpAdd.Location = new Point(114, 150);
            dtpAdd.Name = "dtpAdd";
            dtpAdd.Size = new Size(250, 27);
            dtpAdd.TabIndex = 19;
            // 
            // dtpUpdate
            // 
            dtpUpdate.Location = new Point(114, 379);
            dtpUpdate.Name = "dtpUpdate";
            dtpUpdate.Size = new Size(250, 27);
            dtpUpdate.TabIndex = 20;
            // 
            // tbIdAdd
            // 
            tbIdAdd.Location = new Point(114, 34);
            tbIdAdd.Name = "tbIdAdd";
            tbIdAdd.Size = new Size(250, 27);
            tbIdAdd.TabIndex = 22;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 37);
            label4.Name = "label4";
            label4.Size = new Size(22, 20);
            label4.TabIndex = 21;
            label4.Text = "Id";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(943, 598);
            Controls.Add(tbIdAdd);
            Controls.Add(label4);
            Controls.Add(dtpUpdate);
            Controls.Add(dtpAdd);
            Controls.Add(tbIdUpdate);
            Controls.Add(label3);
            Controls.Add(btnDelete);
            Controls.Add(tbIdDelete);
            Controls.Add(lbId);
            Controls.Add(btnUpdate);
            Controls.Add(tbNameUpdate);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(tbNameAdd);
            Controls.Add(lbBirthday);
            Controls.Add(lbFullname);
            Controls.Add(btnAdd);
            Controls.Add(dataGridView);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView;
        private Button btnAdd;
        private Label lbFullname;
        private Label lbBirthday;
        private TextBox tbNameAdd;
        private TextBox tbNameUpdate;
        private Label label1;
        private Label label2;
        private Button btnUpdate;
        private Button btnDelete;
        private TextBox tbIdDelete;
        private Label lbId;
        private TextBox tbIdUpdate;
        private Label label3;
        private DateTimePicker dtpAdd;
        private DateTimePicker dtpUpdate;
        private TextBox tbIdAdd;
        private Label label4;
    }
}
