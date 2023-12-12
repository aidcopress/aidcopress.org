using aidcopress.org.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aidcopress.org.Domain.Entities.BusServiceRoute
{
    public class BusServiceRoute
    {
        public int Id { get; set; }
        public string Route { get; set; }
        public string RouteDetail{ get; set; }
        public ICollection<Personel> personels { get; set; }

    }
}
