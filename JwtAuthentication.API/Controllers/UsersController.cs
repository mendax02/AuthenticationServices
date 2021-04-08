using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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
        public async Task<string> Get()
        {
            _logger.LogInformation("Authenticated");
            return "Hello World!";
        }

        [HttpGet("GetInfo")]
        [AllowAnonymous]
        public async Task<string> GetInfo()
        {
            return "Anyone can access this endpoint!";
        }
    }
}
