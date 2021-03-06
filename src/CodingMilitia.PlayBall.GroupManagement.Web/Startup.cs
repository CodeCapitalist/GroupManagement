using System;
using CodingMilitia.PlayBall.GroupManagement.Web.Demo.Filters;
using CodingMilitia.PlayBall.GroupManagement.Web.Demo.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CodingMilitia.PlayBall.GroupManagement.Web
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }
    

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option =>
                {
                    option.EnableEndpointRouting = false;
                    option.Filters.Add<DemoActionFilter>();
                }
            );
            services.AddBusiness();
            services.AddTransient<RequestTimingFactoryMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.  

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseMiddleware<RequestTimingAdHocMiddleware>();
            app.UseMiddleware<RequestTimingFactoryMiddleware>();
            app.UseMvc();
        }
    }
}
