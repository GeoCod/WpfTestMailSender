using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Windows;

namespace WpfTestMailSender
{
    public static class Mail
    {
        public static List<string> GetMail(string text)
        {
            return new List<string>();
        }

        public static void SendMail(string login, string password, string address)
        {
            try
            {
                // Используем using, чтобы гарантированно удалить объекты mail и client после использования
                using (MailMessage mail = new MailMessage(login, address))
                {
                    // Формируем письмо
                    mail.From = new MailAddress(login);     // Адрес отправителя
                    mail.To.Add(new MailAddress(address));  // Адрес получателя
                    mail.Subject = "Привет из C#";
                    mail.Body = "Hello, world!";

                    SmtpClient client = new SmtpClient();
                    client.Host = "smtp.yandex.ru";
                    client.Port = 587;
                    client.Timeout = 5000;
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(login, password);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
            }

            SendEndWindow sew = new SendEndWindow();
            sew.ShowDialog();
        }
    }
}
