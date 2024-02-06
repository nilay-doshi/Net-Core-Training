using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace demo_jwt_register_login_.Controllers
{
    [Route:("[controller]")]
    public class AuthController : Controller
    {
        public static IConfiguration _configuration;
        public readonly IDbContext _db;

        public AuthController(IConfiguration configuration, IDbContext db)
        {
            _configuration = configuration;
            _db = db;
        }

        [HttpPost]
        [Route("token")]
        public IActionResult Index([FromBody] User user)
        {
            if(_db.getUsers().Any(x => x.Username == user.Username && x.Password == user.Password))
            {
                var issuer = _configuration.GetSection("Jwt:Issuer").Value;
                var audience = _configuration.GetSection("Jwt:Audience").Value;
                var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Jwt:Key").Value);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    { 
                        new Claim("Id", Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Sub,user.Username),
                        new Claim(JwtRegisteredClaimNames.Email,user.Username),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                       
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.Sha256)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var stringToken = tokenHandler.WriteToken(token);
                return Ok(stringToken);
            }
            return Unauthorized();
        }
    }
}
