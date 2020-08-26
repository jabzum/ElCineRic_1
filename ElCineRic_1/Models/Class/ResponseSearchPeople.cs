using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElCineRic_1.Models.Class
{
    public class ResponseSearchPeople
    {
        public int page { get; set; }
        public List<Result> results { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
    }
}