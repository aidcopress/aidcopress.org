using aidcopress.org.Application.Interfaces.Contexts;
using aidcopress.org.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aidcopress.org.Application.Services.Users.Queries.GetBusServiceRoute
{
    public interface IGetBusServiceRoute
    {

        ResultDto<List<BusServiceRouteDto>> Execute();
    }


    //public class GetBusServiceRoute : IGetBusServiceRoute
    //{
    //    private readonly IDataBaseContext _context;
    //    public GetBusServiceRoute (IDataBaseContext context) 
        
    //    {
        
    //    _context = context;
        
        
    //    }

    //    public ResultDto<List<BusServiceRouteDto>> Execute()
    //    {



    //        var serviceRoute = _context.BusServiceRoutes.ToList();




    //    }
    //}




    public class BusServiceRouteDto
    {

        public int Id { get; set; }
        public string Route { get; set; }
        public string RouteDetail { get; set; }
    }

}
