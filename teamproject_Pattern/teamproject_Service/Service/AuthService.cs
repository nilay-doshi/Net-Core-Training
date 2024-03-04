using Microsoft.AspNetCore.Identity;
using teamproject_Repository.Interface;
using teamproject_Repository.Models;
using teamproject_Repository.Repository;
using teamproject_Service.DTO;
using teamproject_Service.Interface;

namespace teamproject_Service.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRespository _userRepository;
        private readonly IEmailService _emailService;
        private readonly IPasswordHasher<UserRegistration> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthService(IEmailService emailService, IPasswordHasher<UserRegistration> passwordHasher, IConfiguration configuration, UserRepository userRepository)
        {
            _userRepository = userRepository;
            _emailService = emailService;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }
        public async Task<ResponseDTO> adduser(UserRegistration userRegistration)
        {
            try
            {
                if (userRegistration.Email == null || userRegistration.Password == null)
                {
                    return new ResponseDTO()
                    {
                        Status = 404,
                        Message = "Enter valid email and password."
                    };
                }

                userRegistration.Password = "team1234";
                userRegistration.Password = _passwordHasher.HashPassword(userRegistration, userRegistration.Password);
                var user = await _userRepository.adduser(userRegistration);
                await _emailService.SendEmail(userRegistration.Email, "Welcome to our platform " + userRegistration.FirstName, "Thank you for signing up! " + userRegistration.FirstName + " " + userRegistration.LastName);

                //  userLogin.Password.GetHashCode();
                return new ResponseDTO()
                {
                    Status = 200,
                    Data = user
                };
            }
            catch (Exception ex)
            {
                return new ResponseDTO()
                {
                    Status = 500,
                    Message = "internal server error "
                };
            }
        }

        public Task<ResponseDTO> GetTokenAsync(UserLoginDTO loginDTO)
        {
            try
            {

            }
            catch 
            {

            }
            throw new NotImplementedException();
        }
    }
}
