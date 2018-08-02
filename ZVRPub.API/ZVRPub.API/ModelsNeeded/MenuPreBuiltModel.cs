using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZVRPub.API.ModelsNeeded
{
    public class MenuPreBuiltModel
    {
        public int Id { get; set; }
        public string NameOfMenu { get; set; }
        public decimal Price { get; set; }
        public bool TwentyOneOver { get; set; }
    }
}
