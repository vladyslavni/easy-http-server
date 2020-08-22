using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace easy_http_server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Params.ApplyParameters(args);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) 
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://0.0.0.0:" + ConfigParams.Port);
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
