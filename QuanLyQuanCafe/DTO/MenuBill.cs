using System;
using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class MenuBill
    {
        public string FoodName { get; set; }
        public int Count { get; set; }
        public float Price { get; set; }
        public float TotalPrice { get; set; }

        public MenuBill(string foodName, int count, float price, float totalPrice)
        {
            FoodName = foodName;
            Count = count;
            Price = price;
            TotalPrice = totalPrice;
        }

        public MenuBill(DataRow row)
        {
            FoodName = row["FoodName"].ToString();
            Count = (int)row["Count"];
            Price = (float)Convert.ToDouble(row["Price"].ToString());
            TotalPrice = (float)Convert.ToDouble(row["TotalPrice"].ToString());
        }
    }
}
