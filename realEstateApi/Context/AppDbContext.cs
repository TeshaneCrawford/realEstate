using Microsoft.EntityFrameworkCore;
using realEstateApi.Models;

namespace realEstateApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Property>? Properties { get; set; }
        public DbSet<Agent>? Agents { get; set; }
        public DbSet<Amenities>? Amenities { get; set; }
        public DbSet<Image>? Images { get; set; }
        public DbSet<Inquiry>? Inquiries { get; set; }
        public DbSet<Price>? Prices { get; set; }

    }
}
