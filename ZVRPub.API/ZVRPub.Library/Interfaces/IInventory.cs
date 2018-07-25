using System;
using System.Collections.Generic;
using System.Text;

namespace ZVRPub.Library.Interfaces
{
    interface IInventory
    {
         int Id { get; set; }
         string IngredientName { get; set; }
         string IngredientType { get; set; }
         decimal Price { get; set; }

    }
}
