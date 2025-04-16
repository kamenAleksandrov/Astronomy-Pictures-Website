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
    public class DeleteModel : PageModel
    {
        private readonly Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext _context;

        public DeleteModel(Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Cart_item Cart { get; set; } = default!;

        public void OnGet(int? id)
        {
            if (id != null)
            {
                var cart = CookieHelper.GetCart(HttpContext).FirstOrDefault(c => c.ID == id);
                if (cart != null)
                {
                    Cart = cart; // Displaying the cart item for confirmation (optional)
                }
            }
        }

        public IActionResult OnPost(int? id)
        {
            if (id != null)
            {
                // Get current cart from cookies
                var cart = CookieHelper.GetCart(HttpContext);

                // Remove the item with the matching ID
                var itemToRemove = cart.FirstOrDefault(c => c.ID == id);
                if (itemToRemove != null)
                {
                    if (itemToRemove.Quantity > 1)
                    {
                        itemToRemove.Quantity -= 1;
                    }
                    else
                    {
                        cart.Remove(itemToRemove);
                    }
                    // Save updated cart to cookies
                    CookieHelper.SetCart(HttpContext, cart);
                }
            }

            return RedirectToPage("./Index"); // Redirect to cart view page
        }

        //the code below works with the database
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

        //public async Task<IActionResult> OnPostAsync(int? id)
        //{
        //    if (id == null || _context.Cart == null)
        //    {
        //        return NotFound();
        //    }
        //    var cart = await _context.Cart.FindAsync(id);

        //    if (cart != null)
        //    {
        //        Cart = cart;
        //        _context.Cart.Remove(Cart);
        //        await _context.SaveChangesAsync();
        //    }

        //    return RedirectToPage("./Index");
        //}
    }
}
