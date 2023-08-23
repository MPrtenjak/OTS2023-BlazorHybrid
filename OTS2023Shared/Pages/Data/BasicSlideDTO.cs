namespace OTS2023Shared.Pages.Data
{
  public class BasicSlideDTO : SlideDTO
  {
    public string Content { get; init; }

    public BasicSlideDTO(string caption, string content)
        : base("BasicSlide", caption)
    {
      Content = content;
    }
  }
}
