using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PlaceMyBet.Models;

namespace PlaceMyBet.Controllers
{
    public class EventosController : ApiController
    {
        // GET: api/Eventos
        public List<EventoDTO> Get()
        {
            var repo = new EventosRepository();
            List<EventoDTO> eventos = repo.RetrieveDTO();
            return eventos;
        }

        // GET: api/Eventos/5
        public List<Evento> Get(int id)
        {
            return null;
        }

        // POST: api/Eventos

        /*** EJERCICIO 3 ***/
        public void Post(EventoDTODIN e)
        {
            var repo = new EventosRepository();
            repo.Save(e);
        }

        // PUT: api/Eventos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Eventos/5
        public void Delete(int id)
        {
        }
    }
}
