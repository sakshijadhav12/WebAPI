using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FundoNoteApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "logFiles");
            NLog.GlobalDiagnosticsContext.Set("LoggingDirectory", path);
            var logger = NLogBuilder.ConfigureNLog("NLog.config").GetCurrentClassLogger();
            logger.Info("Application is started");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
            .ConfigureLogging(logs =>
            {
                logs.ClearProviders();
                logs.SetMinimumLevel(LogLevel.Trace);

            }).UseNLog();
    }
}
