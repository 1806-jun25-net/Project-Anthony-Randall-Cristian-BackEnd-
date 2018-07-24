using System;
using System.Collections.Generic;

namespace ZVRPub.Scaffold
{
    public partial class MenuCustom
    {
        public MenuCustom()
        {
            MenuCustomHasIventory = new HashSet<MenuCustomHasIventory>();
        }

        public int Id { get; set; }
        public string NameOfCustomMenu { get; set; }
        public int IdOrders { get; set; }

        public Orders IdOrdersNavigation { get; set; }
        public ICollection<MenuCustomHasIventory> MenuCustomHasIventory { get; set; }
    }
}
