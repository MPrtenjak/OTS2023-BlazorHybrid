using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using Microsoft.Extensions.DependencyInjection;
using OTS2023Shared.Messages;

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

      messageBroker.KeyboardEvent += BlazorKeyboard;
    }

    private void BlazorKeyboard(object? sender, KeyboardEventArgs e)
    {
      if (string.Compare(e.Code, "F4", ignoreCase: true) == 0)
      {
        blazorWebView1.Dock = (blazorWebView1.Dock == DockStyle.Fill) ? DockStyle.None : DockStyle.Fill;
      }
    }

    private readonly MessageBroker messageBroker = Program.ServiceProvider!.GetRequiredService<MessageBroker>();
  }
}