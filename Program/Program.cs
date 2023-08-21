using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.PerformanceData;

namespace OTS2023
{
  internal static class Program
  {
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      var services = new ServiceCollection();
      services.AddWindowsFormsBlazorWebView();
      services.AddBlazorWebViewDeveloperTools();
      services.AddSingleton<CounterData>();

      serviceProvider = services.BuildServiceProvider();

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      ApplicationConfiguration.Initialize();
      Application.Run(new Form1());
    }

    public static ServiceProvider? serviceProvider;
  }
}