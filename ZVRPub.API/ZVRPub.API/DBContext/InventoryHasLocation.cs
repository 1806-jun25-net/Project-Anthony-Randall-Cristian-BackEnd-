using System;
using System.Collections.Generic;

namespace ZVRPub.API
{
    public partial class InventoryHasLocation
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }

        public Inventory Inventory { get; set; }
        public Locations Location { get; set; }
    }
}
