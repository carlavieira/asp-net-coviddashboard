using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace app_aspnet_core.Models
{
    [Table("Countries")]
    public class Country
    {
        [Key]
        [Display(Name="Código")]
        public int Id { get; set; }

        [Display(Name="Nome")]
        [Required(ErrorMessage="Campo Obrigatório")]
        public string Name { get; set; }
    }
}
