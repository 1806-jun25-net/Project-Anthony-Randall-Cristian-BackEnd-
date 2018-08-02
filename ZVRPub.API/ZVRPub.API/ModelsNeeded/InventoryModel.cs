using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.API.ModelsNeeded
{
    public class InventoryModel
    {
        public int Id { get; set; }
        public string IngredientName { get; set; }
        public string IngredientType { get; set; }
        public decimal Price { get; set; }
    }
}
