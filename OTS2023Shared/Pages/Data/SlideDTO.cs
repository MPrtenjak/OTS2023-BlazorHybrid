namespace OTS2023Shared.Pages.Data
{
  public class SlideDTO
  {
    public Type SlideComponent { get; init; }
    public string Caption { get; init; }

    public SlideDTO(string slideComponentName, string caption)
    {
      SlideComponent = GetSlideComponentType(slideComponentName);
      Caption = caption;
    }

    private static Type GetSlideComponentType(string slideComponentName)
    {
      var fullTypeName = "OTS2023Shared.Pages.SlideTemplates." + slideComponentName;
      return Type.GetType(fullTypeName)!;
    }
  }
}
