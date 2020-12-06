using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using WpfTestMailSender.Commands;
using WpfTestMailSender.Data;
using WpfTestMailSender.Models;

namespace WpfTestMailSender.ViewModels
{
    class MainViewModel : ViewModelBase
    {

        #region Commands

        public ICommand CloseProgramCommand { get; set; }
        public ICommand DialogCommand { get; set; }

        public void CloseProgramCommand_Execute()
        {
            Application.Current.Shutdown();
        }

        public bool CloseProgramCommand_CanExecute()
        {
            if (Title.Length < 20) return false;
            return true;
        }

        public void DialogCommand_Execute(string text)
        {
            MessageBox.Show(text);
        }

        public bool DialogCommand_CanExecute(string text)
        {
            if (text is null) return false;
            return true;
        }

        #endregion

        public DateTime CurrentTime
        {
            get { return DateTime.Now; }
        }

        private string _title = "Our test window";

        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Server> _servers;
        private ObservableCollection<Sender> _senders;
        private ObservableCollection<Recipient> _recipients;
        private ObservableCollection<Message> _messages;

        public ObservableCollection<Server> Servers
        {
            get { return _servers; }
            set { _servers = value; }
        }
        public ObservableCollection<Sender> Senders
        {
            get { return _senders; }
            set { _senders = value; }
        }
        public ObservableCollection<Recipient> Recipients
        {
            get { return _recipients; }
            set { _recipients = value; }
        }
        public ObservableCollection<Message> Messages
        {
            get { return _messages; }
            set { _messages = value; }
        }

        public MainViewModel()
        {
            CloseProgramCommand = new Command(CloseProgramCommand_Execute, CloseProgramCommand_CanExecute);
            DialogCommand = new RelayCommand<string>(DialogCommand_Execute, DialogCommand_CanExecute);

            Servers = new ObservableCollection<Server>(TestData.Servers);
            Senders = new ObservableCollection<Sender>(TestData.Senders);
            Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
            Messages = new ObservableCollection<Message>(TestData.Messagess);
        }
    }
}
