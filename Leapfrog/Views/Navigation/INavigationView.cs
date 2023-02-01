using System;
using System.Windows.Controls;

namespace Leapfrog.Views.Navigation
{
    public interface INavigationView : IView
    {
        void SetFocusNavigation();
    }
}