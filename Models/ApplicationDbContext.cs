using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EmployeeTimesheet.Extensions;
using Microsoft.EntityFrameworkCore.Tools;

namespace EmployeeTimesheet.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

        public DbSet<TipZadatka> TipZadatka { get; set; }
        public DbSet<Zadatak> Zadaci { get; set; }
        public DbSet<RadniSati> RadniSati { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
    }
}