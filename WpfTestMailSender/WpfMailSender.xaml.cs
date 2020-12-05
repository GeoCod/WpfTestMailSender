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
            var login = LoginTb.Text;
            var password = passwordBox.Password;
            var address = AddressTb.Text;

            Mail.SendMail(login, password, address);
        }
    }
}
