using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListWebApp.Models
{
    public class CheckoutCart
    {
        //public int Productid { get; set; }
        public string ProductName { get; set; }
        public string UnitDesc { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
        public decimal Tax { get; set; }
        public decimal GrandTotal { get; set; }


        public List<Products> CheckoutCartList { get; set; } = new List<Products>();
    }
}
