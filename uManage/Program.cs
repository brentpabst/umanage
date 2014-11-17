using System;
using System.Configuration;
using Nancy.Hosting.Self;

namespace uManage
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = ConfigurationManager.AppSettings["uri"];
            using (var host = new NancyHost(new Uri(uri)))
            {
                host.Start();

                Console.WriteLine("uManage is running on " + uri);
                Console.WriteLine("Press [Enter] to terminate uManage.");
                Console.ReadLine();
            }
        }
    }
}
