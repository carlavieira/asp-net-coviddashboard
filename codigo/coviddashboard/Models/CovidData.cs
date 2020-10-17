using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_aspnet_core.Models
{
    [Table("CovidData")]
    public class CovidData
    {
        [Key]
        [Display(Name="País")]
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }

        [Display(Name="Casos Confirmados")]
        [Required(ErrorMessage="Campo Obrigatório")]
        public int ConfirmedCases { get; set; }

        [Display(Name="Mortes")]
        [Required(ErrorMessage="Campo Obrigatório")]
        public string Deaths { get; set; }

        [Display(Name="Recuperados")]
        [Required(ErrorMessage="Campo Obrigatório")]
        public string Recovered { get; set; }
    }
}
