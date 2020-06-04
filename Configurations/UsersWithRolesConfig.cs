using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeTimesheet.Configurations
{
    public class UsersWithRolesConfig : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        private const string adminUserId = "2E357EEF-3591-4F7E-8CF1-120DA7016486";
        private const string adminRoleId = "6CAC3ED9-597A-4319-87E4-1AB92823B152";

        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            IdentityUserRole<string> iur = new IdentityUserRole<string>
            {
                RoleId = adminRoleId,
                UserId = adminUserId
            };

            builder.HasData(iur);
        }
    }
}