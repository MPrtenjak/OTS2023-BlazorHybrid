using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OTS2023.Platform;
using OTS2023Shared.Messages;
using OTS2023Shared.Platform;
using System.Reflection;

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

      var configurationBuilder = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
      var configuration = configurationBuilder.Build();
      AppSettings = configuration.Get<AppConfiguration>();

      var services = new ServiceCollection();
      services.AddWindowsFormsBlazorWebView();
      services.AddBlazorWebViewDeveloperTools();

      services.AddSingleton<MessageBroker>();
      services.AddScoped<IBlazor, BlazorHybrid>();
      services.AddScoped(sp => new HttpClient());

      ServiceProvider = services.BuildServiceProvider();

      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      ApplicationConfiguration.Initialize();
      Application.Run(new MainForm());
    }

    public static ServiceProvider? ServiceProvider;
    public static AppConfiguration? AppSettings { get; set; }
  }
}