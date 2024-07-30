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
   public class AtendimentoBusiness
    {
        public List<AtendimentoDTO> BuscaAtendimento(int? idAtendimento, int? numAtendimento, string nome)
        {
            AtendimentoDAL ConsultaAtendimentoDal = new AtendimentoDAL();
            var retorno = ConsultaAtendimentoDal.BuscaAtendimento(idAtendimento, numAtendimento, nome);
            return retorno;
        }

        public List<Categoria> ObterCategoria()
        {
            CategoriaDAL categoriaDal = new CategoriaDAL();
            var retorno = categoriaDal.ObterCategoria();
            return retorno;
        }

        public List<TipoAtendimento> ObterTipoAtendimento()
        {
            TipoAtendimentoDAL tipoAtendimentoDal = new TipoAtendimentoDAL();
            var retorno = tipoAtendimentoDal.ObterTipoAtendimento();
            return retorno;
        }

        public List<Status> ObterStatus()
        {
            StatusDAL statusDal = new StatusDAL();
            var retorno = statusDal.ObterStatus();
            return retorno;
        }

        public int IncluirAtendimento(Atendimento atendimento)
        {
            AtendimentoDAL atendimentoDal = new AtendimentoDAL();

            var retorno = 0;
            retorno = atendimentoDal.IncluirAtendimento(atendimento);

            return retorno;
        }

        public List<Descritivo> ObterDescritivo(int idAtendimento)
        {
            AtendimentoDAL atendimentoDal = new AtendimentoDAL();
            return atendimentoDal.ObterDescritivo(idAtendimento);            
        }

        public AtendimentoDTO ObterAtendimento(int idAtendimento)
        {
            var atendimentoRetorno = new AtendimentoDTO();
            AtendimentoDAL atendimentoDal = new AtendimentoDAL();
            var retorno = atendimentoDal.ObterAtendimento(idAtendimento);
            atendimentoRetorno = Mapper.DynamicMap<AtendimentoDTO>(retorno);
            return atendimentoRetorno;
        }

        public int IncluirDescritivo(string descricao, int idAtendimento)
        {
            AtendimentoDAL atendDAL = new AtendimentoDAL();

            var retorno = atendDAL.IncluirDescritivo(descricao, idAtendimento);

            return retorno;

        }
    }
}
