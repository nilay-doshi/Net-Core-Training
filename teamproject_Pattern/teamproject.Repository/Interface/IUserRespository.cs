using teamproject_Repository.Models;

namespace teamproject_Repository.Interface
{
    public interface IUserRespository
    {
        Task<UserRegistration> adduser(UserRegistration userRegistration);
        Task<int?> CheckUserAuthAsync(string email, string password);
    }
}
