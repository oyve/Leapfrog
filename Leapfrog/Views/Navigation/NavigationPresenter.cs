using CommunityToolkit.Mvvm.Messaging;
using Leapfrog.Messages;
using System;

namespace Leapfrog.Views.Navigation
{
    internal class NavigationPresenter : BasePresenter<INavigationView>,
        INavigationPresenter, 
        IRecipient<SelectNavigationMessage>
    {
        public NavigationPresenter(NavigationViewModel viewModel, INavigationView navigationBarView) : base(navigationBarView)
        {
            SetDataContext(viewModel);
            WeakReferenceMessenger.Default.Register<SelectNavigationMessage>(this);
        }

        public void Receive(SelectNavigationMessage message)
        {
            View.SetFocusNavigation();
        }

        protected override void SubscribeToViewEvents()
        {
            
        }

        private void OnNavigateKeyUp(object? sender, EventArgs e)
        {

        }
    }
}
