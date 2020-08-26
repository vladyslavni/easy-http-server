using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System;
namespace easy_http_server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Params.ApplyParameters(args);
            string[] urls = GetEnvironmentUrls("HTTP_SERVER_URLS");
            ConfigParams.UrlStorage.AddAll(urls);

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) 
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }

        public static string[] GetEnvironmentUrls(string variableName)
        {
            return Environment.GetEnvironmentVariable(variableName).Split(",");
        }
    }
}
