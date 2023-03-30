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
    public class RegistoController : Controller
    {
        private ServicosEPedidos_Mod_17EContext db = new ServicosEPedidos_Mod_17EContext();

        // GET: Registo
        public ActionResult Index()
        {
            if (User.IsInRole("Cliente") || User.IsInRole("Administrador") || User.IsInRole("Prestador"))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var utilizador = new Utilizador();
                utilizador.Perfis = new[]
                {
                new  SelectListItem{Value="0", Text="Cliente"}

                };
                return View(utilizador);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Id,Nome,Email,Morada,Password,Perfil")] Utilizador utilizador)
        {
            utilizador.Perfis = new[]
 {
                new  SelectListItem{Value="0", Text="Cliente"}
            };

            if (ModelState.IsValid)
            {
                // verificar se o email já existe
                var temp = db.Utilizadors.Where(u => u.Email == utilizador.Email).ToList();
                if (temp != null && temp.Count > 0)
                {
                    ModelState.AddModelError("Email", "Já existe um utilizador com este email");
                    return View(utilizador);
                }
                // validar a password
                if (utilizador.Password.Trim().Length < 5)
                {
                    ModelState.AddModelError("Password", "A palavra-passe deve ter pelo menos 5 letras");
                }
                // hash password
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 76 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(utilizador.Password));
                utilizador.Password = Convert.ToBase64String(password);
                db.Utilizadors.Add(utilizador);
                db.SaveChanges();

                // iniciar sessao
                FormsAuthentication.SetAuthCookie(utilizador.Nome, false);
                // redirecionar utilizador
                if (Request.QueryString["ReturnUrl"] == null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(utilizador);
        }
    }
}