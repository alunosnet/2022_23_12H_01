using ServicosEPedidos_Mod_17E.Data;
using ServicosEPedidos_Mod_17E.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ServicosEPedidos_Mod_17E.Controllers
{

    public class LoginController : Controller
    {
        private ServicosEPedidos_Mod_17EContext db = new ServicosEPedidos_Mod_17EContext();

        // GET: Login
        public ActionResult Index()
        {
            if (User.IsInRole("Cliente") || User.IsInRole("Administrador") || User.IsInRole("Prestador"))
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {

                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Utilizador utilizador)
        {
            if (utilizador.Nome != null && utilizador.Password != null)
            {
                // hash password
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 76 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(utilizador.Password));
                utilizador.Password = Convert.ToBase64String(password);
                foreach (var u in db.Utilizadors.ToList())
                {
                    if (u.Nome.ToLower() == utilizador.Nome.ToLower() && u.Password == utilizador.Password)
                    {
                        // iniciar sessao
                        FormsAuthentication.SetAuthCookie(utilizador.Nome, false);
                        // redirecionar utilizador
                        if (Request.QueryString["ReturnUrl"] == null)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return Redirect(Request.QueryString["ReturnUrl"].ToString());
                        }
                    }
                }
            }
            ModelState.AddModelError("", "Login falhou. Tente novamente.");
            return View(utilizador);
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }
    }
}