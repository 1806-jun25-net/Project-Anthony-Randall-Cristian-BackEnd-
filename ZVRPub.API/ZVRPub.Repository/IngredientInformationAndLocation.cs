using System;
using System.Collections.Generic;
using System.Text;

namespace ZVRPub.Library.Model
{
    public class IngredientInformationAndLocation
    {
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int InventoryId { get; set; }
        public int Quantity { get; set; }
        public string IngredientName { get; set; }
    }
}
