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

        private ucSearch ucSearch;
        private ucAddEditSavingBooks ucAddEditSavingBooks;
        private ucManageSavingBooks ucManageSavingBooks;
        private ucManageCustomers ucManageCustomers;
        private ucStats ucStats;
        private ucReports ucReports;
        private ucEditAdjustRate ucEditAdjustRate;
        private ucEditRules ucEditRules;

        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnResetColor()
        {
            this.btnSearch.BackColor = Color.Transparent;
            this.btnAddEditSavingBooks.BackColor = Color.Transparent;
            this.btnManageSavingBooks.BackColor = Color.Transparent;
            this.btnManageCustomers.BackColor = Color.Transparent;
            this.btnStats.BackColor = Color.Transparent;
            this.btnReports.BackColor = Color.Transparent;
            this.btnEditAdjustRate.BackColor = Color.Transparent;
            this.btnEditRules.BackColor = Color.Transparent;

        }

        internal void tongglepanelMain (string panelMain)
        {
            this.btnResetColor();
            this.panelMain.Controls.Clear();
            switch (panelMain)
            {
                case "search":
                    if(this.ucSearch == null)
                    {
                        this.ucSearch = new ucSearch();
                        this.panelMain.Controls.Add(ucSearch);
                        this.ucSearch.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucSearch.Location = new System.Drawing.Point(0, 0);
                        this.ucSearch.Name = "ucSearch";
                        this.Size = new System.Drawing.Size(698, 508);
                        this.ucSearch.TabIndex = 0;
                    } 
                    else
                    {
                        this.panelMain.Controls.Add(ucSearch);
                    }
                    break;

                case "add":
                    if (this.ucAddEditSavingBooks == null)
                    {
                        this.ucAddEditSavingBooks = new ucAddEditSavingBooks();
                        this.panelMain.Controls.Add(ucAddEditSavingBooks);
                        this.ucAddEditSavingBooks.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucAddEditSavingBooks.Location = new System.Drawing.Point(0, 0);
                        this.ucAddEditSavingBooks.Name = "ucAddEditSavingBooks";
                        this.Size = new System.Drawing.Size(698, 508);
                        this.ucAddEditSavingBooks.TabIndex = 0;
                    }
                    else
                    {
                        this.panelMain.Controls.Add(ucAddEditSavingBooks);
                    }
                    break;

                case "manageSavingBooks":
                    if (this.ucManageSavingBooks == null)
                    {
                        this.ucManageSavingBooks = new ucManageSavingBooks();
                        this.panelMain.Controls.Add(ucManageSavingBooks);
                        this.ucManageSavingBooks.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucManageSavingBooks.Location = new System.Drawing.Point(0, 0);
                        this.ucManageSavingBooks.Name = "ucManageSavingBooks";
                        this.Size = new System.Drawing.Size(698, 508);
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
                        this.ucManageCustomers = new ucManageCustomers();
                        this.panelMain.Controls.Add(ucManageCustomers);
                        this.ucManageCustomers.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucManageCustomers.Location = new System.Drawing.Point(0, 0);
                        this.ucManageCustomers.Name = "ucManageCustomers";
                        this.Size = new System.Drawing.Size(698, 508);
                        this.ucManageCustomers.TabIndex = 0;
                    }
                    else
                    {
                        this.panelMain.Controls.Add(ucManageCustomers);
                    }
                    break;

                case "stats":
                    if (this.ucStats == null)
                    {
                        this.ucStats = new ucStats();
                        this.panelMain.Controls.Add(ucStats);
                        this.ucStats.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucStats.Location = new System.Drawing.Point(0, 0);
                        this.ucStats.Name = "ucStats";
                        this.Size = new System.Drawing.Size(698, 508);
                        this.ucStats.TabIndex = 0;
                    }
                    else
                    {
                        this.panelMain.Controls.Add(ucStats);
                    }
                    break;

                case "reports":
                    if (this.ucReports == null)
                    {
                        this.ucReports = new ucReports();
                        this.panelMain.Controls.Add(ucReports);
                        this.ucReports.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucReports.Location = new System.Drawing.Point(0, 0);
                        this.ucReports.Name = "ucReports";
                        this.Size = new System.Drawing.Size(698, 508);
                        this.ucReports.TabIndex = 0;
                    }
                    else
                    {
                        this.panelMain.Controls.Add(ucReports);
                    }
                    break;

                case "editAdjustRate":
                    if (this.ucEditAdjustRate == null)
                    {
                        this.ucEditAdjustRate = new ucEditAdjustRate();
                        this.panelMain.Controls.Add(ucEditAdjustRate);
                        this.ucEditAdjustRate.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucEditAdjustRate.Location = new System.Drawing.Point(0, 0);
                        this.ucEditAdjustRate.Name = "ucEditAdjustRate";
                        this.Size = new System.Drawing.Size(698, 508);
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
                        this.ucEditRules = new ucEditRules();
                        this.panelMain.Controls.Add(ucEditRules);
                        this.ucEditRules.Dock = System.Windows.Forms.DockStyle.Fill;
                        this.ucEditRules.Location = new System.Drawing.Point(0, 0);
                        this.ucEditRules.Name = "ucEditRules";
                        this.Size = new System.Drawing.Size(698, 508);
                        this.ucEditRules.TabIndex = 0;
                    }
                    else
                    {
                        this.panelMain.Controls.Add(ucEditRules);
                    }
                    break;

                default:
                    break;

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnSearch.Location.X, btnSearch.Location.Y);
            this.tongglepanelMain("search");

        }

        private void btnAddEditSavingBooks_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnAddEditSavingBooks.Location.X, btnAddEditSavingBooks.Location.Y);
            this.tongglepanelMain("add");
        }

        private void btnManageSavingBooks_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnManageSavingBooks.Location.X, btnManageSavingBooks.Location.Y);
            this.tongglepanelMain("manageSavingBooks");
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnManageCustomers.Location.X, btnManageCustomers.Location.Y);
            this.tongglepanelMain("manageCustomers");
        }

        private void btnStats_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnStats.Location.X, btnStats.Location.Y);
            this.tongglepanelMain("stats");
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnReports.Location.X, btnReports.Location.Y);
            this.tongglepanelMain("reports");
        }

        private void btnEditAdjustRate_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnEditAdjustRate.Location.X, btnEditAdjustRate.Location.Y);
            this.tongglepanelMain("editAdjustRate");
        }

        private void btnEditRules_Click(object sender, EventArgs e)
        {
            this.panelMenuActive.Location = new Point(btnEditRules.Location.X, btnEditRules.Location.Y);
            this.tongglepanelMain("editRules");
        }
    }
}
