using aidcopress.org.Application.Interfaces.Contexts;
using aidcopress.org.Common.Dto;

namespace aidcopress.org.Application.Services.Users.Queries.GetPersonelHolidays
{
    public partial class GetPersonelHolidaysService : IGetPersonelHolidaysService
    {
        private readonly IDataBaseContext _context;

        public GetPersonelHolidaysService(IDataBaseContext context)
        { _context = context;
        }

        public ResultDto<ResultGetPersonelHolidayDto> Execute(int Personel_code)
        {

            try
            {
                var personel = _context.Personels.AsQueryable();
                personel = personel.Where(p => p.Personel_code.Equals(Personel_code));
                return new ResultDto<ResultGetPersonelHolidayDto>()
                {
                    Data = new ResultGetPersonelHolidayDto
                    {
                        Id = personel.First().Id,
                        First_name = personel.First().First_name,
                        Last_name = personel.First().Last_name,
                        Rahkaran_code = personel.First().Rahkaran_code,
                        Personel_code = personel.First().Personel_code,
                        Semat = personel.First().Semat,
                        Shoghl = personel.First().Shoghl,
                    },
                    IsSuccess = true,
                    Message = "با موفقیت اضافه شد",
                };
            }
            catch 
            {
                return new ResultDto<ResultGetPersonelHolidayDto>()
                {
                    Data = new ResultGetPersonelHolidayDto
                    {
                        Id = 0,
                        First_name = "",
                        Last_name ="",
                        Rahkaran_code = 0,
                        Personel_code = 0,
                        Semat = "",
                        Shoghl = "",

                    },
                    IsSuccess = false,
                    Message = "کاربری با این کد پرسنلی یافت نشد",

                };


            }
        }
       
    }
}
