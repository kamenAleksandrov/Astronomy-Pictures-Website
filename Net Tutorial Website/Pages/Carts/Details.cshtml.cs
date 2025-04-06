using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Net_Tutorial_Website.Data;
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

      public Cart Cart { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cart == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FirstOrDefaultAsync(m => m.ID == id);
            if (cart == null)
            {
                return NotFound();
            }
            else 
            {
                Cart = cart;
            }
            return Page();
        }
    }
}
