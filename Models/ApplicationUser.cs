using System;
using Microsoft.AspNetCore.Identity;

namespace EmployeeTimesheet.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}