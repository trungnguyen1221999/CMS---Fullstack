using BlogProject.Api.Services;
using BlogProject.Core.Models.Auth;
using Microsoft.AspNetCore.Mvc;


namespace BlogProject.Api.Controllers.Admin
{
    [Route("api/admin/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public async Task<ActionResult<AuthenticatedResult>> Login([FromBody] LoginRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid Request");
            };

            var result = await _authService.LoginAsync(request);
            if (result == null) return Unauthorized();
            return Ok(result);
            
        }
    }
}
