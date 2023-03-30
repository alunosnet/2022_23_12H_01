using ServicosEPedidos_Mod_17E.Data;
using ServicosEPedidos_Mod_17E.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicosEPedidos_Mod_17E.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ConsultasController : Controller
    {
        private ServicosEPedidos_Mod_17EContext db = new ServicosEPedidos_Mod_17EContext();

        // GET: Consultas
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult PesquisaCliente([Bind(Include = "Id,Nome,Email,Morada,Password,Perfil")] Utilizador utilizador)
        {
            string nome = Request.Form["tbNome"];
            var clientes = db.Utilizadors.Where(c => c.Nome.Contains(nome));
            return View("PesquisaCliente", clientes.ToList());
        }










        public ActionResult PesquisaDinamica()
        {
            return View();
        }
        public JsonResult PesquisaNome(string nome)
        {
            var clientes = db.Utilizadors.Where(c => c.Nome.Contains(nome)).ToList();
            var lista = new List<Campos>();
            foreach (var c in clientes)
                lista.Add(new Campos() { nome = c.Nome });
            return Json(lista, JsonRequestBehavior.AllowGet);
        }












        public ActionResult MelhorCliente()
        {
            string sql = @"SELECT Nome, sum(Valor) as valor FROM Pedidoes INNER JOIN utilizadors ON ClienteId=Id GROUP BY ClienteId, nome ORDER BY valor DESC";
            var melhor = db.Database.SqlQuery<Campos>(sql);
            if (melhor != null && melhor.ToList().Count > 0)
                ViewBag.melhor = melhor.ToList()[0];
            else
            {
                Campos temp = new Campos();
                temp.nome = "Não foram encontrados registos";
                ViewBag.melhor = temp;
            }
            return View();
        }
        public ActionResult MelhorPrestador()
        {
            string sql = @"SELECT Nome, count(*) as pedidos FROM PedidoAceites INNER JOIN utilizadors ON PrestadorId=Id GROUP BY nome ORDER BY pedidos DESC";
            var melhor = db.Database.SqlQuery<Campos>(sql);
            if (melhor != null && melhor.ToList().Count > 0)
                ViewBag.melhor = melhor.ToList()[0];
            else
            {
                Campos temp = new Campos();
                temp.nome = "Não foram encontrados registos";
                ViewBag.melhor = temp;
            }
            return View();
        }  

        public class Campos
        {
            public string nome { get; set; }
            public int pedidos{ get; set; }
            public decimal valor { get; set; }
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