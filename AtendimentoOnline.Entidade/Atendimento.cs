using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtendimentoOnline.Entidade
{
    public class Atendimento : BaseEntidade
    {
        [Index("IX_Codigo", 1, IsUnique = true)]
        public int Codigo { get; set; }

        public string Descricao { get; set; }

        [ForeignKey("Pessoa")]
        public Nullable<int> IdPessoa { get; set; }

        [ForeignKey("Endereco")]
        public Nullable<int> IdEndereco { get; set; }

        [ForeignKey("TipoAtendimento")]
        public Nullable<int> IdTipoAtendimento { get; set; }

        [ForeignKey("Status")]
        public Nullable<int> IdStatus { get; set; }

        [ForeignKey("Categoria")]
        public Nullable<int> IdCategoria { get; set; }

        [ForeignKey("TipoLocalAtendimento")]
        public Nullable<int> IdTipoLocalAtendimento { get; set; }

        public Categoria Categoria { get; set; }
        public Endereco Endereco { get; set; }
        public Pessoa Pessoa { get; set; }
        public TipoAtendimento TipoAtendimento { get; set; }
        public Status Status { get; set; }
        public TipoLocalAtendimento TipoLocalAtendimento { get; set; }

    }
}
