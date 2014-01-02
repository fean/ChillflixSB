using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using SickBeard.Schedule.Models;
using System.Text.RegularExpressions;

namespace SickBeard.Schedule
{

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            var response = new StreamReader(
                new WebClient().OpenRead(
                    string.Format(
                        "http://149.210.154.147:8081/api/{0}/?cmd=future",
                        Properties.Settings.Default.SBKey
                    )
                )
            ).ReadToEnd();

            var definition = new
            {
                data = new
                {
                    soon = new Show[] { },
                    later = new Show[] { },
                    today = new Show[] { },
                    missed = new Show[] { }
                },
                message = "",
                result = ""
            };

            var result = JsonConvert.DeserializeAnonymousType<ScheduleAPIResult>(response, new ScheduleAPIResult());
            Session.Add("scheduleObject", result);

            response = new StreamReader(new WebClient().OpenRead(
                string.Format(
                    "http://149.210.154.147:8081/api/{0}/?cmd=shows",
                    Properties.Settings.Default.SBKey
                )
            )).ReadToEnd();

            Regex OverviewHandler = new Regex("\"[0-9]{1,6}\": {?[^}]*}[^}]*}");
            Regex OverheadCutter = new Regex("{[^}]*}[^}]*}");

            List<Overview> shows = new List<Overview>();
            foreach (Match s in OverviewHandler.Matches(response))
            {
                var output = OverheadCutter.Match(s.Value).Value;
                shows.Add(JsonConvert.DeserializeAnonymousType<Overview>(output, new Overview()));
            }

            Session.Add("overviewObject", shows.ToArray());
        }
    }
}