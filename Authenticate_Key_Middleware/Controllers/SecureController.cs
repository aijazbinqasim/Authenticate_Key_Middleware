using Microsoft.AspNetCore.Mvc;

namespace Authenticate_Key_Middleware.Controllers
{
    [Route("api/secure")]
    [ApiController]
    public class SecureController : ControllerBase
    {
        [Route("home")]
        [HttpGet]
        public IActionResult Home()
        {
            return Ok(new { message = "Welcome to Home Walidad" });
        }
    }
}
