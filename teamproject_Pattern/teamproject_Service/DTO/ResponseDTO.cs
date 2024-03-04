using teamproject_Repository.Models;

namespace teamproject_Service.DTO
{
    public class ResponseDTO
    {
        public int Status { get; set; }
        public UserRegistration? Data { get; set; }
        public string? Message { get; set; }
        public string? Error { get; set; }
    }
}
