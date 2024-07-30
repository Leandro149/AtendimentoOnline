using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtendimentoOnline.Entidade 
{
    public class Pessoa : BaseEntidade
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [MaxLength(50)]
        public string Documento { get; set; }

        [MaxLength(20)]
        public string Telefone { get; set; }

        [MaxLength(20)]
        public string Celular { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(600)]
        public string Descricao { get; set; }

        [ForeignKey("TipoPessoa")]
        public Nullable<int> IdTipoPessoa { get; set; }

        public DateTime DataNascimento { get; set; }

        [ForeignKey("Sexo")]
        public Nullable<int> IdSexo { get; set; }

        public TipoPessoa TipoPessoa { get; set; }

        public Sexo Sexo { get; set; }

        [ForeignKey("Endereco")]
        public Nullable<int> IdEndereco { get; set; }

        public Endereco Endereco { get; set; }

        public bool TituloMunicipio { get; set; }
    }
}
