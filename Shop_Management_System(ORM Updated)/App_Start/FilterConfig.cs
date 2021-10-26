using System.Web;
using System.Web.Mvc;

namespace Shop_Management_System_ORM_Updated_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
