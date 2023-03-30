using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ServicosEPedidos_Mod_17E.Data;
using ServicosEPedidos_Mod_17E.Models;

namespace ServicosEPedidos_Mod_17E.Controllers
{
    public class UtilizadoresController : Controller
    {
        private ServicosEPedidos_Mod_17EContext db = new ServicosEPedidos_Mod_17EContext();

        // GET: Utilizadores
        public ActionResult Index()
        {
            return View(db.Utilizadors.ToList());
        }

        // GET: Utilizadores/Details/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Utilizadores/Create
        public ActionResult Create()
        {
            var utilizador = new Utilizador();
            utilizador.Perfis = new[]
            {
                new  SelectListItem{Value="0", Text="Cliente"},
                new  SelectListItem{Value="1", Text="Administrador"},
                new  SelectListItem{Value="2", Text="Prestador"}

            };
            return View(utilizador);
        }

        [Authorize(Roles = "Administrador")]
        // POST: Utilizadores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Email,Morada,Password,Perfil")] Utilizador utilizador)
        {
            utilizador.Perfis = new[]
{
                new  SelectListItem{Value="0", Text="Cliente"},
                new  SelectListItem{Value="1", Text="Administrador"},
                new  SelectListItem{Value="2", Text="Prestador"}
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
                return RedirectToAction("Index");
            }

            return View(utilizador);
        }

        // GET: Utilizadores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            // se nao é admin so pode editar a sua propria conta
            if (User.IsInRole("Administrador"))
            {
                utilizador.Perfis = new[]
                {
                new  SelectListItem{Value="1", Text="Administrador"}
                };
            }
            else if (User.IsInRole("Prestador"))
            {
                var temp = db.Utilizadors.Where(u => u.Nome == User.Identity.Name).FirstOrDefault();
                utilizador = temp;
                utilizador.Perfis = new[]
                {
                new  SelectListItem{Value="2", Text="Prestador"}
                };
            }
            else if (User.IsInRole("Cliente"))
            {
                var temp = db.Utilizadors.Where(u => u.Nome == User.Identity.Name).FirstOrDefault();
                utilizador = temp;
                utilizador.Perfis = new[]
                {
                new  SelectListItem{Value="0", Text="Cliente"}
                };
            }
            return View(utilizador);
        }

        // POST: Utilizadores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Email,Morada,Password,Perfil")] Utilizador utilizador)
        {
            utilizador.Perfis = new[]
{
                new  SelectListItem{Value="0", Text="Cliente"},
                new  SelectListItem{Value="1", Text="Administrador"},
                new  SelectListItem{Value="2", Text="Prestador"}
            };
            if (ModelState.IsValid)
            {
                // validar a password
                if (utilizador.Password.Trim().Length < 5)
                {
                 ModelState.AddModelError("Password", "A palavra-passe deve ter pelo menos 5 letras");
                }
                // hash password
                HMACSHA512 hMACSHA512 = new HMACSHA512(new byte[] { 76 });
                var password = hMACSHA512.ComputeHash(Encoding.UTF8.GetBytes(utilizador.Password));
                utilizador.Password = Convert.ToBase64String(password);

                db.Entry(utilizador).State = EntityState.Modified;
                db.SaveChanges();
                if (User.IsInRole("Prestador"))
                    return RedirectToAction("Index");
                else
                    return RedirectToAction("Index", "Home");
            }
            if (User.IsInRole("Prestador") == false)
                utilizador.Perfis = new[]
                {
                new  SelectListItem{Value="1", Text="Cliente"}
                };
            return View(utilizador);
        }

        [Authorize(Roles = "Administrador")]
        // GET: Utilizadores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utilizador utilizador = db.Utilizadors.Find(id);
            if (utilizador == null)
            {
                return HttpNotFound();
            }
            return View(utilizador);
        }

        [Authorize(Roles = "Administrador")]
        // POST: Utilizadores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utilizador utilizador = db.Utilizadors.Find(id);
            db.Utilizadors.Remove(utilizador);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
