﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Team_Project.EmailService;
using Team_Project.Models;
using Team_Project.Repository;

namespace Team_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IPasswordHasher<UserRegistration> _passwordHasher;
        private readonly TeamDbContext _dbContext;
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public UserController(IUserRepository userRepository, IEmailService emailService, IPasswordHasher<UserRegistration> passwordHasher, IConfiguration configuration, TeamDbContext dbContext, ILogger logger)
        {

            _userRepository = userRepository;
            _emailService = emailService;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpPost("AddNewUser")]
        public async Task<IActionResult> AddUser([FromBody] UserRegistration userRegistration)
        {
            if (userRegistration.Email == null || userRegistration.Password == null)
            {
                return BadRequest("Invalid User Data");
            }

            try
            {
                //          var registeruser1 = _userService.AddUser(userRegistration);
                userRegistration.Password = "team1234";
                userRegistration.Password = _passwordHasher.HashPassword(userRegistration, userRegistration.Password);
                var user = await _userRepository.AddUser(userRegistration);
                await _emailService.SendEmail(userRegistration.Email, "Welcome to our platform " + userRegistration.FirstName, "Thank you for signing up! " + userRegistration.FirstName + " " + userRegistration.LastName);

                //  userLogin.Password.GetHashCode();
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [AllowAnonymous]
        [HttpPost("LoginWITHOUTJWT")]
        public async Task<IActionResult> LoginUser1(UserloginDTO userlogin)
        {
            if (userlogin == null)
            {
                return BadRequest("invalid login details");
            }
            try
            {
                var user = await _userRepository.GetUserByEmail(userlogin.Email, userlogin.Password);

                if (user == null)
                    return NotFound("user not found");

                if (user.Equals("Success"))
                {
                    return Ok("login successful");
                }
                else
                {
                    return Unauthorized("Invalid Credentials");
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, "internal server error");
            }

        }

        [AllowAnonymous]
        [HttpPost("LoginWITHJWT")]
        public async Task<ActionResult<string>> LOGINWITHJWT(UserloginDTO userlogin)
        {
            if (userlogin == null || string.IsNullOrEmpty(userlogin.Email) || string.IsNullOrEmpty(userlogin.Password))
                return BadRequest("Invalid Login details");
            var user = await _userRepository.GetUserByEmail(userlogin.Email, userlogin.Password);
            
            string token = CreateToken(userlogin);

          //  var resultpassword = _passwordHasher.VerifyHashedPassword(user, user.Password, userlogin.Password);

            if (user == null)
                return NotFound("user not found");

            return Ok(token);
        }

        private string CreateToken(UserloginDTO userlogin)
        {
            var user = _userRepository.GetUserByEmail1(userlogin.Email);

            string FlagRole = user.Value;
            Console.WriteLine(FlagRole);

            List<Claim> claims = new List<Claim>
            {
            new Claim(ClaimTypes.Email, userlogin.Email),
            new Claim(ClaimTypes.Role, FlagRole)
            };

            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                 claims: claims,
                 expires: DateTime.Now.AddDays(1),
                 signingCredentials: credentials);
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }   
}
