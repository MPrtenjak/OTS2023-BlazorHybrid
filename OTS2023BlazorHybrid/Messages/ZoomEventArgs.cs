namespace OTS2023.Messages
{
  internal class ZoomEventArgs : EventArgs
  {
    public int Zoom { get; set; } = 100;

    public static ZoomEventArgs Create(int zoom)
    {
      return new ZoomEventArgs { Zoom = zoom };
    }
  }
}
