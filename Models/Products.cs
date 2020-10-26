using System;
using System.Collections.Generic;

namespace ShoppingListWebApp.Models
{
    public partial class Products
    {
        public int Productid { get; set; }
        public string ProductName { get; set; }
        public string UnitDesc { get; set; }
        public decimal Price { get; set; }
    }
}
