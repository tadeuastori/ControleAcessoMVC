using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ControleAcessoMVC.Models
{
    public class DataAccessController : DbContext
    {
        public DataAccessController()
            : base("dbSigos")
        {
            Database.Connection.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["dbSigos"].ToString(); ;
        }

        public DbSet<SegUsuario> SegUsuario { get; set; }
        public DbSet<SegPerfilUsuario> SegPerfilUsuario { get; set; }
        public DbSet<SegPerfilFuncao> SegPerfilFuncao { get; set; }
        public DbSet<SegPerfil> SegPerfil { get; set; }
        public DbSet<SegNivelAcesso> SegNivelAcesso { get; set; }
        public DbSet<SegFuncao> SegFuncao { get; set; }



    }
}