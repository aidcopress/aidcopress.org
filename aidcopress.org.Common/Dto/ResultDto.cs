using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aidcopress.org.Common.Dto
{
    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }


    }

    public class ResultDto<T>   //در مواردی که خروجی ما بیشتر از ایز ساکسز و ئسیج باشد از تی مدل استفاده میکنیم
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }


    }
}
