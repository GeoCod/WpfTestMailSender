using System;
using System.Windows;
using System.Windows.Input;
using WpfTestMailSender.Commands;

namespace WpfTestMailSender.ViewModels
{
    public class MainViewModel : ViewModelBase
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


        public MainViewModel()
        {
            CloseProgramCommand = new Command(CloseProgramCommand_Execute, CloseProgramCommand_CanExecute);
            DialogCommand = new RelayCommand<string>(DialogCommand_Execute, DialogCommand_CanExecute);
        }
    }
}
