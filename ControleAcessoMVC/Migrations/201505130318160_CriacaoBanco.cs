namespace ControleAcessoMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SEG_FUNCAO",
                c => new
                    {
                        CdFuncao = c.Int(nullable: false, identity: true),
                        CdFuncaoPai = c.Int(),
                        DcrFuncao = c.String(nullable: false, maxLength: 100),
                        DcrCaminho = c.String(maxLength: 255),
                        TipFuncao = c.String(nullable: false, maxLength: 1),
                        FlagBloqueado = c.String(nullable: false, maxLength: 1),
                        DataRegistro = c.DateTime(nullable: false),
                        EstadoRegistro = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.CdFuncao)
                .ForeignKey("dbo.SEG_FUNCAO", t => t.CdFuncaoPai)
                .Index(t => t.CdFuncaoPai);
            
            CreateTable(
                "dbo.SEG_PERFIL_FUNCAO",
                c => new
                    {
                        CdPerfilFuncao = c.Int(nullable: false, identity: true),
                        CdFuncao = c.Int(nullable: false),
                        CdPerfil = c.Int(nullable: false),
                        CdNivelAcesso = c.Int(nullable: false),
                        DataValidade = c.DateTime(),
                        DataRegistro = c.DateTime(nullable: false),
                        EstadoRegistro = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.CdPerfilFuncao)
                .ForeignKey("dbo.SEG_FUNCAO", t => t.CdFuncao, cascadeDelete: true)
                .ForeignKey("dbo.SEG_NIVEL_ACESSO", t => t.CdNivelAcesso, cascadeDelete: true)
                .ForeignKey("dbo.SEG_PERFIL", t => t.CdPerfil, cascadeDelete: true)
                .Index(t => t.CdFuncao)
                .Index(t => t.CdPerfil)
                .Index(t => t.CdNivelAcesso);
            
            CreateTable(
                "dbo.SEG_NIVEL_ACESSO",
                c => new
                    {
                        CdNivelAcesso = c.Int(nullable: false, identity: true),
                        DcrNivelAcesso = c.String(nullable: false, maxLength: 20),
                        DataRegistro = c.DateTime(nullable: false),
                        EstadoRegistro = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.CdNivelAcesso);
            
            CreateTable(
                "dbo.SEG_PERFIL",
                c => new
                    {
                        CdPerfil = c.Int(nullable: false, identity: true),
                        DcrPerfil = c.String(nullable: false, maxLength: 50),
                        FlagBloqueado = c.String(nullable: false, maxLength: 1),
                        DataRegistro = c.DateTime(nullable: false),
                        EstadoRegistro = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.CdPerfil);
            
            CreateTable(
                "dbo.SEG_PERFIL_USUARIO",
                c => new
                    {
                        CdPerfilUsuario = c.Int(nullable: false, identity: true),
                        CdUsuario = c.Int(nullable: false),
                        CdPerfil = c.Int(nullable: false),
                        DataRegistro = c.DateTime(nullable: false),
                        EstadoRegistro = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.CdPerfilUsuario)
                .ForeignKey("dbo.SEG_PERFIL", t => t.CdPerfil, cascadeDelete: true)
                .ForeignKey("dbo.SEG_USUARIO", t => t.CdUsuario, cascadeDelete: true)
                .Index(t => t.CdUsuario)
                .Index(t => t.CdPerfil);
            
            CreateTable(
                "dbo.SEG_USUARIO",
                c => new
                    {
                        CdUsuario = c.Int(nullable: false, identity: true),
                        DcrNomeUsuario = c.String(nullable: false, maxLength: 250),
                        DcrLogin = c.String(nullable: false, maxLength: 20),
                        DcrSenha = c.String(nullable: false, maxLength: 32),
                        DcrEmail = c.String(nullable: false, maxLength: 250),
                        DataValidade = c.DateTime(),
                        FlagBloqueado = c.String(nullable: false, maxLength: 1),
                        DataRegistro = c.DateTime(nullable: false),
                        EstadoRegistro = c.String(nullable: false, maxLength: 1),
                    })
                .PrimaryKey(t => t.CdUsuario);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SEG_PERFIL_USUARIO", "CdUsuario", "dbo.SEG_USUARIO");
            DropForeignKey("dbo.SEG_PERFIL_USUARIO", "CdPerfil", "dbo.SEG_PERFIL");
            DropForeignKey("dbo.SEG_PERFIL_FUNCAO", "CdPerfil", "dbo.SEG_PERFIL");
            DropForeignKey("dbo.SEG_PERFIL_FUNCAO", "CdNivelAcesso", "dbo.SEG_NIVEL_ACESSO");
            DropForeignKey("dbo.SEG_PERFIL_FUNCAO", "CdFuncao", "dbo.SEG_FUNCAO");
            DropForeignKey("dbo.SEG_FUNCAO", "CdFuncaoPai", "dbo.SEG_FUNCAO");
            DropIndex("dbo.SEG_PERFIL_USUARIO", new[] { "CdPerfil" });
            DropIndex("dbo.SEG_PERFIL_USUARIO", new[] { "CdUsuario" });
            DropIndex("dbo.SEG_PERFIL_FUNCAO", new[] { "CdNivelAcesso" });
            DropIndex("dbo.SEG_PERFIL_FUNCAO", new[] { "CdPerfil" });
            DropIndex("dbo.SEG_PERFIL_FUNCAO", new[] { "CdFuncao" });
            DropIndex("dbo.SEG_FUNCAO", new[] { "CdFuncaoPai" });
            DropTable("dbo.SEG_USUARIO");
            DropTable("dbo.SEG_PERFIL_USUARIO");
            DropTable("dbo.SEG_PERFIL");
            DropTable("dbo.SEG_NIVEL_ACESSO");
            DropTable("dbo.SEG_PERFIL_FUNCAO");
            DropTable("dbo.SEG_FUNCAO");
        }
    }
}
