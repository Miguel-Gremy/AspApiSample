using System.Net;
using IO.Swagger.Api;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspApiSample.Web
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                 /* Cookie configuration */
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });

            /* Using cookie authentication */
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
                cookieOption =>
                {
                    /* Defining the login path  */
                    cookieOption.LoginPath = "/Login/Index";
                });

            services.AddControllersWithViews();

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            }).AddRazorPagesOptions(options => {})
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            /* Defining the configuration of the API */
            var apiConfiguration = IO.Swagger.Client.Configuration.Default;
            /* Modify value in appsettings.json file to match the path of the API */
            apiConfiguration.BasePath = Configuration.GetSection("ApiParameters:Path").Value;
            /* Tell the application to ignore API SSL Certificate */
            /* Modify value in appsettings.json file to match API SSL configuration */
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, errors) =>
                    !bool.Parse(Configuration.GetSection("ApiParameters:UseHttps").Value);

            /* Adding interfaces for the dependency injection */
            services.AddScoped<IAuthApi, AuthApi>(provider => new AuthApi(apiConfiguration));
            services.AddScoped<IMailApi, MailApi>(provider => new MailApi(apiConfiguration));
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
                app.UseExceptionHandler("/ErrorController/Index");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();
            app.UseMvc();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });
        }
    }
}