using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SERVER.DatabaseManager
{
    public class BaseDatabaseManager
    {
        protected BaseDatabaseManager() { }

        public static MySqlConnection connection
        {
            get
            {
                MySqlConnection connection =new MySqlConnection();
                string connectionString = "SERVER=localhost;"+"DATABASE=webshop;"+"UID=root;"+"PASSWORD=;"+"SSL MODE=none;";
                connection.ConnectionString = connectionString;
                return connection;
            }
        }
    }
}