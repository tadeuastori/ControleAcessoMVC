using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleAcessoMVC.Models
{
    [Table("SEG_NIVEL_ACESSO")]
    public class SegNivelAcesso
    {
        #region Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int CdNivelAcesso { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Nível de acesso é obrigatório!")]
        [Display(Name = "Nome do Usuário")]
        public string DcrNivelAcesso { get; set; }

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
        //DEFINE QUE:     SegNivelAcesso   1..*   SegPerfilFuncao        

        public virtual ICollection<SegPerfilFuncao> FkSegNivelAcessoPerfilFuncao { get; set; }
        #endregion
    }
}