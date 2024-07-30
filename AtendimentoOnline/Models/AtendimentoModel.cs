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
    public class AtendimentoModel
    {

        public int Id { get; set; }
        public string Codigo { get; set; }

        public string Descricao { get; set; }

        public int IdPessoa { get; set; }

        public int IdEndereco { get; set; }

        public int IdTipoAtendimento { get; set; }

        public int IdStatus { get; set; }

        public int IdCategoria { get; set; }

        public EnderecoModel Endereco { get; set; }

        public List<AtendimentoDTO> ListaAtendimento { get; set; }

        public List<DescritivoDTO> ListaDescritivo { get; set; }

        public SelectList ListaCategoria { get; set; } = new SelectList(new List<Categoria>());

        public SelectList ListaTipoAtendimento { get; set; } = new SelectList(new List<TipoAtendimento>());

        public SelectList ListaStatus { get; set; } = new SelectList(new List<Status>());

        public List<AtendimentoDTO> BuscaAtendimento(int? idAtendimento, int? numAtendimento, string nome)
        {
            AtendimentoBusiness ConsAtendimentoBusiness = new AtendimentoBusiness();

            var retorno = ConsAtendimentoBusiness.BuscaAtendimento(idAtendimento, numAtendimento, nome);

            return retorno;
        }

        public void ObterCategoria(AtendimentoModel atendimentoM)
        {
            AtendimentoBusiness atendimentoCategoriaBusiness = new AtendimentoBusiness();

            var retorno = atendimentoCategoriaBusiness.ObterCategoria();

            atendimentoM.ListaCategoria = new SelectList(retorno, "id", "NomeCategoria");
        }

        public void ObterTipoAtendimento(AtendimentoModel atendimentoM)
        {
            AtendimentoBusiness atendimentoTipoAtendimentoBusiness = new AtendimentoBusiness();

            var retorno = atendimentoTipoAtendimentoBusiness.ObterTipoAtendimento();

            atendimentoM.ListaTipoAtendimento = new SelectList(retorno, "id", "NomeTipoAtendimento");
        }

        public void ObterStatus(AtendimentoModel atendimentoM)
        {
            AtendimentoBusiness atendimentoStatusBusiness = new AtendimentoBusiness();

            var retorno = atendimentoStatusBusiness.ObterStatus();

            atendimentoM.ListaStatus = new SelectList(retorno, "id", "NomeStatus");
        }

        public int IncluirAtendimento(Atendimento atendimento)
        {

            AtendimentoBusiness atendimentoBusiness = new AtendimentoBusiness();
            var retorno = atendimentoBusiness.IncluirAtendimento(atendimento);

            return retorno;
        }

        public AtendimentoModel ObterEndereco(int idPessoa)
        {
            ConsultaPessoaBusiness ConsPessoaBusiness = new ConsultaPessoaBusiness();

            var retorno = ConsPessoaBusiness.ObterPessoa(idPessoa);

            var mapeado = Mapper.DynamicMap<AtendimentoModel>(retorno);

            return mapeado;
        }

        public List<DescritivoDTO> ObterDescritivo(int idAtendimento)
        {
            AtendimentoBusiness atendBusiness = new AtendimentoBusiness();

            var lista = atendBusiness.ObterDescritivo(idAtendimento);
            return lista.Select(Mapper.DynamicMap<DescritivoDTO>).ToList();
        }

        public AtendimentoModel ObterAtendimento(int idAtendimento)
        {
            AtendimentoBusiness atendimentoBusiness = new AtendimentoBusiness();

            var retorno = atendimentoBusiness.ObterAtendimento(idAtendimento);

            var mapeado = Mapper.DynamicMap<AtendimentoModel>(retorno);

            return mapeado;
        }

        public int IncluirDescritivo(string descricao, int idAtendimento)
        {
            AtendimentoBusiness atendBusiness = new AtendimentoBusiness();

            var retorno = atendBusiness.IncluirDescritivo(descricao, idAtendimento);

            return retorno;

        }

    }
}
