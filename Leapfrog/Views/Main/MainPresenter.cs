using Leapfrog.Views.Browser;
using Leapfrog.Views.Navigation;
using System;
using System.Windows.Controls;

namespace Leapfrog.Views.Main
{
    internal class MainPresenter : BasePresenter<IMainView>, IMainPresenter
    {
        private readonly INavigationPresenter navigationBarPresenter;
        private readonly IBrowserPresenter browserPresenter;

        public MainPresenter(
            IMainView mainView,
            MainViewModel mainViewModel,
            INavigationPresenter navigationBarPresenter,
            IBrowserPresenter browserPresenter) : base(mainView)
        {
            this.navigationBarPresenter = navigationBarPresenter;
            this.browserPresenter = browserPresenter;

            SetDataContext(mainViewModel);
        }

        public void ShowView()
        {
            View.Show();
        }

        public void SetMainView(IMainView mainView) { }


        ////NOTE: In MVVM you are able to load dynamic views either View First or ViewModel first.
        ////In VM-First you would typically make a DataTemplate in XAML and map the View and ViewModel, and assign the VM through {Binding}
        ////Because this is MVP, the View doesn't know anything about the world or types, neither does VM, and thus this is assigned directly by the Presenter, as the Presenter knows the View
        
        protected override void OnMainViewLoaded(object? sender, EventArgs e)
        {
            if (View != null)
            {
                (View as MainView).TopContent.Content = navigationBarPresenter.View;
                (View as MainView).MainContent.Content = browserPresenter.View;
            }
        }
    }
}
