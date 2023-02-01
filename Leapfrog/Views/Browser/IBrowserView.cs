using System;

namespace Leapfrog.Views.Browser
{
    public interface IBrowserView : IView
    {
        void Navigate(Uri url);
        void Back();
        void Forward();
        void Refresh();

        event EventHandler<BrowserNavigationStateEventArgs> NavigationStateChanged;
    }
}
