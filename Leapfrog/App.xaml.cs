using CommunityToolkit.Mvvm.Messaging;
using Leapfrog.Views.Browser;
using Leapfrog.Views.Main;
using Leapfrog.Views.Navigation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace Leapfrog
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Services = ConfigureServices();

            MainPresenter mainPresenter = Services.GetService<MainPresenter>();
            mainPresenter.Show();
        }

        public new static App Current => (App)Application.Current;
        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<NavigationViewModel>();
            services.AddTransient<MainViewModel>();

            services.AddSingleton<MainPresenter>();
            services.AddSingleton<NavigationPresenter>();
            services.AddSingleton<BrowserPresenter>();

            return services.BuildServiceProvider();
        }
    }
}
