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
    public class DeleteModel : PageModel
    {
        private readonly Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext _context;

        public DeleteModel(Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Canvas Canvas { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Canvas == null)
            {
                return NotFound();
            }
            var canvas = await _context.Canvas.FindAsync(id);

            if (canvas != null)
            {
                Canvas = canvas;
                _context.Canvas.Remove(Canvas);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
