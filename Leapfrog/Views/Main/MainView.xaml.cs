using System;
using System.Windows;
using System.Windows.Controls;

namespace Leapfrog.Views.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window, IMainView
    {
        public event EventHandler ViewLoaded;

        public MainView()
        {
            InitializeComponent();
        }

        public void ShowMainView()
        {
            this.Show();
        }

        private void MainView_Loaded(object sender, RoutedEventArgs e)
        {
            ViewLoaded?.Invoke(this, e);
        }
    }
}
