using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("ApplicationUserNadredjeni")]
        public string ApplicationUserID { get; set; }

        public virtual ApplicationUser ApplicationUserNadredjeni { get; set; }

        public virtual ICollection<ApplicationUser> Nadredjeni { get; set; }
    }
}