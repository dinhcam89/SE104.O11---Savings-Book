using GUI.DashboardApp;
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
    public partial class Dashboard : Form
    {

        private ucQuanLyPhieu ucSearch;
        private ucQuanLyPhieu ucManageSavingBooks;
        private ucQuanLyKhachHang ucManageCustomers;
        private ucDoanhSoHoatDong ucSaleReport;
        private ucQuanLyLoaiTietKiem ucEditAdjustRate;
        private ucChinhSuaQuyDinh ucEditRules;
        private ucQuanLyChiTietRutTien ucQuanLyChiTietRutTien;
        private ucQuanLyChiTietGuiTien ucQuanLyChiTietGuiTien;

        public Dashboard()
        {
            InitializeComponent();
            this.panelMenuActive.Location = new Point(btnQuanLyPhieu.Location.X, btnQuanLyPhieu.Location.Y);
            this.tongglepanelMain("manageSavingBooks");
        }

        private void btnResetColor()
        {
            this.btnQuanLyPhieu.BackColor = Color.Transparent;
            //this.btnAddEditSavingBooks.BackColor = Color.Transparent;
            this.btnQuanLyPhieu.BackColor = Color.Transparent;
            this.btnQuanLyKhachHang.BackColor = Color.Transparent;
            this.btnDoanhSoHoatDong.BackColor = Color.Transparent;
            this.btnQuanLyLoaiTietKiem.BackColor = Color.Transparent;
            this.btnChinhSuaQuyDinh.BackColor = Color.Transparent;
            this.btnQuanLyChiTietGuiTien.BackColor = Color.Transparent;
            this.btnQuanLyChiTietRutTien.BackColor = Color.Transparent;

        }

        internal void tongglepanelMain(string panelMain)
        {
            this.btnResetColor();
            this.panelMain.Controls.Clear();
            switch (panelMain)
            {
                case "manageSavingBooks":
                    if (this.ucManageSavingBooks == null)
                    {
                        this.ucManageSavingBooks = new ucQuanLyPhieu();
                        this.panelMain.Controls.Add(ucManageSavingBooks);
                        this.ucManageSavingBooks.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucManageSavingBooks.Location = new System.Drawing.Point(0, 0);
                        this.ucManageSavingBooks.Name = "ucManageSavingBooks";
                        this.Size = new System.Drawing.Size(1526, 893);
                        this.ucManageSavingBooks.TabIndex = 0;
                    }
                    else
                    {
                        this.panelMain.Controls.Add(ucManageSavingBooks);
                    }
                    break;

                case "manageCustomers":
                    if (this.ucManageCustomers == null)
                    {
                        this.ucManageCustomers = new ucQuanLyKhachHang();
                        this.panelMain.Controls.Add(ucManageCustomers);
                        this.ucManageCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucManageCustomers.Location = new System.Drawing.Point(0, 0);
                        this.ucManageCustomers.Name = "ucManageCustomers";
                        this.Size = new System.Drawing.Size(1526, 893);
                        this.ucManageCustomers.TabIndex = 0;
                    }
                    else
                    {
                        this.panelMain.Controls.Add(ucManageCustomers);
                    }
                    break;

                case "sale":
                    if (this.ucSaleReport == null)
                    {
                        this.ucSaleReport = new ucDoanhSoHoatDong();
                        this.panelMain.Controls.Add(ucSaleReport);
                        this.ucSaleReport.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucSaleReport.Location = new System.Drawing.Point(0, 0);
                        this.ucSaleReport.Name = "ucSaleReport";
                        this.Size = new System.Drawing.Size(1526, 893);
                        this.ucSaleReport.TabIndex = 0;
                    }
                    else
                    {
                        this.panelMain.Controls.Add(ucSaleReport);
                    }
                    break;

                case "editAdjustRate":
                    if (this.ucEditAdjustRate == null)
                    {
                        this.ucEditAdjustRate = new ucQuanLyLoaiTietKiem();
                        this.panelMain.Controls.Add(ucEditAdjustRate);
                        this.ucEditAdjustRate.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucEditAdjustRate.Location = new System.Drawing.Point(0, 0);
                        this.ucEditAdjustRate.Name = "ucEditAdjustRate";
                        this.Size = new System.Drawing.Size(1526, 893);
                        this.ucEditAdjustRate.TabIndex = 0;
                    }
                    else
                    {
                        this.panelMain.Controls.Add(ucEditAdjustRate);
                    }
                    break;

                case "editRules":
                    if (this.ucEditRules == null)
                    {
                        this.ucEditRules = new ucChinhSuaQuyDinh();
                        this.panelMain.Controls.Add(ucEditRules);
                        this.ucEditRules.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucEditRules.Location = new System.Drawing.Point(0, 0);
                        this.ucEditRules.Name = "ucEditRules";
                        this.Size = new System.Drawing.Size(1526, 893);
                        this.ucEditRules.TabIndex = 0;
                    }
                    else
                    {
                        this.panelMain.Controls.Add(ucEditRules);
                    }
                    break;

                case "ChiTietRutTien":
                    if (this.ucQuanLyChiTietRutTien == null)
                    {
                        this.ucQuanLyChiTietRutTien = new ucQuanLyChiTietRutTien();
                        this.panelMain.Controls.Add(ucQuanLyChiTietRutTien);
                        this.ucQuanLyChiTietRutTien.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucQuanLyChiTietRutTien.Location = new System.Drawing.Point(0, 0);
                        this.ucQuanLyChiTietRutTien.Name = "ucQuanLyChiTietRutTien";
                        this.Size = new System.Drawing.Size(1526, 893);
                        this.ucQuanLyChiTietRutTien.TabIndex = 0;
                    }
                    else
                    {
                        this.panelMain.Controls.Add(ucQuanLyChiTietRutTien);
                    }
                    break;

                case "ChiTietGuiTien":
                    if (this.ucQuanLyChiTietGuiTien == null)
                    {
                        this.ucQuanLyChiTietGuiTien = new ucQuanLyChiTietGuiTien();
                        this.panelMain.Controls.Add(ucQuanLyChiTietGuiTien);
                        this.ucQuanLyChiTietGuiTien.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucQuanLyChiTietGuiTien.Location = new System.Drawing.Point(0, 0);
                        this.ucQuanLyChiTietGuiTien.Name = "ucQuanLyChiTietGuiTien";
                        this.Size = new System.Drawing.Size(1526, 893);
                        this.ucQuanLyChiTietGuiTien.TabIndex = 0;
                    }
                    else
                    {
                        this.panelMain.Controls.Add(ucQuanLyChiTietGuiTien);
                    }
                    break;

                default:
                    break;

            }
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnQuanLyKhachHang.Location.X, btnQuanLyKhachHang.Location.Y);
            this.tongglepanelMain("manageCustomers");
        }

        private void btnSaleReports_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnDoanhSoHoatDong.Location.X, btnDoanhSoHoatDong.Location.Y);
            this.tongglepanelMain("sale");
        }

        private void btnEditAdjustRate_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnQuanLyLoaiTietKiem.Location.X, btnQuanLyLoaiTietKiem.Location.Y);
            this.tongglepanelMain("editAdjustRate");
        }

        private void btnEditRules_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnChinhSuaQuyDinh.Location.X, btnChinhSuaQuyDinh.Location.Y);
            this.tongglepanelMain("editRules");
        }


        private void btnManageSavingBooks_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnQuanLyPhieu.Location.X, btnQuanLyPhieu.Location.Y);
            this.tongglepanelMain("manageSavingBooks");
        }

        private void btnManageSavingBooks_Click_1(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnQuanLyPhieu.Location.X, btnQuanLyPhieu.Location.Y);
            this.tongglepanelMain("manageSavingBooks");
        }


        private void btnQuanLyChiTietGuiTien_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnQuanLyChiTietGuiTien.Location.X, btnQuanLyChiTietGuiTien.Location.Y);
            this.tongglepanelMain("ChiTietGuiTien");
        }

        private void btnQuanLyChiTietRutTien_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnQuanLyChiTietRutTien.Location.X, btnQuanLyChiTietRutTien.Location.Y);
            this.tongglepanelMain("ChiTietRutTien");
        }

        private void panelMenuActive_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}