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
    public partial class AddSavingBooks : Form
    {
        public AddSavingBooks()
        {
            InitializeComponent();
            customizeDesign();
            // Thiết lập không cho phép thay đổi kích thước Form
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void customizeDesign()
        {
            // Ẩn submenu khi khởi động ứng dụng
            panelTypeMenu.Visible = false;
        }
        private void hideSubMenu()
        {
            // Kiểm tra và ẩn các submenu nếu chúng đang hiển thị
            if (panelTypeMenu.Visible == true)
                panelTypeMenu.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            // Kiểm tra nếu submenu đang bị ẩn thì hiển thị, nếu đang hiển thị thì ẩn nó
            if (subMenu.Visible == false)
            {
                hideSubMenu(); // Ẩn tất cả submenu khác trước khi hiển thị submenu hiện tại
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void btnTypeMenu_Click(object sender, EventArgs e)
        {
            showSubMenu(panelTypeMenu);
        }

        private void btnType1_Click(object sender, EventArgs e)
        {
            //
            hideSubMenu();
        }

        private void btnType2_Click(object sender, EventArgs e)
        {
            //
            hideSubMenu();
        }

        private void btnType3_Click(object sender, EventArgs e)
        {
            //
            hideSubMenu();
        }


    }
}

