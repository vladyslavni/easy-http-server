using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Extension;

namespace easy_http_server
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/who", async context =>
                {
                    context.toUtf8();
                    context.Response.Headers.Add("InCamp-Student", Dns.GetHostName().ToString());

                    await context.Response.WriteAsync(Quote.GetRandomWho());
                });

                endpoints.MapGet("/how", async context =>
                {
                    context.toUtf8();
                    context.Response.Headers.Add("InCamp-Student", Dns.GetHostName().ToString());

                    await context.Response.WriteAsync(Quote.GetRandomHow());
                });

                endpoints.MapGet("/does", async context =>
                {
                    context.toUtf8();
                    context.Response.Headers.Add("InCamp-Student", Dns.GetHostName().ToString());

                    await context.Response.WriteAsync(Quote.GetRandomDoes());
                });

                endpoints.MapGet("/what", async context =>
                {
                    context.toUtf8();
                    context.Response.Headers.Add("InCamp-Student", Dns.GetHostName().ToString());

                    await context.Response.WriteAsync(Quote.GetRandomWhat());
                });
                
                endpoints.MapGet("/quote", async context =>
                {
                    context.toUtf8();
                    context.Response.Headers.Add("InCamp-Student", Dns.GetHostName().ToString());

                    await context.Response.WriteAsync(Quote.GetQuote());
                });

                endpoints.MapGet("/incamp18-quote", async context =>
                {
                    Timer timer = new Timer();
                    timer.Start();

                    context.toUtf8();
                    context.Response.Headers.Add("InCamp-Student", Dns.GetHostName().ToString());

                    IUrlStorage urlStorage = ConfigParams.UrlStorage;
                    string[] urls = ConfigParams.RandomUrl.GetRandomUrls(urlStorage.Get());
                    WebResponse[] responses = await ConfigParams.RequestType.makeRequest(urls);
                    
                    ResponseInfo[] info = responses.Select(r => r.GetInformation()).ToArray();

                    timer.End();
                    await context.Response.WriteAsync(info.BuildResponse() + "<br>" + timer.GetTime());
                });
            });
        }

        public static async Task<WebResponse> MakeRequest(string url, string endpoint)
        {  
            return await WebRequest.Create($"{url}/{endpoint}").GetResponseAsync();
        }
    }
}