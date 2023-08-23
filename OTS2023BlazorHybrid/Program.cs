using Microsoft.Extensions.DependencyInjection;
using OTS2023Shared.Messages;

namespace OTS2023
{
  internal static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main()
    {
      var services = new ServiceCollection();
      services.AddWindowsFormsBlazorWebView();
      services.AddBlazorWebViewDeveloperTools();
      services.AddSingleton<MessageBroker>();

      serviceProvider = services.BuildServiceProvider();

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      ApplicationConfiguration.Initialize();
      Application.Run(new MainForm());
    }

    public static ServiceProvider? serviceProvider;
  }
}