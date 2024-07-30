using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtendimentoOnline.Entidade
{
   public class Descritivo : BaseEntidade
    {
        //[Column(TypeName = "varchar(MAX)")]
        public string NomeDescritivo { get; set; }

        [ForeignKey("Atendimento")]
        public Nullable<int> IdAtendimento { get; set; }

        public Atendimento Atendimento { get; set; }
    }
}
