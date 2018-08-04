using System;
using System.Collections.Generic;

namespace ZVRPub.Scaffold
{
    public partial class Orders
    {
        public Orders()
        {
            LocationOrderProcess = new HashSet<LocationOrderProcess>();
            MenuCustom = new HashSet<MenuCustom>();
            MenuCustomHasOrders = new HashSet<MenuCustomHasOrders>();
            MenuPrebuiltHasOrders = new HashSet<MenuPrebuiltHasOrders>();
        }

        public int OrderId { get; set; }
        public DateTime? OrderTime { get; set; }
        public int LocationId { get; set; }
        public int UserId { get; set; }
        public decimal? Cost { get; set; }

        public Users User { get; set; }
        public ICollection<LocationOrderProcess> LocationOrderProcess { get; set; }
        public ICollection<MenuCustom> MenuCustom { get; set; }
        public ICollection<MenuCustomHasOrders> MenuCustomHasOrders { get; set; }
        public ICollection<MenuPrebuiltHasOrders> MenuPrebuiltHasOrders { get; set; }
    }
}
