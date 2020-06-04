using System.Threading.Tasks;
using EmployeeTimesheet.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTimesheet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {

        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        // api/auth/register
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result); // 200
                }

                return BadRequest(result);
            }

            return BadRequest("Not Valid"); // 400
        }

    }
}