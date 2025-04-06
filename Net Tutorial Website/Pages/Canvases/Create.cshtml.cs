using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Net_Tutorial_Website.Data;
using Net_Tutorial_Website.Models;

namespace Net_Tutorial_Website.Pages.Canvases
{
    public class CreateModel : PageModel
    {
        private readonly Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext _context;
        private readonly IWebHostEnvironment _hostenvironment;

        public CreateModel(Net_Tutorial_Website.Data.Net_Tutorial_WebsiteContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _hostenvironment = webHostEnvironment;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Canvas Canvas { get; set; } = default!;
        [BindProperty]
        public FileViewModel FileUpload { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            //if (!ModelState.IsValid /*|| _context.Canvas == null || Canvas == null*/)
            //{
            //    return Page();
            //}

            if (FileUpload.FormFile.Length > 0)
            {
                using (var stream = new FileStream(Path.Combine(_hostenvironment.WebRootPath,
                    "Images", FileUpload.FormFile.FileName), FileMode.Create))
                {
                    await FileUpload.FormFile.CopyToAsync(stream);
                }
            }
            //save image to database.
            using (var memoryStream = new MemoryStream())
            {
                await FileUpload.FormFile.CopyToAsync(memoryStream);

                string folderName = "Images";

                var file = new Canvas()
                {
                    Title = Canvas.Title,
                    Info = Canvas.Info,
                    Price = Canvas.Price,
                    ImagePath = folderName + "/" + FileUpload.FormFile.FileName.ToString()  /*Path.Combine(_hostenvironment.WebRootPath,"Images", FileUpload.FormFile.FileName)*//*Path.Combine("D:/OneDrive/Personal_Projects/Random/Net Tutorial Website/Net Tutorial Website/wwwroot/Images/", FileUpload.FormFile.FileName.ToString())*/    /*FileUpload.FormFile.FileName.ToString()*/

                };

                    _context.Canvas.Add(file);
                    await _context.SaveChangesAsync();
               
            }

             //_context.Movie.Add(Movie);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
