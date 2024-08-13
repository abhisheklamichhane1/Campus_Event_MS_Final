using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CampusEventMS.Data.Models
{
    // ApplicationDbContext class inherits from IdentityDbContext to include ASP.NET Core Identity functionality
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        // Constructor that accepts DbContextOptions and passes them to the base class constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

  
        // DbSets represent tables in the database
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }

        // OnModelCreating method is used to configure the model using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            // Call the base class's OnModelCreating method
            base.OnModelCreating(modelBuilder);

            // Configure the relationship between Category and Event entities
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Events) // A Category can have many Events
                .WithOne(e => e.Category) // Each Event has one Category
                .HasForeignKey(e => e.CategoryId); // Foreign key property in the Event entity
        }
    }
}
