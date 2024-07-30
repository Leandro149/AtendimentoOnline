using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AtendimentoOnline.Utility
{
    public class Authorization : AuthorizeAttribute
    {
        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    if (string.IsNullOrEmpty(System.Web.HttpContext.Current.User.Identity.Name))
        //    {
        //        // A sessão está nula ou vazia, não existe usuário logado.
        //        filterContext.Result = new RedirectToRouteResult(
        //        new RouteValueDictionary(
        //            new
        //            {
        //                controller = "Login",
        //                action = "Index"
        //            })
        //        );
        //    }
        //}

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return UserLogged.Usuario != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectResult("/Login");
        }
    }
}