using JwtAuthentication.API.Models;
using JwtAuthentication.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthentication.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("/token")]
        public IActionResult Create([FromBody] User user)
        {
            if (!_authService.Authenticate(user.Username, user.Password))
                return Unauthorized();
            else
                return new ObjectResult(_authService.GenerateToken(user.Username));
        }

    }
}
