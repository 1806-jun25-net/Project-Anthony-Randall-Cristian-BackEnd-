using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.API.ModelsNeeded
{
    public class UserHasPreBuildMenuAndInvModel
    {
        public ICollection<OrderModel> Order { get; set; }
        public ICollection<UserModel> User { get; set; }
        public ICollection<MenuPreBuiltModel> PreBuilt { get; set; }
        public ICollection<MenuPreBuiltHasInventoryModel> PreBuiltHasInv { get; set; }
        public ICollection<MenuPrebuiltHasOrdersModel> PreBuiltHasOrder { get; set; }
        public ICollection<InventoryModel> Inventories { get; set; }
        public ICollection<LocationModel> Location { get; set; }
    }
}
