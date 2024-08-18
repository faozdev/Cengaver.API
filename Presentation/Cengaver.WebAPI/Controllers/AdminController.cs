using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cengaver.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [Authorize(Policy = "AdminPolicy")]
        [HttpGet("admin-data")]
        public IActionResult GetAdminData()
        {
            return Ok("This is protected data");
        }
    }

}
