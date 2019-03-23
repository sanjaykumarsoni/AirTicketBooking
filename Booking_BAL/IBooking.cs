using SharedModel;
using System.Collections.Generic;

namespace Booking_BAL
{
    public interface IBooking
    {
       AirlineModel getAirlineDetails(string id,string AirlineURL);
    }
}
