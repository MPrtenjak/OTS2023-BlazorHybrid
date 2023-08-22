using Microsoft.JSInterop;

namespace OTS2023.Helpers
{
    public static class IJSRuntimeExtensionMethods
    {
        public static ValueTask<object> SetInSessionStorage(this IJSRuntime js, string key, string content)
            => js.InvokeAsync<object>("sessionStorage.setItem", key, content);
        public static ValueTask<string> GetFromSessionStorage(this IJSRuntime js, string key)
                => js.InvokeAsync<string>("sessionStorage.getItem", key);

        public static ValueTask<object> SetInLocalStorage(this IJSRuntime js, string key, string content)
            => js.InvokeAsync<object>("localStorage.setItem", key, content);
        public static ValueTask<string> GetFromLocalStorage(this IJSRuntime js, string key)
                => js.InvokeAsync<string>("localStorage.getItem", key);


        public static ValueTask<object> DoHighlight(this IJSRuntime js)
                => js.InvokeAsync<object>("hljs.highlightAll");
        public static ValueTask<string> HighlightString(this IJSRuntime js, string code, string language)
                => js.InvokeAsync<string>("highlightCode", code, language);

        public static ValueTask<string> ChangeURL(this IJSRuntime js, string subPage)
                => js.InvokeAsync<string>("changeUrl", subPage);
    }
}
