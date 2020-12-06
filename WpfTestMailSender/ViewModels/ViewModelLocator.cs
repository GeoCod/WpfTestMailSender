using Microsoft.Extensions.DependencyInjection;
using MailSender;

namespace MailSender.ViewModels
{
    class ViewModelLocator
    {
        public MainWindowViewModel MainWindowModel => App.Services.GetRequiredService<MainWindowViewModel>();
    }
}
