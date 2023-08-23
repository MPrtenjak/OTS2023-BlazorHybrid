namespace OTS2023.Pages.Data
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
