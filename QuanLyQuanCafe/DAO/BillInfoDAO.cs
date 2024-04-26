using QuanLyQuanCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyQuanCafe.DAO
{
    public class BillInfoDAO
    {
        private static BillInfoDAO instance;

        public static BillInfoDAO Instance 
        { 
            get { if (instance == null) instance = new BillInfoDAO();  return instance; }
            private set => instance = value; 
        }

        private BillInfoDAO() { }

        public List<BillInfo> GetListBillInfoByIdBill(int idBill)
        {
            var listBillInfo = new List<BillInfo>();

            DataTable data = DataProvider.Instance.ExecuteQuery("select * from dbo.BillInfo where IdBill = " + idBill);

            foreach (DataRow row in data.Rows)
            {
                BillInfo info = new BillInfo(row);

                listBillInfo.Add(info);
            }

            return listBillInfo;
        }

        public void InsertBillInfo(int idBill, int idFood, int count)
        {
            DataProvider.Instance.ExecuteNonQuery("USP_InsertBillInfo @IdBill , @IdFood , @Count", new object[] { idBill, idFood, count });
        }
    }
}
