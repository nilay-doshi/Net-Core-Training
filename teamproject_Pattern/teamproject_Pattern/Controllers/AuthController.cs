using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using teamproject.Repository.Repository.Models;
using teamproject.Service.Service.DTO;
using teamproject.Service.Service.Interface;
using teamproject__Repository.Models;
using teamproject__Service.DTO;
using teamproject__Service.Interface;

namespace teamproject_Pattern.Controllers
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

        [HttpPost("adduser")]
        public async Task<IActionResult> adduser(UserRegistration userRegistration)
        {
            return Ok(await _authService.adduser(userRegistration));
        }

        [HttpPost("login")]
        public async Task<IActionResult> GetToken(UserLoginDTO userlogindto)
        {
            return Ok(await _authService.GetTokenAsync(userlogindto));  
        }

    }
}
