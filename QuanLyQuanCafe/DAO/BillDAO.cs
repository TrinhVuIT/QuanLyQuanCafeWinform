using QuanLyQuanCafe.DTO;
using System.Data;

namespace QuanLyQuanCafe.DAO
{
    public class BillDAO
    {
        private static BillDAO instance;

        public static BillDAO Instance 
        {
            get { if (instance == null) instance = new BillDAO(); return instance; } 
            private set => instance = value; 
        }
        private BillDAO() { }

        public int GetUncheckBillIdByTableId(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.Bill where IdTableFood = " + id + "and Status = 0");
            
            if(data.Rows.Count > 0)
            {
                Bill bill = new Bill(data.Rows[0]);

                return bill.Id;
            }

            return -1;
        }

        public void InsertBill(int idTable)
        {
            DataProvider.Instance.ExecuteNonQuery("exec USP_InsertBill @idTable", new object[] {idTable});
        }

        public int GetMaxIdBill()
        {
            try
            {
                var result = (int)DataProvider.Instance.ExecuteScalar("select Max(Id) from dbo.Bill");

                return result;
            }
            catch
            {
                return -1;
            }
        }
    }
}
