using QuanLyQuanCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyQuanCafe.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;

        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            private set => instance = value;
        }

        private FoodDAO() { }

        public List<Food> GetListFoodByCategoryId(int categoryId)
        {
            var list = new List<Food>();

            var query = "select * from dbo.Food where IdCategory = " + categoryId;

            var data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                var food = new Food(item);

                list.Add(food);
            }

            return list;
        }
    }
}
