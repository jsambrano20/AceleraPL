using System.Web;
using System.Web.Mvc;

namespace Aula08_AtividadeIdentity
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
