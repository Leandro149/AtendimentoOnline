using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AtendimentoOnline.Entidade
{
    public class TipoPessoa : BaseEntidade
    {
        [Required] 
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(50)]
        public string Codigo { get; set; }
    }
}
