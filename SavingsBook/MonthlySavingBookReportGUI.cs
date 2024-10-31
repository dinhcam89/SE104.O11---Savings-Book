using BUS;
using DTO;
using Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace GUI
{
    public partial class MonthlySavingBookReportGUI : Form
    {
        private BookTypeBUS bookTypeBUS;
        private MonthlySavingBookReportBUS monthlySavingBookReportBUS;
        List<ComboBoxItem> bookTypeComboBoxList;
        public MonthlySavingBookReportGUI()
        {
            InitializeComponent();
            bookTypeBUS = new BookTypeBUS();
            monthlySavingBookReportBUS = new MonthlySavingBookReportBUS();
            List<BookTypeDTO>? bookTypeList = bookTypeBUS.getAllBookType();
            if (bookTypeList != null)
            {
                bookTypeComboBoxList = new List<ComboBoxItem>();
                foreach (BookTypeDTO bookType in bookTypeList)
                {
                    bookTypeComboBoxList.Add(new ComboBoxItem(bookType.MaSo, bookType.ThoiHan.ToString()));
                }
                cbBookType.DataSource = sortBookType(bookTypeComboBoxList);
                cbBookType.DisplayMember = "Text";
                cbBookType.ValueMember = "ID";
            }
            else
            {
                bookTypeComboBoxList = new List<ComboBoxItem>();
            }
        }
        private List<ComboBoxItem> sortBookType(List<ComboBoxItem> bookTypeList)
        {
            List<ComboBoxItem> sortedBookTypeList = bookTypeList.OrderBy(o => int.Parse(o.Text)).ToList();
            foreach (ComboBoxItem bookType in bookTypeList)
            {
                bookType.Text = bookType.Text + " tháng";
            }
            return sortedBookTypeList;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Get the book type
            int bookTypeId;
            if (cbBookType.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn loại tiết kiệm", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                bookTypeId = (int)cbBookType.SelectedValue;
            }

            // Get the month and year
            DateTime date = dtpReport.Value;

            // Show the report
            dataGridView1.DataSource = monthlySavingBookReportBUS.getMonthlySavingBookReportByMonthAndBookType(date, bookTypeId);
            dataGridView1.Columns[0].HeaderText = "Ngày";
            dataGridView1.Columns[1].HeaderText = "Số sổ mở";
            dataGridView1.Columns[2].HeaderText = "Số sổ đóng";
            dataGridView1.Columns[3].HeaderText = "Chênh lệch";
            dataGridView1.Refresh();
        }
    }
}
