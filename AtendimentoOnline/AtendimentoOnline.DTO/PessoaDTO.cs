using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtendimentoOnline.DTO;

namespace AtendimentoOnline.DTO
{
    public class PessoaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Documento { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string Descricao { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public int IdSexo { get; set; }

        public int IdTipoPessoa { get; set; }

        public string TipoPessoa { get; set; }

        public DateTime DataNascimento { get; set; }      
        
        public EnderecoDTO Endereco { get; set; }

        public string Sexo { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string CEP { get; set; }

        public string UF { get; set; }

        public string Logradouro { get; set; }

        public int TituloMunicipio { get; set; }

    }
}
