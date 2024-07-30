using System;
using System.Collections.Generic;
using System.Linq;
using AtendimentoOnline.Models;
using AtendimentoOnline.Business;
using AtendimentoOnline.Entidade;

namespace AtendimentoOnline.Models
{
    public class EnderecoModel
    {
        public int id { get; set; }
        public string Logradouro { get; set; }
        public string CEP { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

    }
}