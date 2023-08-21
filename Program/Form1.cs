using Microsoft.AspNetCore.Components.WebView.WindowsForms;

namespace OTS2023
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();

      blazorWebView1.Dock = DockStyle.Fill;

      blazorWebView1.HostPage = "wwwroot\\index.html";
      blazorWebView1.Services = Program.serviceProvider!;
      blazorWebView1.RootComponents.Add<Counter>("#app");
    }
  }
}