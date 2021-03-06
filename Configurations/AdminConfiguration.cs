using System;
using EmployeeTimesheet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTimesheet.Configurations
{
    public class AdminConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        private const string adminId = "2E357EEF-3591-4F7E-8CF1-120DA7016486";

        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var admin = new ApplicationUser
            {
                Id = adminId,
                UserName = "superadmin",
                NormalizedUserName = "SUPERADMIN",
                FirstName = "Master",
                LastName = "Admin",
                Email = "arandjic@gmail.com",
                NormalizedEmail = "ARANDJIC@GMAIL.COM",
                PhoneNumber = "0000",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                BirthDate = new DateTime(1990, 1, 1),
                SecurityStamp = Guid.NewGuid().ToString().ToUpper(),
                Address = "New Street 2",
                City = "MD",
                UserTypeID = 1
            };

            admin.PasswordHash = PassGenerate(admin);

            builder.HasData(admin);
        }

        public string PassGenerate(ApplicationUser user)
        {
            var passHash = new PasswordHasher<ApplicationUser>();
            return passHash.HashPassword(user, "Admin!11");
        }
    }
}