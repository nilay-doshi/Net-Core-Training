using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Team_Project.Models;

namespace Team_Project.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly TeamDbContext _dbContext;
        private readonly IPasswordHasher<UserRegistration> _passwordHasher;
        private readonly IPasswordHasher<UserloginDTO> _passwordHasher1;
        
        public UserRepository(TeamDbContext dbContext, IPasswordHasher<UserRegistration> passwordHasher, IPasswordHasher<UserloginDTO> passwordHasher1) 
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _passwordHasher1 = passwordHasher1; 
            
        }

        public async Task<UserRegistration> AddUser(UserRegistration userRegistration)
        {
            if (userRegistration == null)
            {
                throw new ArgumentNullException(nameof(userRegistration));
            }

            await _dbContext.Registration.AddAsync(userRegistration);
            await _dbContext.SaveChangesAsync();
    
            return userRegistration;
        }

        public async Task<ActionResult<string>> GetUserByEmail(string email, string password)
        {
            try
            {
                var user = await _dbContext.Registration.FirstOrDefaultAsync(u => u.Email == email);

                if (user == null)
                    return "null"; 

                var resultPassword = _passwordHasher.VerifyHashedPassword(user, user.Password, password);

                if (resultPassword == PasswordVerificationResult.Success)
                {
                    return "Success"; 
                }
                else
                {
                    return null; 
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ActionResult<string> GetUserByEmail1(string email)
        {
            try
            {
                var user = _dbContext.Registration.FirstOrDefault(u => u.Email == email);
                
                return user.FlagRole.ToString();
            }
            catch
            {
                throw;
            }
        }
    }
}
