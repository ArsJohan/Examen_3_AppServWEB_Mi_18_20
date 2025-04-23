using System.Web;
using System.Web.Mvc;

namespace Examen_3_AppServWEB_Mi_18_20
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
