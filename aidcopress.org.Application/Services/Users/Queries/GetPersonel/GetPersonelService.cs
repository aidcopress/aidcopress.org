using aidcopress.org.Application.Interfaces.Contexts;
using aidcopress.org.Common;
using System.Linq;

namespace aidcopress.org.Application.Services.Users.Queries.GetUser
{
    //ابتدا باید یه کلاس بسازیم که این سرویس مارا پیاده سازی کند
    public class GetPersonelService : IGetPersonelService
    {

        //در این کلاس نیاز داریم به دیتا بیس متصل بشیم .ما الان در لایه اپلیکیشن هستیم برای اتصال به پرسیستنس باید از اینترفیس کانتکس استفاده کنیم
          private readonly IDataBaseContext _context; //در متد سازنده اینجکشن را انجام میدهیم

            public GetPersonelService(IDataBaseContext context)
        {
            _context = context;
        }


        public ResultGetPersonelDto Execute(RequestGetPersonelDto request)

        {
            var personel = _context.Personels.AsQueryable();
            if(!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                personel = personel.Where(p => p.First_name.Contains(request.SearchKey) && p.Last_name.Contains(request.SearchKey) && p.Semat.Contains(request.SearchKey) && p.Shoghl.Contains(request.SearchKey));
            }

            int rowsCount = 0;
           var personelList= personel.ToPaged(request.page, 2000, out rowsCount).Select(p => new GetPersonelDto
            {

                Id = p.Id,
                First_name = p.First_name,
                Last_name = p.Last_name,
                Rahkaran_cod=p.Rahkaran_code,
                Personel_code = p.Personel_code,
                Semat = p.Semat,
                Shoghl = p.Shoghl,
               
            }


            ).ToList();

            return new ResultGetPersonelDto
            {
                
                Rows = rowsCount,
                Personels = personelList,
            };

        }
    }

}
