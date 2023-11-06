using FolderMonitor.FileProcessors.Builders;
using FolderMonitor.Monitor;
using Microsoft.Extensions.Configuration;

internal class Program
{
    static IConfiguration _config;
    private static void Main(string[] args)
    {
        Console.WriteLine("Configuration init...");

        _config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

        Console.WriteLine($"Starting watcher...");

        FolderWatcher watcher = new FolderWatcher(_config);
        watcher.OnFileCreated += OnFileCreatedCallback;

        Console.WriteLine("Press Enter to terminate application...");
        Console.ReadLine();
    }

    private static void OnFileCreatedCallback(Tuple<string, string> fileInfo)
    {
        var fileProcessor = new FileProcessorBuilder()
            .ForFileExtension(fileInfo.Item1)
            .WithFilePath(fileInfo.Item2)
            .WithResultFile(_config["ResultFilePath"])
            .Build();

        Task.Run(fileProcessor.Execute);
    }
}

    

