using System.IO;
using System.ServiceProcess;

namespace MyWindowsService
{
    public class FileWriterService : ServiceBase
    {
        private readonly string _outputPath;

        public FileWriterService(string outputPath = @"C:\test.txt")
        {
            _outputPath = outputPath;
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            WriteToFile();
        }

        internal void WriteToFile()
        {
            File.WriteAllText(_outputPath, "hello world");
        }

        protected override void OnStop()
        {
            base.OnStop();
        }
    }
}
