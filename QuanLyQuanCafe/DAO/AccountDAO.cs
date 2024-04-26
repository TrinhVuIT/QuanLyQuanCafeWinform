namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value;
        }
        private AccountDAO() { }

        public bool Login(string userName, string password)
        {
            string query = "USP_Login @userName , @password";
            var result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, password });

            return result.Rows.Count > 0;
        }
    }
}
