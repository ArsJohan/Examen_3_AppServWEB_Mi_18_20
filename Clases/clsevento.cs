using Examen_3_AppServWEB_Mi_18_20.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace Examen_3_AppServWEB_Mi_18_20.Clases
{
    public class clsevento
    {
        private NatilleraEntities Natilla = new NatilleraEntities();
        public Evento evento { get; set; }
        public string insertar()
        {
            try
            {
                Natilla.Eventos.Add(evento);
                Natilla.SaveChanges();
                return "Se inserto correctamente el evento en la abse de datos";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private Evento ConsultarXId(int id)
        {
            return Natilla.Eventos.FirstOrDefault(x => x.idEventos == id);
        }

        public Evento ConsultarXTipo(string tipo)
        {
            return Natilla.Eventos.FirstOrDefault(x => x.TipoEvento == tipo);
        }

        public Evento ConsultarXNombre(string nombre)
        {
            return Natilla.Eventos.FirstOrDefault(x => x.NombreEvento == nombre);
        }


        public Evento ConsultarXFecha(string fecha)
        {
            DateTime fechaParsed = DateTime.Parse(fecha); // Convert outside the query
            return Natilla.Eventos.FirstOrDefault(x => x.FechaEvento == fechaParsed);
        }

        public string Actualizar()
        {
            try
            {
                Evento eventoActual = ConsultarXId(evento.idEventos);
                if (eventoActual == null)
                {
                    return "Evento no encontrado";
                }
                Natilla.Eventos.AddOrUpdate(evento);
                Natilla.SaveChanges();
                return "Se actualizo Correctamente";
            }
            catch (Exception ex)
            {

                return "No se pudo actualizar el empleado: " + ex.Message;

            }

        }

        public string Eliminar(string id)
        {
            try
            {
                Evento evento = ConsultarXId(Convert.ToInt32(id));
                if (evento == null)
                {
                    return "Evento no encontrado";
                }
                Natilla.Eventos.Remove(evento);
                Natilla.SaveChanges();
                return "Se elimino correctamente";
            }
            catch (Exception ex)
            {
                return "No se pudo eliminar el evento: " + ex.Message;
            }

        }
    }
}