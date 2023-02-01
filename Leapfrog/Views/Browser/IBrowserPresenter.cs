namespace Leapfrog.Views.Browser
{
    internal interface IBrowserPresenter : IBasePresenter<IBrowserView>
    {
        void Navigate(string url);
    }
}
