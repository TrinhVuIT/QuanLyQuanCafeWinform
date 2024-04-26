using System;
using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {
        public int Id {  get; set; }
        public int IdTableFood { get; set; }
        public int Status { get; set; }
        public DateTime? DateCheckIn { get; set; }
        public DateTime? DateCheckOut { get; set; }

        public Bill(int id, int status, DateTime? dateCheckIn, DateTime? dateCheckOut)
        {
            Id = id;
            Status = status;
            DateCheckIn = dateCheckIn;
            DateCheckOut = dateCheckOut;
        }

        public Bill(DataRow row) 
        { 
            Id = (int)row["Id"];
            Status = (int)row["Status"];
            IdTableFood = (int)row["IdTableFood"];
            DateCheckIn = (DateTime?)row["DateCheckIn"];
            DateCheckOut = row["DateCheckOut"].ToString() != "" ? (DateTime?)row["DateCheckOut"] : null;
        }
    }
}
