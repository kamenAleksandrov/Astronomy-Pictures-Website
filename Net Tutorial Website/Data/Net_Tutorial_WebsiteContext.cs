using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Net_Tutorial_Website.Models;

namespace Net_Tutorial_Website.Data
{
    public class Net_Tutorial_WebsiteContext : DbContext
    {
        public Net_Tutorial_WebsiteContext (DbContextOptions<Net_Tutorial_WebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<Net_Tutorial_Website.Models.Canvas>? Canvas { get; set; }

        public DbSet<Net_Tutorial_Website.Models.Cart>? Cart { get; set; }
    }
}
