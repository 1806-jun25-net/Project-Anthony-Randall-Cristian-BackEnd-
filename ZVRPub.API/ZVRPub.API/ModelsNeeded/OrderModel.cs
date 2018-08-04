using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.API.ModelsNeeded
{
    public class OrderModel
    {

        public int OrderId { get; set; }
        public DateTime OrderTime { get; set; }
        public int LocationId { get; set; }
        public int UserId { get; set; }

    }
}
