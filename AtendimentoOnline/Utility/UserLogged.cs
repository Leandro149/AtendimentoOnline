using System;
using System.Web;
using System.Web.Security;
using AtendimentoOnline.Entidade;

namespace AtendimentoOnline.Utility
{
    public class UserLogged
    {
        public static Usuario Usuario
        {
            get
            {
                if (HttpContext.Current.Session["UserLogged"] == null)
                    return null;

                return HttpContext.Current.Session["UserLogged"] as Usuario;
            }
            set
            {
                HttpContext.Current.Session["UserLogged"] = value;
            }
        }

        public static void Remove()
        {
            HttpContext.Current.Session.RemoveAll();
        }

        public static void LembrarSenha(string usuario)
        {
            //create the authentication ticket
            var authTicket = new FormsAuthenticationTicket(
              1,
              usuario,                       //user id
              DateTime.Now,
              DateTime.Now.AddMinutes(60),  // expiry
              true,                         //true to remember
              "",                           //roles 
              "/"
            );

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));

        }
    }
}