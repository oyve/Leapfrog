using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Leapfrog.Views.Browser
{
    public record BrowserNavigationStateEventArgs(bool CanGoBack, bool CanGoForward);

    /// <summary>
    /// Interaction logic for BrowserView.xaml
    /// </summary>
    public partial class BrowserView : UserControl, IBrowserView
    {
        public event EventHandler ViewLoaded;
        public event EventHandler<BrowserNavigationStateEventArgs> NavigationStateChanged;

        public BrowserView()
        {
            InitializeComponent();
            Loaded += BrowserView_Loaded;
        }

        private void BrowserView_Loaded(object sender, RoutedEventArgs e)
        {
            ViewLoaded?.Invoke(this, e);
        }

        //To reduce Code Behind one could also make bindable Browser extensions
        //https://stackoverflow.com/questions/263551/databind-the-source-property-of-the-webbrowser-in-wpf/265648#265648

        private void Browser_Navigated(object sender, NavigationEventArgs e)
        {
            SetSilent(Browser, true); // disable javascript errors
            
            NavigationStateChanged?.Invoke(this, new BrowserNavigationStateEventArgs(Browser.CanGoBack, Browser.CanGoForward));
        }

        /// <summary>
        /// Suppress browser scripts errrors
        /// https://stackoverflow.com/questions/6138199/wpf-webbrowser-control-how-to-suppress-script-errors
        /// </summary>
        /// <param name="browser"></param>
        /// <param name="silent"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void SetSilent(WebBrowser browser, bool silent)
        {
            if (browser == null) throw new ArgumentNullException(nameof(browser));

            // get an IWebBrowser2 from the document
            if (browser.Document is IOleServiceProvider sp)
            {
                Guid IID_IWebBrowserApp = new("0002DF05-0000-0000-C000-000000000046");
                Guid IID_IWebBrowser2 = new("D30C1661-CDAF-11d0-8A3E-00C04FC9E26E");

                sp.QueryService(ref IID_IWebBrowserApp, ref IID_IWebBrowser2, out object webBrowser);
                webBrowser?.GetType().InvokeMember("Silent", BindingFlags.Instance | BindingFlags.Public | BindingFlags.PutDispProperty, null, webBrowser, new object[] { silent });
            }
        }

        [ComImport, Guid("6D5140C1-7436-11CE-8034-00AA006009FA"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface IOleServiceProvider
        {
            [PreserveSig]
            int QueryService([In] ref Guid guidService, [In] ref Guid riid, [MarshalAs(UnmanagedType.IDispatch)] out object ppvObject);
        }
    }
}
