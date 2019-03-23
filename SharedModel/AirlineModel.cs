using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedModel
{
    public class AirlineModel
    {
        public int id { get; set; }
        public string From { get; set; }
        public string UpTo { get; set; }
        public int BaseFare { get; set; }
        public int TotalSeats { get; set; }
        public SeatPreferences SeatPreference { get; set; }
        public PriceSeatPrefs PriceSeatPref { get; set; }
    }

    public class SeatPreferences
    {
        public bool WindowCheck { get; set; }
        public string Window { get; set; }
        public int SelectedSeatsWindow { get; set; }

        public bool MiddleCheck { get; set; }
        public string Middle { get; set; }
        public int SelectedSeatsMiddle { get; set; }

        public bool AisleCheck { get; set; }
        public string Aisle { get; set; }
        public int SelectedSeatsAisle { get; set; }
    }
    public class PriceSeatPrefs
    {
        public int Window { get; set; }
        public int Middle { get; set; }
        public int Aisle { get; set; }
    }
}
