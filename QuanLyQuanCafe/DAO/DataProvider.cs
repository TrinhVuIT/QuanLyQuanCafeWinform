using System.Data;
using System.Data.SqlClient;

namespace QuanLyQuanCafe.DAO
{
    public class DataProvider
    {

        private static DataProvider instance; //Ctrl + R + E  Dùng để đóng gói

        private string connectionSTR = "Data Source=TrinhCau;Initial Catalog=QuanLyQuanCafe;Integrated Security=True;TrustServerCertificate=True";

        public static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return instance; }
            private set => instance = value; 
        }
        private DataProvider() { }

        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');

                    int i = 0;
                    foreach (string str in listPara)
                    {
                        if (str.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(str, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

                dataAdapter.Fill(data);

                conn.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');

                    int i = 0;
                    foreach (string str in listPara)
                    {
                        if (str.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(str, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteNonQuery();  //Đếm số dòng thành công
                conn.Close();
            }


            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection conn = new SqlConnection(connectionSTR))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(query, conn);

                if (parameter != null)
                {
                    string[] listPara = query.Split(' ');

                    int i = 0;
                    foreach (string str in listPara)
                    {
                        if (str.Contains("@"))
                        {
                            cmd.Parameters.AddWithValue(str, parameter[i]);
                            i++;
                        }
                    }
                }
                data = cmd.ExecuteScalar(); //Trả về dòng + cột đầu tiên trong bảng kết quả 
                conn.Close();
            }


            return data;
        }
    }
}
