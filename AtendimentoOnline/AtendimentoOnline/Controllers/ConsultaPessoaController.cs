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
    public class ConsultaPessoaController : BaseController
    {
        // GET: ConsultaPessoa
        public ActionResult Index()
        {
            VerificaLogado();
            PessoaDTO pessoa = new PessoaDTO();
            PessoaModel Model = new PessoaModel();
            List<PessoaDTO> list = new List<PessoaDTO>();

            var routeValues = Url.RequestContext.RouteData.Values;
            var paramName = "id";
            var id = routeValues.ContainsKey(paramName) ? routeValues[paramName] : Request.QueryString[paramName];

            int registro = Convert.ToInt32(id);

            if (id != null)
            {
                var idPessoa = registro;
                Model.ListaPessoa = Model.BuscaPessoa(idPessoa, "", "");
            }else
            {
                Model.ListaPessoa = list;
            }

            return View(Model);
        }

        public ActionResult BuscaPessoa(string documento, string nome)
        {
            VerificaLogado();
            PessoaDTO pessoa = new PessoaDTO();
            PessoaModel Model = new PessoaModel();

            Model.ListaPessoa = Model.BuscaPessoa(null, documento, nome);

            return View("Index", Model);
        }
    }
}