using System;
using System.Collections.Generic;
using System.Windows;
using System.Net;
using System.Net.Mail;

namespace WpfTestMailSender
{
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {
            List<string> listStrMails = new List<string> { "test.textovitch@yandex.ru" };  // Список email'ов кому мы отправляем письмо
            string strPassword = passwordBox.Password;
            foreach (string mail in listStrMails)
            {
                // Используем using, чтобы гарантированно удалить объект MailMessage после использования
                using (MailMessage mm = new MailMessage("test.textovitch@yandex.ru", mail))
                {
                    // Формируем письмо
                    mm.Subject = "Привет из C#"; // Заголовок письма
                    mm.Body = "Hello, world!";       // Тело письма
                    mm.IsBodyHtml = false;           // Не используем html в теле письма
                                                     // Авторизуемся на smtp-сервере и отправляем письмо
                                                     // Оператор using гарантирует вызов метода Dispose, даже если при вызове 
                                                     // методов в объекте происходит исключение.
                    using (SmtpClient sc = new SmtpClient("smtp.yandex.ru", 587))
                    {
                        sc.EnableSsl = true;
                        sc.Credentials = new NetworkCredential("test.textovitch@yandex.ru", strPassword);
                        try
                        {
                            sc.Send(mm);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Невозможно отправить письмо " + ex.ToString());
                        }
                    }
                }
            }
            SendEndWindow sew = new SendEndWindow();
            sew.ShowDialog();
        }
    }
}
