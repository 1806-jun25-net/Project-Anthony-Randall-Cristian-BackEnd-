using System;
using System.Collections.Generic;

namespace ZVRPub.API
{
    public partial class LocationOrderProcess
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int OrderId { get; set; }

        public Locations Location { get; set; }
        public Orders Order { get; set; }
    }
}
