using System.Collections.Generic;
using System.Threading.Tasks;
using EmployeeTimesheet.Services;
using EmployeeTimesheet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTimesheet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RadniciController : ControllerBase
    {
        private IUserService _userService;

        public RadniciController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRadnici()
        {
            var result = await _userService.GetRadniciAsync(User.Identity.Name);

            return Ok(result);

        }
    }
}