using Microsoft.AspNetCore.Mvc;

namespace Endpoint.site.Areas.site.aidcopress.org.Controllers
{
    public class ServiceRouteController : Controller
    {



        [Area("site.aidcopress.org")]
        public IActionResult Serviceroute()
        {
            return View();
        }
    }
}
