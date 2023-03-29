using System.IO;
using System.ServiceProcess;

namespace MyWindowsService
{
    public class FileWriterService : ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            WriteToFile();
        }

        private void WriteToFile()
        {
            File.WriteAllText("C:\\test.txt", "hello world");
        }

        protected override void OnStop()
        {
            base.OnStop();
        }
    }
}
