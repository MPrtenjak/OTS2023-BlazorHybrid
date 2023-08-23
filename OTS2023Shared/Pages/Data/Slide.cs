using System.Xml.Linq;

namespace OTS2023Shared.Pages.Data
{
  public class Slide
  {
    public static SlideDTO FromXElement(XElement xElement)
    {
      string type = xElement.Element("Type")?.Value ?? string.Empty;

      if (string.Equals(type, "Slide", StringComparison.InvariantCultureIgnoreCase))
        return new BasicSlideDTO(
            caption: xElement.Element("Caption")!.Value,
            content: xElement.Element("Content")!.Value.Trim()
        );

      if (string.Equals(type, "Comparer", StringComparison.InvariantCultureIgnoreCase))
        return new ComparerSlideDTO(
            caption: xElement.Element("Caption")!.Value,
            vueCode: xElement.Element("VueCode")?.Value.Trim() ?? string.Empty,
            blazorCode: xElement.Element("BlazorCode")?.Value.Trim() ?? string.Empty,
            blazorComponent: GetTypeFromPartialName(xElement.Element("BlazorComponent")!.Value)
        );

      return new ProjectFileSlideDTO(
          caption: xElement.Element("Caption")!.Value,
          content: xElement.Element("Content")!.Value.Trim()
      );
    }

    private static Type GetTypeFromPartialName(string partialName)
    {
      var fullTypeName = "OTS2023Shared.Pages.Components." + partialName;
      return Type.GetType(fullTypeName)!;
    }
  }
}
