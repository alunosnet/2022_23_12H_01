using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using ServicosEPedidos_Mod_17E.Data;
using ServicosEPedidos_Mod_17E.Models;

namespace ServicosEPedidos_Mod_17E.Controllers
{
    [Authorize]
    public class PedidoAceitesController : Controller
    {
        private ServicosEPedidos_Mod_17EContext db = new ServicosEPedidos_Mod_17EContext();

        // GET: PedidoAceites
        public ActionResult Index(int? id)
        {

            var pedidoes = db.PedidoAceites.Include(c => c.IdPrest);
            if (User.IsInRole("Prestador"))
            {
                pedidoes = db.PedidoAceites.Where(p => p.PrestadorId == id).Include(c => c.IdPrest);
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

            //var pedidoAceites = db.PedidoAceites.Include(p => p.IdPedido).Include(p => p.IdPrest);
            //return View(pedidoes.ToList());
        }

        // GET: PedidoAceites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoAceite pedidoAceite = db.PedidoAceites.Find(id);
            if (pedidoAceite == null)
            {
                return HttpNotFound();
            }
            return View(pedidoAceite);
        }

        // GET: PedidoAceites/Create
        [Authorize(Roles = "Prestador")]
        public ActionResult Create()
        {
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "IdPed", "IdPed");
            ViewBag.PrestadorId = new SelectList(db.Utilizadors, "Id", "Nome");
            return View();
        }

        // POST: PedidoAceites/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, int ped,[Bind(Include = "IdPedAc,PrestadorId,DataPedAc,PedidoId")] PedidoAceite pedidoAceite)
        {
            if (ModelState.IsValid)
            {
                var data = db.Pedidoes.FirstOrDefault(x => x.IdPed == ped);
                if (data != null)
                {
                    data.Estado = true;
                }

                /////////////////////////////////////
                pedidoAceite.PrestadorId = id;
                pedidoAceite.PedidoId = ped;

                db.PedidoAceites.Add(pedidoAceite);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.PedidoId = new SelectList(db.Pedidoes, "IdPed", "IdPed", pedidoAceite.PedidoId);
            ViewBag.PrestadorId = new SelectList(db.Utilizadors, "Id", "Nome", pedidoAceite.PrestadorId);
            return View(pedidoAceite);
        }

        // GET: PedidoAceites/Edit/5
        /*
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoAceite pedidoAceite = db.PedidoAceites.Find(id);
            if (pedidoAceite == null)
            {
                return HttpNotFound();
            }
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "IdPed", "IdPed", pedidoAceite.PedidoId);
            ViewBag.PrestadorId = new SelectList(db.Utilizadors, "Id", "Nome", pedidoAceite.PrestadorId);
            return View(pedidoAceite);
        }

        // POST: PedidoAceites/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPedAc,PrestadorId,DataPedAc,PedidoId")] PedidoAceite pedidoAceite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pedidoAceite).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PedidoId = new SelectList(db.Pedidoes, "IdPed", "IdPed", pedidoAceite.PedidoId);
            ViewBag.PrestadorId = new SelectList(db.Utilizadors, "Id", "Nome", pedidoAceite.PrestadorId);
            return View(pedidoAceite);
        }

        // GET: PedidoAceites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoAceite pedidoAceite = db.PedidoAceites.Find(id);
            if (pedidoAceite == null)
            {
                return HttpNotFound();
            }
            return View(pedidoAceite);
        }

        // POST: PedidoAceites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoAceite pedidoAceite = db.PedidoAceites.Find(id);
            db.PedidoAceites.Remove(pedidoAceite);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
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
