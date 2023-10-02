using OTS2023Shared.Platform;
using System.Xml.Linq;
using System.Xml.XPath;

namespace OTS2023Shared.Pages.Data
{
  public class SlideCollection
  {
    public Language CurrentLanguage { get; set; }

    public SlideCollection()
    {
      CurrentLanguage = Language.Si;
    }

    public void Add(Dictionary<Language, XDocument> xmlData)
    {
      foreach (var key in xmlData.Keys)
        _slides.Add(key, ConvertFromXml(xmlData[key]));
    }

    public SlideDTO this[int index] => _slides[CurrentLanguage][index];

    public int Count => _slides.ContainsKey(CurrentLanguage)
      ? _slides[CurrentLanguage].Count
      : 0;

    private static List<SlideDTO> ConvertFromXml(XDocument xDocument)
    {
      List<SlideDTO> result = new();

      foreach (var slide in xDocument.XPathSelectElements("//Slide"))
        result.Add(Slide.FromXElement(slide));

      return result;
    }

    private readonly Dictionary<Language, List<SlideDTO>> _slides = new();
  }
}
