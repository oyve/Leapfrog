using System;
using System.Windows;
using System.Windows.Controls;

namespace Leapfrog.Views.Main
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public event EventHandler ViewLoaded;

        public MainView()
        {
            InitializeComponent();
        }
    }
}
