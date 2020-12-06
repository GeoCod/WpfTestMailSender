﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using WpfTestMailSender.ViewModels;

namespace WpfTestMailSender
{
    /// <summary>Логика взаимодействия для App.xaml</summary>
    public partial class App : Application
    {
        private static IHost _hosting;

        public static IHost Hosting
        {
            get
            {
                if (_hosting != null) return _hosting;
                _hosting = Host.CreateDefaultBuilder(Environment.GetCommandLineArgs()).ConfigureServices(ConfigureServices).Build();
                return _hosting;
            }
        }

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
//#if DEBUG
//            services.AddTransient<IMailService, DebugMailService>();
//#else
//            services.AddTransient<IMailService, SmtpMailService>();
//#endif

            services.AddSingleton<MainViewModel>();

        }

        public static IServiceProvider Services { get { return Hosting.Services; } }
    }
}
