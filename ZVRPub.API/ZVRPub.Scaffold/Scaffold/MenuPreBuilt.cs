using System;
using System.Collections.Generic;

namespace ZVRPub.Scaffold
{
    public partial class MenuPreBuilt
    {
        public MenuPreBuilt()
        {
            MenuPreBuiltHasInventory = new HashSet<MenuPreBuiltHasInventory>();
        }

        public int Id { get; set; }
        public string NameOfMenu { get; set; }
        public decimal Price { get; set; }
        public bool TwentyOneOver { get; set; }

        public ICollection<MenuPreBuiltHasInventory> MenuPreBuiltHasInventory { get; set; }
    }
}
