using Microsoft.AspNetCore.Components.Web;

namespace OTS2023.Messages
{
  internal class MessageBroker
  {
    public event EventHandler<KeyboardEventArgs> KeyboardEvent = null!;
    public event EventHandler<ZoomEventArgs> ZoomChangedEvent = null!;

    public void NotifyNewKeyboardEvent(KeyboardEventArgs e)
    {
      KeyboardEvent?.Invoke(this, e);
    }

    public void NotifyZoomChanged(int zoom)
    {
      ZoomChangedEvent?.Invoke(this, ZoomEventArgs.Create(zoom));
    }
  }
}
