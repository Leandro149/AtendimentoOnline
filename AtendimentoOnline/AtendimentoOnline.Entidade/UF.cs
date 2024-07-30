using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AtendimentoOnline.Entidade
{
    public class UF 
    {

        [Key]
        public int id { get; set; }

        [Required]
        [MaxLength(5)]
        public string Codigo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }
    }
}
