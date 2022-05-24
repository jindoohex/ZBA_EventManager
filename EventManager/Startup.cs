using EventManager.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Services.EventServices;
using EventManager.Services.Booking;

namespace EventManager
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            // services.AddSingleton<>
            services.AddSingleton<IUserService, UserServicesDB>();
            services.AddSingleton<TrainService, TrainService>();
            services.AddSingleton<IEventService, EventServiceDB>();
            services.AddSingleton<IBookingService, BookingServiceDB>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded =context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(
                CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieOptions =>
                {
                    CookieOptions.LoginPath = "/_Login/Index";
                });

            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AuthorizeFolder("/MockData");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = ".AspNetCore.Identity.Application";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
                options.SlidingExpiration = true;
            });

            // services.AddSession();
            // If you want to set the duration of a session (default: 20 min) to something else
            // services.AddSession(options => {options.IdleTimeout = TimeSpan.FromMinutes(30)});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();


            // If desired goal is to use session for logins, then uncomment app.UseSession();
            // app.UseSession();


            app.UseRouting();
            
            // Who are 'you'
            app.UseAuthentication();

            // Are 'you' allowed
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
