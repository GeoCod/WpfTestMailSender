using MailSender.Commands;
using MailSender.Data;
using MailSender.lib.Interfaces;
using MailSender.Models;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace MailSender.ViewModels
{
    class MainWindowViewModel : ViewModelBase
    {

        #region Commands

        #region SendMessageCommand
        public ICommand SendMessageCommand { get; set; }
        public void SendMessageCommand_Execute()
        {
            var mailSender = _mailService.GetSender(SelectedServer.Address, SelectedServer.Port, SelectedServer.IsSSL, SelectedServer.Login, SelectedServer.Password);
            mailSender.Send(SelectedSender.Address, SelectedRecipient.Address, SelectedMessage.Subject, SelectedMessage.Body);
        }

        public bool SendMessageCommand_CanExecute()
        {
            if (SelectedServer != null && SelectedSender != null && SelectedRecipient != null && SelectedMessage != null) return true;
            return false;
        }

        #endregion

        #region DialogCommand
        public ICommand DialogCommand { get; set; }

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


        #region AddServerCommand

        private ICommand _AddServerCommand;

        // Вариант для C# 8.0 с оператором присваивания объединения со значением NULL ??=
        //public ICommand AddServerCommand => _AddServerCommand
        //    ??= new LambdaCommand(OnAddServerCommandExecuted, CanAddServerCommandExecute);

        public ICommand AddServerCommand
        {
            get
            {
                if (_AddServerCommand is null)
                    _AddServerCommand = new LambdaCommand(OnAddServerCommandExecuted, CanAddServerCommandExecute);
                return _AddServerCommand;
            }
        }
        private bool CanAddServerCommandExecute(object p) => true;

        private void OnAddServerCommandExecuted(object p)
        {
            // Основное действие, выполняемое командой, описывается здесь!!!

            MessageBox.Show("Создание нового сервера!", "Управление серверами");
        }
        #endregion

        #region EditServerCommand

        private ICommand _EditServerCommand;

        public ICommand EditServerCommand
        {
            get
            {
                if (_EditServerCommand is null)
                    _EditServerCommand = new LambdaCommand(OnEditServerCommandExecuted, CanEditServerCommandExecute);
                return _EditServerCommand;
            }
        }
        private bool CanEditServerCommandExecute(object p) => p is Server || SelectedServer != null;

        private void OnEditServerCommandExecuted(object p)
        {
            var server = p as Server ?? SelectedServer;
            if (server is null) return;

            MessageBox.Show($"Редактирование сервера {server.Address}!", "Управление серверами");
        }
        #endregion

        #region DeleteServerCommand

        private ICommand _DeleteServerCommand;

        public ICommand DeleteServerCommand
        {
            get
            {
                if (_DeleteServerCommand is null)
                    _DeleteServerCommand = new LambdaCommand(OnDeleteServerCommandExecuted, CanDeleteServerCommandExecute);
                return _DeleteServerCommand;
            }
        }
        private bool CanDeleteServerCommandExecute(object p) => p is Server || SelectedServer != null;

        private void OnDeleteServerCommandExecuted(object p)
        {
            var server = p as Server ?? SelectedServer;
            if (server is null) return;

            Servers.Remove(server);
            SelectedServer = Servers.FirstOrDefault();

            MessageBox.Show($"Удаление сервера {server.Address}!", "Управление серверами");
        }
        #endregion


        #region AddSenderCommand
        private ICommand _AddSenderCommand;

        public ICommand AddSenderCommand
        {
            get
            {
                if (_AddSenderCommand is null)
                    _AddSenderCommand = new LambdaCommand(OnAddSenderCommandExecuted, CanAddSenderCommandExecute);
                return _AddSenderCommand;
            }
        }
        private bool CanAddSenderCommandExecute(object p) => true;

        private void OnAddSenderCommandExecuted(object p)
        {
            // Основное действие, выполняемое командой, описывается здесь!!!

            MessageBox.Show("Создание нового отправителя!", "Управление отправителями");
        }
        #endregion

        #region EditSenderCommand
        private ICommand _EditSenderCommand;

        public ICommand EditSenderCommand
        {
            get
            {
                if (_EditSenderCommand is null)
                    _EditSenderCommand = new LambdaCommand(OnEditSenderCommandExecuted, CanEditSenderCommandExecute);
                return _EditSenderCommand;
            }
        }
        private bool CanEditSenderCommandExecute(object p) => p is Sender || SelectedSender != null;

        private void OnEditSenderCommandExecuted(object p)
        {
            var sender = p as Sender ?? SelectedSender;
            if (sender is null) return;

            MessageBox.Show($"Редактирование отправителя {sender.Name}!", "Управление отправителями");
        }
        #endregion

        #region DeleteSenderCommand
        private ICommand _DeleteSenderCommand;

        public ICommand DeleteSenderCommand
        {
            get
            {
                if (_DeleteSenderCommand is null)
                    _DeleteSenderCommand = new LambdaCommand(OnDeleteSenderCommandExecuted, CanDeleteSenderCommandExecute);
                return _DeleteSenderCommand;
            }
        }
        private bool CanDeleteSenderCommandExecute(object p) => p is Sender || SelectedSender != null;

        private void OnDeleteSenderCommandExecuted(object p)
        {
            var sender = p as Sender ?? SelectedSender;
            if (sender is null) return;

            Senders.Remove(sender);
            SelectedSender = Senders.FirstOrDefault();

            MessageBox.Show($"Удаление отправителя {sender.Name}!", "Управление отправителями");
        }
        #endregion


        #region AddRecipientCommand
        private ICommand _AddRecipientCommand;

        public ICommand AddRecipientCommand
        {
            get
            {
                if (_AddRecipientCommand is null)
                    _AddRecipientCommand = new LambdaCommand(OnAddRecipientCommandExecuted, CanAddRecipientCommandExecute);
                return _AddRecipientCommand;
            }
        }
        private bool CanAddRecipientCommandExecute(object p) => true;

        private void OnAddRecipientCommandExecuted(object p)
        {
            // Основное действие, выполняемое командой, описывается здесь!!!

            MessageBox.Show("Создание нового получателя!", "Управление получателями");
        }
        #endregion

        #region EditRecipientCommand
        private ICommand _EditRecipientCommand;

        public ICommand EditRecipientCommand
        {
            get
            {
                if (_EditRecipientCommand is null)
                    _EditRecipientCommand = new LambdaCommand(OnEditRecipientCommandExecuted, CanEditRecipientCommandExecute);
                return _EditRecipientCommand;
            }
        }
        private bool CanEditRecipientCommandExecute(object p) => p is Recipient || SelectedRecipient != null;

        private void OnEditRecipientCommandExecuted(object p)
        {
            var recipient = p as Recipient ?? SelectedRecipient;
            if (recipient is null) return;

            MessageBox.Show($"Редактирование получателя {recipient.Name}!", "Управление получателями");
        }
        #endregion

        #region DeleteRecipientCommand
        private ICommand _DeleteRecipientCommand;

        public ICommand DeleteRecipientCommand
        {
            get
            {
                if (_DeleteRecipientCommand is null)
                    _DeleteRecipientCommand = new LambdaCommand(OnDeleteRecipientCommandExecuted, CanDeleteRecipientCommandExecute);
                return _DeleteRecipientCommand;
            }
        }
        private bool CanDeleteRecipientCommandExecute(object p) => p is Recipient || SelectedRecipient != null;

        private void OnDeleteRecipientCommandExecuted(object p)
        {
            var recipient = p as Recipient ?? SelectedRecipient;
            if (recipient is null) return;

            Recipients.Remove(recipient);
            SelectedRecipient = Recipients.FirstOrDefault();

            MessageBox.Show($"Удаление получателя {recipient.Name}!", "Управление получателями");
        }
        #endregion

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


        private Server _selectedServer;
        private Sender _selectedSender;
        private Recipient _selectedRecipient;
        private Message _selectedMessage;

        public Server SelectedServer
        {
            get { return _selectedServer; }
            set { _selectedServer = value; OnPropertyChanged(); }
        }
        public Sender SelectedSender
        {
            get { return _selectedSender; }
            set { _selectedSender = value; OnPropertyChanged(); }
        }
        public Recipient SelectedRecipient
        {
            get { return _selectedRecipient; }
            set { _selectedRecipient = value; OnPropertyChanged(); }
        }
        public Message SelectedMessage
        {
            get { return _selectedMessage; }
            set { _selectedMessage = value; OnPropertyChanged(); }
        }

        private IMailService _mailService { get; set; }

        public MainWindowViewModel(IMailService mailService)
        {
            _mailService = mailService;

            Servers = new ObservableCollection<Server>(TestData.Servers);
            Senders = new ObservableCollection<Sender>(TestData.Senders);
            Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
            Messages = new ObservableCollection<Message>(TestData.Messagess);
        }
    }
}
