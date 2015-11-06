using System;
using System.Configuration;
using Microsoft.Owin.Hosting;
using NLog;

namespace S203.uManage
{
    class Program
    {
        static void Main(string[] args)
        {
            LoggerConfig.StartLogging();
            var logger = LogManager.GetLogger("uManage");

            try
            {
                logger.Info("Starting uManage...");
                logger.Debug(Art.Logo);

                var baseAddress = ConfigurationManager.AppSettings["Uri"];
                if (String.IsNullOrWhiteSpace(baseAddress))
                    throw new ArgumentNullException(baseAddress, "Base Address Not Specified!  Check app.config and ensure the Uri appSetting has been provided!");
                logger.Info("Base Address Set: {0}", baseAddress);

                logger.Info("Starting Web Server");
                using (WebApp.Start<Startup>(baseAddress))
                {
                    logger.Info("uManage is Ready to Serve!");

                    if (Environment.UserInteractive)
                        logger.Info("Press Any Key to Exit");

                    Console.ReadLine();

                    logger.Warn("Web server is stopping");
                }
                logger.Warn("Stopping uManage");
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Unhandled error, uManage must terminate!");
            }
        }
    }
}
