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
            dgvReport = new DataGridView();
            dtpReport = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            cbBookType = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            dgvChart = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvChart).BeginInit();
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
            // dgvReport
            // 
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(12, 84);
            dgvReport.Name = "dgvReport";
            dgvReport.RowHeadersWidth = 51;
            dgvReport.Size = new Size(1224, 324);
            dgvReport.TabIndex = 1;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(496, 53);
            label3.Name = "label3";
            label3.Size = new Size(254, 28);
            label3.TabIndex = 7;
            label3.Text = "Dữ liệu cho bảng báo cáo";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(515, 411);
            label4.Name = "label4";
            label4.Size = new Size(199, 28);
            label4.TabIndex = 9;
            label4.Text = "Dữ liệu cho biểu đồ";
            // 
            // dgvChart
            // 
            dgvChart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChart.Location = new Point(12, 442);
            dgvChart.Name = "dgvChart";
            dgvChart.RowHeadersWidth = 51;
            dgvChart.Size = new Size(1224, 140);
            dgvChart.TabIndex = 8;
            // 
            // MonthlySavingBookReportGUI
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1248, 640);
            Controls.Add(label4);
            Controls.Add(dgvChart);
            Controls.Add(label3);
            Controls.Add(cbBookType);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpReport);
            Controls.Add(dgvReport);
            Controls.Add(btnLoad);
            Name = "MonthlySavingBookReportGUI";
            Text = "MonthlySavingBookReportGUI";
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvChart).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnLoad;
        private DataGridView dgvReport;
        private DateTimePicker dtpReport;
        private Label label1;
        private Label label2;
        private ComboBox cbBookType;
        private Label label3;
        private Label label4;
        private DataGridView dgvChart;
    }
}