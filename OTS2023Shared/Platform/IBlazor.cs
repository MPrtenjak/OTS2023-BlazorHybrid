using System.Xml.Linq;

namespace OTS2023Shared.Platform
{
  public enum BlazorType
  {
    WebAssembly,
    Hybrid
  }

  public interface IBlazor
  {
    BlazorType BlazorType { get; }

    Task<XDocument> ReadSlideData();

    Task RunExternalExample(string exampleId);

    Task CompareMainFormOfExample(string exampleId);
  }
}
