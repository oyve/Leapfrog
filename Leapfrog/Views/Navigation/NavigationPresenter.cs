using CommunityToolkit.Mvvm.Messaging;
using Leapfrog.Messages;
using System;

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
            View.SetFocusNavigation();
        }
    }
}
