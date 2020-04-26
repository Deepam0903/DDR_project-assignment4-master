using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DDRProject.Models
{
    public class RootObject
    {
        public string total { get; set; }
        public List<object> errors { get; set; }
        public List<Datum> data { get; set; }
        public string dates { get; set; }
        public string pagenumber { get; set; }
        public string pagesize { get; set; }
    }
}