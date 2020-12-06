using Microsoft.Extensions.DependencyInjection;
using WpfTestMailSender;

namespace WpfTestMailSender.ViewModels
{
    class ViewModelLocator
    {
        public MainViewModel MainWindowModel => App.Services.GetRequiredService<MainViewModel>();
    }
}
