using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AtendimentoOnline.Entidade
{
    public class Status : BaseEntidade
    {   
        [Required]
        [MaxLength(100)]
        public string NomeStatus { get; set; }

        [MaxLength(1000)]
        public string Descricao { get; set; }
    }
}
