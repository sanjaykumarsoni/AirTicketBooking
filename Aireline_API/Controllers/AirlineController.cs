using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.Options;
using SharedModel;

namespace Aireline_API.Controllers
{
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly List<AirlineModel> airlineModels;

        public AirlineController(IOptions<List<AirlineModel>> option)
        {
            airlineModels = option.Value;
        }
        [Route("api/Airline")]
        [HttpGet]
        public ActionResult<AirlineModel> Get(int id)
        {
            AirlineModel airlineModelobj = new AirlineModel();
            var DataObj = airlineModels.Where(x => x.id == Convert.ToInt32(id)).FirstOrDefault();
            if (DataObj != null)
            {
                
                airlineModelobj.BaseFare = DataObj.BaseFare;
                airlineModelobj.TotalSeats = DataObj.TotalSeats;
                airlineModelobj.SeatPreference = DataObj.SeatPreference;
                airlineModelobj.PriceSeatPref = DataObj.PriceSeatPref;
            }
            

            return airlineModelobj;
        }
    }
}
