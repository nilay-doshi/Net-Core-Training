using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teamproject__Repository.Interface;
using teamproject__Repository.Models;

namespace teamproject__Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<UserRegistration> adduser(UserRegistration userRegistration)
        {
            throw new NotImplementedException();
        }

        public Task<int?> CheckUserAuthAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
