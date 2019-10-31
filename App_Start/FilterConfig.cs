using System.Web;
using System.Web.Mvc;

namespace Test_educational_MVC_EP
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
