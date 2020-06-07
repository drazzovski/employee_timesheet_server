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
    public class ZadaciController : ControllerBase
    {
        private IZadatakService _zadatakService;
        private IUserService _userService;

        public ZadaciController(IZadatakService zadatakService, IUserService userService)
        {
            _zadatakService = zadatakService;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> GetZadaci()
        {
            var user = await _userService.GetUserByUserName(User.Identity.Name);

            // get zadaci by 
            string userID = null;
            if (user.UserTypeID == 3)
            {
                userID = user.ApplicationUserID;
            }
            else if (user.UserTypeID == 2)
            {
                userID = user.Id;
            }
            var list = _zadatakService.GetZadaci(userID);

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> PostZadatak(ZadatakViewModel model)
        {
            if (model.IsEdit)
            {
                _zadatakService.EditZadatak(model);
            }
            else
            {
                var user = await _userService.GetUserByUserName(User.Identity.Name);
                model.KreiranOd = user.Id;

                _zadatakService.PostZadatak(model);
            }

            return Ok();
        }

    }
}