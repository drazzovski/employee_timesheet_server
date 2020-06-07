using System.Collections.Generic;

namespace EmployeeTimesheet.Models
{
    public class UserType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ICollection<ApplicationUser> Nadredjeni { get; set; }
    }
}