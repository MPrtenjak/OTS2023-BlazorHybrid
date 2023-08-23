namespace OTS2023Shared.Messages
{
  public class ZoomEventArgs : EventArgs
  {
    public int Zoom { get; set; } = 100;

    public static ZoomEventArgs Create(int zoom)
    {
      return new ZoomEventArgs { Zoom = zoom };
    }
  }
}
