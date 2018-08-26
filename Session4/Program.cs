using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Session4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            //var Eng = new Session4.LinQSample.Logic.Engine();
            //Console.WriteLine("-----------------1--------------");
            //Eng.Sample1();
            //Console.WriteLine("-----------------2--------------");
            //Eng.Sample2();
            //Console.WriteLine("-----------------3--------------");
            //Eng.Sample3();
            //Console.WriteLine("-----------------4--------------");
            //Eng.Sample4();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
