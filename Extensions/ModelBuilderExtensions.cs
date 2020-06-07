using EmployeeTimesheet.Configurations;
using EmployeeTimesheet.Models;
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

            modelBuilder.Entity<TipZadatka>().HasData(new TipZadatka[] {
                new TipZadatka{Id=1,Name="Projekat"},
                new TipZadatka{Id=2,Name="Aktivnost"},
            });

            modelBuilder.Entity<UserType>().HasData(new UserType[] {
                new UserType{Id=1,Name="Admin"},
                new UserType{Id=2,Name="Nadredjeni"},
                new UserType{Id=3,Name="Radnik"},
            });

        }
    }
}