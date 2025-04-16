using Microsoft.AspNetCore.Mvc.RazorPages;
using Net_Tutorial_Website.Helpers;
using Net_Tutorial_Website.Models;
using System.Collections.Generic;

namespace Net_Tutorial_Website.Pages.Shared
{
    public class _LayoutModel : PageModel
    {
        public int CartCount { get; set; }

        public void OnGet()
        {
            var cart = CookieHelper.GetCart(HttpContext);
            CartCount = cart?.Count ?? 0;
        }
    }
}
