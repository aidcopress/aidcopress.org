using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using aidcopress.org.Application.Services.Users.Commands.RegisterUser;
using aidcopress.org.Application.Services.Users.Commands;
using aidcopress.org.Application.Services.Users.Commands.RegisterUser;
using aidcopress.org.Application.Services.Users.Commands;




namespace Endpoint.site.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly IRegisterUserService _registerUserService;
        private readonly IUserLoginService _userLoginService;


        public AuthenticationController( IUserLoginService userLoginService)  //IRegisterUserService registerUserService ,
        {
            
           // _registerUserService = registerUserService;
            _userLoginService = userLoginService;



        }



        public IActionResult Signin(string ReturnUrl = "/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }




        [HttpPost]
        public IActionResult Signin(string Username, string Password, string url = "/")
        {

            var signupResult = _userLoginService.Execute(Username, Password);
            if (signupResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,signupResult.Data.UserId.ToString()),
                  //  new Claim(ClaimTypes.em, Username),
                    new Claim(ClaimTypes.Name, signupResult.Data.Name),
                    new Claim(ClaimTypes.Role, signupResult.Data.Roles ),
                };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
                HttpContext.SignInAsync(principal, properties);

            }
            return Json(signupResult);

         
        }



    }
}
