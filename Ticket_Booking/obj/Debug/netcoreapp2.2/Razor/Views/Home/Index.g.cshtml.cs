#pragma checksum "D:\AirLineBooking\Ticket_Booking\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "185bde68cb5c91bc1cf744f24d344022bf8e7433"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\AirLineBooking\Ticket_Booking\Views\_ViewImports.cshtml"
using Ticket_Booking;

#line default
#line hidden
#line 2 "D:\AirLineBooking\Ticket_Booking\Views\_ViewImports.cshtml"
using Ticket_Booking.Models;

#line default
#line hidden
#line 1 "D:\AirLineBooking\Ticket_Booking\Views\Home\Index.cshtml"
using SharedModel;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"185bde68cb5c91bc1cf744f24d344022bf8e7433", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ad7e2a181926349d34a5c30c748fc8747bffdae", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BookingViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "D:\AirLineBooking\Ticket_Booking\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(85, 189, true);
            WriteLiteral("\n<div class=\"text-center\">\n    <h1 class=\"display-4\">Welcome To Travel Booking</h1>\n</div>\n<div class=\"row\">\n    <div class=\"col col-lg-2\">Booking For</div> \n    <div class=\"col col-lg-2\">\n");
            EndContext();
#line 13 "D:\AirLineBooking\Ticket_Booking\Views\Home\Index.cshtml"
           
            List<SelectListItem> selectListItem = new List<SelectListItem>();
            foreach(var item in Model.FromUptoDropDown)
            {
                selectListItem.Add(new SelectListItem { Value = item.id.ToString(), Text = item.FromUpto });
            }
        

#line default
#line hidden
            BeginContext(567, 8, true);
            WriteLiteral("        ");
            EndContext();
            BeginContext(576, 71, false);
#line 20 "D:\AirLineBooking\Ticket_Booking\Views\Home\Index.cshtml"
   Write(Html.DropDownListFor(model=>Model.FromTOid,selectListItem,"--Select--"));

#line default
#line hidden
            EndContext();
            BeginContext(647, 57, true);
            WriteLiteral("\n    </div>\n</div>\n<div id=\"AirLinePartial\">\n    \n</div>\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BookingViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
