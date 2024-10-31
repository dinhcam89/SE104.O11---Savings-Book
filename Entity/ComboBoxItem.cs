using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class ComboBoxItem
    {
        #region Properties
        public int ID { get; set; }
        public string Text { get; set; }
        #endregion
        public ComboBoxItem()
        {
            ID = 0;
            Text = "";
        }
        public ComboBoxItem(int id, string text)
        {
            ID = id;
            Text = text;
        }

    }
}
