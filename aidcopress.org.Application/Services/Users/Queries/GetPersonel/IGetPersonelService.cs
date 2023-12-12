using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace aidcopress.org.Application.Services.Users.Queries.GetUser
{
    public interface IGetPersonelService
    {
        ResultGetPersonelDto Execute(RequestGetPersonelDto request);//لیست را از داده های ذیر تهیه میکند در ضمن میتوانیم یک ورودی یا دو ورودی یکی کلمه برای سرچ و دیگری شماره صفحه برای نمایش صفحه

    }

}
