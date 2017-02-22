using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace SportsEvents.Web
{
    public class Program
    {
        //Test change here
        public static void Main(string[] args)
        {
            try
            {


                var host = new WebHostBuilder()
                    .UseKestrel()
                    .UseContentRoot(Directory.GetCurrentDirectory())
                    .UseIISIntegration()
                    .UseStartup<Startup>()
                    .UseApplicationInsights()
                    .Build();

                host.Run();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
