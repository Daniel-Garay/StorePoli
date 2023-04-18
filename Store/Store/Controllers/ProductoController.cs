using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Productos
        public ActionResult Crear()
        {
            return View();
        }

        public ActionResult Listado()
        {
            return View();
        }

    }
}
