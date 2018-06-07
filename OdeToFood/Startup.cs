using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Services;

namespace OdeToFood
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              IGreeter greeter,
                              ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                //ASPNETCORE_ENVIRONMENT can be set to anything you need in the development cycle. Like QA, UnitTests, and so on. Set in the Properties/launchSettings.json file
                //Don't use that unless it's very important, because it shows a lot of the request, the error, the stack trace, and lot of stuff that a malicious user can use to attack your app.
                app.UseDeveloperExceptionPage();
            }

            //In this case the sequence matters. You can have an error if you change the lines.
            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            //Otherwise, if you use this way, you can guarantee that the static files will be searched first.
            //app.UseFileServer();

            //Setting up the ASP.NET MVC.
            app.UseStaticFiles();

            //app.UseMvcWithDefaultRoute();

            //Testing the error when calling without routing configuration
            app.UseMvc(ConfigureRoutes);

            //Class Using IApplicationBuilder.
            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        logger.LogInformation("Request Incoming");
            //        if (context.Request.Path.StartsWithSegments("/mym"))
            //        {
            //            await context.Response.WriteAsync("Hit!!");
            //            logger.LogInformation("Request handled");
            //        }
            //        else
            //        {
            //            await next(context);
            //            logger.LogInformation("Response outgoing");
            //        }
            //    };
            //});

            //app.UseWelcomePage(new WelcomePageOptions
            //{
            //    Path="/wp"
            //});

            app.Run(async (context) =>
            {
                //Just to test the error page.
                //throw new Exception("error!");


                var greeting = greeter.GetMessageOfTheDay();
                //Just to show the MVC configuration.
                //await context.Response.WriteAsync($"{greeting} : {env.EnvironmentName}");

                //In the last publish of the course, it was need to set the content type as showing below, but testing now (06/06/18), it was no longer necessary, at least to show simple text.
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Not Found");
            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index
            routeBuilder.MapRoute("Default",
                "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
