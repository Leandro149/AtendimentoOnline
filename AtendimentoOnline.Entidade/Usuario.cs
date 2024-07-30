using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace AtendimentoOnline.Entidade
{
    public class Usuario : BaseEntidade
    {
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(100)]
        public string Nome { get; set; }
        
        [Required(ErrorMessage ="O login é obrigatório")]
        [MaxLength(30)]
        public string Login { get; set; }

        [Required(ErrorMessage = "A Senha é obrigatório")]
        [MaxLength(30)]
        public string Senha { get; set; }
        
        [ForeignKey("Perfil")]
        public Nullable<int> IdPerfil { get; set; }

        public Perfil Perfil { get; set; }
    }
}
