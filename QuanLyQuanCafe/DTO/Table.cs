using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class Table
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public Table(int id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }

        public Table(DataRow row)
        {
            Id = (int)row["Id"];
            Name = row["TableName"].ToString();
            Status = row["Status"].ToString();
        }
    }
}
