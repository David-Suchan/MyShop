using Shop.Model2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Useful
{
    internal class ProductList
    {
        public static Item Skirt { get; set; } = new Item()
        {
            Name = "Skirt",
            Price = 19.99m,           
        };

        public static Item Slacks { get; set; } = new Item()
        {
            Name = "Slacks",
            Price = 29.99m,
        };

        public static Item GreenTshirt { get; set; } = new Item()
        {
            Name = "Green T-shirt",
            Price = 24.99m,
        };
    }
}
