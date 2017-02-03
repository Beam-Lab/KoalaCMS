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
using BeamLab.Koala.Web.Data;
using BeamLab.Koala.Web.Models;
using BeamLab.Koala.Web.Services;
using Microsoft.AspNetCore.ResponseCompression;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;

namespace BeamLab.Koala.Web
{
    public class Startup
    {
        private readonly IConfigurationRoot configuration;

        public Startup(IHostingEnvironment env)
        {
            this.configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                // Add configuration from the config.json file.
                .AddJsonFile("appsettings.json")
                // Add configuration from an optional config.development.json, config.staging.json or
                // config.production.json file, depending on the environment. These settings override the ones in the
                // config.json file.
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                // This reads the configuration keys from the secret store. This allows you to store connection strings
                // and other sensitive settings, so you don't have to check them into your source control provider.
                // Only use this in Development, it is not intended for Production use. See
                // http://docs.asp.net/en/latest/security/app-secrets.html
                .AddUserSecrets()
                // Add configuration specific to the Development, Staging or Production environments. This config can
                // be stored on the machine being deployed to or if you are using Azure, in the cloud. These settings
                // override the ones in all of the above config files.
                // Note: To set environment variables for debugging navigate to:
                // Project Properties -> Debug Tab -> Environment Variables
                // Note: To get environment variables for the machine use the following command in PowerShell:
                // [System.Environment]::GetEnvironmentVariable("[VARIABLE_NAME]", [System.EnvironmentVariableTarget]::Machine)
                // Note: To set environment variables for the machine use the following command in PowerShell:
                // [System.Environment]::SetEnvironmentVariable("[VARIABLE_NAME]", "[VARIABLE_VALUE]", [System.EnvironmentVariableTarget]::Machine)
                // Note: Environment variables use a colon separator e.g. You can override the site title by creating a
                // variable named AppSettings:SiteTitle. See http://docs.asp.net/en/latest/security/app-secrets.html
                .AddEnvironmentVariables()
                .Build();

            //var launchConfiguration = new ConfigurationBuilder()
            //        .SetBasePath(env.ContentRootPath)
            //        .AddJsonFile(@"Properties\launchSettings.json")
            //        .Build();
            //this .sslPort = launchConfiguration.GetValue<int>("iisSettings:iisExpress:sslPort");
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAntiforgerySecurely();
            services.AddCaching();

            services.AddRouting(options =>
            {
                // Improve SEO by stopping duplicate URL's due to case differences or trailing slashes.
                // See http://googlewebmastercentral.blogspot.co.uk/2010/04/to-slash-or-not-to-slash.html
                // All generated URL's should append a trailing slash.
                options.AppendTrailingSlash = true;
                // All generated URL's should be lower-case.
                options.LowercaseUrls = true;
            });

            services.AddResponseCaching();

            /* Static file compression */
            services.AddResponseCompression(
                options => options.MimeTypes = ResponseCompressionMimeTypes.Defaults);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("SqliteConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc(c =>
                c.Conventions.Add(new ApiExplorerGroupPerVersionConvention())
            )
            .AddViewLocalization();
  
            services.AddApplicationServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            app.UseIdentity();

            UsersRolesExtensions.AddUsersRoles(app.ApplicationServices).Wait();

            app.UseResponseCompression()
                .UseStaticFiles(new StaticFileOptions
                {
                    OnPrepareResponse =
                        _ => _.Context.Response.Headers[HeaderNames.CacheControl] = "public,max-age=604800"

                })
                .UseMvc(routes =>
                {
                    routes.MapRoute(
                        name: "article",
                        template: "n/{title}",
                        defaults: new { controller = "Home", action = "Article" });

                    routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}/{id?}");
                });

            app.UseSwagger();

            app.UseSwaggerUi(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Koala CMS API V1");
            });
        }
    }
}