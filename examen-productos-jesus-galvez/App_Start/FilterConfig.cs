using System.Web;
using System.Web.Mvc;

namespace examen_productos_jesus_galvez
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
