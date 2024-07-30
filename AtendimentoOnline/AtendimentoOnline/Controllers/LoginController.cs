using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AtendimentoOnline.Models;
using AtendimentoOnline.Utility;
using AtendimentoOnline.Entidade;
using AtendimentoOnline.DTO;
using AtendimentoOnline.DAL;


namespace AtendimentoOnline.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (UserLogged.Usuario != null)
                return RedirectToAction("Index", "Home");

            ViewBag.Mensagem = TempData["Erro"];
            var usuario = new Usuario();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Index(Usuario usuario)
        {
            using (Context dado = new Context())
            {
                dado.Database.CommandTimeout = 0;
                var result = dado.Usuarios
               .Where(u => u.Login == usuario.Login && u.Senha == usuario.Senha && (bool)u.Ativo)
               .Select(s => new { s.id, s.Ativo, s.Nome }).FirstOrDefault();

                if (result != null)
                {
                    UserLogged.Usuario = new Usuario();
                    UserLogged.Usuario.id = result.id;
                    UserLogged.Usuario.Ativo = result.Ativo;
                    UserLogged.Usuario.Nome = result.Nome;

                    UserLogged.LembrarSenha(result.Nome);

                    return RedirectToAction("Index", "Home");
                }
                else
                    TempData["mensagem"] = "error";
            }

            return View();
        }
    }
}