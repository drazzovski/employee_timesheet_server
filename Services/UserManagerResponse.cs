using System.Collections.Generic;

namespace EmployeeTimesheet.Services
{
    public class UserManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public string UserType { get; set; }
    }
}