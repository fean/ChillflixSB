using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SickBeard.Schedule.Models
{
    public class SearchResult
    {
        public Nullable<DateTime> first_aired { get; set; }
        public string name { get; set; }
        public long tvdbid { get; set; }
    }
}