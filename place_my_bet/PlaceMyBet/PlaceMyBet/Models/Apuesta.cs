using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(int id, string tipo, double cuota, double dineroApostado, int idMercado, string emailUsuario)
        {
            Id = id;
            Tipo = tipo;
            Cuota = cuota;
            DineroApostado = dineroApostado;
            IdMercado = idMercado;
            EmailUsuario = emailUsuario;
        }
        public int Id { get; set; }
        public string Tipo { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }
        public int IdMercado { get; set; }
        public string EmailUsuario { get; set; }

       
    }

    public class ApuestaDTO
    {
        public ApuestaDTO(string tipo, double cuota, double dineroApostado, int idMercado, string emailUsuario)
        {
            Tipo = tipo;
            Cuota = cuota;
            DineroApostado = dineroApostado;
            IdMercado = idMercado;
            EmailUsuario = emailUsuario;
        }
        public string Tipo { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }
        public int IdMercado { get; set; }
        public string EmailUsuario { get; set; }
    }

    public class ApuestaDTOEVME
    {
        public ApuestaDTOEVME(string tipo_mercado,  int id_evento, int id, string tipo, double cuota, double dineroApostado, int idMercado, string emailUsuario)
        {
            Tipo_Mercado = tipo_mercado;
            Id_Evento = id_evento;
            Tipo = tipo;
            Cuota = cuota;
            DineroApostado = dineroApostado;
            IdMercado = idMercado;
            EmailUsuario = emailUsuario;
        }
        public string Tipo_Mercado { get; set; }
        public int Id_Evento { get; set; }
        public string Tipo { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }
        public int IdMercado { get; set; }
        public string EmailUsuario { get; set; }


    }
}