using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtendimentoOnline.Entidade
{
    public class TipoLocalAtendimento : BaseEntidade
    {
        [Required]
        [MaxLength(100)]
        public string NomeTipoLocalAtendimento { get; set; }

        [MaxLength(1000)]
        public string Descricao { get; set; }
    }
}
