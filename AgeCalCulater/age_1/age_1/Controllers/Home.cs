using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Data;
using System.CodeDom;
using System.Configuration;
using System.Net.Http;

namespace age_1.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class Home : Controller
    {

        [HttpPost]
        [Route("GetDetails")]

        public JsonResult GetDetails(GetDate dt)
        {
            CultureInfo culture = new CultureInfo("es-ES");
            DateTime endTime = DateTime.Today;
            TimeSpan timespan = endTime.Subtract(dt.date);
            var totalDays = timespan.TotalDays;
            var totalYears = Math.Truncate(totalDays / 365);
            var totalMonths = Math.Truncate((totalDays % 365) / 30);
            var remainingDays = Math.Truncate((totalDays % 365) % 30);

            var calculatedAge = string.Format("{0} year(s), {1} month(s)and {2} day(s)", totalYears, totalMonths, remainingDays);


            var json = Json(new
            {
                calculatedAge
            });
            return json;
        }



    }

    public class GetDate
    {
        public DateTime date { get; set; }
    }
}





