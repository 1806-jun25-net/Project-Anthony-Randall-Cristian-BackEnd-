using System;
using System.Collections.Generic;

namespace ZVRPub.Scaffold
{
    public partial class MenuCustomHasOrders
    {
        public int Id { get; set; }
        public int CustomPreBuildId { get; set; }
        public int OrdersId { get; set; }

        public Orders Orders { get; set; }
    }
}
