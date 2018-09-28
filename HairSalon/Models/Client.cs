using System;
using System.Collections.Generic;
using HairSalon;
using MySql.Data.MySqlClient;

namespace HairSalon.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int StylistId { get; set; }

        public Client(string name, string address, string phone, int stylistId, int newId = 0)
        {
            Name = name;
            Address = address;
            Phone = phone;
            StylistId = stylistId;
            Id = newId;
        }
        public void Create()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand()as MySqlCommand;
            cmd.CommandText = @"INSERT INTO `clients` (`name`, `address`, `phone`, `stylist_id`) VALUES (@name, @address, @phone, @stylistId);";
            cmd.Parameters.AddWithValue("@name", this.Name);
            cmd.Parameters.AddWithValue("@address", this.Address);
            cmd.Parameters.AddWithValue("@phone", this.Phone);
            cmd.Parameters.AddWithValue("@stylistId", this.StylistId);

            cmd.ExecuteNonQuery();
            Id = (int)cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand()as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `clients`;";
            MySqlDataReader rdr = cmd.ExecuteReader()as MySqlDataReader;

            while (rdr.Read())
            {
                int Id = rdr.GetInt32(0);
                string Name = rdr.GetString(1);
                string Address = rdr.GetString(2);
                string Phone = rdr.GetString(3);
                int StylistId = rdr.GetInt32(4);

                Client newClient = new Client(Name, Address, Phone, StylistId, Id);
                allClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allClients;
        }

        public static void ClearAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand()as MySqlCommand;
            cmd.CommandText = @"DELETE FROM `clients`;";

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
            cmd.CommandText = @"DELETE FROM `clients`where id = @id;";
            cmd.Parameters.AddWithValue("@id", id);

            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Update(string newName, string newAddress, string newPhone, int newStylistId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand()as MySqlCommand;
            cmd.CommandText = @"UPDATE `clients` SET name = @newName, address = @newAddress, phone = @newPhone, stylist_id = @newStylistId WHERE id = @thisId;";
            cmd.Parameters.AddWithValue("@newName", newName);
            cmd.Parameters.AddWithValue("@newAddress", newAddress);
            cmd.Parameters.AddWithValue("@newPhone", newPhone);
            cmd.Parameters.AddWithValue("@newStylistId", newStylistId);
            cmd.Parameters.AddWithValue("@thisId", this.Id);
            cmd.ExecuteNonQuery();

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static Client Find(int clientId)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand()as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE id = @id;";
            cmd.Parameters.AddWithValue("@id", clientId);

            MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
            int Id = 0;
            string Name = "";
            string Address = "";
            string Phone = "";
            int StylistId = 0;

            while (rdr.Read())
            {
              Id = rdr.GetInt32(0);
              Name = rdr.GetString(1);
              Address = rdr.GetString(2);
              Phone = rdr.GetString(3);
              StylistId = rdr.GetInt32(4);
            }
            Client foundClient = new Client(Name, Address, Phone, StylistId, Id);

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return foundClient;
        }

    }
}
