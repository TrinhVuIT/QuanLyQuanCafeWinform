using QuanLyQuanCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyQuanCafe.DAO
{
    public class MenuBillDAO
    {
        private static MenuBillDAO instance;

        public static MenuBillDAO Instance 
        {
            get { if (instance == null) instance = new MenuBillDAO(); return instance; } 
            private set => instance = value; 
        }

        private MenuBillDAO() { }

        public List<MenuBill> GetListMenuBillByIdTable(int idTable)
        {
            var listMenuBill = new List<MenuBill>();

            var query = "select f.FoodName, bi.Count, f.Price, bi.Count*f.Price as TotalPrice from dbo.BillInfo as bi, dbo.Bill as b, dbo.Food as f where bi.IdBill = b.Id and bi.IdFood = f.Id and b.Status = 0 and b.IdTableFood = " + idTable;

            var data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                var menuBill = new MenuBill(item);

                listMenuBill.Add(menuBill);
            }

            return listMenuBill;
        }
    }
}
