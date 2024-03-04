﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Team.Repo.Interface;
using Team.Repo.Models;
using Team.Service.DTO;
using Team.Service.Interface;

namespace Team.Service.Service
{
    public class AuthService : IAuthService
    {
        private readonly IEmailService _emailService;
        private readonly IPasswordHasher<UserRegistration> _passwordHasher;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthService(IEmailService emailService,IPasswordHasher<UserRegistration> passwordHasher,IUserRepository userRepository,IConfiguration configuration)
        {
            _emailService = emailService;
            _passwordHasher = passwordHasher;   
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public async Task<ResponseDTO> Adduser(UserRegistration userRegistration)
        {
            try
            {
                if (userRegistration.Email == null || userRegistration.Password == null)
                {
                    return new ResponseDTO
                    {
                        Status = 500,
                        Message = "Email or Password is null"
                    };
                }

                userRegistration.Password = "team1234";
                userRegistration.Password = _passwordHasher.HashPassword(userRegistration, userRegistration.Password);
                await _userRepository.Adduser(userRegistration);
                await _emailService.SendEmail(userRegistration.Email, "Welcome to our platform " + userRegistration.FirstName, "Thank you for signing up! " + userRegistration.FirstName + " " + userRegistration.LastName);
                
                return new ResponseDTO
                {    
                    Status = 200,
                    Message = "Data Entered Success"
                };

            }

            catch(Exception ex)
            {
                return new ResponseDTO { Status = 500 , Error = ex.Message };
            }
        }

        public async Task<ResponseDTO> GetTokenAsync(UserLoginDTO userlogin)
        {
            try 
            { 
            if (userlogin == null)
            {
                return new ResponseDTO
                {
                    Status = 500,
                    Message = "Email or Password is null"
                };
            }
                var user = await _userRepository.CheckUserAuthAsync(userlogin.Email, userlogin.Password);

                var resultPassword = _passwordHasher.VerifyHashedPassword(user, user.Password, userlogin.Password);

                if (resultPassword == PasswordVerificationResult.Success)
                {
                    userlogin.Password = null;
                    user.Password = null;
                    
                    var token = CreateToken(userlogin);

                    if (user == null)
                        return new ResponseDTO { Message = "User not found " };

                    return new ResponseDTO { token = token };
                }
                else
                {
                    return null;
                }

                
            }
            catch (Exception ex)
            {
                return new ResponseDTO { Status = 500, Error = ex.Message };
            }
        }
        private string CreateToken(UserLoginDTO userlogin)
        {
            var user = _userRepository.GetUserByEmail1(userlogin.Email);

            string FlagRole = user.Result;
            Console.WriteLine(FlagRole);

            List<Claim> claims = new List<Claim>
            {
            new Claim("email", userlogin.Email),
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
