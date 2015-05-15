using ControleAcessoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ControleAcessoMVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private static UsuarioLogado userLogin;
        
        #region PROPRIEDADES GLOBAIS PARA A APLICAÇÃO
        public static string nomeUser { get { return userLogin.NomeUsuario; } }
        public static string emailUser { get { return userLogin.EmailUsuario; } }
        public static int idUser { get { return userLogin.IdUsuario; } }
        #endregion

        protected void Application_Start()
        {
            userLogin = null;

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        public void fazerLoginSistema(SegUsuario usuario)
        {
            if (userLogin == null)
                userLogin = new UsuarioLogado();

            userLogin.NomeUsuario = usuario.DcrNomeUsuario;
            userLogin.IdUsuario = usuario.CdUsuario;
            userLogin.EmailUsuario = usuario.DcrEmail;
        }

        public void fazerLogoffSistema()
        {
            userLogin = null;
        }

    }

    public class UsuarioLogado
    {
        public string NomeUsuario { get; set; }
        public int IdUsuario { get; set; }
        public string EmailUsuario { get; set; }
    }



}