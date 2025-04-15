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
    public class DetailsModel : PageModel
    {
        private readonly Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext _context;

        public DetailsModel(Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext context)
        {
            _context = context;
        }

      public Cart_item Cart { get; set; } = default!;

        public void OnGet(int? id)
        {
            if (id != null)
            {
                // Get the cart item from cookies
                Cart = CookieHelper.GetCart(HttpContext).FirstOrDefault(c => c.ID == id);

                // If no cart item is found, redirect to the index
                if (Cart == null)
                {
                    RedirectToPage("./Index");
                }
            }
        }

        //below code works with database
        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null || _context.Cart == null)
        //    {
        //        return NotFound();
        //    }

        //    var cart = await _context.Cart.FirstOrDefaultAsync(m => m.ID == id);
        //    if (cart == null)
        //    {
        //        return NotFound();
        //    }
        //    else 
        //    {
        //        Cart = cart;
        //    }
        //    return Page();
        //}
    }
}
