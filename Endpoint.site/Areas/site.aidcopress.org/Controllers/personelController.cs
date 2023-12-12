using aidcopress.org.Application.Services.Users.Queries.GetUser;
using Microsoft.AspNetCore.Mvc;

namespace Endpoint.site.Areas.site.aidcopress.org.Controllers
{
    public class personelController : Controller
    {

        private readonly IGetPersonelService _getpersonelService;

        public personelController(IGetPersonelService getpersonelService)
        {
            _getpersonelService = getpersonelService;
;        }

        [Area("site.aidcopress.org")]
        public IActionResult Personel(string searchkey , int page=1)
        {
            return View(_getpersonelService.Execute(new RequestGetPersonelDto
            {
                page = page,
                SearchKey = searchkey ,

            }
                
                ));
        }

      


    }
}
