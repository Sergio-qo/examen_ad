using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class EventosRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=localhost;Port=3306;Database=mydb;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Evento> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from partido";
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            List<Evento> eventos = new List<Evento>();
            while (reader.Read())
            {
                eventos.Add(new Evento(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
            }
            return eventos;
        }
    }
}