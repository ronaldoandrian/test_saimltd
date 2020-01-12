using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAIMLTD.Models.DAO
{
    public class DBConnection
    {
        private string connectionString = "Data Source=localhost; Initial Catalog=test_saimltd_bdd; user id=root; password=root";
        private MySqlConnection connection;
        public DBConnection()
        {

        }

        public MySqlConnection GetConnection()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CloseConnection()
        {
            try
            {
                if (connection != null) connection.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}