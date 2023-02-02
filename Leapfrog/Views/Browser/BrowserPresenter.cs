using CommunityToolkit.Mvvm.Messaging;
using Leapfrog.Messages;
using System;
using System.Windows;

namespace Leapfrog.Views.Browser
{
    internal class BrowserPresenter : BasePresenter<BrowserView>,
        IRecipient<NavigateToMessage>,
        IRecipient<RefreshMessage>,
        IRecipient<NavigateBackMessage>,
        IRecipient<NavigateForwardMessage>
    {
        public BrowserPresenter() : base()
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
                //(View as BrowserView).Browser.Navigate(new Uri(url));
                Navigate(new Uri(url));
            }
            catch(Exception ex)
            {
                //show 404
                Navigate(new Uri(Environment.CurrentDirectory + "/Resources/404.html"));
            }
        }

        public void Navigate(Uri uri)
        {
            View.Browser.Navigate(uri);
        }

        protected override void View_Loaded(object? sender, RoutedEventArgs e)
        {
            base.View_Loaded(sender, e);

            Uri url = new(Environment.CurrentDirectory + "/Resources/intro.html");
            Navigate(url);
        }

        public void Receive(NavigateToMessage message)
        {
            Navigate(message.Url);
        }

        public void Receive(RefreshMessage message)
        {
            View.Browser.Refresh();
        }

        public void Receive(NavigateBackMessage message)
        {
            View.Browser.GoBack();
        }

        public void Receive(NavigateForwardMessage message)
        {
            View.Browser.GoForward();
        }
    }
}