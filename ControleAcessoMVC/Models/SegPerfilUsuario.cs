using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleAcessoMVC.Models
{
    [Table("SEG_PERFIL_USUARIO")]
    public class SegPerfilUsuario
    {
        #region Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int CdPerfilUsuario { get; set; }

        [Required(ErrorMessage = "Usuário é obrigatório!")]
        [Display(Name = "Usuário")]
        public int CdUsuario { get; set; }

        [Required(ErrorMessage = "Perfil é obrigatório!")]
        [Display(Name = "Perfil")]
        public int CdPerfil { get; set; }

        [Required(ErrorMessage = "Data do registro é obrigatório!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "Registro")]
        public DateTime DataRegistro { get; set; }

        [StringLength(1, ErrorMessage = "Informe apenas A(Ativo) ou H(Histórico)")]
        [Required(ErrorMessage = "Estado do registro é obrigatório!")]
        [Display(Name = "Status")]
        public string EstadoRegistro { get; set; } 
        #endregion

        #region Relacionamentos
        [ForeignKey("CdPerfil")]
        public virtual SegPerfil FkPerfilUsuarioPerfil { get; set; }

        [ForeignKey("CdUsuario")]
        public virtual SegUsuario FkPerfilUsuarioUsuario { get; set; }
        #endregion
    }
}