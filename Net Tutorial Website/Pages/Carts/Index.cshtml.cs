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
