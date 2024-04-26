using QuanLyQuanCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyQuanCafe.DAO
{
    public class TableFoodDAO
    {
        private static TableFoodDAO instance;
        public static int Width = 90;
        public static int Height = 90;

        public static TableFoodDAO Instance
        {
            get { if(instance == null) instance = new TableFoodDAO(); return instance; }
            private set => instance = value;
        }

        public TableFoodDAO() { }

        public List<Table> LoadTableList()
        {
            List<Table> list = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow row in data.Rows)
            {
                Table table = new Table(row);

                list.Add(table);
            }
            return list;
        }
    }
}
