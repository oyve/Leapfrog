using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Leapfrog.Views.Navigation
{
    public class NavigateEventArgs : EventArgs
    {
        public NavigateEventArgs(string url)
        {
            Url = url;
        }

        public string Url { get; }
    }

    /// <summary>
    /// Interaction logic for NavigationBarView.xaml
    /// </summary>
    public partial class NavigationView : UserControl, INavigationView
    {
        public event EventHandler ViewLoaded;

        public NavigationView() => InitializeComponent();

        private void NavigationBarView_Loaded(object sender, RoutedEventArgs e)
        {
            ViewLoaded?.Invoke(this, e);
        }

        public void SetFocusNavigation()
        {
            URL.Focusable = true;
            URL.Focus();
            Keyboard.Focus(URL);
            URL.SelectAll();
        }
    }
}
