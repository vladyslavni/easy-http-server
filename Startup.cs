using System;
using System.Collections.Generic;
using Extension;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace easy_http_server
{
    public class Startup
    {
        static Dictionary<string, Func<string>> ways = new Dictionary<string, Func<string>>();

        private List<string> urls = new List<string>{"http://localhost:5002"};
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ways.Add("who", RandomWordGenerator.GetRandomWho); 
            ways.Add("how", RandomWordGenerator.GetRandomHow);
            ways.Add("does", RandomWordGenerator.GetRandomDoes);
            ways.Add("what", RandomWordGenerator.GetRandomWhat);
            ways.Add("quote", RandomWordGenerator.GetRandomQuote);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/{way}", async context =>
                {
                    string way = context.Request.RouteValues["way"].ToString();

                    context.Response.ContentType = "text/html; charset=utf8";
                    context.Response.Headers.Add("InCamp-Student", "Nicolenco Vladislav");
                    await context.Response.WriteAsync(ways[way]());
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
            
            return whoInfo.body + " " + 
                    howInfo.body + " " + 
                    doesInfo.body + " " + 
                    whatInfo.body + "</br>" +
                    whoInfo.GetFullInfo() + "</br>" + 
                    howInfo.GetFullInfo() + "</br>" + 
                    doesInfo.GetFullInfo() + "</br>" + 
                    whatInfo.GetFullInfo();
        }
    
        private WebResponse MakeRequestToStudent(string url, string endpoint)
        {  
                WebRequest request = WebRequest.Create($"{url}/{endpoint}");
                return request.GetResponse();
        }
    }
}