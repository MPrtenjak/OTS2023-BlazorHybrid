using Microsoft.JSInterop;

namespace OTS2023Shared.Helpers
{
  public class RunExampleEventInterop
  {
    private readonly IJSRuntime jsRuntime;
    private DotNetObjectReference<RunExampleEventHelper>? netObjectReference;

    public RunExampleEventInterop(IJSRuntime jsRuntime)
    {
      this.jsRuntime = jsRuntime;
    }

    public ValueTask SetupRunExampleEventCallback(Func<string, Task> callback)
    {
      netObjectReference = DotNetObjectReference.Create(new RunExampleEventHelper(callback));
      return jsRuntime.InvokeVoidAsync("addRunExampleEventListener", netObjectReference);
    }

    public ValueTask TearDownRunExampleEventCallback()
    {
      netObjectReference?.Dispose();
      return jsRuntime.InvokeVoidAsync("removeRunExampleEventListener");
    }
  }
}
