using System;
using System.Net;
using System.Net.Mail;

namespace Support
{
    public class Mail
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public bool IsSSL { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public void SendMail(string sender, string recipient, string subject, string body)
        {
            try
            {
                // Используем using, чтобы гарантированно удалить объекты mail и client после использования
                using (MailMessage mail = new MailMessage(sender, recipient))
                {
                    // Формируем письмо
                    mail.From = new MailAddress(sender);     // Адрес отправителя
                    mail.To.Add(new MailAddress(recipient));  // Адрес получателя
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
