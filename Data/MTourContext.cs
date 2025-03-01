using Microsoft.EntityFrameworkCore;
using TourManagerment.Models;

namespace TourManagerment.Data
{
    public class MTourContext : DbContext
    {
        public MTourContext(DbContextOptions<MTourContext> options) : base(options)
        {
        }

        public DbSet<Tour> Tours { get; set; }
    }
}
