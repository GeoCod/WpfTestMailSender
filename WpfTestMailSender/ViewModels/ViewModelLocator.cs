using Microsoft.Extensions.DependencyInjection;
using MailSender;

namespace MailSender.ViewModels
{
    class ViewModelLocator
    {
        public MainViewModel MainWindowModel => App.Services.GetRequiredService<MainViewModel>();
    }
}
