using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DDRProject.Models
{
    public class Datum2
    {
        public string regulationsurl { get; set; }
        public string weatheroverview { get; set; }
        public Campsites campsites { get; set; }
        public Accessibility accessibility { get; set; }
        public string directionsoverview { get; set; }
        public string reservationsurl { get; set; }
        public string directionsUrl { get; set; }
        public string reservationssitesfirstcome { get; set; }
        public string name { get; set; }
        public string regulationsoverview { get; set; }
        public string latLong { get; set; }
        public string description { get; set; }
        public string reservationssitesreservable { get; set; }
        public string parkCode { get; set; }
        public Amenities amenities { get; set; }
        public string id { get; set; }
        public string reservationsdescription { get; set; }
    }
}