using Microsoft.AspNetCore.Mvc;

namespace Endpoint.site.Areas.site.aidcopress.org.Controllers
{
    public class HomeController : Controller
    {


        [Area("site.aidcopress.org")]
        public IActionResult Index()
        {
            return View();
        }

        [Area("site.aidcopress.org")]
        public IActionResult Login()
        {
            return View();
        }


    }
}
