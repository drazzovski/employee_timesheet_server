using EmployeeTimesheet.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTimesheet.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new AdminConfiguration());
            modelBuilder.ApplyConfiguration(new UsersWithRolesConfig());
        }
    }
}