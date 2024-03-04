using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Team.Repo.Models;
using Team.Service.DTO;
using Team.Service.Interface;

namespace Team_Project_Final.Controllers
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
            return Ok(await _authService.Adduser(userRegistration));
        }

        [HttpPost("gettoken")]
        public async Task<IActionResult> GetToken(UserLoginDTO userlogindto)
        {
            return Ok(await _authService.GetTokenAsync(userlogindto));
        }

        [HttpPost("updatepassword")]
        public async Task<IActionResult> updatepassword(UpdatepasswordDTO updatePassword)
        {
            try
            {
                if (updatePassword == null || string.IsNullOrEmpty(updatePassword.newPassword))
                    return null;
                return null;
            }
            catch
            {
                return null;
            }
        }

    }
}

