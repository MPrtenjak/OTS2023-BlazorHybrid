using System.Xml.Linq;

namespace OTS2023Shared.Platform
{
  public enum BlazorType
  {
    WebAssembly,
    Hybrid
  }

  public enum Language
  {
    Si,
    En,
  }

  public interface IBlazor
  {
    BlazorType BlazorType { get; }

    Task<Dictionary<Language, XDocument>> ReadSlideData();

    Task RunExternalExample(string exampleKey);
  }
}
