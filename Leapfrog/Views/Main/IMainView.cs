using Leapfrog.Views;
using System;
using System.Windows.Controls;

namespace Leapfrog.Views.Main
{
    public interface IMainView : IView
    {
        //event EventHandler MainViewLoaded;
        void Show();
        void SetTop(ContentControl control);
        void SetContent(ContentControl control);
    }
}