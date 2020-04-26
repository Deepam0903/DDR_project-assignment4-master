using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DDRProject.Models
{
    public class Accessibility
    {
        public string wheelchairaccess { get; set; }
        public string internetinfo { get; set; }
        public string rvallowed { get; set; }
        public string cellphoneinfo { get; set; }
        public string firestovepolicy { get; set; }
        public string rvmaxlength { get; set; }
        public string additionalinfo { get; set; }
        public string trailermaxlength { get; set; }
        public string adainfo { get; set; }
        public string rvinfo { get; set; }
        public List<string> accessroads { get; set; }
        public string Trailerallowed { get; set; }
        public List<string> classifications { get; set; }
    }
}