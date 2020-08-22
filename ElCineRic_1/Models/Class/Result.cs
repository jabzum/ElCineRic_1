using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElCineRic_1.Models.Class
{
    public class Result
    {
        public string profile_path { get; set; }
        public bool adult { get; set; }
        public int id { get; set; }
        public List<KnownFor> known_for { get; set; }
        public string name { get; set; }
        public double popularity { get; set; }
    }
}