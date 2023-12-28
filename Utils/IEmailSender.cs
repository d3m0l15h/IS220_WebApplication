namespace IS220_WebApplication.Utils;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
}