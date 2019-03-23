using Newtonsoft.Json;
using SharedModel;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Booking_BAL
{
    public class BookingBLD : IBooking
    {
        public AirlineModel getAirlineDetails(string id,string AirlineUrl)
        {
            AirlineModel airlineModels = new AirlineModel();
            Uri uri = new Uri(AirlineUrl);

            using(HttpClient httpClient=new HttpClient())
            {
                httpClient.BaseAddress = uri;
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var Response = httpClient.GetAsync("api/Airline?id="+id,HttpCompletionOption.ResponseContentRead);
                airlineModels = JsonConvert.DeserializeObject<AirlineModel>(Response.Result.Content.ReadAsStringAsync().Result);
            }
            return airlineModels;
        }
    }
}
