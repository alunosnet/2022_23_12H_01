using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServicosEPedidos_Mod_17E.Data
{
    public class ServicosEPedidos_Mod_17EContext : DbContext
    {
        public ServicosEPedidos_Mod_17EContext() : base("name=ServicosEPedidos_Mod_17EContext")
        {
        }

        public System.Data.Entity.DbSet<ServicosEPedidos_Mod_17E.Models.Utilizador> Utilizadors { get; set; }

        public System.Data.Entity.DbSet<ServicosEPedidos_Mod_17E.Models.Pedido> Pedidoes { get; set; }

        public System.Data.Entity.DbSet<ServicosEPedidos_Mod_17E.Models.PedidoAceite> PedidoAceites { get; set; }
    }
}