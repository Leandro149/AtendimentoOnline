using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace AtendimentoOnline.Entidade
{
    public class Endereco : BaseEntidade
    {
        [Required(ErrorMessage ="O endereço é obrigatório")]
        [MaxLength(300)]
        public string Logradouro { get; set; }

        [MaxLength(20)]
        public string Numero { get; set; }

        [MaxLength(300)]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [MaxLength(8)]
        public string CEP { get; set; } 

        [Required(ErrorMessage = "O Bairro é obrigatório")]
        [MaxLength(300)]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatório")]
        [MaxLength(300)]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O UF é obrigatório")]
        [MaxLength(300)]
        public string UF { get; set; }
    }
}
