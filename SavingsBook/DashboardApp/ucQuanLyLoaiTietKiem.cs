using BUS;
using DTO;

namespace GUI.DashboardApp
{
    public partial class ucQuanLyLoaiTietKiem : UserControl
    {
        private List<LoaiTietKiem> _loaiTietKiemList;
        private LoaiTietKiemBUS _loaiTietKiemBUS;
        public ucQuanLyLoaiTietKiem()
        {
            InitializeComponent();
            _loaiTietKiemBUS = new LoaiTietKiemBUS();
            _loaiTietKiemList = new List<LoaiTietKiem>();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ThemLoaiTietKiem addForm = new ThemLoaiTietKiem(loadItems);
            addForm.ShowDialog();
        }

        private void populateItems(List<LoaiTietKiem> loaiTietKiem)
        {
            ListItem[] listItems = new ListItem[loaiTietKiem.Count];

            EventHandler resizePanel = (s, e) =>
            {
                foreach (ListItem item in flowLayoutPanel1.Controls)
                {
                    item.Width = flowLayoutPanel1.ClientSize.Width;
                }
            };

            flowLayoutPanel1.Controls.Clear();

            for (int i = 0; i < listItems.Length; i++)
            {
                listItems[i] = new ListItem(loaiTietKiem[i], loadItems);
                flowLayoutPanel1.Controls.Add(listItems[i]);
            }
            resizePanel(this, null);
            flowLayoutPanel1.Resize += resizePanel;
        }
        private void loadItems()
        {
            _loaiTietKiemList = _loaiTietKiemBUS.getListLoaiTietKiem();
            populateItems(_loaiTietKiemList);
        }
        private void ucQuanLyLoaiTietKiem_Layout(object sender, LayoutEventArgs e)
        { 
            loadItems();
        }

        private void ucQuanLyLoaiTietKiem_Load(object sender, EventArgs e)
        {
            loadItems();
        }
    }
}
