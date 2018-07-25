using System;
using System.Collections.Generic;
using System.Text;
using ZVRPub.Scaffold;

namespace ZVRPub.Library.Interfaces
{
    interface IInventoryHasLocation
    {
        int Id { get; set; }
        int LocationId { get; set; }
        int InventoryId { get; set; }
        int Quantity { get; set; }

        Inventory Inventory { get; set; }
        Locations Location { get; set; }

    }
}
