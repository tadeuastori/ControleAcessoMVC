using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleAcessoMVC.Controllers
{
    public class ModuloController : Controller
    {
        //
        // GET: /Modulo/

        public ActionResult Inicio()
        {

            ViewBag.NomeUsuario = MvcApplication.nomeUser;

            return View();
        }

    }
}
