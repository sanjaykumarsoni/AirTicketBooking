using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace TicketBooking.Filters
{
    [Produces("application/json")]
    public class HealthCheckFilterAttribute : ActionFilterAttribute
    {
        private readonly string URL=string.Empty;
        public HealthCheckFilterAttribute(string HealthFor)
        {
            URL = HealthFor;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Uri uri = new Uri(URL);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls;
            string HealthyChk = string.Empty;
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = uri;
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/text"));
                try
                {
                    var Result = httpClient.GetAsync("/healthcheck", HttpCompletionOption.ResponseHeadersRead);
                    HealthyChk = Result.Result.Content.ReadAsStringAsync().Result.ToString();
                }catch(Exception ex)
                {
                    HealthyChk = "Not Healthy";
                }
                
                if (HealthyChk != "Healthy")
                {
                    context.Result = new RedirectToRouteResult(new RouteValueDictionary {
                        { "controller", "Error" },
                        { "action", "Index" }  });
                }
            }
        }

        
    }
}
