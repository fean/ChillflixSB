using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SickBeard.Schedule.Models
{
    public class Overview
    {
        public byte air_by_date { get; set; }
        public CacheItems cache { get; set; }
        public string language { get; set; }
        public string network { get; set; }
        public Nullable<DateTime> next_ep_airdate { get; set; }
        public byte paused { get; set; }
        public string quality { get; set; }
        public string show_name { get; set; }
        public string status { get; set; }
        public long tvdbid { get; set; }
        public Int32 tvrage_id { get; set; }
        public string tvrage_name { get; set; }
    }
}