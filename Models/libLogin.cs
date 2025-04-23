using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_3_AppServWEB_Mi_18_20.Models
{
    public class Login
    {
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Documento { get; set; }
        public string NombreCompleto { get; set; }

    }
    public class LoginRespuesta
    {
        public string Usuario { get; set; }
        public bool Autenticado { get; set; }
        public string Token { get; set; }
        public string Mensaje { get; set; }
    }
}