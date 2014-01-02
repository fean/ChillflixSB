using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SickBeard.Schedule.Models
{
    public class ScheduleAPIResult
    {
        public ScheduleData data { get; set; }
        public string message { get; set; }
        public string result { get; set; }
    }
}