namespace OTS2023.Messages
{
  internal class PageCaptionArgs : EventArgs
  {
    public string Caption { get; set; } = string.Empty;

    public static PageCaptionArgs Create(string caption)
    {
      return new PageCaptionArgs { Caption = caption };
    }
  }
}
