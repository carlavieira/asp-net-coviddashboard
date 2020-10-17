using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PainelCovid19.Models
{
    [Table("Paises")]
    public class Pais
    {
        [Key]
        [Display(Name ="Código")]
        public int Codigo { get; set; }

        [Display(Name ="Nome")]
        public String Nome { get; set; }

    }
}
