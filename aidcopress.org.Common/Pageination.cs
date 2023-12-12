using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aidcopress.org.Common
{
    public static class Pageination
    {

        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int Page, int pageSize, out int rowsCount)

        {

            rowsCount = source.Count();
            return source.Skip((Page - 1) * pageSize).Take(pageSize);

        }


    }
}
