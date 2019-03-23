using Booking_BAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using SharedModel;
using System.Collections.Generic;
using TicketBooking.Filters;

namespace Ticket_Booking.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<BookingModel> bookingModel;
        private BookingViewModel bookingViewModel = new BookingViewModel();
        private AppSettings appSettings = new AppSettings();
        private IBooking bookingBLD;

        public HomeController(IOptions<List<BookingModel>> options, IOptions<AppSettings> AppSettings,IBooking bookingObj)
        {
            bookingModel = options.Value;
            appSettings = AppSettings.Value;
            bookingBLD = bookingObj;
        }

        [TypeFilter(typeof(HealthCheckFilterAttribute),Arguments =new object[] { "http://localhost:49916" })]
        [Route("Home")]
        public IActionResult Index()
        {
            bookingViewModel.FromUptoDropDown = new List<FromUptowithID>();
           foreach (var FromUpto in bookingModel)
            {
                bookingViewModel.FromUptoDropDown.Add(new FromUptowithID { id=FromUpto.id, FromUpto=FromUpto.From+" - "+FromUpto.UpTo });
            } 
            return View(bookingViewModel);
        }

        [Route("Airline")]
        public IActionResult AirLineBooking(string id)
        {
           var BookingData= bookingBLD.getAirlineDetails(id, appSettings.AirLineUrl);
            bookingViewModel.BasePrice = BookingData.BaseFare;
            bookingViewModel.TotalSeats = BookingData.TotalSeats;
            bookingViewModel.SeatPreference = BookingData.SeatPreference;
            bookingViewModel.PriceSeatPref = BookingData.PriceSeatPref;

            return PartialView("AirLineBooking",bookingViewModel);
        }
        
    }
}
