using System.Collections.Generic;
namespace aidcopress.org.Application.Services.Users.Queries.GetUser
{
    public class ResultGetPersonelDto        //این متد برای این است که کل ردیف های پرسنل را بشمارد
    {

       public  List<GetPersonelDto> Personels { get; set; }
        public int Rows { get; set; }

    }

}
