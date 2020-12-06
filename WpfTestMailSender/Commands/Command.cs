using System;
using System.Windows.Input;

namespace MailSender.Commands
{
    abstract class Command : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        bool ICommand.CanExecute(object parameter) => CanExecute(parameter);

        void ICommand.Execute(object parameter) => Execute(parameter);

        protected virtual bool CanExecute(object p) => true;

        protected abstract void Execute(object p);
    }

    //public class Command : ICommand
    //{
    //    public event EventHandler CanExecuteChanged
    //    {
    //        add { CommandManager.RequerySuggested += value; }
    //        remove { CommandManager.RequerySuggested -= value; }
    //    }
    //    private Action methodToExecute;
    //    private Func<bool> canExecuteEvaluator;
    //    public Command(Action methodToExecute, Func<bool> canExecuteEvaluator)
    //    {
    //        this.methodToExecute = methodToExecute;
    //        this.canExecuteEvaluator = canExecuteEvaluator;
    //    }
    //    public Command(Action methodToExecute)
    //        : this(methodToExecute, null)
    //    {
    //    }
    //    public bool CanExecute(object parameter)
    //    {
    //        if (this.canExecuteEvaluator == null)
    //        {
    //            return true;
    //        }
    //        else
    //        {
    //            bool result = this.canExecuteEvaluator.Invoke();
    //            return result;
    //        }
    //    }
    //    public void Execute(object parameter)
    //    {
    //        this.methodToExecute.Invoke();
    //    }
    //}
}
