namespace WpfTestMailSender.Services
{
    public interface IMailService
    {
        IMailSender GetSender(string Server, int Port, bool IsSSL, string Login, string Password);
    }

    public interface IMailSender
    {
        void Send(string from, string recipient, string subject, string body);
    }
}
