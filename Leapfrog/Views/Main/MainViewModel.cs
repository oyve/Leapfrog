using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Leapfrog.Messages;
using Leapfrog.ViewModels;
using System;

namespace Leapfrog.Views.Main
{

    internal class MainViewModel : BaseViewModel
    {
        public RelayCommand RefreshCommand { get; private set; }
        public RelayCommand SelectNavigationCommand { get; private set; }

        public MainViewModel()
        {
            RefreshCommand = new RelayCommand(OnRefresh);
            SelectNavigationCommand = new RelayCommand(OnSelectNavigation);
        }

        private void OnSelectNavigation()
        {
            WeakReferenceMessenger.Default.Send(new SelectNavigationMessage());
        }

        private void OnRefresh()
        {
            WeakReferenceMessenger.Default.Send(new RefreshMessage());
        }
    }
}
