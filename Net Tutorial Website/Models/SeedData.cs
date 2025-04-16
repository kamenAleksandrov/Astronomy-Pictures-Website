using Microsoft.EntityFrameworkCore;
using Net_Tutorial_Website.Data;

namespace Net_Tutorial_Website.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) {

            using (var context = new Net_Tutorial_WebsiteContext(serviceProvider.GetRequiredService<DbContextOptions<Net_Tutorial_WebsiteContext>>())) {

         
            }
        }
    }
}
