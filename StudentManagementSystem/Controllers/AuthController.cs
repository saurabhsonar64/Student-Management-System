using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        
        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            
            var token = _authService.Login(request);
            if (token == null) return Unauthorized("Invalid credentials");
            
            return Ok(new { Token = token });
        }
    }
}
