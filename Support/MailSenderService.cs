using System;
using System.Net;
using System.Net.Mail;

namespace MailSender.lib
{
    public class MailSenderService
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool IsSSL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public void SendMail(string SenderAddress, string RecipientAddress, string subject, string body)
        {
            try
            {
                // Используем using, чтобы гарантированно удалить объекты mail и client после использования
                using (MailMessage mail = new MailMessage(SenderAddress, RecipientAddress))
                {
                    // Формируем письмо
                    mail.From = new MailAddress(SenderAddress);     // Адрес отправителя
                    mail.To.Add(new MailAddress(RecipientAddress));  // Адрес получателя
                    mail.Subject = subject;
                    mail.Body = body;

                    SmtpClient client = new SmtpClient();
                    client.Host = Server;
                    client.Port = Port;
                    client.Timeout = 5000;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(Login, Password);
                    client.Send(mail);
                }

            }
            catch (Exception ex)
            {
            }
        }
    }
}
