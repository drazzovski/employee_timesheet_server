using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTimesheet.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        private const string adminRoleId = "6CAC3ED9-597A-4319-87E4-1AB92823B152";
        private const string nadredjeniRoleId = "9E91AA16-4C34-44DD-B9E3-27A7918E401E";
        private const string radnikRoleId = "711E84F4-9AA5-42E0-8118-B25F4F6C2B12";

        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {

            builder.HasData(
                    new IdentityRole
                    {
                        Id = adminRoleId,
                        Name = "Administrator",
                        NormalizedName = "ADMINISTRATOR"
                    },
                    new IdentityRole
                    {
                        Id = nadredjeniRoleId,
                        Name = "Nadredjeni",
                        NormalizedName = "NADREDJENI"
                    },
                    new IdentityRole
                    {
                        Id = radnikRoleId,
                        Name = "Radnik",
                        NormalizedName = "RADNIK"
                    }
                );
        }
    }
}