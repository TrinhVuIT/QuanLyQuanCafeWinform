using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class Bill
    {
        private int Id {  get; set; }
        private int IdTableFood { get; set; }
        private int Status { get; set; }
        private DateTime? DateCheckIn { get; set; }
        private DateTime? DateCheckOut { get; set; }

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
            DateCheckOut = (DateTime?)row["DateCheckOut"];
        }
    }
}
