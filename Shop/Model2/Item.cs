using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Shop.Model2
{
    public class Item
    {
        public decimal Price;
        public string Name;

        public override string ToString()
        {
            return $"{Name} {Price}";
        }
    }
}
