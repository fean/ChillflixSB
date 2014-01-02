using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SickBeard.Schedule.Models
{
    public class ScheduleData
    {
        public Show[] today { get; set; }
        public Show[] soon { get; set; }
        public Show[] later { get; set; }
        public Show[] missed { get; set; }
    }
}