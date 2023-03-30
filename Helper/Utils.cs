using System;
using ServicosEPedidos_Mod_17E.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ServicosEPedidos_Mod_17E.Helper
{
    public static class Utils
    {
        public static string UserId(this HtmlHelper htmlHelper, System.Security.Principal.IPrincipal utilizador)
        {
            string iduser = "";

            using (var context = new ServicosEPedidos_Mod_17EContext())
            {
                var consulta = context.Database.SqlQuery<int>("SELECT Id FROM utilizadors WHERE nome=@p0",
                    utilizador.Identity.Name);
                if (consulta.ToList().Count > 0)
                {
                    iduser = consulta.ToList()[0].ToString();
                }
            }
            return iduser;
        }

    }
}