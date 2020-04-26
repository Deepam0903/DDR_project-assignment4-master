using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DDRProject.Models
{
    public class Time
    {
        public string timestart { get; set; }
        public string timeend { get; set; }
        public string sunsetend { get; set; }
        public string sunrisestart { get; set; }
    }
}