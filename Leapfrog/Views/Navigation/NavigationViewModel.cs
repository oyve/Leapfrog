using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Leapfrog.Helpers;
using Leapfrog.Messages;
using Leapfrog.ViewModels;
using System;

namespace Leapfrog.Views.Navigation
{
    public class NavigationViewModel : BaseViewModel,
        IRecipient<NavigationStateChangedMessage>
    {
        public RelayCommand BackCommand { get; private set; }
        public RelayCommand ForwardCommand { get; private set; }
        public RelayCommand NavigateCommand { get; private set; }
        private string _url = string.Empty;

        public string URL
        {
            get => _url;
            set
            {
                SetProperty(ref _url, value);
                NavigateCommand.NotifyCanExecuteChanged();
            }
        }

        public NavigationViewModel()
        {
            WeakReferenceMessenger.Default.Register<NavigationStateChangedMessage>(this);

            BackCommand = new RelayCommand(NavigateBack, () => { return NavigationState != null && NavigationState.CanGoBack; });
            ForwardCommand = new RelayCommand(NavigateForward, () => { return NavigationState != null && NavigationState.CanGoForward; });
            NavigateCommand = new RelayCommand(NavigateTo, IsValidUrl);

            URL = "Type an URL...";
        }

        private void NavigateBack()
        {
            WeakReferenceMessenger.Default.Send(new NavigateBackMessage());
        }

        private void NavigateForward()
        {
            WeakReferenceMessenger.Default.Send(new NavigateForwardMessage());
        }

        bool IsValidUrl()
        {
            return UrlHelper.IsValidUrl(URL);
        }

        private void NavigateTo()
        {
            var message = new NavigateToMessage(URL);
            WeakReferenceMessenger.Default.Send(message);
        }

        public NavigationStateChangedMessage? NavigationState { get; private set; }

        void IRecipient<NavigationStateChangedMessage>.Receive(NavigationStateChangedMessage message)
        {
            NavigationState = message;
            BackCommand.NotifyCanExecuteChanged();
            ForwardCommand.NotifyCanExecuteChanged();
        }
    }
}
