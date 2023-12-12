using aidcopress.org.Common.Dto;
using static aidcopress.org.Application.Services.Users.Queries.GetPersonelHolidays.GetPersonelHolidaysService;

namespace aidcopress.org.Application.Services.Users.Queries.GetPersonelHolidays
{
    public interface IGetPersonelHolidaysService
    {
        ResultDto<ResultGetPersonelHolidayDto> Execute(int Personel_code);
    }
}
