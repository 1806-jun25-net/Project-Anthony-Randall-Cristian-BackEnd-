using System;
using System.Collections.Generic;

namespace ZVRPub.API
{
    public partial class MenuPrebuiltHasOrders
    {
        public int Id { get; set; }
        public int MenuPreBuildId { get; set; }
        public int OrdersId { get; set; }

        public Orders Orders { get; set; }
    }
}
