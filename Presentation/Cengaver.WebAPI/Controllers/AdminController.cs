using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cengaver.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // This endpoint requires the AdminPolicy to be satisfied
        [Authorize(Policy = "AdminPolicy")]
        [HttpGet("admin-data")]
        public IActionResult GetAdminData()
        {
            // Your logic here
            return Ok("This is protected data");
        }
    }

}
