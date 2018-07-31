using System;
using System.Collections.Generic;
using System.Text;

namespace ZVRPub.Library.Model
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderTime { get; set; }
        public string Location { get; set; }
        public int UserId { get; set; }

    }
}