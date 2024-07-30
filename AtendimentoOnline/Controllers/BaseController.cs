using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AtendimentoOnline.Utility;

namespace AtendimentoOnline.Controllers
{

    [Authorization]
    public class BaseController : Controller
    {


        public void VerificaLogado()
        {
            if (UserLogged.Usuario == null)
                Response.Redirect("/Login");
        }

    //    GET: Base
        [AllowAnonymous]
        protected override void OnException(ExceptionContext exceptionContext)
        {
            //LogUtility.LogError(exceptionContext.Exception);
            Response.Redirect("/Login");
        }

    public ActionResult Sair()
        {
            UserLogged.Remove();
            return RedirectToAction("Index", "Login");
        }      
    }
}