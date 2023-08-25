using Microsoft.JSInterop;

namespace OTS2023Shared.Helpers
{
  public class RunExampleEventHelper
  {
    private readonly Func<string, Task> externalProgramCallback;

    public RunExampleEventHelper(Func<string, Task> callback)
    {
      externalProgramCallback = callback;
    }

    [JSInvokable]
    public Task OnRunExample(string programID)
    {
      return externalProgramCallback(programID);
    }
  }
}
