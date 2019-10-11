using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class ApuestasRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=localhost;Port=3306;Database=mydb;Uid=root;password=;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Apuesta> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuesta";
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Apuesta> apuestas = new List<Apuesta>();
                while (reader.Read())
                {
                    apuestas.Add(new Apuesta(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5)));
                }
                con.Close();
                return apuestas;
            }
            catch(MySqlException ex)
            {
                Console.WriteLine("Se ha producido un error: " + ex);
                return null;
            }
        }

        internal List<ApuestaDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from apuesta";
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (reader.Read())
                {
                    apuestas.Add(new ApuestaDTO(reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetString(5)));
                }
                con.Close();
                return apuestas;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Se ha producido un error: " + ex);
                return null;
            }
        }

        internal void Save(Apuesta a)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into apuesta values(" + a.Id + "," + "'" + a.Tipo + "'" + "," + a.Cuota + "," + a.DineroApostado+","+a.IdMercado+"," + "'" + a.EmailUsuario + "'" + ");";
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error " + e);
            }
            con.Close();
            if (a.Tipo.ToUpper() == "OVER")
            {
                command.CommandText = "UPDATE mercado SET dinero_apostado_over = dinero_apostado_over + " + a.DineroApostado + " WHERE id=" + a.IdMercado+";";
            }
            if (a.Tipo.ToUpper() == "UNDER")
            {
                command.CommandText = "UPDATE mercado SET dinero_apostado_under = dinero_apostado_under + " + a.DineroApostado + " WHERE id=" + a.IdMercado + ";";
            }
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error " + e);
            }
            con.Close();
            con.Open();
            command.CommandText = "select dinero_apostado_over from mercado where id="+ a.IdMercado+"; ";
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            double dino = reader.GetDouble(0);
            reader.Close();
            con.Close();

            con.Open();
            command.CommandText = "select dinero_apostado_under from mercado where id=" + a.IdMercado + "; ";
            reader = command.ExecuteReader();
            reader.Read();
            double dinu = reader.GetDouble(0);
            reader.Close();
            con.Close();
            double po = dino / (dino + dinu);
            double pu = dinu / (dinu + dino);
            command.CommandText = "update mercado set cuota_under = "+ (1/po)*0.95+" where id = " + a.IdMercado + "; update mercado set cuota_over ="+(1/pu)*0.95+" where id = "+ a.IdMercado +"; ";
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Error " + e);
            }
            con.Close();
        }
    }
}