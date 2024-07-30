using System;
using System.Linq;
using System.Web.Mvc;
using AtendimentoOnline.Utility;

namespace AtendimentoOnline.Controllers
{
    public class HomeController : BaseController     
    {
        public ActionResult Index() 
        {
            VerificaLogado();
            //Response.Redirect("ConsultaPessoa");
            return View();
        }
    }
}