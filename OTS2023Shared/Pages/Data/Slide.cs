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

      throw new ArgumentException($"Unknown slide type: {type}");
    }
  }
}
