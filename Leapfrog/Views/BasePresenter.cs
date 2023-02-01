using CommunityToolkit.Diagnostics;
using Leapfrog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Leapfrog.Views
{
    public interface IBasePresenter<T>
    {
        T View { get; }
    }

    internal abstract class BasePresenter<T> : IBasePresenter<T> where T : IView
    {
        public BasePresenter(T view)
        {
            View = view;

            SubscribeToViewEvents();
        }

        public T View { get; }

        protected virtual void SubscribeToViewEvents()
        {
            View.ViewLoaded += OnMainViewLoaded;
        }

        protected virtual void OnMainViewLoaded(object? sender, EventArgs e)
        {
        }

        protected void SetDataContext(IViewModel viewModel)
        {
            Guard.IsNotNull(viewModel);

            (View as ContentControl).DataContext = viewModel;
        }
    }
}
