using aidcopress.org.Application.Interfaces.Contexts;
using aidcopress.org.Common.Dto;
using aidcopress.org.Domain.Entities.Users;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aidcopress.org.Common;


namespace aidcopress.org.Application.Services.Users.Commands
{
    public interface IUserLoginService
    {
        ResultDto<ResultUserloginDto> Execute(String Username, String Password);

    }

    public class UserLoginService : IUserLoginService

    {
        private readonly IDataBaseContext _context;

       public UserLoginService (IDataBaseContext context)
        {
            _context = context;
        }


       

        public ResultDto<ResultUserloginDto> Execute(string Username, string  Password)
        {



            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "نام کاربری و رمز عبور را وارد نمایید",
                };
            }



            var user = _context.Users
              
                .Include(p => p.UserInRoles)  //در اینجا پی داخل یوزر را بر میگرداند
                .ThenInclude(p => p.Role)    //در اینجا پی داخل یوزر این رول را برمیگرداند
                .Where(p => p.Username.Equals(Username) //ما در اینجا نیاز داریم تا اسم رول را در بیاوریم
                 && p.IsActive == false)        //دراصل با این کد لیست رول های یوزر دریافتی بر میگردد.
                .FirstOrDefault();



            if (user == null)
            {
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "کاربری با این نام کاربری ثبت نام نکرده است",
                };
            }


           
         


              var passwordHasher = new PasswordHasherr();   
              bool resultVerifyPassword = passwordHasher.VerifyPassword(user.Password, Password);
              if (resultVerifyPassword == false)
             

            {
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "رمز وارد شده اشتباه است!",
                };
            }







            var roles = "";
            foreach (var item in user.UserInRoles)//در اینجا چون رول را اینکلود یوزر این رول کرده بودیم بنابر این میتوان لیست رول را از یوزر این رول در آورد
            {
                roles += $"{item.Role.Name}";//در اینجا لیست رول های یک یوزر در می آید
            }


            return new ResultDto<ResultUserloginDto>()
            {
                Data = new ResultUserloginDto()
                {
                    Roles = roles,
                    UserId = user.Id,
                    Name = user.Fname
                },
                IsSuccess = true,
                Message = "ورود به سایت با موفقیت انجام شد",
            };


        }
    }


    public class ResultUserloginDto
    {
        public long UserId { get; set; }
        public string Roles { get; set; }
        public string Name { get; set; }

    }
}
