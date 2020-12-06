using System;
using System.Windows;

namespace MailSender
{
    /// <summary>Логика взаимодействия для ExceptionWindow.xaml</summary>
    public partial class ExceptionWindow : Window
    {
        public ExceptionWindow()
        {
            InitializeComponent();
        }

        public ExceptionWindow(string textException)
        {
            InitializeComponent();
            tbException.Text = textException;
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
