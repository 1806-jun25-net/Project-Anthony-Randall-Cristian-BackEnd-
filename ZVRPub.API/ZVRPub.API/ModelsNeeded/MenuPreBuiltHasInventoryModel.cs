using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.API.ModelsNeeded
{
    public class MenuPreBuiltHasInventoryModel
    {
        public int Id { get; set; }
        public int MenuPreBuildId { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
    }
}
