using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public Category(int id, string categoryName)
        {
            Id = id;
            CategoryName = categoryName;
        }

        public Category(DataRow row)
        {
            Id = (int)row["Id"];
            CategoryName = row["CategoryName"].ToString();
        }
    }
}
