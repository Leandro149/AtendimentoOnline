using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtendimentoOnline.Entidade
{
   public class BaseEntidade
    {
        [Key]
        public int id { get; set; }

        [Required]
        public DateTime DataCadastro { get; set; }

        public DateTime DataAlteracao { get; set; }

        [Required]
        public int idUsuarioCadastro { get; set; }
        public int idUsuarioAlteracao { get; set; }

        [Required]
        public bool Ativo { get; set; }

    }
}
