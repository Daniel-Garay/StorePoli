using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Routing;
using Store.Models;

namespace Store.Controllers
{
    public class UsuariosRestController : ApiController
    {
        Usuario objUsuario = new Usuario();

        [HttpGet]
        [Route("api/ConsultarUsuarios")]
        public HttpResponseMessage ConsultarUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios = objUsuario.ConsultarUsuarios();
            return Request.CreateResponse(HttpStatusCode.OK, usuarios, Configuration.Formatters.JsonFormatter);
        }

        [HttpGet]
        [Route("api/ConsultarUsuario/{id}")]
        public HttpResponseMessage ConsultarUsuario(int id)
        {
            Usuario usuario = objUsuario.ConsultarUsuario(id);
            return Request.CreateResponse(HttpStatusCode.OK, usuario, Configuration.Formatters.JsonFormatter);
        }

        [HttpPost]
        [Route("api/CrearUsuario")]
        public HttpResponseMessage CrearUsuario([FromBody] Usuario usuario)
        {
            bool estado = objUsuario.CrearUsuario(usuario);
            var respuesta = new { exitoso = estado, Message = estado ? "Proceso realizado con exito" : "Hubo un error en el proceso" };
            return Request.CreateResponse(HttpStatusCode.OK, respuesta, Configuration.Formatters.JsonFormatter);
        }
        [HttpPut]
        [Route("api/ActualizarUsuario")]
        public HttpResponseMessage ActualizarUsuario([FromBody] Usuario usuario)
        {
            bool estado = objUsuario.ActualizarUsuario(usuario);
            var respuesta = new { exitoso = estado, Message = estado ? "Proceso realizado con exito" : "Hubo un error en el proceso" };
            return Request.CreateResponse(HttpStatusCode.OK, respuesta, Configuration.Formatters.JsonFormatter);
        }


        [HttpDelete]
        [Route("api/EliminarUsuario")]
        public HttpResponseMessage EliminarUsuario([FromBody] DeleteUsuario deleteUsuario)
        {

            bool estado = objUsuario.EliminarUsuario(deleteUsuario.id);
            var respuesta = new { exitoso = estado, Message = estado ? "Proceso realizado con exito" : "Hubo un error en el proceso" };
            return Request.CreateResponse(HttpStatusCode.OK, respuesta, Configuration.Formatters.JsonFormatter);
        }

        public class DeleteUsuario
        {
            public int id { get; set; }
        }

    }
}
