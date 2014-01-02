using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;
using System.Globalization;
using System.Web.Mvc;
using Newtonsoft.Json;
using SickBeard.Schedule.Models;
using System.Text.RegularExpressions;

namespace SickBeard.Schedule.Controllers
{
    [Authorize()]
    public class ScheduleController : Controller
    {
        public ActionResult Index()
        {
            return Redirect("/Schedule");
        }

        public ActionResult Overview()
        {
            return View(Session["overviewObject"]);
        }

        public ActionResult Schedule()
        {
            return View((ScheduleAPIResult)Session["scheduleObject"]);
        }

        public ActionResult Request()
        {
            return View();
        }

        [HttpPost()]
        public ActionResult Request(SearchEntry entry)
        {
            var response = new StreamReader(
                new WebClient().OpenRead(
                    string.Format(
                        "http://149.210.154.147:8081/api/{0}/?cmd=sb.searchtvdb&name={1}&lang=en",
                        Properties.Settings.Default.SBKey,
                        entry.query
                    )
                )
            ).ReadToEnd();

            response = new Regex("\\[(?<=\\[)(.*?)(?=\\])\\]", RegexOptions.Singleline).Match(response).Value;
            var result = JsonConvert.DeserializeAnonymousType<SearchResult[]>(response, new SearchResult[] { });

            entry.results = result;

            return View(entry);
        }

        public ActionResult Add(Nullable<long> id)
        {
            if (id.HasValue)
            {
                var response = new StreamReader(
                    new WebClient().OpenRead(
                        string.Format(
                            "http://149.210.154.147:8081/api/{0}/?cmd=show.addnew&tvdbid={1}",
                            Properties.Settings.Default.SBKey,
                            id.Value
                        )
                    )
                ).ReadToEnd();

                response = new Regex("(success|failure)").Match(response).Value;

                return View(new String[] { response });
            }
            else
            {
                return View(new String[] { "failed" });
            }

        }

        [OutputCache(Duration = 604800, VaryByParam = "id")]
        public ActionResult GetBanner(Nullable<long> id)
        {
            if (id != null)
            {
                var response = new MemoryStream();
                new WebClient().OpenRead(
                    string.Format(
                        "http://149.210.154.147:8081/api/{0}/?cmd=show.getbanner&tvdbid={1}",
                         Properties.Settings.Default.SBKey,
                         id
                     )
                ).CopyTo(response);
                return File(response.ToArray(), "image/jpeg");
            }
            else
            {
                return Content("Parameter id is required and needs to be of the type Long/Int64.");
            }
        }

        [OutputCache(Duration = 604800, VaryByParam = "id")]
        public ActionResult GetPoster(Nullable<long> id)
        {
            if (id != null)
            {
                var response = new MemoryStream();
                new WebClient().OpenRead(
                    string.Format(
                        "http://149.210.154.147:8081/api/{0}/?cmd=show.getposter&tvdbid={1}",
                         Properties.Settings.Default.SBKey,
                         id
                     )
                ).CopyTo(response);
                return File(response.ToArray(), "image/jpeg");
            }
            else
            {
                return Content("Parameter id is required and needs to be of the type Long/Int64.");
            }
        }

    }
}
