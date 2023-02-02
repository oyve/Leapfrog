using CommunityToolkit.Diagnostics;
using Leapfrog.ViewModels;
using System.Windows.Controls;

namespace Leapfrog.Views
{
    internal abstract class BasePresenter<TView> where TView: ContentControl, new()
    {
        public BasePresenter() : this(new())
        {
        }

        public BasePresenter(TView view)
        {
            View = view;

            View.Loaded += View_Loaded;
            View.Unloaded += View_Unloaded;
        }

        public TView View { get; }

        protected virtual void View_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            View.DataContext = null;
        }

        protected virtual void View_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        protected void SetDataContext(BaseViewModel viewModel)
        {
            Guard.IsNotNull(viewModel);

            View.DataContext = viewModel;
        }
    }
}
