using MySql.Data.MySqlClient;

namespace SHOPPP_Cherkashneva.Data.Common
{
    public class Connection
    {
        readonly static string ConnectionData = "server=127.0.0.1; uid=root; database=Shop";

        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(ConnectionData);
            connection.Open();
            return connection;
        }

        public static MySqlDataReader GetQuery (string sql, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand(sql, connection);
            return command.ExecuteReader();
        }

        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();

            MySqlConnection.ClearPool(connection); 
        }

    }
}
