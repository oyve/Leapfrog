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

        public void SetTop(ContentControl control)
        {
            //control.Height = 50;
            SetDock(control, Dock.Top);
        }

        public void SetContent(ContentControl control)
        {
            SetDock(control, Dock.Bottom);
        }

        void SetDock(ContentControl control, Dock dock)
        {
            DockPanel.SetDock(control, dock);
            MainDockPanel.Children.Add(control);
        }

    }
}
