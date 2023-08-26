using OTS2023Shared.Platform;
using System.Diagnostics;
using System.Xml.Linq;

namespace OTS2023WebAssembly.Platform
{
  public class BlazorWebAssembly : IBlazor
  {
    public BlazorType BlazorType => BlazorType.WebAssembly;

    public BlazorWebAssembly(HttpClient http)
    {
      _http = http;
    }

    public async Task<XDocument> ReadSlideData()
    {
      string fileName = "blazor_hybrid.xml";
      string filePath = "data";

      var xmlDataFile = $"_content/OTS2023Shared/{filePath}/{fileName}";
      var stringResult = await _http.GetStringAsync(xmlDataFile);
      return XDocument.Parse(stringResult);
    }

    public Task RunExternalExample(string exampleKey)
    {
      return Task.CompletedTask;
    }

    private readonly HttpClient _http;
  }
}
