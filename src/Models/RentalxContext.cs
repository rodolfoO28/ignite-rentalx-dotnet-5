using Microsoft.EntityFrameworkCore;

namespace Rentalx.Models
{
    public class RentalxContext : DbContext
    {
        public RentalxContext(DbContextOptions<RentalxContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
    }
}