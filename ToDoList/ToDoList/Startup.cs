using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ToDoList.Data;
using ToDoList.Models;
using ToDoList.Services;
using React.AspNet;
using Microsoft.AspNetCore.Http;
using TodoList.Domain.Entities;
using TodoList.Domain.Interfaces;
using TodoList.Infrastructure.Data.Context;
using TodoList.Infrastructure.Data.Seed;
using TodoList.Infrastructure.Data.SqlRepository;
using TodoList.Services;
using TodoList.Services.Interfaces;

namespace ToDoList
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets<Startup>();
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

      

            //React Js
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();

            services.AddMvc(options =>
            {
                options.SslPort = 44370;
                options.Filters.Add(new Microsoft.AspNetCore.Mvc.RequireHttpsAttribute());
            });
            
            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddTransient<IEventService, EventService>();
            services.AddTransient<IRegionService, RegionService>();
            services.AddTransient<IUserService, UserService>();
           // services.AddTransient<IGenericRepository<Event>, GenericRepository<ProjectContext, Event>>();
       //     services.AddTransient<ICommentRepo, CommentRepo>();
            //   services.
            // services.AddScoped(typeof(IGenericRepository<Event>), typeof(GenericRepository<ProjectContext, Event>));

            

            var builder =
                new DbContextOptionsBuilder().UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));


            var oo =
                SqlServerDbContextOptionsExtensions.UseSqlServer(builder, Configuration.GetConnectionString("DefaultConnection"));

            // services.AddScoped(typeof(ProjectContext), typeof(new ProjectContext(oo.Options)));

            //  ProjectContext c = new ProjectContext(new SqlServerDbContextOptionsExtensions(){})
            //  services.AddScoped(typeof(GenericRepository<ProjectContext, Event>), typeof(GenericRepository<ProjectContext, Event>));
            // services.AddScoped(GenericRepository<ProjectContext, Event> => new GenericRepository<ProjectContext;
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            services.AddDbContext<ProjectContext>(options =>
             options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            

            //Repos
            //services.AddTransient<IEventRepo, EventRepo>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                // Browser Link is not compatible with Kestrel 1.1.0
                // For details on enabling Browser Link, see https://go.microsoft.com/fwlink/?linkid=840936
                // app.UseBrowserLink();

                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<ProjectContext>().Database.Migrate();
                    serviceScope.ServiceProvider.GetService<ProjectContext>().EnsureSeedData();

                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseReact(config =>
            {
                // If you want to use server-side rendering of React components,
                // add all the necessary JavaScript files here. This includes
                // your components as well as all of their dependencies.
                // See http://reactjs.net/ for more information. Example:
                //config
                //  .AddScript("~/Scripts/First.jsx")
                //  .AddScript("~/Scripts/Second.jsx");

                // If you use an external build too (for example, Babel, Webpack,
                // Browserify or Gulp), you can improve performance by disabling
                // ReactJS.NET's version of Babel and loading the pre-transpiled
                // scripts. Example:
                //config
                //  .SetLoadBabel(false)
                //  .AddScriptWithoutTransform("~/Scripts/bundle.server.js");
            });

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseGoogleAuthentication(new GoogleOptions()
            {
                ClientId = Configuration["Authentication:Google:ClientId"],
                ClientSecret = Configuration["Authentication:Google:ClientSecret"]
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

          


        }
    }
}
