using teamproject.Repository.Repository.Models;
using teamproject_Service.DTO;

namespace teamproject_Service.Interface
{
    public interface IAuthService
    {
        Task<ResponseDTO> adduser(UserRegistration userRegistration);
        Task<ResponseDTO> GetTokenAsync(UserLoginDTO loginDTO);
    }
}
