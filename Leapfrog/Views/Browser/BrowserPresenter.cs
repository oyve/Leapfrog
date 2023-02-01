using CommunityToolkit.Mvvm.Messaging;
using Leapfrog.Messages;
using System;

namespace Leapfrog.Views.Browser
{
    internal class BrowserPresenter : BasePresenter<IBrowserView>,
        IBrowserPresenter, 
        IRecipient<NavigateToMessage>,
        IRecipient<RefreshMessage>,
        IRecipient<NavigateBackMessage>,
        IRecipient<NavigateForwardMessage>
    {
        public BrowserPresenter(IBrowserView browserView) : base(browserView)
        {
            WeakReferenceMessenger.Default.Register<NavigateToMessage>(this);
            WeakReferenceMessenger.Default.Register<RefreshMessage>(this);
            WeakReferenceMessenger.Default.Register<NavigateBackMessage>(this);
            WeakReferenceMessenger.Default.Register<NavigateForwardMessage>(this);

            View.NavigationStateChanged += OnNavigationStateChanged;
        }

        private void OnNavigationStateChanged(object? sender, BrowserNavigationStateEventArgs e)
        {
            WeakReferenceMessenger.Default.Send(new NavigationStateChangedMessage(e.CanGoBack, e.CanGoForward));
        }

        public void Navigate(string url)
        {
            if (!url.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
            {
                url = "https://" + url;
            }

            try
            {
                View.Navigate(new Uri(url));
            }
            catch(Exception ex)
            {
                //do some logging
                //show 404
                View.Navigate(new(Environment.CurrentDirectory + "/Resources/404.html"));
            }
        }

        protected override void SubscribeToViewEvents()
        {
            View.ViewLoaded += View_ViewLoaded;
        }

        private void View_ViewLoaded(object? sender, EventArgs e)
        {
            Uri url = new(Environment.CurrentDirectory + "/Resources/intro.html");
            View.Navigate(url);
        }

        public void Receive(NavigateToMessage message)
        {
            Navigate(message.Url);
        }

        public void Receive(RefreshMessage message)
        {
            View.Refresh();
        }

        public void Receive(NavigateBackMessage message)
        {
            View.Back();
        }

        public void Receive(NavigateForwardMessage message)
        {
            View.Forward();
        }
    }
}