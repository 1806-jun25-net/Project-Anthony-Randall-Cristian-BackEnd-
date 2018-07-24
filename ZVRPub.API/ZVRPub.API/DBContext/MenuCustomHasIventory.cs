using System;
using System.Collections.Generic;

namespace ZVRPub.API
{
    public partial class MenuCustomHasIventory
    {
        public int Id { get; set; }
        public int IdInventory { get; set; }
        public int IdMenuCustom { get; set; }

        public Inventory IdInventoryNavigation { get; set; }
        public MenuCustom IdMenuCustomNavigation { get; set; }
    }
}
