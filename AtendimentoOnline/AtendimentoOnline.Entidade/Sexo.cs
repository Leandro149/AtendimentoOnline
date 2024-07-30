using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AtendimentoOnline.Entidade
{
    public class Sexo : BaseEntidade
    {
        [Required(ErrorMessage ="O sexo é obrigatório")]
        public string Nome { get; set; }
    }
}
