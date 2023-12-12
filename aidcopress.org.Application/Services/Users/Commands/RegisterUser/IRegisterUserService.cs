using aidcopress.org.Application.Interfaces.Contexts;
using aidcopress.org.Common;
using aidcopress.org.Common.Dto;
using aidcopress.org.Domain;
using aidcopress.org.Domain.Entities.Users;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aidcopress.org.Application.Services.Users.Commands.RegisterUser
{
    public interface IRegisterUserService
    {
        //در اینجا خروجی را برمیگرداند بنابر این خروجی ما باید 1.ای دی کاربری که ثبت نام شد را برگرداند2.یک بولین که مشخص کند موفقیت امیز بوده است3.یک پیغام
        //این اینتر فیس با لایه پرسیستنس که اون لایه با دیتا بیس در ارتباط است مرتبط است

        ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto Request);


    }
    //حالا بایستی یک کلاس بسازیم تا این اینتر فیس را پیاده سازی کند  

    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;

        public RegisterUserService(IDataBaseContext context)//در اینجا از کانتکس یه شی می سازیم
        {
            _context = context;
        }

        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto Request)
        {
            try
            {                        //ترای میکن اگه ثبت نام شد موفقیت است اگه ثبت نام نشد نا موفق است 
            
                if (string.IsNullOrWhiteSpace(Request.Fname))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام را وارد نمایید"
                    };
                }

                if (string.IsNullOrWhiteSpace(Request.Lname))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام خانوادگی را وارد نمایید"
                    };
                }


                if (string.IsNullOrWhiteSpace(Request.Password))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور را وارد نمایید"
                    };
                }
                if (Request.Password != Request.RePassword)
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار آن برابر نیست"
                    };
                }


                foreach (var  item in Request.roles) //در اینجا از ریکویست رجیستر دی تی او رول را انتخاب میکنیم

                {
                    if (item.Id == 0)

                    {

                        return new ResultDto<ResultRegisterUserDto>()
                        {
                            Data = new ResultRegisterUserDto()
                            {
                                UserId = 0,
                            },
                            IsSuccess = false,
                            Message = "یک نقش انتخاب نمایید"
                        };

                    }
                }

                var passwordHasher = new PasswordHasherr();
                var hashedPassword = passwordHasher.HashPassword(Request.Password);


                User user = new User()
                {
                    Fname = Request.Fname,
                    Lname = Request.Lname,
                    Username = Request.Username,
                    Password = hashedPassword,


                };
                List<UserInRole> userInRoles = new List<UserInRole>();

                foreach (var item in Request.roles) //در اینجا از ریکویست رجیستر دی تی او رول را انتخاب میکنیم

                {
                    var roles = _context.Roles.Find(item.Id);                     //نقش مورد نظر را از دیتا بیس بگیر و به یوزر اد کن
                    userInRoles.Add(new UserInRole
                    {
                        Role = roles,
                        RoleId = roles.Id,
                        User = user,
                        UserId = user.Id,

                    });
                }
                user.UserInRoles = userInRoles;//نقش های شما این باشد

                _context.Users.Add(user);
                _context.SaveChanges();

                return new ResultDto<ResultRegisterUserDto>()

                {
                    Data = new ResultRegisterUserDto()

                    {
                        UserId = user.Id,
                    },

                    IsSuccess = true,
                    Message = "ثبت نام کاربر انجام شد",
                };

            }

            catch
            {

                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"
                };


            }
           
        }
    }

    public class RequestRegisterUserDto
    {
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public List<RoleRegisterUserDto> roles { get; set; }

    }


    public class RoleRegisterUserDto
    {
        public int Id { get; set; }

    }


    public class ResultRegisterUserDto     //در اینجا چیزی که در خروجی برمیگردد را معرفی میکنیم و دی تی او یعنی در بین لایه ها قابل انتقال است
    {
        public int UserId { get; set; }


    }




}
