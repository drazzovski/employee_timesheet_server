using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTimesheet.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AktivnostiController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetString()
        {
            return new string[] { "one", "two", "three", "four", "five" };
        }



    }
}
