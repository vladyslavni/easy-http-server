using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace easy_http_server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        private readonly HttpListener listener = new HttpListener();
        private RandomWordGenerator generator = new RandomWordGenerator();
        private List<string> urls = new List<string>{"5002"};
        
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
                    context.Response.ContentType = "text/html; charset=utf8";
                    context.Response.Headers.Add("InCamp-Student", "Nicolenco Vladislav");
                    await context.Response.WriteAsync(generator.GetRandomWho());
                });
                
                endpoints.MapGet("/how", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf8";
                    context.Response.Headers.Add("InCamp-Student", "Nicolenco Vladislav");
                    await context.Response.WriteAsync(generator.GetRandomHow());
                });
                
                endpoints.MapGet("/does", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf8";
                    context.Response.Headers.Add("InCamp-Student", "Nicolenco Vladislav");
                    await context.Response.WriteAsync(generator.GetRandomDoes());
                });
                
                endpoints.MapGet("/what", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf8";
                    context.Response.Headers.Add("InCamp-Student", "Nicolenco Vladislav");
                    await context.Response.WriteAsync(generator.GetRandomWhat());
                });
                                
                endpoints.MapGet("/quote", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf8";
                    context.Response.Headers.Add("InCamp-Student", "Nicolenco Vladislav");
                    await context.Response.WriteAsync(generator.GetRandomQuote());
                });

                endpoints.MapGet("/incamp18-quote", async context =>
                {
                    context.Response.ContentType = "text/html; charset=utf8";
                    context.Response.Headers.Add("InCamp-Student", "Nicolenco Vladislav");
                    string text = BuildResponseData();
                   
                    await context.Response.WriteAsync(text);
                });
            });
        }

        private string BuildResponseData()
        {
            WebResponse whoResponse = MakeRequestToStudent(urls.GetRandomValue(), "who"); 
            WebResponse howResponse = MakeRequestToStudent(urls.GetRandomValue(), "how"); 
            WebResponse doesResponse = MakeRequestToStudent(urls.GetRandomValue(), "does"); 
            WebResponse whatResponse = MakeRequestToStudent(urls.GetRandomValue(), "what");
            
            ResponseInfo<string, string> whoInfo = whoResponse.GetInformation();
            ResponseInfo<string, string> howInfo = howResponse.GetInformation();
            ResponseInfo<string, string> doesInfo = doesResponse.GetInformation();
            ResponseInfo<string, string> whatInfo = whatResponse.GetInformation();
            
            return whoInfo.body + " " + howInfo.body + " " + doesInfo.body + " " + whatInfo.body + "</br>" +
                whoInfo.GetFullInfo() + "</br>" + howInfo.GetFullInfo() + "</br>" + doesInfo.GetFullInfo() + "</br>" + whatInfo.GetFullInfo();
        }
    
        private WebResponse MakeRequestToStudent(string port, string endpoint)
        {
            WebRequest request = WebRequest.Create($"http://localhost:{port}/{endpoint}");
            return request.GetResponse();
        }
    }
}
