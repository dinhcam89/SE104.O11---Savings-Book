namespace GUI
{
    partial class DailyOperatingSalesReport
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
            label1 = new Label();
            label2 = new Label();
            dtpSalesReport = new DateTimePicker();
            btnSubmitSalesReport = new Button();
            dataGridView1 = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(150, 9);
            label1.Name = "label1";
            label1.Size = new Size(494, 41);
            label1.TabIndex = 0;
            label1.Text = "Báo cáo doanh số hoạt động ngày";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 86);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 1;
            label2.Text = "Ngày";
            // 
            // dtpSalesReport
            // 
            dtpSalesReport.Location = new Point(62, 81);
            dtpSalesReport.Name = "dtpSalesReport";
            dtpSalesReport.Size = new Size(250, 27);
            dtpSalesReport.TabIndex = 2;
            // 
            // btnSubmitSalesReport
            // 
            btnSubmitSalesReport.Location = new Point(317, 409);
            btnSubmitSalesReport.Name = "btnSubmitSalesReport";
            btnSubmitSalesReport.Size = new Size(179, 29);
            btnSubmitSalesReport.TabIndex = 3;
            btnSubmitSalesReport.Text = "Lập báo cáo";
            btnSubmitSalesReport.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 114);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(776, 289);
            dataGridView1.TabIndex = 4;
            // 
            // DailyOperatingSalesReport
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(btnSubmitSalesReport);
            Controls.Add(dtpSalesReport);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "DailyOperatingSalesReport";
            Text = "DailyOperatingSalesReport";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private DateTimePicker dtpSalesReport;
        private Button btnSubmitSalesReport;
        private DataGridView dataGridView1;
    }
}