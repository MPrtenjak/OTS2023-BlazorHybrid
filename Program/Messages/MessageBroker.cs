namespace OTS2023.Messages
{
  internal class MessageBroker
  {
    public event EventHandler<PageCaptionArgs> CaptionChangedEvent = null!;
    public event EventHandler NextPageEvent = null!;
    public event EventHandler PrevPageEvent = null!;

    public void NotifyNewCaption(string newCaption)
    {
      CaptionChangedEvent?.Invoke(this, PageCaptionArgs.Create(newCaption));
    }

    public void NotifyNextPage()
    {
      NextPageEvent?.Invoke(this, EventArgs.Empty);
    }

    public void NotifyPrevPage()
    {
      PrevPageEvent?.Invoke(this, EventArgs.Empty);
    }
  }
}
