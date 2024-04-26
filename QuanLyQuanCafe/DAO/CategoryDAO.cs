using QuanLyQuanCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyQuanCafe.DAO
{
    public class CategoryDAO
    {
        private static CategoryDAO instance;

        public static CategoryDAO Instance 
        {
            get { if (instance == null) instance = new CategoryDAO(); return instance; } 
            private set => instance = value; 
        }

        private CategoryDAO() { }

        public List<Category> GetListCategory()
        {
            var list = new List<Category>();

            var data = DataProvider.Instance.ExecuteQuery("select * from dbo.FoodCategory");

            foreach (DataRow item in data.Rows)
            {
                var category = new Category(item);

                list.Add(category);
            }

            return list;
        }
    }
}
