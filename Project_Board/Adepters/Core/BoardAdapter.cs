using System.Configuration;
using System.Data.SqlClient;


namespace Project_Board.Adepters.Core
{
    public class BoardAdapter
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MemberConnectionString"].ConnectionString;

        public SqlConnection _connection;

        public SqlConnection Connection
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(connectionString);
                }
                return _connection;
            }
        }

    }
}