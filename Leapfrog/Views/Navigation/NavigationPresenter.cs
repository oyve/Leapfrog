using CommunityToolkit.Mvvm.Messaging;
using Leapfrog.Messages;
using System;
using System.Security.Policy;
using System.Windows.Input;

namespace Leapfrog.Views.Navigation
{
    internal class NavigationPresenter : BasePresenter<NavigationView>, IRecipient<SelectNavigationMessage>
    {
        public NavigationPresenter(NavigationViewModel viewModel) : base()
        {
            WeakReferenceMessenger.Default.Register<SelectNavigationMessage>(this);

            SetDataContext(viewModel);
        }

        public void Receive(SelectNavigationMessage message)
        {
            View.URL.Focusable = true;
            View.URL.Focus();
            Keyboard.Focus(View.URL);
            View.URL.SelectAll();
        }
    }
}
