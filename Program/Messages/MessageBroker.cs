namespace OTS2023.Messages
{
  internal class MessageBroker
  {
    public event EventHandler<PageCaptionArgs> CaptionChangedEvent = null!;

    public void NotifyNewCaption(string newCaption)
    {
      CaptionChangedEvent?.Invoke(this, PageCaptionArgs.Create(newCaption));
    }
  }
}
