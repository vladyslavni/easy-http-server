using System;
using System.Collections.Generic;
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
                endpoints.MapGet("/{way}", async context =>
                {
                    context.toUtf8();
                    context.Response.Headers.Add("InCamp-Student", "Nicolenco Vladislav");
                    string endpoint = context.Request.RouteValues["way"].ToString();

                    await context.Response.WriteAsync(Quote.getWord(endpoint));
                });

                endpoints.MapGet("/quote", async context =>
                {
                    context.toUtf8();
                    context.Response.Headers.Add("InCamp-Student", "Nicolenco Vladislav");

                    await context.Response.WriteAsync(Quote.GetQuote());
                });

                endpoints.MapGet("/incamp18-quote", async context =>
                {
                    Timer timer = new Timer();
                    timer.Start();

                    context.toUtf8();
                    context.Response.Headers.Add("InCamp-Student", "Nicolenco Vladislav");
                    List<ResponseInfo> info = await new AsyncRequest().makeRequest();
                    
                    timer.End();
                    await context.Response.WriteAsync(info.BuildResponse() + "<br>" + timer.GetTime());
                });
            });
        }
    }
}