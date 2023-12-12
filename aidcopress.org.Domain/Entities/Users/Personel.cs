using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aidcopress.org.Domain.Entities.Users
{
    public class Personel
    {
        
        public int Id { get; set; }
        public int Rahkaran_code { get; set; }
        public int Personel_code { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public string Semat { get; set;}

        public string Shoghl { get; set; }

        

        public int Service_route_id { get; set; }
        public BusServiceRoute.BusServiceRoute BusServiceRoute { get; set; }

    }
}
