using aidcopress.org.Application.Services.Users.Queries.GetPersonelHolidays;
using aidcopress.org.Domain.Entities.Users;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Principal;

namespace Endpoint.site.Areas.site.aidcopress.org.Controllers
{

    [Area("site.aidcopress.org")]
    public class HolidaysController : Controller
    {
        private readonly IGetPersonelHolidaysService _getPersonelHolidaysService;

        public HolidaysController(IGetPersonelHolidaysService getPersonelHolidaysService)
        {
            _getPersonelHolidaysService = getPersonelHolidaysService;
        }


        public IActionResult Holidays(string ReturnUrl = "/")
        {

            ViewBag.url = ReturnUrl;

            return View();
           

        }


        [HttpPost]
        public IActionResult Holidays(int Personel_code , string url = "/")
        {

            var result_Personel_Code = _getPersonelHolidaysService.Execute(Personel_code);          
       
            return Json(result_Personel_Code);
        }

       


    }
}
