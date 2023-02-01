namespace Leapfrog.Messages
{
    public abstract record BaseMessage();

    public record NavigateToMessage(string Url);
    public record SelectNavigationMessage();
    public record RefreshMessage();
    public record NavigationStateChangedMessage(bool CanGoBack, bool CanGoForward);
    public record NavigateBackMessage();
    public record NavigateForwardMessage() : BaseMessage; //just an example of using a record base;
}
