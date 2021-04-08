using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace JwtAuthentication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public string Get()
        {
            _logger.LogInformation("Authenticated");
            return "Hello World!";
        }

        [HttpGet("GetInfo")]
        [AllowAnonymous]
        public string GetInfo()
        {
            return "Anyone can access this endpoint!";
        }
    }
}
