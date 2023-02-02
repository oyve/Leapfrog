using System;

namespace Leapfrog.Views.Browser
{
    public interface IBrowserView : IView
    {
        event EventHandler<BrowserNavigationStateEventArgs> NavigationStateChanged;
    }
}
