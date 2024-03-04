using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teamproject__Service.Interface;
using teamproject__Repository.Repositories;
using teamproject__Repository.Models;
using teamproject__Repository.Interface;
using Microsoft.Extensions.Configuration;

namespace teamproject__Service.Service
{   
    public class AuthService: IAuthService
    {
        private readonly IEmailService _emailService;
        private readonly IPasswordHasher<UserRegistration> _passwordHasher;
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;
        public AuthService(IEmailService emailService, IPasswordHasher<UserRegistration> passwordHasher, IConfiguration configuration, UserRepository userRepository)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }
        
    }
}
