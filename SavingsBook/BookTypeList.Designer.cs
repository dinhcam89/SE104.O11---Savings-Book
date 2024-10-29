namespace GUI
{
    partial class BookTypeList
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
            dataGridView1 = new DataGridView();
            btnLoadBookTypes = new Button();
            btnAdd = new Button();
            btnDelete = new Button();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 391);
            dataGridView1.TabIndex = 0;
            // 
            // btnLoadBookTypes
            // 
            btnLoadBookTypes.Location = new Point(12, 409);
            btnLoadBookTypes.Name = "btnLoadBookTypes";
            btnLoadBookTypes.Size = new Size(153, 29);
            btnLoadBookTypes.TabIndex = 1;
            btnLoadBookTypes.Text = "Load book types";
            btnLoadBookTypes.UseVisualStyleBackColor = true;
            btnLoadBookTypes.Click += btnLoadBookTypes_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(171, 409);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(173, 29);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add a random thing";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(350, 409);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(135, 29);
            btnDelete.TabIndex = 3;
            btnDelete.Text = "Delete the last";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(491, 409);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(193, 29);
            btnUpdate.TabIndex = 4;
            btnUpdate.Text = "Update the last row";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // BookTypeList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnUpdate);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(btnLoadBookTypes);
            Controls.Add(dataGridView1);
            Name = "BookTypeList";
            Text = "BookTypeList";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Button btnLoadBookTypes;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnUpdate;
    }
}