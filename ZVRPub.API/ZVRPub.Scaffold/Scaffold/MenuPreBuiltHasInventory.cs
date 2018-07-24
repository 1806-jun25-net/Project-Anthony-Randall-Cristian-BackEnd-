using System;
using System.Collections.Generic;

namespace ZVRPub.Scaffold
{
    public partial class MenuPreBuiltHasInventory
    {
        public int Id { get; set; }
        public int MenuPreBuildId { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }

        public Inventory Inventory { get; set; }
        public MenuPreBuilt MenuPreBuild { get; set; }
    }
}
