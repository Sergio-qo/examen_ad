using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        public Mercado(int id, double dineroApostadoUnder, double dineroApostadoOver, double cuotaUnder, double cuotaOver, string tipo, int idPartido)
        {
            Id = id;
            DineroApostadoOver = dineroApostadoOver;
            DineroApostadoUnder = dineroApostadoUnder;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            Tipo = tipo;
            IdPartdio = idPartido;
        }

        public int Id { get; set; }
        public double DineroApostadoUnder { get; set; }
        public double DineroApostadoOver { get; set; }
        public double CuotaUnder { get; set; }
        public double CuotaOver { get; set;}
        public string Tipo { get; set;}
        public int IdPartdio { get; set;}
    }

    public class MercadoDTO
    {
        public MercadoDTO(double cuotaUnder, double cuotaOver, string tipo, int idPartido)
        {
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            Tipo = tipo;
            IdPartdio = idPartido;
        }

        public double CuotaUnder { get; set; }
        public double CuotaOver { get; set; }
        public string Tipo { get; set; }
        public int IdPartdio { get; set; }
    }
}