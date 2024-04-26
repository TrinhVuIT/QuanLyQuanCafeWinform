﻿using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}