using System;
using AspApiSample.API.Mappings;
using AspApiSample.API.Services;
using AspApiSample.Lib;
using AspApiSample.Lib.Models;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AspApiSample.API
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
            /* Change the "DbProvider" value in appsettings.json to your database provider */
            /* Possible values are "mssql", "slite3", "psql" */
            var databaseProvider = Configuration.GetSection("DbProvider").Value;
            /* Change the connection string in appsettings.json for your configuration */
            switch (databaseProvider)
            {
                case "mssql":
                    services.AddDbContext<ApplicationContext>(option =>
                        option.UseSqlServer(Configuration.GetConnectionString("DbConnection")));
                    break;
                case "sqlite3":
                    services.AddDbContext<ApplicationContext>(option =>
                        option.UseSqlite(Configuration.GetConnectionString("DbConnection")));
                    break;
                case "psql":
                    services.AddDbContext<ApplicationContext>(option =>
                        option.UseNpgsql(Configuration.GetConnectionString("DbConnection")));
                    break;
                default:
                    throw new NotImplementedException(
                        $"The database provider {databaseProvider} is not supported");
            }

            services.AddIdentity<User, Role>(options =>
                {
                    /* Password configuration */
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = false;

                    /* User configuration */
                    options.User.RequireUniqueEmail = true;

                    /* SignIn configuration */
                    options.SignIn.RequireConfirmedEmail = true;
                })
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(2);
            });

            services.AddScoped<IMapper, Mapper>(provider =>
                new Mapper(new MapperConfiguration(options =>
                {
                    options.AddProfile<AuthApiMapping>();
                }))
            );

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo { Title = "AspApiSample.Web.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AspApiSample.Web.API v1"));
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}