using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using ServicosEPedidos_Mod_17E.Data;
using ServicosEPedidos_Mod_17E.Helper;
using ServicosEPedidos_Mod_17E.Models;

namespace ServicosEPedidos_Mod_17E.Controllers
{
    public class PedidosController : Controller
    {
        private ServicosEPedidos_Mod_17EContext db = new ServicosEPedidos_Mod_17EContext();

        // GET: Pedidos
        public ActionResult Index(int? id)
        {
            if (User.IsInRole("Cliente"))
            {
                /*
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                */
            }

            var pedidoes = db.Pedidoes.Include(c => c.IdClie);
            if (User.IsInRole("Cliente"))
            {
                pedidoes = db.Pedidoes.Where( p => p.ClienteId==id).Include(c => c.IdClie);
            }

            //if (User.IsInRole("Prestador"))
            //{
            //    pedidoes = db.Pedidoes.Include(c => c.IdClie);
            //}

            if (pedidoes.ToList().Count == 0)
            {
                ViewBag.mensagem = "Não foram feitos pedidos";
                return View(pedidoes.ToList());
            }

            return View(pedidoes.ToList());
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Where(q => q.IdPed == id).Include(q => q.IdClie).FirstOrDefault();
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.Algo = pedido.IdPed.ToString();

            return View(pedido);
        }

        // GET: Pedidos/Create
        public ActionResult Create(string trabalho)
        {
            if (trabalho == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Utilizadors, "Id", "Nome");
            return View();
        }

        // POST: Pedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, string trabalho, [Bind(Include = "IdPed,ClienteId,DataPed,Valor,Tipo,Descricao")] Pedido pedido)
        {

            pedido.Tipo = "";

            if (trabalho == "1")
            {
                pedido.Tipo = "Manutenção";
            }
            else if(trabalho == "2")
            {
                pedido.Tipo = "Taxi";
            }
            else if(trabalho == "3")
            {
                pedido.Tipo = "Entrega";
            }
            pedido.ClienteId = id;

            db.Pedidoes.Add(pedido);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        /*
        // GET: Pedidos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Utilizadors, "Id", "Nome", pedido.ClienteId);
            return View(pedido);
        }

        // POST: Pedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPed,ClienteId,DataPed,Valor")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Utilizadors, "Id", "Nome", pedido.ClienteId);
            return View(pedido);
        }
        */

        // GET: Pedidos/Delete/5
        [Authorize(Roles = "Cliente")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pedido pedido = db.Pedidoes.Find(id);
            if (pedido == null)
            {
                return HttpNotFound();
            }
            return View(pedido);
        }

        [Authorize(Roles = "Cliente")]
        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pedido pedido = db.Pedidoes.Find(id);
            db.Pedidoes.Remove(pedido);
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
