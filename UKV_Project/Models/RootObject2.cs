using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DDRProject.Models
{
    public class RootObject2
    {
        public string total { get; set; }
        public List<Datum2> data { get; set; }
        public string limit { get; set; }
        public string start { get; set; }
    }
}