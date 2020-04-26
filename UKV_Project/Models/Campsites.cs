using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DDRProject.Models
{
    public class Campsites
    {
        public string other { get; set; }
        public string group { get; set; }
        public string horse { get; set; }
        public string totalsites { get; set; }
        public string tentonly { get; set; }
        public string electricalhookups { get; set; }
        public string rvonly { get; set; }
        public string walkboatto { get; set; }
    }

}