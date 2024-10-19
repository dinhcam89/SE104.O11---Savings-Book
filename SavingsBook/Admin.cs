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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAccount addAccount = new AddAccount();
            addAccount.Show();
        }

        //private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        //{
        //    // Thiết lập màu sắc và độ dày của viền
        //    Color borderColor = Color.Black;
        //    int borderWidth = 2;

        //    // Vẽ viền xung quanh Panel
        //    ControlPaint.DrawBorder(e.Graphics, guna2GradientPanel1.ClientRectangle,
        //        borderColor, borderWidth, ButtonBorderStyle.Solid,
        //        borderColor, borderWidth, ButtonBorderStyle.Solid,
        //        borderColor, borderWidth, ButtonBorderStyle.Solid,
        //        borderColor, borderWidth, ButtonBorderStyle.Solid);
        //}
    }
}
