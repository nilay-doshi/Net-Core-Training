using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teamproject__Repository.Models;

namespace teamproject__Repository.Interface
{
    public interface IUserRepository
    {
        Task<UserRegistration> adduser(UserRegistration userRegistration);
        Task<int?> CheckUserAuthAsync(string email, string password);
    }
}
