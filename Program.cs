using System.ServiceProcess;

namespace MyWindowsService
{
    internal static class Program
    {
        private static void Main()
        {
            ServiceBase.Run(new ServiceBase[] { new FileWriterService() });
        }
    }
}