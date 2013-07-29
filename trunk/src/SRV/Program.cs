namespace THS.UMS.SRV
{
    using System;
    using System.Reflection;
    using System.ServiceProcess;

    static class Program
    {
        const BindingFlags Flags = BindingFlags.Instance | BindingFlags.NonPublic;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            var servicesToRun = new ServiceBase[] 
                                              { 
                                                  new PostOffice(),
                                                  new Reminder()
                                              };

            if (Environment.UserInteractive)
            {
                var type = typeof(ServiceBase);
                var method = type.GetMethod("OnStart", Flags);

                foreach (var service in servicesToRun)
                {
                    method.Invoke(service, new object[] { args });
                }

                Console.WriteLine("Press any key to exit");
                Console.Read();

                foreach (var service in servicesToRun)
                {
                    service.Stop();
                }
            }
            else
            {
                ServiceBase.Run(servicesToRun);
            }
        }
    }
}
