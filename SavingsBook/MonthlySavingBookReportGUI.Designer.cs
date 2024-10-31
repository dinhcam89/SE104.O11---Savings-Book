namespace GUI
{
    partial class MonthlySavingBookReportGUI
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
            dataGridView1 = new DataGridView();
            dtpReport = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            cbBookType = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnLoad
            // 
            btnLoad.Location = new Point(530, 588);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(184, 40);
            btnLoad.TabIndex = 0;
            btnLoad.Text = "Load báo cáo sổ tháng";
            btnLoad.UseVisualStyleBackColor = true;
            btnLoad.Click += btnLoad_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1224, 537);
            dataGridView1.TabIndex = 1;
            // 
            // dtpReport
            // 
            dtpReport.Location = new Point(71, 9);
            dtpReport.Name = "dtpReport";
            dtpReport.Size = new Size(250, 27);
            dtpReport.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 14);
            label1.Name = "label1";
            label1.Size = new Size(53, 20);
            label1.TabIndex = 4;
            label1.Text = "Tháng";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(362, 14);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 5;
            label2.Text = "Loại tiết kiệm";
            // 
            // cbBookType
            // 
            cbBookType.FormattingEnabled = true;
            cbBookType.Location = new Point(472, 8);
            cbBookType.Name = "cbBookType";
            cbBookType.Size = new Size(151, 28);
            cbBookType.TabIndex = 6;
            // 
            // MonthlySavingBookReportGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1248, 640);
            Controls.Add(cbBookType);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpReport);
            Controls.Add(dataGridView1);
            Controls.Add(btnLoad);
            Name = "MonthlySavingBookReportGUI";
            Text = "MonthlySavingBookReportGUI";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoad;
        private DataGridView dataGridView1;
        private DateTimePicker dtpReport;
        private Label label1;
        private Label label2;
        private ComboBox cbBookType;
    }
}