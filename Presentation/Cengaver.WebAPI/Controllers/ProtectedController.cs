using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cengaver.WebAPI.Controllers
{
    [Authorize] // Require authentication for all actions in this controller
    public class ProtectedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
