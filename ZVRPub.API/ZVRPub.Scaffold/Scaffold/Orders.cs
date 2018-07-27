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
            MenuPrebuiltHasOrders = new HashSet<MenuPrebuiltHasOrders>();
        }

        public int OrderId { get; set; }
        public DateTime OrderTime { get; set; } = DateTime.Now;
        public int LocationId { get; set; }
        public int UserId { get; set; }

        public Users User { get; set; }
        public ICollection<LocationOrderProcess> LocationOrderProcess { get; set; }
        public ICollection<MenuCustom> MenuCustom { get; set; }
        public ICollection<MenuPrebuiltHasOrders> MenuPrebuiltHasOrders { get; set; }
    }
}