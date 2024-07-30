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
    public class CadastroPessoaController : BaseController
    {
        // GET: CadastroPessoa
        public ActionResult Index()
        {
            VerificaLogado();
            PessoaModel Model = new PessoaModel();
            Sexo Sexo = new Sexo();
            TipoPessoa TipoPessoa = new TipoPessoa();

            var routeValues = Url.RequestContext.RouteData.Values;
            var paramName = "id";
            var id = routeValues.ContainsKey(paramName) ? routeValues[paramName] : Request.QueryString[paramName];

            int registro = Convert.ToInt32(id);

            if (id != null)
            {
                Model = Model.ObterPessoa(registro);
                Model.ObterSexo(Model);
                Model.ObterTipoPessoa(Model);
                Model.ObterMunicio(Model);

                Model.IdSexo = Model.ObterPessoa(registro).IdSexo;
                Model.IdTipoPessoa = Model.ObterPessoa(registro).IdTipoPessoa;
                Model.TituloMunicipio = Model.ObterPessoa(registro).TituloMunicipio;
            }
            else
            {             
            Model.ObterSexo(Model);
            Model.ObterTipoPessoa(Model);
            Model.ObterMunicio(Model);
            }

            return View(Model);
        }

        [HttpPost]
        public ActionResult Salvar(Pessoa Pessoa)
        {
            VerificaLogado();
            PessoaModel PessoaGet = new PessoaModel();
            //if (ModelState.IsValid)
            //{ 
                var ValorRetorno = PessoaGet.CadastroPessoa(Pessoa);

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
            return RedirectToAction("Index", "CadastroPessoa");
        }
    }
}