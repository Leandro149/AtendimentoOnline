using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtendimentoOnline.Entidade
{
    public class Categoria : BaseEntidade
    {
        [StringLength(100)]
        [Required(ErrorMessage = "A Categoaria é obrigatório")]
        [MaxLength(100)]
        public string NomeCategoria { get; set; }

        [StringLength(1000)]
        public string Descricao { get; set; }
    }
}
