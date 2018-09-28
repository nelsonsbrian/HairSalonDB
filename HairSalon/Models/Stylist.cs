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

        public static void Delete(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand()as MySqlCommand;
            cmd.CommandText = @"DELETE FROM `stylists`where id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Update(string newName, int newWage)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand()as MySqlCommand;
            cmd.CommandText = @"UPDATE `stylists` SET name = @newName, wage = @newWage WHERE id = @thisId;";
            cmd.Parameters.AddWithValue("@newName", newName);
            cmd.Parameters.AddWithValue("@newWage", newWage);
            cmd.Parameters.AddWithValue("@thisId", this.Id);
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Stylist Find(int stylistId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `stylists` WHERE id = @id;";
            cmd.Parameters.AddWithValue("@id", stylistId);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;

            int Id = 0;
            string Name = "";
            int Wage = 0;
            DateTime StartDate = DateTime.MinValue;

            while (rdr.Read())
            {
              Id = rdr.GetInt32(0);
              Name = rdr.GetString(1);
              Wage = rdr.GetInt32(2);
              StartDate = rdr.GetDateTime(3);
            }
            Stylist foundStylist = new Stylist(Name, Wage, StartDate, Id);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundStylist;
        }

        public void AddSpecialty(int specialtyId)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"INSERT INTO `stylists_specialties` (`stylist_id`, `specialty_id`) VALUES (@stylistID, @specialtyID);";
          cmd.Parameters.AddWithValue("@stylistID", this.Id);
          cmd.Parameters.AddWithValue("@specialtyID", specialtyId);

          cmd.ExecuteNonQuery();

          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
        }

        public void RemoveSpecialty(int specialtyId)
        {
          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"DELETE FROM `stylists_specialties` WHERE specialty_id = @specialtyID AND stylist_id = @stylistID;";
          cmd.Parameters.AddWithValue("@stylistID", this.Id);
          cmd.Parameters.AddWithValue("@specialtyID", specialtyId);

          cmd.ExecuteNonQuery();

          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
        }

        public List<Specialty> GetSpecialties()
        {
          List<Specialty> allSpecialties = new List<Specialty> {};

          MySqlConnection conn = DB.Connection();
          conn.Open();

          var cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT specialties.* FROM stylists
          JOIN stylists_specialties ON (stylist_id = stylists.id)
          JOIN specialties ON (specialties.id = specialty_id)
          WHERE stylist_id = @stylistID;";
          cmd.Parameters.AddWithValue("@stylistID", this.Id);
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while (rdr.Read())
          {
              int Id = rdr.GetInt32(0);
              string Description = rdr.GetString(1);
              Specialty newSpecialty = new Specialty(Description, Id);
              allSpecialties.Add(newSpecialty);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allSpecialties;
        }

    }
}
