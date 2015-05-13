using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleAcessoMVC.Models
{
    [Table("SEG_PERFIL_FUNCAO")]
    public class SegPerfilFuncao
    {
        #region Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int CdPerfilFuncao { get; set; }

        [Required(ErrorMessage = "Função é obrigatório!")]
        [Display(Name = "Função")]
        public int CdFuncao { get; set; }

        [Required(ErrorMessage = "Perfil é obrigatório!")]
        [Display(Name = "Perfil")]
        public int CdPerfil { get; set; }

        [Required(ErrorMessage = "Nível de acesso é obrigatório!")]
        [Display(Name = "Nível de Acesso")]
        public int CdNivelAcesso { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Validade do acesso")]
        public DateTime? DataValidade { get; set; }

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
        public virtual SegPerfil FkPerfilFuncaoPerfil { get; set; }

        [ForeignKey("CdNivelAcesso")]
        public virtual SegNivelAcesso FkPerfilFuncaoNivelAcesso { get; set; } 

        [ForeignKey("CdFuncao")]
        public virtual SegFuncao FkPerfilFuncaoFuncao { get; set; }
        #endregion        
    }
}