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

        #region SendMessageCommand
        public ICommand SendMessageCommand { get; set; }
        public void SendMessageCommand_Execute()
        {

        }

        public bool SendMessageCommand_CanExecute()
        {
            return true;
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
        public ICommand AddServerCommand { get; set; }
        public void AddServerCommand_Execute()
        {
            MessageBox.Show("add");
        }

        public bool AddServerCommand_CanExecute()
        {
            return true;
        }
        #endregion

        #region EditServerCommand
        public ICommand EditServerCommand { get; set; }
        public void EditServerCommand_Execute()
        {
            MessageBox.Show("Edit");
        }

        public bool EditServerCommand_CanExecute()
        {
            return true;
        }
        #endregion

        #region DeleteServerCommand
        public ICommand DeleteServerCommand { get; set; }
        public void DeleteServerCommand_Execute()
        {
            MessageBox.Show("Del");
        }

        public bool DeleteServerCommand_CanExecute()
        {
            return true;
        }
        #endregion

        #region AddSenderCommand
        public ICommand AddSenderCommand { get; set; }
        public void AddSenderCommand_Execute()
        {
            MessageBox.Show("add");
        }

        public bool AddSenderCommand_CanExecute()
        {
            return true;
        }
        #endregion

        #region EditSenderCommand
        public ICommand EditSenderCommand { get; set; }
        public void EditSenderCommand_Execute()
        {
            MessageBox.Show("Edit");
        }

        public bool EditSenderCommand_CanExecute()
        {
            return true;
        }
        #endregion

        #region DeleteSenderCommand
        public ICommand DeleteSenderCommand { get; set; }
        public void DeleteSenderCommand_Execute()
        {
            MessageBox.Show("Del");
        }

        public bool DeleteSenderCommand_CanExecute()
        {
            return true;
        }
        #endregion

        #region AddAddresseeCommand
        public ICommand AddAddresseeCommand { get; set; }
        public void AddAddresseeCommand_Execute()
        {
            MessageBox.Show("add");
        }

        public bool AddAddresseeCommand_CanExecute()
        {
            return true;
        }
        #endregion

        #region EditAddresseeCommand
        public ICommand EditAddresseeCommand { get; set; }
        public void EditAddresseeCommand_Execute()
        {
            MessageBox.Show("Edit");
        }

        public bool EditAddresseeCommand_CanExecute()
        {
            return true;
        }
        #endregion

        #region DeleteAddresseeCommand
        public ICommand DeleteAddresseeCommand { get; set; }
        public void DeleteAddresseeCommand_Execute()
        {
            MessageBox.Show("Del");
        }

        public bool DeleteAddresseeCommand_CanExecute()
        {
            return true;
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
            set { _selectedServer = value; }
        }
        public Sender SelectedSender
        {
            get { return _selectedSender; }
            set { _selectedSender = value; }
        }
        public Recipient SelectedRecipient
        {
            get { return _selectedRecipient; }
            set { _selectedRecipient = value; }
        }
        public Message SelectedMessage
        {
            get { return _selectedMessage; }
            set { _selectedMessage = value; }
        }

        

        public MainViewModel()
        {
            SendMessageCommand = new Command(SendMessageCommand_Execute, SendMessageCommand_CanExecute);
            DialogCommand = new RelayCommand<string>(DialogCommand_Execute, DialogCommand_CanExecute);

            AddServerCommand = new Command(AddServerCommand_Execute, AddServerCommand_CanExecute);
            EditServerCommand = new Command(EditServerCommand_Execute, EditServerCommand_CanExecute);
            DeleteServerCommand = new Command(DeleteServerCommand_Execute, DeleteServerCommand_CanExecute);

            AddSenderCommand = new Command(AddSenderCommand_Execute, AddSenderCommand_CanExecute);
            EditSenderCommand = new Command(EditSenderCommand_Execute, EditSenderCommand_CanExecute);
            DeleteSenderCommand = new Command(DeleteSenderCommand_Execute, DeleteSenderCommand_CanExecute);

            AddAddresseeCommand = new Command(AddAddresseeCommand_Execute, AddAddresseeCommand_CanExecute);
            EditAddresseeCommand = new Command(EditAddresseeCommand_Execute, EditAddresseeCommand_CanExecute);
            DeleteAddresseeCommand = new Command(DeleteAddresseeCommand_Execute, DeleteAddresseeCommand_CanExecute);

            Servers = new ObservableCollection<Server>(TestData.Servers);
            Senders = new ObservableCollection<Sender>(TestData.Senders);
            Recipients = new ObservableCollection<Recipient>(TestData.Recipients);
            Messages = new ObservableCollection<Message>(TestData.Messagess);
        }
    }
}
