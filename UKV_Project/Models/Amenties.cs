using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DDRProject.Models
{
    public class Amenities
    {
        public string trashrecyclingcollection { get; set; }
        public List<string> toilets { get; set; }
        public string internetconnectivity { get; set; }
        public List<string> showers { get; set; }
        public string cellphonereception { get; set; }
        public string laundry { get; set; }
        public string amphitheater { get; set; }
        public string dumpstation { get; set; }
        public string campstore { get; set; }
        public string stafforvolunteerhostonsite { get; set; }
        public List<string> potablewater { get; set; }
        public string iceavailableforsale { get; set; }
        public string firewoodforsale { get; set; }
        public string ampitheater { get; set; }
        public string foodstoragelockers { get; set; }
    }
}