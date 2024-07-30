using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtendimentoOnline.DTO;

namespace AtendimentoOnline.DTO
{
    public class AtendimentoDTO
    {
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public Nullable<int> IdPessoa { get; set; }
        public Nullable<int> IdEndereco { get; set; }
        public Nullable<int> IdTipoAtendimento { get; set; }
        public Nullable<int> IdStatus { get; set; }
        public Nullable<int> IdCategoria { get; set; }
        public Nullable<int> IdTipoLocalAtendimento { get; set; }
        public string Categoria { get; set; }
        public EnderecoDTO Endereco { get; set; }
        public string Pessoa { get; set; }
        public string TipoAtendimento { get; set; }
        public string Status { get; set; }
        public string TipoLocalAtendimento { get; set; }

    }
}
