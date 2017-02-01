using BeamLab.Koala.Web.Repository;
using BeamLab.Koala.Web.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BeamLab.Koala.Web
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddAntiforgerySecurely(this IServiceCollection services)
        {
            return services.AddAntiforgery(
                options =>
                {
                    // Rename the Anti-Forgery cookie from "__RequestVerificationToken" to "f". This adds a little
                    // security through obscurity and also saves sending a few characters over the wire.
                    options.CookieName = "f";

                    // Rename the form input name from "__RequestVerificationToken" to "f" for the same reason above
                    // e.g. <input name="__RequestVerificationToken" type="hidden" value="..." />
                    options.FormFieldName = "f";

                    // Rename the Anti-Forgery HTTP header from RequestVerificationToken to X-XSRF-TOKEN. X-XSRF-TOKEN
                    // is not a standard but a common name given to this HTTP header popularized by Angular.
                    options.HeaderName = "X-XSRF-TOKEN";

                    // If you have enabled SSL/TLS. Uncomment this line to ensure that the Anti-Forgery cookie requires
                    // SSL /TLS to be sent across the wire.
                    options.RequireSsl = false;
                });
        }

        public static IServiceCollection AddCaching(this IServiceCollection services)
        {
            return services
                // Adds IMemoryCache which is a simple in-memory cache.
                .AddMemoryCache()
                // Adds IDistributedCache which is a distributed cache shared between multiple servers. This adds a
                // default implementation of IDistributedCache which is not distributed. See below:
                .AddDistributedMemoryCache();
            // Uncomment the following line to use the Redis implementation of IDistributedCache. This will
            // override any previously registered IDistributedCache service.
            // Redis is a very fast cache provider and the recommended distributed cache provider.
            // .AddDistributedRedisCache(
            //     options =>
            //     {
            //     });
            // Uncomment the following line to use the Microsoft SQL Server implementation of IDistributedCache.
            // Note that this would require setting up the session state database.
            // Redis is the preferred cache implementation but you can use SQL Server if you don't have an alternative.
            // .AddSqlServerCache(
            //     x =>
            //     {
            //         x.ConnectionString = "Server=.;Database=ASPNET5SessionState;Trusted_Connection=True;";
            //         x.SchemaName = "dbo";
            //         x.TableName = "Sessions";
            //     });
        }

        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Singleton - Only one instance is ever created and returned.
            // services.AddSingleton<IExampleService, ExampleService>();

            // Scoped - A new instance is created and returned for each request/response cycle.
            // services.AddScoped<IExampleService, ExampleService>();

            // Transient - A new instance is created and returned each time.
            // services.AddTransient<IExampleService, ExampleService>();

            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            services.AddTransient<IRepository, KoalaRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Koala CMS API",
                    Description = "The Koala CMS Web API for your custom services.",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Emanuele B.", Email = "emanuele@beamlab.cloud", Url = "http://twitter.com/kasuken" },
                    License = new License { Name = "Use under GPL", Url = "http://github.com/beamlab/Koala.CMS" }
                });

                var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                var xmlPath = Path.Combine(basePath, "BeamLab.Koala.Web.xml");
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }

    }
}
