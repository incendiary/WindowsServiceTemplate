using System.IO;
using MyWindowsService;
using Xunit;

namespace WindowsServiceTemplate.Tests;

public sealed class FileWriterServiceTests : IDisposable
{
    private readonly string _tempPath = Path.GetTempFileName();

    [Fact]
    public void WriteToFile_WritesHelloWorldContent()
    {
        var service = new FileWriterService(_tempPath);

        service.WriteToFile();

        Assert.Equal("hello world", File.ReadAllText(_tempPath));
    }

    [Fact]
    public void WriteToFile_CreatesFileWhenItDoesNotExist()
    {
        File.Delete(_tempPath);
        var service = new FileWriterService(_tempPath);

        service.WriteToFile();

        Assert.True(File.Exists(_tempPath));
    }

    public void Dispose() => File.Delete(_tempPath);
}
