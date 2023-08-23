using Microsoft.JSInterop;

namespace OTS2023Shared.Helpers
{
  public class GestureEventHelper
  {
    private readonly Func<string, Task> gestureCallback;

    public GestureEventHelper(Func<string, Task> callback)
    {
      gestureCallback = callback;
    }

    [JSInvokable]
    public Task OnGesture(string gesture) => gestureCallback(gesture);
  }
}
