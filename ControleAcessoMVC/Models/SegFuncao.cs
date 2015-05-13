using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleAcessoMVC.Models
{
    [Table("SEG_FUNCAO")]
    public class SegFuncao
    {
        #region Propriedades
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int CdFuncao { get; set; }

        [Display(Name = "Função Pai")]
        public int? CdFuncaoPai { get; set; }

        [StringLength(100)]
        [Required(ErrorMessage = "Função é obrigatório!")]
        [Display(Name = "Função")]
        [DataType(DataType.Text)]
        public string DcrFuncao { get; set; }

        [StringLength(255)]
        [Display(Name = "Caminho")]
        [DataType(DataType.Text)]
        public string DcrCaminho { get; set; }

        [StringLength(1, ErrorMessage = "Informe apenas M(Menu) ou T(Tela)")]
        [Required(ErrorMessage = "Tipo do menu é obrigatório!")]
        [Display(Name = "Tipo da função")]
        public string TipFuncao { get; set; }
        
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
        //DEFINE QUE:     SegFuncao   1..*   SegPerfilFuncao        

        public virtual ICollection<SegPerfilFuncao> FkSegFuncaoPerfilFuncao { get; set; }

        public virtual ICollection<SegFuncao> FkSegFuncaoFuncaoPai { get; set; }

        [ForeignKey("CdFuncaoPai")]
        public virtual SegFuncao FkSegFuncaoPaiFuncao { get; set; }
        #endregion
    }
}