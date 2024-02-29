using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Team_Project.Models;

namespace Team_Project.Repository
{
    public interface IUserRepository
    {
      public Task<UserRegistration> AddUser(UserRegistration userRegistration);
      public Task<ActionResult<string>> GetUserByEmail(string email, string Password);
      public ActionResult<string> GetUserByEmail1(string email);


    }
}
