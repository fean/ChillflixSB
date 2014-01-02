using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SickBeard.Schedule.Models
{
    public class Show
    {
        public DateTime airdate { get; set; }
        public string airs { get; set; }
        public string ep_name { get; set; }
        public string ep_plot { get; set; }
        public int episode { get; set; }
        public string network { get; set; }
        public int paused { get; set; }
        public string quality { get; set; }
        public int season { get; set; }
        public string show_name { get; set; }
        public string show_status { get; set; }
        public long tvdbid { get; set; }
        public int weekday { get; set; }
    }
}