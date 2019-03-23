using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SharedModel
{
    public class BookingViewModel
    {
        public int FromTOid { get; set; }
        public List<FromUptowithID> FromUptoDropDown { get; set; }
        public int BasePrice { get; set; }
        public int TotalSeats { get; set; }
        public SeatPreferences SeatPreference { get; set; }
        public PriceSeatPrefs PriceSeatPref { get; set; }
    }

    public class FromUptowithID
    {
        public int id { get; set; }
        public string FromUpto { get; set; }
    }
}
