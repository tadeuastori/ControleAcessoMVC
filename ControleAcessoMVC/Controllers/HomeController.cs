using ControleAcessoMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ControleAcessoMVC.Controllers
{
    public class HomeController : Controller
    {
        #region VIEW
        public ActionResult Index()
        {
            new MvcApplication().fazerLogoffSistema();

            return View();
        }




        #endregion


        public bool efetuarLogin(string txtUsuario, string txtSenha)
        {
            System.Threading.Thread.Sleep(2000);

            SegUsuario result;

            using (DataAccessController dac = new DataAccessController())
            {
                try
                {
                    result = dac.SegUsuario.Where(x => x.DcrLogin == txtUsuario && x.DcrSenha == txtSenha).FirstOrDefault();

                    if (result != null)
                    {
                        new MvcApplication().fazerLoginSistema(result);
                    }

                }
                catch (Exception)
                {
                    result = null;
                }
            }

            return (result != null);
        }

    }
}
