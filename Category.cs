using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopsCLI
{
    internal class Category
    {
        public int CategoryCode { get; set; }
        public string CategoryName { get; set; }

        public Category(int categoryCode, string categoryName)
        {
            CategoryCode = categoryCode;
            CategoryName = categoryName;
        }
    }
}
