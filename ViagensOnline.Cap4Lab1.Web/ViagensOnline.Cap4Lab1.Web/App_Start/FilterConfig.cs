using System.Web;
using System.Web.Mvc;

namespace ViagensOnline.Cap4Lab1.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
