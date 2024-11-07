using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class EditSavingBook : Form
    {
        public EditSavingBook()
        {
            InitializeComponent();
            //customizeDesign();
            // Thiết lập không cho phép thay đổi kích thước Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            cboxType.Text = "Loại kỳ hạn";

            cboxType.Items.Add("Không kỳ hạn");
            cboxType.Items.Add("Kỳ hạn 3 tháng");
            cboxType.Items.Add("Kỳ hạn 6 tháng");
            cboxType.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }



        private void cboxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxType.SelectedIndex != -1)
            {
                
                string selectedValue = cboxType.SelectedItem.ToString(); cboxType.SelectedIndex = -1;
            }
        }
    }
}
