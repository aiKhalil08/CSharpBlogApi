using BusinessLogicLayer.IServices;
using BusinessLogicLayer.Service;
using DomainLayer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data;


namespace Blog.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(IJwtService jwtService, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _jwtService = jwtService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            // Validate the input
            if (string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest("Username and password are required.");
            }

            // Find the user by username or email
            var user = await _userManager.FindByNameAsync(request.Username) ??
                       await _userManager.FindByEmailAsync(request.Username);

            if (user == null)
            {
                return Unauthorized("Invalid username or password.");
            }

            // Attempt to sign in the user
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                return Unauthorized("Invalid username or password.");
            }

            // Generate JWT token
            //var roles = await _userManager.GetRolesAsync(user);
            //var token = _jwtService.GenerateToken(user.Id, roles.FirstOrDefault());
            var token = _jwtService.GenerateToken(user.Id, "admin");

            return Ok(new { Token = token });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

}