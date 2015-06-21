using System.Configuration;
using Microsoft.Owin.Hosting;
using System;

namespace E203.uManage
{
    class Program
    {
        static void Main(string[] args)
        {
            var baseAddress = ConfigurationManager.AppSettings["Uri"];

            if (String.IsNullOrWhiteSpace(baseAddress))
                throw new ArgumentNullException(baseAddress, "Base Address Not Specified!  Check app.config and ensure the Uri appSetting has been provided!");

            using (WebApp.Start<Startup>(baseAddress))
            {
                Console.WriteLine(StartupArt.Header);
                Console.WriteLine(StartupArt.Logo);
                Console.WriteLine("Listening on " + baseAddress);
                Console.WriteLine("Ready to Serve!");

                if (Environment.UserInteractive)
                    Console.WriteLine("Press Enter to Quit");

                Console.ReadLine();
            }
        }
    }
}
