using System.Web;
using System.Web.Mvc;

namespace Murz1k.DrinksVendingMachine
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
