using System;
using System.Collections.Generic;

namespace ZVRPub.Scaffold
{
    public partial class Inventory
    {
        public Inventory()
        {
            InventoryHasLocation = new HashSet<InventoryHasLocation>();
            MenuCustomHasIventory = new HashSet<MenuCustomHasIventory>();
            MenuPreBuiltHasInventory = new HashSet<MenuPreBuiltHasInventory>();
        }

        public int Id { get; set; }
        public string IngredientName { get; set; }
        public string IngredientType { get; set; }
        public decimal Price { get; set; }

        public ICollection<InventoryHasLocation> InventoryHasLocation { get; set; }
        public ICollection<MenuCustomHasIventory> MenuCustomHasIventory { get; set; }
        public ICollection<MenuPreBuiltHasInventory> MenuPreBuiltHasInventory { get; set; }
    }
}
