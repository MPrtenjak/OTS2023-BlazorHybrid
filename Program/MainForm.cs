using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using OTS2023.Messages;
using System.Diagnostics;
using System.Diagnostics.Metrics;

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

    // private readonly MessageBroker messageBroker = Program.serviceProvider!.GetRequiredService<MessageBroker>();
  }
}