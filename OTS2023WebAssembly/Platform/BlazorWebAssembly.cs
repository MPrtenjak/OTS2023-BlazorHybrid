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

    public async Task<Dictionary<Language, XDocument>> ReadSlideData()
    {
      string filePath = "data";

      Dictionary<Language, string> languageFiles = new()
      {
        { Language.Si, "blazor_hybrid.xml" },
        { Language.En, "blazor_hybrid_en.xml" },
      };

      Dictionary<Language, XDocument> result = new();

      foreach (var languageFile in languageFiles)
      {

        var xmlDataFile = $"_content/OTS2023Shared/{filePath}/{languageFile.Value}";
        var slides = await _http.GetStringAsync(xmlDataFile);
        result.Add(languageFile.Key, XDocument.Parse(slides));
      }

      return result;
    }

    public Task RunExternalExample(string exampleKey)
    {
      return Task.CompletedTask;
    }

    private readonly HttpClient _http;
  }
}
