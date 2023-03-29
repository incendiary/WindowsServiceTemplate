using System.ServiceProcess;

namespace MyWindowsService
{
    static class Program
    {
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                new FileWriterService()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}