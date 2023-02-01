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

        private void OnNavigateTo(object? sender, NavigateEventArgs e)
        {
            browserPresenter.Navigate(e.Url);
        }

        protected override void OnMainViewLoaded(object? sender, EventArgs e)
        {
            View.SetTop((UserControl)navigationBarPresenter.View);
            View.SetContent((UserControl)browserPresenter.View);
        }
    }
}
