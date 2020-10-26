using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListWebApp.Models
{
    public class ShoppingCart
    {
        //public int Productid { get; set; }
        public string ProductName { get; set; }
        public string UnitDesc { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }

        //public List<Products> ShoppingListCart { get; set; } = new List<Products>();

        //public List<Products> ShoppingListCartPrices { get; set; } = new List<Products>();
        public List<Products> SelectListItem { get; set; } = new List<Products>();
        public List<AddtoList> ShoppingListCart { get; set; } = new List<AddtoList>();
    }

}
