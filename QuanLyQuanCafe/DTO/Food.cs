using System;
using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class Food
    {
        public int Id { get; set; }
        public int IdCategory { get; set; }
        public string FoodName { get; set; }
        public float Price { get; set; }

        public Food(int id, int idCategory, string foodName, float price)
        {
            Id = id;
            IdCategory = idCategory;
            FoodName = foodName;
            Price = price;
        }

        public Food(DataRow row)
        {
            Id = (int)row["Id"];
            IdCategory = (int)row["IdCategory"];
            FoodName = row["FoodName"].ToString();
            Price = (float)Convert.ToDouble(row["Price"].ToString());
        }
    }
}
