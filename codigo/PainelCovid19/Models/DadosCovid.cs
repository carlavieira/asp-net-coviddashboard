using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PainelCovid19.Models
{
    [Table("DadosCovid")]
    public class DadosCovid
    {
        [Key]
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Display(Name = "Casos confirmados")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int CasosConfirmados { get; set; }

        [Display(Name = "Mortes")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Mortes { get; set; }

        [Display(Name = "Recuperados")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int Recuperados { get; set; }

        [Display(Name = "Pais")]
        [Required(ErrorMessage ="Campo obrigatório")]
        public int PaisId { get; set; }

        [ForeignKey("PaisId")]
        public Pais Pais { get; set; }

    }
}
