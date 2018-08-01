using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NLog;
using ZVRPub.Repository;
using ZVRPub.Scaffold;

namespace ZVRPub.API
{
    public class Startup
    {
        private static readonly Logger log = LogManager.GetCurrentClassLogger();

        public Startup(IConfiguration configuration)
        {
            log.Info("Starting configuration");
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            log.Info("Beginning registration");
            log.Info("Registering repository");
            services.AddScoped<IZVRPubRepository, ZVRPubRepository>();

            log.Info("Registering first db context");
            services.AddDbContext<ZVRContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ZVRPubConnection")));

            log.Info("Registering identity db context");
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ZVRPubIdentity"),
                    b => b.MigrationsAssembly("ZVRPub.API")));

            // Add-Migration <migration-name> -Context TodoContext
            // Update-Database -Context TodoContext

            // Add-Migration ZVRPubAuthenticationDB -Context IdentityDbContext
            // Update-Database -Context IdentityDbContext

            log.Info("Registering options required for identity functionality");
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                // Password settings (defaults - optional)
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;

                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyz" +
                    "ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                    "0123456789" +
                    "-._@+";
            })
                .AddEntityFrameworkStores<IdentityDbContext>();

            log.Info("Registering cookie for login information storage");
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "ZVRPubAuth";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(120);
                options.Events = new CookieAuthenticationEvents
                {
                    OnRedirectToLogin = ctx =>
                    {
                        ctx.Response.StatusCode = 401; // Unauthorized
                        return Task.FromResult(0);
                    }
                };
            });

            services.AddAuthentication();

            services.AddMvc().AddXmlSerializerFormatters().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);

            log.Info("Registering swagger UI");
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My API", Version = "v1" });
            });

            log.Info("Registering identity db context");
            services.AddDbContext<IdentityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ZVRPubIdentity"),
                    b => b.MigrationsAssembly("ZVRPub.API")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            log.Info("Configuring settings for swagger UI");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseMvc();
        }
    }
}
