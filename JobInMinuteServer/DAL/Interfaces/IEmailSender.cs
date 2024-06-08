namespace JobInMinuteServer.DAL.Interfaces
{
    public interface IEmailSender
    {
        //Task SendEmailAsync(string email, string subject, string message);
        Task SendEmailAsync(string to, string subject, string body);
    }
}
