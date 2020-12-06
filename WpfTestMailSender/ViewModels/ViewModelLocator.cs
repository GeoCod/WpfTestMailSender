using Microsoft.Extensions.DependencyInjection;

namespace WpfTestMailSender.ViewModels
{
    class ViewModelLocator
    {
        public MainViewModel MainWindowModel => App.Services.GetRequiredService<MainViewModel>();
    }
}
