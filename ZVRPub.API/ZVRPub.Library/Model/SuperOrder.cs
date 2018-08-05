using System;
using System.Collections.Generic;
using System.Text;

namespace ZVRPub.Library.Model
{
    public class SuperOrder
    {
        public string user { get; set; }
        public DateTime orderTime { get; set; }
        public decimal? cost { get; set; }
        public string location { get; set; }
        public List<string> items { get; set; }
    }
}
