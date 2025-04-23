using Examen_3_AppServWEB_Mi_18_20.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen_3_AppServWEB_Mi_18_20.Clases
{
    public class clsLogin
    {
        public clsLogin()
        {
            loginRespuesta = new LoginRespuesta();
        }
        public NatilleraEntities dbNatillera = new NatilleraEntities();
        public Login login { get; set; }
        public LoginRespuesta loginRespuesta { get; set; }
        private bool ValidarUsuario()
        {
            try
            {

                //Se consulta el usuario, sólo con el nombre, para obtener la información básica del usuario: Clave.
                Administrador admon = dbNatillera.Administradors.FirstOrDefault(u => u.Usuario == login.Usuario);
                if (admon == null)
                {
                    //El usuario no existe, se retorna un error
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario no existe";
                    return false;
                }
             
                //Se obtiene la clave 
                login.Clave = admon.Clave;
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        private bool ValidarClave()
        {
            try
            {
                //Se consulta el usuario con la clave y el usuario para validar si existe. 
                Administrador admon = dbNatillera.Administradors.FirstOrDefault(u => u.Usuario == login.Usuario && u.Clave == login.Clave);
                if (admon == null)
                {
                    //Si no existe la clave es incorrecta
                    loginRespuesta.Autenticado = false;
                    loginRespuesta.Mensaje = "Usuario/Contraseña Incorrectos";
                    return false;
                }
                //La clave y el usuario son correctos. Traemos la información del usuario NombreCompleto y Documento
                login.Documento = admon.Documento;
                login.NombreCompleto = admon.NombreCompleto;
                return true;
            }
            catch (Exception ex)
            {
                loginRespuesta.Autenticado = false;
                loginRespuesta.Mensaje = ex.Message;
                return false;
            }
        }
        public IQueryable<LoginRespuesta> Ingresar()
        {
            //Si la validación es simple, en este punto se pone el código: if (user = "admin"){ token=...;}else{error;}
            if (ValidarUsuario() && ValidarClave())
            {
                //Si el usuario y la clave son correctas, se genera el token
                string token = TokenGenerator.GenerateTokenJwt(login.Usuario, login.Documento, login.NombreCompleto);
                //Consulta la información del usuario y el perfil
                return from U in dbNatillera.Set<Administrador>()
                       where U.Usuario == login.Usuario &&
                               U.Clave == login.Clave
                       select new LoginRespuesta
                       {
                           Usuario = U.Usuario,
                           Autenticado = true,
                           Token = token,
                           Mensaje = ""
                       };
            }
            else
            {
                List<LoginRespuesta> List = new List<LoginRespuesta>();
                List.Add(loginRespuesta);
                return List.AsQueryable();
            }
        }
    }
}