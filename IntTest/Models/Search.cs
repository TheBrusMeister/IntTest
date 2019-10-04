using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntTest.Models.Enums;

namespace IntTest.Models
{
    public class Search
    {
        public string Keyword { get; set; }
        public string Location { get; set; }
        public Radius? Radius { get; set; }
        public SearchType SearchType { get; set; }
    }
}
