using System.Web;
using System.Web.Mvc;

namespace GruppL_IK073G_ht19
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
