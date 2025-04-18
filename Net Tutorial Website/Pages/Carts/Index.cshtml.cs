using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Net_Tutorial_Website.Data;
using Net_Tutorial_Website.Helpers;
using Net_Tutorial_Website.Models;

namespace Net_Tutorial_Website.Pages.Carts
{
    public class IndexModel : PageModel
    {
        private readonly Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext _context;

        public IndexModel(Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext context)
        {
            _context = context;
        }

        public IList<Cart_item> Cart { get;set; } = default!;

        //this increases item quantity
        //public IActionResult OnPostIncrease(int id)
        //{
        //    var cart = CookieHelper.GetCart(HttpContext);
        //    var item = cart.FirstOrDefault(c => c.ID == id);
        //    if (item != null)
        //    {
        //        item.Quantity += 1;
        //        CookieHelper.SetCart(HttpContext, cart);
        //    }
        //    return RedirectToPage();
        //}

        ////this decreases item quantity
        //public IActionResult OnPostDecrease(int id)
        //{
        //    var cart = CookieHelper.GetCart(HttpContext);
        //    var item = cart.FirstOrDefault(c => c.ID == id);
        //    if (item != null)
        //    {
        //        if (item.Quantity > 1)
        //        {
        //            item.Quantity -= 1;
        //        }
        //        else
        //        {
        //            cart.Remove(item);
        //        }
        //        CookieHelper.SetCart(HttpContext, cart);
        //    }
        //    return RedirectToPage();
        //}

        public JsonResult OnPostIncreaseAjax(int id)
        {
            var cart = CookieHelper.GetCart(HttpContext);
            var item = cart.FirstOrDefault(c => c.ID == id);
            if (item != null)
            {
                item.Quantity += 1;
                CookieHelper.SetCart(HttpContext, cart);
                return new JsonResult(new
                {
                    quantity = item.Quantity,
                    itemTotal = item.Price * item.Quantity,
                    cartTotal = cart.Sum(x => x.Price * x.Quantity)
                });
            }
            return new JsonResult(new { error = true });
        }

        public JsonResult OnPostDecreaseAjax(int id)
        {
            var cart = CookieHelper.GetCart(HttpContext);
            var item = cart.FirstOrDefault(c => c.ID == id);
            if (item != null)
            {
                if (item.Quantity > 1)
                {
                    item.Quantity -= 1;
                }
                else
                {
                    cart.Remove(item);
                }

                CookieHelper.SetCart(HttpContext, cart);
                return new JsonResult(new
                {
                    quantity = item.Quantity,
                    itemTotal = item.Price * item.Quantity,
                    cartTotal = cart.Sum(x => x.Price * x.Quantity),
                    removed = item.Quantity == 0
                });
            }
            return new JsonResult(new { error = true });
        }

        public IActionResult OnPostClearCart()
        {
            // Clear the cart by saving an empty list to cookies
            CookieHelper.ClearCart(HttpContext);
            return RedirectToPage(); // Refresh the page
        }

        //[BindProperty(SupportsGet = true)]
        //public string totalPrice { get; set; }

        //this gets cart items from the database
        //public async Task OnGetAsync()
        //{
        //    if (_context.Cart != null)
        //    {
        //        Cart = await _context.Cart.ToListAsync();
        //    }

        //}
        public void OnGet()
        {
            Cart = CookieHelper.GetCart(HttpContext);
        }
    }
}
