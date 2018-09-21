using System;
using MySql.Data.MySqlClient;
using BestRestaurants;
using static BestRestaurants.Startup;

namespace HairSalon.Models
{
    public class DB
    {
        public static MySqlConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
            return conn;
        }
    }
}
