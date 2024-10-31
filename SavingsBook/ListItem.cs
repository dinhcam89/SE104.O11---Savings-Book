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
    public partial class ListItem : UserControl
    {
        public ListItem()
        {
            InitializeComponent();
        }

        private string _name;
        private string _id;
        private string _type;
        private Image _image;


        [Category("Custom")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string CustomerName
        {
            get { return _name; }
            set { _name = value; lblCustomerName.Text = value; }
        }

        [Category("Custom")]
        public string Id
        {
            get { return _id; }
            set { _id = value; lblIDNumber.Text = value; }
        }

        [Category("Custom")]
        public string Type
        { 
            get { return _type; }
            set { _type = value; lblType.Text = value; }
        }

        [Category("Custom")]
        public Image Avatar
        { 
            get { return _image; }
            set { _image = value; picAvatar.Image = value; }
        }

    }
}
