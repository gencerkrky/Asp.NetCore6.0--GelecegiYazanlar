using _101_Controller.Models;
using Asp.NetCore6._0.Models;
using Microsoft.EntityFrameworkCore;

namespace Turkcell.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Visitor> Visitors { get; set; }
    }
}
