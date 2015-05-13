using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleAcessoMVC.Models
{
    [Table("SEG_USUARIO")]
    public class SegUsuario
    {
        #region Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int CdUsuario { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Nome do usuário é obrigatório!")]
        [Display(Name = "Nome do Usuário")]
        public string DcrNomeUsuario { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Login é obrigatório!")]
        [Display(Name = "Login")]
        public string DcrLogin { get; set; }

        [StringLength(32)]
        [Required(ErrorMessage = "Senha é obrigatório!")]
        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        public string DcrSenha { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "E-Mail é obrigatório!")]
        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string DcrEmail { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Validade da Conta")]
        public DateTime? DataValidade { get; set; }

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
        //DEFINE QUE:     SegUsuario   1..*   SegPerfilUsuario        

        public virtual ICollection<SegPerfilUsuario> FkSegUsuarioPerfilUsuario { get; set; }
        #endregion
    }
}