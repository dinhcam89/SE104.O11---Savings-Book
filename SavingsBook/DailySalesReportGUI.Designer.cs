namespace GUI
{
    partial class DailySalesReportGUI
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
            btnLoad = new Button();
            dateTimePicker1 = new DateTimePicker();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(347, 393);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(135, 45);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load report";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(12, 400);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(329, 27);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.Value = new DateTime(2023, 6, 1, 0, 0, 0, 0);
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 375);
            dataGridView1.TabIndex = 3;
            // 
            // DailySalesReportGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(dateTimePicker1);
            Controls.Add(btnLoad);
            Name = "DailySalesReportGUI";
            Text = "DailySalesReportGUI";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnLoad;
        private DateTimePicker dateTimePicker1;
        private DataGridView dataGridView1;
    }
}