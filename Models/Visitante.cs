using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Santi.Models
{
    public class Visitante
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O CPF é obrigatorio")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "O Telefone é obrigatorio")]
        public string Telefone { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime DataVisita { get; set; }
        [Required]
        public bool VisitanteAtivo { get; set; }
    }
}