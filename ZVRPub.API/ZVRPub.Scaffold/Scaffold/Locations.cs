using System;
using System.Collections.Generic;

namespace ZVRPub.Scaffold
{
    public partial class Locations
    {
        public Locations()
        {
            InventoryHasLocation = new HashSet<InventoryHasLocation>();
            LocationOrderProcess = new HashSet<LocationOrderProcess>();
        }

        public int Id { get; set; }
        public string StreetAddress { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string States { get; set; }

        public ICollection<InventoryHasLocation> InventoryHasLocation { get; set; }
        public ICollection<LocationOrderProcess> LocationOrderProcess { get; set; }
    }
}
