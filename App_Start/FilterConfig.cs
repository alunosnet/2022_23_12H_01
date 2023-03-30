using System.Web;
using System.Web.Mvc;

namespace ServicosEPedidos_Mod_17E
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
