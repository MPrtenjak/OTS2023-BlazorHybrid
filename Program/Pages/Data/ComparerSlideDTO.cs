namespace OTS2023.Pages.Data
{
  public class ComparerSlideDTO : SlideDTO
  {
    public string VueCode { get; init; }
    public string BlazorCode { get; init; }
    public Type BlazorComponent { get; init; }

    public ComparerSlideDTO(string caption, string vueCode, string blazorCode, Type blazorComponent)
        : base("ShowComparisementSlide", caption)
    {
      VueCode = vueCode;
      BlazorCode = blazorCode;
      BlazorComponent = blazorComponent;
    }
  }
}
