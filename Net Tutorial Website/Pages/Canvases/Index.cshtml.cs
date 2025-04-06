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
            string title = "";
            decimal price = 0;
            string imagePath = "";
            //IQueryable<string> genreQuery = from m in _context.Canvas
            //                                orderby m.Genre
            //                                select m.Genre;
            var canvas = from m in _context.Canvas select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                canvas = canvas.Where(s => s.Title.Contains(SearchString));
            }
            //if (!string.IsNullOrEmpty(CanvasGenre))
            //{
            //    canvas = canvas.Where(x => x.Genre == CanvasGenre);
            //}
            //Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            if (!string.IsNullOrEmpty(AddToCart))
            {
                var canvasToCart = canvas.Where(t => t.Title.Contains(AddToCart));

                foreach (var canvasItem in canvasToCart)
                {
                    title = canvasItem.Title;
                    price = canvasItem.Price;
                    imagePath = canvasItem.ImagePath;

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

            Canvas = await canvas.ToListAsync();

        }

        //public async Task<IActionResult> OnPostAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return Page();
        //    }

        //    var canvas = await _context.Canvas.FindAsync(id);

        //    var cart = new Cart()
        //    {
        //        Title = canvas.Title,
        //        Price = canvas.Price,
        //        ImagePath = canvas.ImagePath
        //    };

        //    _context.Cart.Add(cart);
        //    await _context.SaveChangesAsync();

        //    return Page();
        //}
    }
}
