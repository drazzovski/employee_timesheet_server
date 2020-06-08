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
            var user = await _userService.GetUserByUserName(User.Identity.Name);
            if (model.IsEdit)
            {
                _zadatakService.EditZadatak(model);
                return Ok();
            }
            else
            {
                model.KreiranOd = user.Id;
                var data = _zadatakService.PostZadatak(model);
                data.KreiranOd = user.FirstName + " " + user.LastName;
                return Ok(data);
            }
        }

        [Route("deactivate")]
        [HttpPost]
        public IActionResult Deactivate(ZadatakViewModel model)
        {
            _zadatakService.Deactivate(model.Id.Value);
            return Ok();
        }

    }
}