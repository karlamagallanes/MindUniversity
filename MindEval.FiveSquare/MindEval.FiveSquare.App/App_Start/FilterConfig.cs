using System.Web;
using System.Web.Mvc;

namespace MindEval.FiveSquare.App
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
