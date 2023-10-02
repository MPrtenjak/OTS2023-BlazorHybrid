
using OTS2023Shared.Platform;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace OTS2023.Platform
{
  public class BlazorHybrid : IBlazor
  {
    public BlazorHybrid()
    {
      var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
      pathForCompares = Path.Combine(appPath, "compares");
    }

    public BlazorType BlazorType => BlazorType.Hybrid;

    public async Task<Dictionary<Language, XDocument>> ReadSlideData()
    {
      string filePath = "data";

      Dictionary<Language, string> languageFiles = new()
      {
        { Language.Si, "blazor_hybrid.xml" },
        { Language.En, "blazor_hybrid_en.xml" },
      };

      Dictionary<Language, XDocument> result = new();

      foreach (var languageFile in languageFiles)
      {
        var xmlDataFile = $"wwwroot/{filePath}/{languageFile.Value}";
        using var stream = File.OpenRead(xmlDataFile);

        var slides = await XDocument.LoadAsync(stream, LoadOptions.None, CancellationToken.None);
        result.Add(languageFile.Key, slides);
      }

      return result;
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
          compareMainFormOfExample((exampleId < 5) ? 2 : 4, exampleId);
        if (string.Compare(elements[1], "prev", ignoreCase: true) == 0)
          compareMainFormOfExample(exampleId - 1, exampleId);
      }

      return Task.CompletedTask;
    }

    public Task compareMainFormOfExample(int firstId, int secondId)
    {
      if (!Directory.Exists(pathForCompares))
      {
        Directory.CreateDirectory(pathForCompares);
      }

      runGit(firstId);
      runGit(secondId);
      runWinMerge(firstId, secondId);
      return Task.CompletedTask;

      void runGit(int stepId)
      {
        string outputFileName = Path.Combine(pathForCompares, $"STEP{stepId}_Main.cs");

        if (File.Exists(outputFileName))
          return;

        string command = $"/c git show origin/STEP{stepId}:\"Simple CRUD/Main.cs\" > {outputFileName}";
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
        string command = Program.AppSettings!.PathToWinMerge!;
        string outputFileName1 = Path.Combine(pathForCompares, $"STEP{firstId}_Main.cs");
        string outputFileName2 = Path.Combine(pathForCompares, $"STEP{secondId}_Main.cs");
        string arguments = $"{outputFileName1} {outputFileName2}";

        var psi = new ProcessStartInfo
        {
          FileName = command,
          Arguments = arguments,
          WorkingDirectory = basePath
        };
        _ = Process.Start(psi);
      }
    }

    private readonly string basePath = Program.AppSettings!.PathToGitWithExamples!;
    private readonly string pathForCompares = "";
  }
}
