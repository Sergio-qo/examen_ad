using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace PlaceMyBet.Models
{
    public class MercadosRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=localhost;Port=3306;Database=mydb;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Mercado> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercado";
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Mercado> mercados = new List<Mercado>();
                while (reader.Read())
                {
                    mercados.Add(new Mercado(reader.GetInt32(0), reader.GetDouble(1), reader.GetDouble(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetString(5), reader.GetInt32(6)));
                }
                con.Close();
                return mercados;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Se ha producido un error: " + ex);
                return null;
            }
        }
    }
}