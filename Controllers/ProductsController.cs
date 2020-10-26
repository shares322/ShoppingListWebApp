using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingListWebApp.Context;
using ShoppingListWebApp.Models;


namespace ShoppingListWebApp.Controllers
{
    public class ProductsController : Controller
    {
        public ShoppingCart shoppingCart { get; set; }
        public string product { get; set; }
        public decimal[] Prices { get; private set; }
        public AddtoList productName { get; set; }

        private readonly ShoppingCartContext _context;
       

        public ProductsController(ShoppingCartContext context)
        {
            _context = context;
            //shoppingCart = new ShoppingCart();
        }

        // Add to List
        public IActionResult AddtoList()
        {
            ////use the context to get list of product names
            var productNames = _context.Products.Select(p => p.ProductName).ToList();
            var productNameSelectItems = new List<SelectListItem>();
            foreach (var productName in productNames)
            {
                productNameSelectItems.Add(new SelectListItem(productName, productName));
            }
            //throw this to something that we can also use in the view for reference
            ViewData["ProductNames"] = productNameSelectItems;
            return View();
        }


        //Add to cart
        public IActionResult ShoppingCart(AddtoList addtoList)
        {
           
            ShoppingCart shoppingCart = new ShoppingCart();
            shoppingCart.ShoppingListCart = new List<AddtoList>();
            var products = _context.Products.Find(addtoList.Productid);
            addtoList.SelectListItem.Add(products);

            shoppingCart.ShoppingListCart.Add(addtoList);
            shoppingCart.Price += shoppingCart.Price;

            return View(shoppingCart);
        }

        //[HttpPost]
        ////Checkout Cart
        //public async Task<IActionResult> CheckoutCart(ShoppingCart shoppingCart)
        //{
        //    //use the context to get list of product names
        //    var checkoutCart = new CheckoutCart();
        //    checkoutCart.CheckoutCartList = shoppingCart.ShoppingListCart;
        //    checkoutCart.Total = shoppingCart.Total;
        //    checkoutCart.Tax = Decimal.Multiply(checkoutCart.Total, (decimal)0.06);
        //    checkoutCart.GrandTotal = Decimal.Add(checkoutCart.Total, checkoutCart.Tax);
        //    return View("CheckoutCart");
        //}

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Productid == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Productid,ProductName,UnitDesc,Price")] Products products)
        {
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.FindAsync(id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Productid,ProductName,UnitDesc,Price")] Products products)
        {
            if (id != products.Productid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.Productid))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products
                .FirstOrDefaultAsync(m => m.Productid == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.FindAsync(id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.Productid == id);
        }
    }
}
