using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.DashboardApp
{
    public partial class ucEditAdjustRate : UserControl
    {
        public ucEditAdjustRate()
        {
            InitializeComponent();

        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditAdjustRateForm editForm = new EditAdjustRateForm();
            editForm.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAjustRateForm addForm = new AddAjustRateForm();
            addForm.ShowDialog();
        }
    }
}
