using System.ComponentModel.DataAnnotations;

namespace EmployeeTimesheet.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(15, MinimumLength = 6)]
        public string UserName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 8)]
        public string Password { get; set; }
    }
}