using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class BillInfo
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public int BillId { get; set; }
        public int Count { get; set; }

        public BillInfo(int id, int foodId, int billId, int count) 
        {
            Id = id;
            FoodId = foodId;
            BillId = billId;
            Count = count;
        }

        public BillInfo(DataRow row)
        {
            Id = (int)row["Id"];
            FoodId = (int)row["IdFood"];
            BillId = (int)row["IdBill"];
            Count = (int)row["Count"];
        }
    }
}
