using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Net_Tutorial_Website.Models;
using System.Collections.Generic;
using Net_Tutorial_Website.Migrations;

namespace Net_Tutorial_Website.Helpers
{
    public static class CookieHelper
    {
        public static void SetCart(HttpContext context, List<Cart_item> cart)
        {
            var options = new CookieOptions
            {
                Expires = DateTimeOffset.Now.AddDays(7),
                IsEssential = true
            };

            var cartJson = JsonSerializer.Serialize(cart);
            context.Response.Cookies.Append("Cart", cartJson, options);
        }

        public static List<Cart_item> GetCart(HttpContext context)
        {
            if (context.Request.Cookies.TryGetValue("Cart", out var cartJson))
            {
                return JsonSerializer.Deserialize<List<Cart_item>>(cartJson) ?? new List<Cart_item>();
            }

            return new List<Cart_item>();
        }

        public static void ClearCart(HttpContext context)
        {
            context.Response.Cookies.Delete("Cart");
        }

    }
}
