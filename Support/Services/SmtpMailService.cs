using MailSender.lib.Interfaces;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace MailSender.lib.Services
{
    public class SmtpMailService : IMailService
    {
        public IMailSender GetSender(string Server, int Port, bool IsSSL, string Login, string Password)
        {
            return new SmtpMailSender(Server, Port, IsSSL, Login, Password);
        }
    }

    public class SmtpMailSender : IMailSender
    {
        public string Address { get; set; }
        public int Port { get; set; }
        public bool IsSSL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public SmtpMailSender(string address, int port, bool isSSL, string login, string password)
        {
            Address = address;
            Port = port;
            IsSSL = isSSL;
            Login = login;
            Password = password;
        }

        public void Send(string senderAddress, string recipientAddress, string subject, string body)
        {
            var from = new MailAddress(senderAddress);
            var to = new MailAddress(recipientAddress);

            using (var mail = new MailMessage(from, to))
            {
                mail.Subject = subject;
                mail.Body = body;

                using (var client = new SmtpClient(Address, Port))
                {
                    client.EnableSsl = true;

                    client.Credentials = new NetworkCredential
                    {
                        UserName = Login,
                        Password = Password
                    };

                    try
                    {
                        client.Send(mail);
                    }
                    catch (Exception ex)
                    {
                        Trace.TraceError(ex.ToString());
                        throw;
                    }
                }
            }

        }
    }
}
