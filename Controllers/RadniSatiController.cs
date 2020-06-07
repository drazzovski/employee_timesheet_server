using System;
using System.Threading.Tasks;
using EmployeeTimesheet.Models;
using EmployeeTimesheet.Services;
using EmployeeTimesheet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTimesheet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RadniSatiController : ControllerBase
    {

        private IRadniSatiService _radniSati;
        private IUserService _userService;
        private IZadatakService _zadatakService;

        public RadniSatiController(IRadniSatiService radniSati, IUserService userService, IZadatakService zadatakService)
        {
            _radniSati = radniSati;
            _userService = userService;
            _zadatakService = zadatakService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRadniSati()
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
            var list = _radniSati.GetRadniSati(userID);

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> PostRadniSat(RadniSatiViewModel model)
        {
            var user = await _userService.GetUserByUserName(User.Identity.Name);
            model.UserId = user.Id;

            _radniSati.PostRadniSati(model);

            return Ok();
        }

        [Route("zadacidropdown")]
        [HttpGet]
        public async Task<IActionResult> GetZadaciDropdown()
        {
            var user = await _userService.GetUserByUserName(User.Identity.Name);
            string userID = null;
            if (user.UserTypeID == 3)
            {
                userID = user.ApplicationUserID;
            }
            else if (user.UserTypeID == 2)
            {
                userID = user.Id;
            }
            var ddown = _zadatakService.ZadaciDropdown(userID);

            return Ok(ddown);
        }

        [Route("delete")]
        [HttpPost]
        public IActionResult DeleteRadniSat(RadniSatiViewModel model)
        {
            _radniSati.DeleteRadniSati(model.Id.Value);
            return Ok();
        }

    }
}