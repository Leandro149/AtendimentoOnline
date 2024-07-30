using System;
using System.Collections.Generic;
using System.Linq;
using AtendimentoOnline.Models;
using AtendimentoOnline.Business;
using AtendimentoOnline.Entidade;
using AtendimentoOnline.DTO;
using System.Web.Mvc;
using AutoMapper;

namespace AtendimentoOnline.Models
{
    public class PessoaModel
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string DataNascimento { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public string Descricao { get; set; }
        public  EnderecoModel Endereco { get; set; }
        public int IdTipoPessoa { get; set; }
        public int IdSexo { get; set; }

        public bool TituloMunicipio { get; set; }

        public SelectList ListaSexoCombo { get; set; } = new SelectList(new List<Sexo>());

        public SelectList ListaTipoPessoaCombo { get; set; } = new SelectList(new List<TipoPessoa>());

        public SelectList ListaMunicipioTitulo { get; set; } = new SelectList(new List<Municipio>());

        public List<PessoaDTO> ListaPessoa { get; set; } 

        public int CadastroPessoa(Pessoa Pessoa)
        {

            CadadastroPessoaBusiness PessoaBusiness = new CadadastroPessoaBusiness();
            var retorno = PessoaBusiness.CadastroPessoa(Pessoa);

            return retorno;
        }

        public void ObterSexo(PessoaModel PessoaM)
        {
            CadadastroPessoaBusiness PessoaSexoBusiness = new CadadastroPessoaBusiness();

            var retorno = PessoaSexoBusiness.ObterSexo();

            PessoaM.ListaSexoCombo = new SelectList(retorno, "id", "Nome");            
        }

        public void ObterTipoPessoa(PessoaModel PessoaM)
        {
            CadadastroPessoaBusiness TipoPessoaBusiness = new CadadastroPessoaBusiness();

            var retorno = TipoPessoaBusiness.ObterTipoPessoa();

            PessoaM.ListaTipoPessoaCombo = new SelectList(retorno, "id", "Nome");
        }

        public List<PessoaDTO> BuscaPessoa(int? idPessoa, string documento, string nome)
        {
            ConsultaPessoaBusiness ConsPessoaBusiness = new ConsultaPessoaBusiness();

            var retorno = ConsPessoaBusiness.BuscaPessoa(idPessoa, documento, nome);

            return retorno;
        }

        public PessoaModel ObterPessoa(int idPessoa)
        {
            ConsultaPessoaBusiness ConsPessoaBusiness = new ConsultaPessoaBusiness();

            var retorno = ConsPessoaBusiness.ObterPessoa(idPessoa);

            var mapeado = Mapper.DynamicMap<PessoaModel>(retorno);

            return mapeado;
        }

        public void ObterMunicio(PessoaModel PessoaM)
        {
            CadadastroPessoaBusiness pessoaMunicipioBusiness = new CadadastroPessoaBusiness();

            var retorno = pessoaMunicipioBusiness.ObterMunicipio();

            PessoaM.ListaMunicipioTitulo = new SelectList(retorno, "id", "Nome");
        }

    }

}