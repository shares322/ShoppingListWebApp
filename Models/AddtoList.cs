using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingListWebApp.Models
{
    public class AddtoList
    {
        public int Productid { get; set; }
        public string ProductName { get; set; }

        public int Price { get; set; }

        public List<Products> SelectListItem { get; set; } = new List<Products>();
    }
}
