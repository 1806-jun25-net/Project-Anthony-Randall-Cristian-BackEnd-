using System;
using System.Collections.Generic;
using System.Text;

namespace ZVRPub.Library.Model
{
    public class BigOrder
    {
        public string user { get; set; }
        public string Location { get; set; }

        public DateTime OrderTime { get; set; }

        public bool wrap { get; set; }
        public int QuantityWrap { get; set; }
        public bool burger { get; set; }
        public int QuantityBurger { get; set; }
        public bool Taco { get; set; }
        public int QuantityTaco { get; set; }
        public bool Draft_Beer { get; set; }
        public int QuantityDraft_Beer { get; set; }
        public bool CockTail { get; set; }
        public int QuantityCocktail { get; set; }
        public string Custom_Burger { get; set; }
        public int QuantityOfBurger { get; set; }

        public bool CustomBurgerYes { get; set; }
        
        public string ingredient { get; set; }

        public string ingredient1 { get; set; }

        public string ingredient2 { get; set; }

        public string ingredient3 { get; set; }

        public string ingredient4 { get; set; }

    }
}
