using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Net_Tutorial_Website.Data;
using Net_Tutorial_Website.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Net_Tutorial_Website.Helpers;

namespace Net_Tutorial_Website.Pages.Canvases
{
    public class IndexModel : PageModel
    {
        private readonly Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext _context;

        public IndexModel(Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext context)
        {
            _context = context;
        }

        public IList<Canvas> Canvas { get; set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string CanvasGenre { get; set; }

        [BindProperty(SupportsGet = true)]
        public string AddToCart { get; set; }

        public async Task OnGetAsync()
        {
            //string title = "";
            //decimal price = 0;
            //string imagePath = "";
            //this is the search field function
            var canvas = from m in _context.Canvas select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                canvas = canvas.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(AddToCart))
            {
                var canvasItem = await canvas.FirstOrDefaultAsync(t => t.Title.Contains(AddToCart));

                if (canvasItem != null)
                {
                    var cart = CookieHelper.GetCart(HttpContext);

                    var existingItem = cart.FirstOrDefault(c => c.ID == canvasItem.ID);

                    if (existingItem != null)
                    {
                        existingItem.Quantity += 1;
                    }
                    else
                    {
                        cart.Add(new Cart_item
                        {
                            ID = canvasItem.ID,
                            Title = canvasItem.Title,
                            Price = canvasItem.Price,
                            ImagePath = canvasItem.ImagePath,
                            Quantity = 1
                        });
                    }

                    CookieHelper.SetCart(HttpContext, cart);
                }
            }

            //this adds the selected item to the cart
            //could be usefull if i implement user accounts
            //since its better to save the cart in the database
            //so the user can access it from any device
            //if (!string.IsNullOrEmpty(AddToCart))
            //{
            //    var canvasToCart = canvas.Where(t => t.Title.Contains(AddToCart));

            //    foreach (var canvasItem in canvasToCart)
            //    {
            //        title = canvasItem.Title;
            //        price = canvasItem.Price;
            //        imagePath = canvasItem.ImagePath;

            //    }

            //    var cart = new Cart_item()
            //    {
            //        Title = title,
            //        Price = price,
            //        ImagePath = imagePath
            //    };
            //    _context.Cart.Add(cart);
            //    await _context.SaveChangesAsync();
            //}

            Canvas = await canvas.ToListAsync();

        }
    }
}
