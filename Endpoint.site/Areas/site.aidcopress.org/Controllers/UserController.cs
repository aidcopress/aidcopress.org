using aidcopress.org.Application.Services.Users.Commands.RegisterUser;
using aidcopress.org.Application.Services.Users.Queries.GetRoles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Endpoint.site.Areas.site.aidcopress.org.Controllers
{



    [Area("site.aidcopress.org")]
    public class UserController : Controller
    {
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;


        public UserController(IGetRolesService getRolesService, IRegisterUserService registerUserService)


        {
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;

        }

      

        [HttpGet]

        public IActionResult Create()
        {
            ViewBag.Roles = new SelectList(_getRolesService.Execute().Data, "Id", "Name");//در اینجا ای دی می شود ولیو و نام می شود نمایش نام
            

            return View();
        }




        [HttpPost]

        public IActionResult Create(string Fname, string Lname, string Username, string Password, string RePassword, int RoleId)//این موارد را از کاربر در صفحه اصلی میگیریم
        {

            //در اینجا مواردی راکه از بایلا گرفته ایم را به سرویس میدهیم


            var result = _registerUserService.Execute(new RequestRegisterUserDto

            {
                Fname = Fname,
                Lname = Lname,
                Username = Username,
                roles = new List<RoleRegisterUserDto>()
                {
                   new RoleRegisterUserDto
                   {
                       Id= RoleId
                   }


                },

                Password = Password,
                RePassword = RePassword,


            });

            return Json(result);
        }


    }
}
