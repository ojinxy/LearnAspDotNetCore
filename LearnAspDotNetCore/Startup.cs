using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LearnAspDotNetCore.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using LearnAspDotNetCore.Api.Interfaces;
using LearnAspDotNetCore.Api.Implementations;

namespace LearnAspDotNetCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // Add framework services.
            Console.WriteLine(Configuration.GetConnectionString("DefaultConnection"));
            services.AddDbContext<LearnAspDotNetCoreContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));                                             
				//options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            // Add framework services.

            services.AddMvc();

            //Add custom services
            services.AddSingleton<IScramble, ScrambleReverse>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, 
                              ILoggerFactory loggerFactory, LearnAspDotNetCoreContext context)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }


            app.UseStaticFiles();
            //app.UseFileServer(enableDirectoryBrowsing:env.IsDevelopment());

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                
            });

            DbInitializer.Initialize(context);
        }
    }
}
