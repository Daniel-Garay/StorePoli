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
    public class ProductosRestController : ApiController
    {
        Producto objProducto = new Producto();

        [HttpGet]
        [Route("api/ConsultarProductos")]
        public HttpResponseMessage ConsultarProductos()
        {
            List<Producto> productos= new List<Producto>();
            productos = objProducto.ConsultarProductos();
            return Request.CreateResponse(HttpStatusCode.OK, productos, Configuration.Formatters.JsonFormatter);
        }

        [HttpGet]
        [Route("api/ConsultarProducto/{id}")]
        public HttpResponseMessage ConsultarProducto(int id)
        {
            Producto producto = objProducto.ConsultarProducto(id);
            return Request.CreateResponse(HttpStatusCode.OK, producto, Configuration.Formatters.JsonFormatter);
        }

        [HttpPost]
        [Route("api/CrearProducto")]
        public HttpResponseMessage CrearProducto([FromBody] Producto producto)
        {
            bool estado = objProducto.CrearProducto(producto);
            var respuesta2 = new { exitoso = estado, Message = estado ? "Proceso realizado con exito" : "Hubo un error en el proceso" };
            return Request.CreateResponse(HttpStatusCode.OK, respuesta2, Configuration.Formatters.JsonFormatter);
        }

        [HttpPut]
        [Route("api/ActualizarProducto")]
        public HttpResponseMessage ActualizarProducto([FromBody] Producto producto)
        {
            bool estado = objProducto.ActualizarProducto(producto);
            var respuesta = new { exitoso = estado, Message = estado ? "Proceso realizado con exito" : "Hubo un error en el proceso" };
            return Request.CreateResponse(HttpStatusCode.OK, respuesta, Configuration.Formatters.JsonFormatter);
        }


        [HttpDelete]
        [Route("api/EliminarProducto")]
        public HttpResponseMessage EliminarProducto([FromBody] DeleteProducto deleteProducto)
        {

            bool estado = objProducto.EliminarProducto(deleteProducto.id);
            var respuesta = new { exitoso = estado, Message = estado ? "Proceso realizado con exito" : "Hubo un error en el proceso" };
            return Request.CreateResponse(HttpStatusCode.OK, respuesta, Configuration.Formatters.JsonFormatter);
        }

        public class DeleteProducto
        {
            public int id { get; set; }
        }

    }


}
