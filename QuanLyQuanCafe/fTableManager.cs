using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
        }

        #region Method

        void LoadCategory()
        {
            var listCategory = CategoryDAO.Instance.GetListCategory();

            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "CategoryName";
        }

        void LoadFoodByCategoryId(int categoryId)
        {
            var listFood = FoodDAO.Instance.GetListFoodByCategoryId(categoryId);

            cbFood.DataSource = listFood;
            cbFood.DisplayMember = "FoodName";
        }
        void LoadTable()
        {
            var tableList = TableFoodDAO.Instance.LoadTableList();
            foreach (var table in tableList)
            {
                Button btn = new Button() { Width = TableFoodDAO.Width, Height = TableFoodDAO.Height, Cursor = Cursors.Hand };
                btn.Text = table.Name + Environment.NewLine + table.Status;
                btn.Click += btn_Click;
                btn.Tag = table;

                switch (table.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }

                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int idTable)
        {
            lsvBill.Items.Clear();

            float totalPriceBill = 0;

            var listMenuBill = MenuBillDAO.Instance.GetListMenuBillByIdTable(idTable);

            foreach (var item in listMenuBill)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPriceBill += item.TotalPrice;

                lsvBill.Items.Add(lsvItem);
            }
            //Định dạng tiền tệ sang tiền việt nam
            CultureInfo culture = new CultureInfo("vi-VN");
            
            txbTotalPriceBill.Text = totalPriceBill.ToString("c", culture);
        }

        #endregion

        #region Events

        private void btn_Click(object sender, EventArgs e)
        {
            int tableId = ((sender as Button).Tag as Table).Id;
            lsvBill.Tag = (sender as Button).Tag as Table;
            ShowBill(tableId);
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin fAdmin = new fAdmin();
            fAdmin.ShowDialog();
        }
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null) return;

            Category category = cb.SelectedItem as Category;

            id = category.Id;

            LoadFoodByCategoryId(id);
        }

        private void btnAddFood_Click(object sender, EventArgs e)
        {
            var table = lsvBill.Tag as Table;

            int idBill = BillDAO.Instance.GetUncheckBillIdByTableId(table.Id);
            int idFood = (cbFood.SelectedItem as Food).Id;
            int count = (int)nmFoodCount.Value;

            if(idBill == -1)
            {
                BillDAO.Instance.InsertBill(table.Id);

                BillInfoDAO.Instance.InsertBillInfo(BillDAO.Instance.GetMaxIdBill(), idFood, count);
            }
            else
            {
                BillInfoDAO.Instance.InsertBillInfo(idBill, idFood, count);
            }

            ShowBill(table.Id);
        }
        #endregion

    }
}
