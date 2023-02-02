using Leapfrog.Views.Browser;
using Leapfrog.Views.Navigation;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Leapfrog.Views.Main
{
    internal class MainPresenter : BasePresenter<MainView>
    {
        private readonly NavigationPresenter navigationBarPresenter;
        private readonly BrowserPresenter browserPresenter;

        public MainPresenter(
            MainViewModel mainViewModel,
            NavigationPresenter navigationBarPresenter,
            BrowserPresenter browserPresenter) : base()
        {
            this.navigationBarPresenter = navigationBarPresenter;
            this.browserPresenter = browserPresenter;

            SetDataContext(mainViewModel);
        }

        public void Show()
        {
            View.Show();
        }

        ////NOTE: In MVVM you are able to load dynamic views either View First or ViewModel first.
        ////In VM-First you would typically make a DataTemplate in XAML and map the View and ViewModel, and assign the VM through {Binding}
        ////Because this is MVP, the View doesn't know anything about the world or types, neither does VM, and thus this is assigned directly by the Presenter, as the Presenter knows the View

        protected override void View_Loaded(object? sender, RoutedEventArgs e)
        {
            base.View_Loaded(sender, e);

            View.TopArea.Content = navigationBarPresenter.View;
            View.MainArea.Content = browserPresenter.View;
        }
    }
}
