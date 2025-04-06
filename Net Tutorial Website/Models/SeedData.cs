using Microsoft.EntityFrameworkCore;
using Net_Tutorial_Website.Data;

namespace Net_Tutorial_Website.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) {

            using (var context = new Net_Tutorial_WebsiteContext(serviceProvider.GetRequiredService<DbContextOptions<Net_Tutorial_WebsiteContext>>())) {

                //if (context == null || context.Movie == null) { 
                //throw new ArgumentNullException("Null Net tutorial canvas context");
                //}

                //if (context.Movie.Any())
                //{
                //    return; 
                //}

                //context.Canvas.AddRange(
                //    new Canvas {
                //        Title = "testTitle2",
                //        ReleaseDate = DateTime.Parse("1989-2-12"),
                //        Genre = "testGenre2",
                //        Price = 7.99M,
                //        Rating = "R"
                //    },
                //     new Canvas
                //     {
                //         Title = "testTitle3",
                //         ReleaseDate = DateTime.Parse("1989-3-12"),
                //         Genre = "testGenre3",
                //         Price = 8.99M,
                //        Rating = "R"
                //     },
                //      new Canvas
                //      {
                //          Title = "testTitle4",
                //          ReleaseDate = DateTime.Parse("1989-4-12"),
                //          Genre = "testGenre4",
                //          Price = 9.99M,
                //          Rating = "R"
                //      },
                //       new Canvas
                //       {
                //           Title = "testTitle5",
                //           ReleaseDate = DateTime.Parse("1989-5-12"),
                //           Genre = "testGenre5",
                //           Price = 3.99M,
                //           Rating = "R"
                //       }
                //);
                //context.SaveChanges();
            }
        }
    }
}
