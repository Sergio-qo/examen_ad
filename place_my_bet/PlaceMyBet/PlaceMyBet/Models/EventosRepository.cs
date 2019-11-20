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


        /*** EJERCICIO 3 ***/
        internal void Save(EventoDTODIN e)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "insert into partido values(" + e.Id + ", " + "'" + e.EquipoV + "'"  + "," + "'" + e.EquipoL + "'" + ");";
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Se ha producido un error: " + ex);
                con.Close();
            }

            int id = 0;

            command.CommandText = "SELECT MAX(id) FROM mercado;";
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                reader.Read();
                id = reader.GetInt32(0);

                con.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Se ha producido un error: " + ex);
                con.Close();
            }


            int mercado1id = id + 1;
            int mercado2id = id + 2;
            int mercado3id = id + 3;
            double probabilidad = e.Dinero / (e.Dinero + e.Dinero);
            double cuota = Convert.ToDouble((1 / probabilidad) * 0.95);

            command.CommandText = "insert into mercado (id, dinero_apostado_under, dinero_apostado_over, cuota_under, cuota_over, tipo, id_partido) values(" + mercado1id + "," + "'" + e.Dinero + "'" + "," + "'" + e.Dinero + "'" + "," + "'" + cuota + "'" + "," + "'" + cuota + "'" + "," + "1.5" + "," + e.Id + ");";
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Se ha producido un error: " + ex);
                con.Close();
            }

            command.CommandText = "insert into mercado (id, dinero_apostado_under, dinero_apostado_over, cuota_under, cuota_over, tipo, id_partido) values(" + mercado2id + "," + "'" + e.Dinero + "'" + "," + "'" + e.Dinero + "'" + "," + "'" + cuota + "'" + "," + "'" + cuota + "'" + "," + "2.5" + "," + e.Id + ");";
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Se ha producido un error: " + ex);
                con.Close();
            }

            command.CommandText = "insert into mercado (id, dinero_apostado_under, dinero_apostado_over, cuota_under, cuota_over, tipo, id_partido) values(" + mercado3id + "," + "'" + e.Dinero + "'" + "," + "'" + e.Dinero + "'" + "," + "'" + cuota + "'" + "," + "'" + cuota + "'" + "," + "3.5" + "," + e.Id + ");";
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Se ha producido un error: " + ex);
                con.Close();
            }
        }


        internal List<Evento> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from partido";
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<Evento> eventos = new List<Evento>();
                while (reader.Read())
                {
                    eventos.Add(new Evento(reader.GetInt32(0), reader.GetString(1), reader.GetString(2)));
                }
                con.Close();
                return eventos;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Se ha producido un error: " + ex);
                return null;
            }
        }

        internal List<EventoDTO> RetrieveDTO()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from partido";
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                List<EventoDTO> eventos = new List<EventoDTO>();
                while (reader.Read())
                {
                    eventos.Add(new EventoDTO(reader.GetString(1), reader.GetString(2)));
                }
                con.Close();
                return eventos;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Se ha producido un error: " + ex);
                return null;
            }
        }
    }
}