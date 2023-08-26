
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
      using var stream = File.OpenRead(xmlDataFile);
      return await XDocument.LoadAsync(stream, LoadOptions.None, CancellationToken.None);
    }

    public Task RunExternalExample(string exampleKey)
    {
      var elements = exampleKey.Split(';');
      if (elements.Length < 1)
        return Task.CompletedTask; 

      if (!int.TryParse(elements[0], out int exampleId))
        return Task.CompletedTask;

      if (elements.Length == 1)
      {
        string executablePath = @"ExecutableFiles";

        var examplePath = Path.Combine(basePath, executablePath, $"STEP{exampleId}", "Simple CRUD.exe");
        var psi = new ProcessStartInfo(examplePath);
        _ = Process.Start(psi);
      }
      else
      {
        if (string.Compare(elements[1], "all", ignoreCase: true) == 0)
          compareMainFormOfExample(1, exampleId);
        if (string.Compare(elements[1], "prev", ignoreCase: true) == 0)
          compareMainFormOfExample(exampleId - 1, exampleId);
      }

      return Task.CompletedTask;
    }

    public Task compareMainFormOfExample(int firstId, int secondId)
    {
      string comparePath = Path.Combine(basePath, "compares");
      if (!Directory.Exists(comparePath))
      {
        Directory.CreateDirectory(comparePath);
      }

      runGit(firstId);
      runGit(secondId);
      runWinMerge(firstId, secondId);
      return Task.CompletedTask;

      void runGit(int stepId)
      {
        string command = $"/c git show STEP{stepId}:\"Simple CRUD/Main.cs\" > compares/STEP{stepId}_Main.cs";
        var psi = new ProcessStartInfo
        {
          FileName = "cmd",
          Arguments = command,
          WorkingDirectory = basePath
        };
        _ = Process.Start(psi);
      }

      void runWinMerge(int firstId, int secondId)
      {
        string command = @"C:\Program Files\WinMerge\WinMergeU.exe ";
        string arguments = $"compares/STEP{firstId}_Main.cs compares/STEP{secondId}_Main.cs";

        var psi = new ProcessStartInfo
        {
          FileName = command,
          Arguments = arguments,
          WorkingDirectory = basePath
        };
        _ = Process.Start(psi);
      }
    }

    private readonly string basePath = @"C:\Razvoj\github-hosted\WinForms_2_BlazorHybrid";
  }
}
