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
    public class IndexModel : PageModel
    {
        private readonly Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext _context;

        public IndexModel(Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext context)
        {
            _context = context;
        }

        public IList<Cart> Cart { get;set; } = default!;

        //[BindProperty(SupportsGet = true)]
        //public string totalPrice { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Cart != null)
            {
                Cart = await _context.Cart.ToListAsync();
            }

            //var cartItem = from m in _context.Cart select m;
            //decimal priceTotal = 0;
            //foreach (var item in cartItem)
            //{
            //    priceTotal += item.Price;
  
            //}

        }
    }
}
