
using OTS2023Shared.Platform;
using System.Diagnostics;
using System.Xml.Linq;

namespace OTS2023.Platform
{
  public class BlazorHybrid : IBlazor
  {
    public BlazorType BlazorType => BlazorType.Hybrid;

    public async Task<XDocument> ReadSlideData()
    {
      string fileName = "blazor_hybrid.xml";
      string filePath = "data";

      var xmlDataFile = $"wwwroot/{filePath}/{fileName}";
      using var stream = System.IO.File.OpenRead(xmlDataFile);
      return await XDocument.LoadAsync(stream, LoadOptions.None, CancellationToken.None);
    }

    public Task RunExternalExample(string exampleId)
    {
      /*
      string executablePath = @"ExecutableFiles";

      var examplePath = Path.Combine(basePath, executablePath, $"STEP{exampleId}", "Simple CRUD.exe");
      var psi = new ProcessStartInfo(examplePath);
      _ = Process.Start(psi);

      return Task.CompletedTask;
      */
      return CompareMainFormOfExample(exampleId);
    }

    public Task CompareMainFormOfExample(string exampleId)
    {
      string comparePath = Path.Combine(basePath, "compares");
      if (!Directory.Exists(comparePath))
      {
        Directory.CreateDirectory(comparePath);
      }

      runGit("1");
      runGit(exampleId);
      runWinMerge(exampleId);
      return Task.CompletedTask;

      void runGit(string stepId)
      {
        string command = $"/c git show STEP{stepId}:\"Simple CRUD/Main.cs\" > compares/STEP{stepId}_Main.cs";
        var psi = new ProcessStartInfo();
        psi.FileName = "cmd";
        psi.Arguments = command;
        psi.WorkingDirectory = basePath;
        _ = Process.Start(psi);
      }

      void runWinMerge(string stepId)
      {
        string command = @"C:\Program Files\WinMerge\WinMergeU.exe ";
        string arguments = $"compares/STEP1_Main.cs compares/STEP{stepId}_Main.cs";

        var psi = new ProcessStartInfo();
        psi.FileName = command;
        psi.Arguments = arguments;
        psi.WorkingDirectory = basePath;
        _ = Process.Start(psi);
      }
    }

    private readonly string basePath = @"C:\Razvoj\github-hosted\WinForms_2_BlazorHybrid";
  }
}
