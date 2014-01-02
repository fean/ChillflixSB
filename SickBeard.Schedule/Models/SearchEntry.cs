using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SickBeard.Schedule.Models
{
    public class SearchEntry
    {
        public string query { get; set; }
        public SearchResult[] results { get; set; }
    }
}