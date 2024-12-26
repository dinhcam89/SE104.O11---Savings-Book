namespace GUI
{
    partial class GiaHanVaTinhLai
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
            dgvPhieuGoiTien = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuGoiTien).BeginInit();
            SuspendLayout();
            // 
            // dgvPhieuGoiTien
            // 
            dgvPhieuGoiTien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhieuGoiTien.Location = new Point(12, 12);
            dgvPhieuGoiTien.Name = "dgvPhieuGoiTien";
            dgvPhieuGoiTien.RowHeadersWidth = 51;
            dgvPhieuGoiTien.Size = new Size(776, 426);
            dgvPhieuGoiTien.TabIndex = 0;
            // 
            // GiaHanVaTinhLai
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvPhieuGoiTien);
            Name = "GiaHanVaTinhLai";
            Text = "GiaHanVaTinhLai";
            ((System.ComponentModel.ISupportInitialize)dgvPhieuGoiTien).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPhieuGoiTien;
    }
}