using System;
using System.Collections.Generic;
using HairSalon;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Stylist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wage { get; set; }
        public DateTime StartDate { get; set; }

        public Stylist(string name, int wage, DateTime start_date, int newId = 0)
        {
            Name = name;
            Wage = wage;
            StartDate = start_date;
            Id = newId;
        }
        public void Create()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand()as MySqlCommand;
            cmd.CommandText = @"INSERT INTO `stylists` (`name`, `wage`, `start_date`) VALUES (@name, @wage, @start_date);";
            cmd.Parameters.AddWithValue("@name", this.Name);
            cmd.Parameters.AddWithValue("@wage", this.Wage);
            cmd.Parameters.AddWithValue("@start_date", this.StartDate);

            cmd.ExecuteNonQuery();
            Id = (int)cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Stylist> GetAll()
        {
            List<Stylist> allStylists = new List<Stylist> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand()as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `stylists`;";
            MySqlDataReader rdr = cmd.ExecuteReader()as MySqlDataReader;

            while (rdr.Read())
            {
                int Id = rdr.GetInt32(0);
                string Name = rdr.GetString(1);
                int Wage = rdr.GetInt32(2);
                DateTime StartDate = rdr.GetDateTime(3);

                Stylist newStylist = new Stylist(Name, Wage, StartDate, Id);
                allStylists.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylists;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand()as MySqlCommand;
            cmd.CommandText = @"DELETE FROM `stylists`;";

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        // public void Update(string newFoodType)
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();
        //
        //     var cmd = conn.CreateCommand()as MySqlCommand;
        //     cmd.CommandText = @"UPDATE `stylists` SET food = @NewType WHERE id = @thisId;";
        //
        //     MySqlParameter foodType = new MySqlParameter();
        //     cmd.Parameters.AddWithValue("@NewType", newFoodType);
        //     MySqlParameter Id = new MySqlParameter();
        //     cmd.Parameters.AddWithValue("@thisId", this.Id);
        //     this.FoodType = newFoodType;
        //     cmd.ExecuteNonQuery();
        //
        //     conn.Close();
        //     if (conn != null)
        //     {
        //         conn.Dispose();
        //     }
        // }

        public static int FindId(string stylistId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand()as MySqlCommand;
            cmd.CommandText = @"SELECT id FROM `stylists` WHERE name = @name;";
            cmd.Parameters.AddWithValue("@name", stylistId);

            MySqlDataReader rdr = cmd.ExecuteReader()as MySqlDataReader;

            rdr.Read();
            int newId = rdr.GetInt32(0);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newId;
        }


        // public static bool ExistingStylist(string cuisineName)
        // {
        //     MySqlConnection conn = DB.Connection();
        //     conn.Open();

        //     var cmd = conn.CreateCommand()as MySqlCommand;
        //     cmd.CommandText = @"SELECT food FROM `cuisines`";
        //      MySqlDataReader rdr = cmd.ExecuteReader()as MySqlDataReader;
        //     List<Stylist> allC
        //      while (rdr.Read())
        //      {

        //      }

        // }

    }
}
