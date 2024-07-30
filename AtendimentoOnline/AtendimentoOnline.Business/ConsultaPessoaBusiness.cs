using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AtendimentoOnline.DAL;
using AtendimentoOnline.Entidade;
using AtendimentoOnline.DTO;
using AutoMapper;

namespace AtendimentoOnline.Business
{
    public class ConsultaPessoaBusiness
    {
        public List<PessoaDTO> BuscaPessoa(int? idPessoa, string documento, string nome)
        {
            ConsultaPessoaDAL ConsultaPessoaDal = new ConsultaPessoaDAL();
            var retorno = ConsultaPessoaDal.BuscaPessoa(idPessoa, documento, nome);
            return retorno;
        }

        public PessoaDTO ObterPessoa(int idPessoa)
        {
            var pessoaRetorno = new PessoaDTO();
            ConsultaPessoaDAL ConsultaPessoaDal = new ConsultaPessoaDAL();
            var retorno = ConsultaPessoaDal.ObterPessoa(idPessoa);
            pessoaRetorno = Mapper.DynamicMap<PessoaDTO>(retorno);
            return pessoaRetorno;
        }
    }
}
