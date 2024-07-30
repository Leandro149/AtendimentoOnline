using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace AtendimentoOnline.Entidade
{
    public class Perfil : BaseEntidade
    {
        [Required(ErrorMessage ="O Perfil é obrigatório")]
        [MaxLength(100)]
        public string Nome { get; set; }
    }
}
