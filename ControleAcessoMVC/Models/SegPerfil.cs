using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleAcessoMVC.Models
{
    [Table("SEG_PERFIL")]
    public class SegPerfil
    {
        #region Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int CdPerfil { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Perfil é obrigatório!")]
        [Display(Name = "Perfil")]
        public string DcrPerfil { get; set; }

        [StringLength(1, ErrorMessage = "Informe apenas S(Sim) ou N(Não)")]
        [Required(ErrorMessage = "Flag de Bloqueio é obrigatório!")]
        [Display(Name = "Bloqueado?")]
        public string FlagBloqueado { get; set; }

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

        //ICollection
        //DEFINE QUE:     SegPerfil   1..*   SegPerfilUsuario        

        public virtual ICollection<SegPerfilUsuario> FkSegPerfilPerfilUsuario { get; set; }

        public virtual ICollection<SegPerfilFuncao> FkSegPerfilPerfilFuncao { get; set; }
        #endregion
    }
}