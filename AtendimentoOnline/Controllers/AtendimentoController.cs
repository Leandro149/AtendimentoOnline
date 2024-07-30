using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AtendimentoOnline.Models;
using AtendimentoOnline.Entidade;
using AtendimentoOnline.DTO;
using AtendimentoOnline.Utility;


namespace AtendimentoOnline.Controllers
{
    public class AtendimentoController : BaseController
    {
        public ActionResult Index()
        {
            VerificaLogado();

            AtendimentoDTO atendimento = new AtendimentoDTO();
            AtendimentoModel Model = new AtendimentoModel();
            List<AtendimentoDTO> list = new List<AtendimentoDTO>();

            var routeValues = Url.RequestContext.RouteData.Values;
            var paramName = "id";
            var id = routeValues.ContainsKey(paramName) ? routeValues[paramName] : Request.QueryString[paramName];

            int registro = Convert.ToInt32(id);

            if (id != null)
            {
                int idAtendimento = registro;
                Model.ListaAtendimento = Model.BuscaAtendimento(idAtendimento, null, "");
            }
            else
            {
                Model.ListaAtendimento = list;
            }

            return View(Model);
        }

        

        public ActionResult BuscaAtendimento(int? Codigo, string nome)
        {
            VerificaLogado();
            AtendimentoDTO atendimento = new AtendimentoDTO();
            AtendimentoModel Model = new AtendimentoModel();

            Model.ListaAtendimento = Model.BuscaAtendimento(null, Codigo, nome);

            return View("Index", Model);
        }

        public ActionResult IncluirAtendimento()
        {
            VerificaLogado();
            AtendimentoModel Model = new AtendimentoModel();

            var routeValues = Url.RequestContext.RouteData.Values;
            var paramName = "IdPessoa";
            var IdPessoa = routeValues.ContainsKey(paramName) ? routeValues[paramName] : Request.QueryString[paramName];

            int registro = Convert.ToInt32(IdPessoa);

            if (TempData["Mensagem"] == "sucesso" || TempData["Mensagem"] == "error")
            {
                Model.ObterCategoria(Model);
                Model.ObterTipoAtendimento(Model);
                Model.ObterStatus(Model);
            }
            else if(IdPessoa != null)
            {
                Model = Model.ObterEndereco(registro);
                Model.ObterCategoria(Model);
                Model.ObterTipoAtendimento(Model);
                Model.ObterStatus(Model);
                Model.IdPessoa = registro;
                Model.Descricao = string.Empty;

                Model.IdStatus = (int)Enum.EnumStatus.Aberto;
            }
            else
            {
                return RedirectToAction("Index", "ConsultaPessoa");
            }

            return View(Model);
        }

        public ActionResult AlterarAtendimento()
        {
            VerificaLogado();
            AtendimentoModel Model = new AtendimentoModel();

            var routeValues = Url.RequestContext.RouteData.Values;
            var paramName = "id";
            var id = routeValues.ContainsKey(paramName) ? routeValues[paramName] : Request.QueryString[paramName];

            int registro = Convert.ToInt32(id);

            if (TempData["Mensagem"] == "sucesso" || TempData["Mensagem"] == "error")
            {
                Model.ListaDescritivo = Model.ObterDescritivo(registro);
                Model.ObterCategoria(Model);
                Model.ObterTipoAtendimento(Model);
                Model.ObterStatus(Model);

                Model.IdCategoria = Model.ObterAtendimento(registro).IdCategoria;
                Model.IdTipoAtendimento = Model.ObterAtendimento(registro).IdTipoAtendimento;
                Model.IdStatus = Model.ObterAtendimento(registro).IdStatus;
                Model.Descricao = string.Empty;
            }
            else if(id != null)
            {
                Model = Model.ObterAtendimento(registro);
                Model.ListaDescritivo = Model.ObterDescritivo(registro);
                Model.ObterCategoria(Model);
                Model.ObterTipoAtendimento(Model);
                Model.ObterStatus(Model);

                Model.IdCategoria = Model.ObterAtendimento(registro).IdCategoria;
                Model.IdTipoAtendimento = Model.ObterAtendimento(registro).IdTipoAtendimento;
                Model.IdStatus = Model.ObterAtendimento(registro).IdStatus;
                Model.Descricao = string.Empty;
            }
            else
            {
                return RedirectToAction("Index", "Atendimento");
            }

            return View(Model);
        }

        public ActionResult Salvar(Atendimento atendimento)
        {
            VerificaLogado();
            AtendimentoModel atendimentoGet = new AtendimentoModel();
            //if (ModelState.IsValid)
            //{ 
            var ValorRetorno = atendimentoGet.IncluirAtendimento(atendimento);

            if (ValorRetorno > 0)
            {
                TempData["Mensagem"] = "sucesso";
                TempData["retorno"] = ValorRetorno;
            }
            else
            {
                TempData["Mensagem"] = "error";
            }

            //}
            return RedirectToAction("IncluirAtendimento", "Atendimento");
        }

        public PartialViewResult PartialDescritivo(string descricao, string idAtendimento)
        {
            VerificaLogado();
            AtendimentoModel  model = new AtendimentoModel();

            model.IncluirDescritivo(descricao, int.Parse(idAtendimento));

            model.ListaDescritivo = model.ObterDescritivo(int.Parse(idAtendimento));


            return PartialView(model);
        }

    }
}