using Microsoft.JSInterop;

namespace OTS2023.Helpers
{
    public class GestureEventInterop
    {
        private readonly IJSRuntime jsRuntime;
        private DotNetObjectReference<GestureEventHelper>? netObjectReference;

        public GestureEventInterop(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public ValueTask SetupGestureEventCallback(Func<string, Task> callback)
        {
            netObjectReference = DotNetObjectReference.Create(new GestureEventHelper(callback));
            return jsRuntime.InvokeVoidAsync("addGestureEventListener", netObjectReference);
        }

        public ValueTask TearDownGestureEventCallback()
        {
            netObjectReference?.Dispose();
            return jsRuntime.InvokeVoidAsync("removeGestureEventListener");
        }
    }
}
