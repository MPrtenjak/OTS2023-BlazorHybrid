using Microsoft.AspNetCore.Components.WebView.WindowsForms;

namespace OTS2023
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();

      blazorWebView1.Dock = DockStyle.Fill;

      blazorWebView1.HostPage = "wwwroot\\index.html";
      blazorWebView1.Services = Program.serviceProvider!;
      blazorWebView1.RootComponents.Add<App>("#app");
    }
  }
}