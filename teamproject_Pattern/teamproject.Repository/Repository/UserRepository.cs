using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using teamproject_Repository.Interface;
using teamproject_Repository.Models;

namespace teamproject_Repository.Repository
{
    public class UserRepository : IUserRespository
    {
        private readonly TeamDbContext _dbContext;
        private readonly IPasswordHasher<UserRegistration> _passwordhasher;

        public UserRepository(TeamDbContext dbContext,IPasswordHasher<UserRegistration> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordhasher = passwordHasher;

        }
        public async Task<UserRegistration> adduser(UserRegistration userRegistration)
        {
            try
            {
                if (userRegistration == null)
                {
                    throw new ArgumentNullException(nameof(userRegistration));
                }
                    var checkEmailexists = _dbContext.Registration.FirstOrDefault(u => u.Email == userRegistration.Email);
                    if (checkEmailexists != null)
                        return checkEmailexists;

                    await _dbContext.Registration.AddAsync(userRegistration);
                    await _dbContext.SaveChangesAsync();

                    userRegistration.Password = null;

                    return userRegistration;
            }
            catch(Exception ex) 
            {
                return null; 
            }
        }

        public async Task<int?> CheckUserAuthAsync(string email, string password)
        {
            try
            {
                var user = await _dbContext.Registration.FirstOrDefaultAsync(u => u.Email == email);

             //   if (user == null)
              //      return flag = 0;

                var resultPassword = _passwordhasher.VerifyHashedPassword(user, user.Password, password);

                if (resultPassword == PasswordVerificationResult.Success)
                {
                    int flag = 1;
                    password = null;
                    user.Password = null;
                    return flag;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
