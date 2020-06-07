using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EmployeeTimesheet.Models;
using EmployeeTimesheet.Models.Settings;
using EmployeeTimesheet.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeTimesheet.Services
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model, string User);
        Task<UserManagerResponse> LoginUserAsync(LoginViewModel model);
        Task<List<RadnikViewModel>> GetRadniciAsync(string User);
        Task<ApplicationUser> GetUserByUserName(string UserName);
    }

    public class UserService : IUserService
    {
        private UserManager<ApplicationUser> _userManager;
        private JWT _jwtSettings;

        public UserService(UserManager<ApplicationUser> userManager, IOptions<JWT> jwtSettings)
        {
            _userManager = userManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "Invalid username or password",
                    IsSuccess = false
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!result)
            {
                return new UserManagerResponse
                {
                    Message = "Invalid username or password",
                    IsSuccess = false
                };
            }
            var userType = _userManager.Users.Include(x => x.UserType).FirstOrDefault(x => x.UserName == user.UserName).UserType.Name;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Role, userType)
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return new UserManagerResponse
            {
                Message = token,
                IsSuccess = true
            };
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterViewModel model, string User)
        {
            if (model == null)
                throw new NullReferenceException("Register model is null");


            var identityUser = new ApplicationUser
            {
                Email = model.Email,
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.Phone,
                Address = model.Address,
                City = model.City,
                UserTypeID = model.UserTypeID,
                ApplicationUserID = model.ApplicationUserID

            };

            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(identityUser, model.Role);
                return new UserManagerResponse
                {
                    Message = "User created sucessfully",
                    IsSuccess = true
                };
            }

            return new UserManagerResponse
            {
                Message = "User did not create",
                IsSuccess = false,
                Errors = result.Errors.Select(x => x.Description)
            };
        }

        public async Task<List<RadnikViewModel>> GetRadniciAsync(string User)
        {
            var currentUser = await _userManager.FindByNameAsync(User);

            var roles = await _userManager.GetRolesAsync(currentUser);
            var users = _userManager.Users.Include(x => x.UserType).AsQueryable();

            if (roles.FirstOrDefault(x => x == "Nadredjeni") != null)
            {
                users = users.Where(x => x.ApplicationUserID == currentUser.Id);
            }

            var list = users.AsEnumerable().Select(x => new RadnikViewModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Address = x.Address,
                City = x.City,
                Phone = x.PhoneNumber,
                Email = x.PhoneNumber,
                BirthDate = x.BirthDate.HasValue ? x.BirthDate.Value.ToString("dd/MM/yyyy") : "",
                Type = x.UserType?.Name,
                UserName = x.UserName
            });

            return list.ToList();

        }

        public async Task<ApplicationUser> GetUserByUserName(string UserName)
        {
            var user = await _userManager.FindByNameAsync(UserName);
            return user;
        }
    }
}