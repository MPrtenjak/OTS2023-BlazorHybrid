using Microsoft.AspNetCore.Components.WebView.WindowsForms;

namespace OTS2023
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();

      WindowState = FormWindowState.Maximized;

      blazorWebView1.Dock = DockStyle.Fill;

      blazorWebView1.HostPage = "wwwroot\\index.html";
      blazorWebView1.Services = Program.ServiceProvider!;
      blazorWebView1.RootComponents.Add<App>("#app");
    }

    // private readonly MessageBroker messageBroker = Program.serviceProvider!.GetRequiredService<MessageBroker>();
  }
}