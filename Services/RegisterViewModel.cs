using System.ComponentModel.DataAnnotations;

namespace EmployeeTimesheet.Services
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 8)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Role { get; set; }
    }
}