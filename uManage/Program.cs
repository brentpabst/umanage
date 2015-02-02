using System;
using System.Configuration;
using Microsoft.Owin.Hosting;

namespace uManage
{
    class Program
    {
        static void Main(string[] args)
        {
            var appUri = ConfigurationManager.AppSettings["appUri"];

            // Start OWIN
            using (WebApp.Start<Startup>(appUri))
            {
                Console.WriteLine("uManage is running on " + appUri);
                Console.WriteLine("Press [Enter] to terminate uManage.");
                Console.ReadLine();
            }
        }
    }
}
