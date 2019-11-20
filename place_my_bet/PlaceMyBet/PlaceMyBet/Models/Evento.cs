using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Evento
    {
        public Evento(int id, string equipov, string equipol)
        {
            EventoId = id;
            EquipoL = equipol;
            EquipoV = equipov;
        }
        public int EventoId { get; set; }
        public string EquipoL { get; set; }
        public string EquipoV { get; set; }
    }

    public class EventoDTO
    {
        public EventoDTO(string equipov, string equipol)
        {
            EquipoL = equipol;
            EquipoV = equipov;
        }
        public string EquipoL { get; set; }
        public string EquipoV { get; set; }
    }



    /*** EJERCICIO 3 ***/
    public class EventoDTODIN
    {
        public EventoDTODIN(int id, string visitante, string local, double dinero)
        {
            EquipoL = local;
            EquipoV = visitante;
            Id = id;
            Dinero = dinero;
        }
        public string EquipoL { get; set; }
        public string EquipoV { get; set; }
        public int Id { get; set; }
        public double Dinero { get; set; }
    }
}