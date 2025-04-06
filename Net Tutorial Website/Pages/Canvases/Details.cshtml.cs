using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Net_Tutorial_Website.Data;
using Net_Tutorial_Website.Models;

namespace Net_Tutorial_Website.Pages.Canvases
{
    public class DetailsModel : PageModel
    {
        private readonly Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext _context;

        public DetailsModel(Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext context)
        {
            _context = context;
        }

        public Canvas Canvas { get; set; } = default!;

        [BindProperty(SupportsGet = true)]
        public string AddToCart { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            string title = "";
            decimal price = 0;
            string imagePath = "";

            if (id == null || _context.Canvas == null)
            {
                return NotFound();
            }

            var canvas = await _context.Canvas.FirstOrDefaultAsync(m => m.ID == id);
            if (canvas == null)
            {
                return NotFound();
            }
            else
            {
                Canvas = canvas;
            }
            var canvasList = from m in _context.Canvas select m;
            if (!string.IsNullOrEmpty(AddToCart))
            {
                var canvasToCart = canvasList.Where(t => t.Title.Contains(AddToCart));

                foreach (var movie in canvasToCart)
                {
                    title = movie.Title;
                    price = movie.Price;
                    imagePath = movie.ImagePath;

                }

                var cart = new Cart()
                {
                    Title = title,
                    Price = price,
                    ImagePath = imagePath
                };
                _context.Cart.Add(cart);
                await _context.SaveChangesAsync();
            }

            return Page();
        }
    }
}
