using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Examen_3_AppServWEB_Mi_18_20.Clases;
using Examen_3_AppServWEB_Mi_18_20.Models;

namespace Examen_3_AppServWEB_Mi_18_20.Controllers
{
    [RoutePrefix("api/Evento")]
    [Authorize]
    public class EventoController : ApiController
    {
        [HttpGet]
        [Route("ConsultarEventoNombre")]
        public Evento ConsultarEventoNombre(string nombre)
        {
            clsevento evento = new clsevento();
            return evento.ConsultarXNombre(nombre);
        }

        [HttpGet]
        [Route("ConsultarEventoTipo")]
        public Evento ConsultarEventoTipo(string tipo)
        {
            clsevento evento = new clsevento();
            return evento.ConsultarXTipo(tipo);
        }

        [HttpGet]
        [Route("ConsultarEventoFecha")]
        public Evento ConsultarEventoFecha(string fecha)
        {
            clsevento evento = new clsevento();
            return evento.ConsultarXFecha(fecha);
        }

        [HttpPost]
        [Route("InsertarEvento")]
        public string InsertarEvento([FromBody] Evento evento)
        {
            clsevento eventoNuevo = new clsevento();
            eventoNuevo.evento = evento;
            return eventoNuevo.insertar();
        }

        [HttpPut]
        [Route("ActualizarEvento")]
        public string ActualizarEvento([FromBody] Evento evento)
        {
            clsevento eventoActualizar = new clsevento();
            eventoActualizar.evento = evento;
            return eventoActualizar.Actualizar();
        }

        [HttpDelete]
        [Route("EliminarEvento")]
        public string EliminarEvento(string id)
        {
            clsevento eventoEliminar = new clsevento();
            return eventoEliminar.Eliminar(id);
        }
    }
}