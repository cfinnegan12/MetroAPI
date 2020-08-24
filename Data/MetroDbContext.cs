using MetroAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MetroAPI.Data
{
    public class MetroDBContext : DbContext
    {
        public MetroDBContext(DbContextOptions<MetroDBContext> opt) : base(opt)
        {

        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Stop> Stops { get; set; }
        public DbSet<Route> Routes { get; set; }
        public DbSet<Journey> Journeys { get; set; }

    }
}
