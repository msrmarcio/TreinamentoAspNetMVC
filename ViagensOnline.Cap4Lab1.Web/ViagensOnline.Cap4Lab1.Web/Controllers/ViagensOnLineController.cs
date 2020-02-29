using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ViagensOnline.Cap4Lab1.Web.Controllers
{
    public class ViagensOnLineController : Controller
    {
        // GET: ViagensOnLine
        public ActionResult Inicio()
        {
            return View();
        }
    }
}