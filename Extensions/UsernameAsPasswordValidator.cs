using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmployeeTimesheet.Extensions
{
    public class UsernameAsPasswordValidator<TUser> : IPasswordValidator<TUser>
    where TUser : IdentityUser
    {
        public Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user, string password)
        {
            if (password.Length > 25)
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "PasswordMaxLength",
                    Description = "Password maximum length is 25 characters"
                }));
            }

            if (user.UserName.Length < 6)
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "UserNameMinLength",
                    Description = "Username minimum length is 6 characters"
                }));
            }

            if (user.UserName.Length > 15)
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "UserNameMaxLength",
                    Description = "Username maximum length is 15 characters"
                }));
            }

            if (char.IsDigit(user.UserName[0]))
            {
                return Task.FromResult(IdentityResult.Failed(new IdentityError
                {
                    Code = "UserNameFirstLetter",
                    Description = "Username first letter cannot be number"
                }));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}