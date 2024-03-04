namespace teamproject_Service.Interface
{
    public interface IEmailService
    {
        Task SendEmail(string to, string subject, string body);
    }
}
