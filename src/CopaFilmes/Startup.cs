﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AutoMapper;
using CopaFilmes.Infrastructure;

namespace CopaFilmes
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                    .AddJsonOptions(opt => 
                    {
                        opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                        opt.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                        opt.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                    });
            
            services.AddAutoMapper();
            services.AddApiVersioning();
            services.AddRouting(options => options.LowercaseUrls = true);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            var jsonExceptionMiddleware = new JsonExceptionMiddleware(
                app.ApplicationServices.GetRequiredService<IHostingEnvironment>()
            );

            app.UseExceptionHandler(new ExceptionHandlerOptions 
            {
                ExceptionHandler = jsonExceptionMiddleware.Invoke
            });
            
            app.UseMvc();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Copa Filmes");
            });
        }
    }
}
