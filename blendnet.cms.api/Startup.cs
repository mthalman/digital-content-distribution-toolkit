using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blendnet.common.infrastructure;
using blendnet.common.infrastructure.ServiceBus;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;

namespace blendnet.cms.api
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
            // configure Azure AD B2C Authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(options =>
            {
                Configuration.Bind("AzureAdB2C", options);

                options.TokenValidationParameters.NameClaimType = "name";
            },
            options => {
                Configuration.Bind("AzureAdB2C", options);
            });

            services.AddControllers();

            //Configure Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BlendNet CMS API",
                    Description = "Web API to manage media content on the BlendNet platform.",
                    TermsOfService = new Uri("https://api.blendnet.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "BlendNet Team",
                        Url = new Uri("https://twitter.com/teamblendnet"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under BlendNet terms",
                        Url = new Uri("https://api.blendnet.com/license"),
                    }
                });
            });

            //Configuring API Versiong
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);

                // If user does not specified a version we consider is 1.0 version of our API
                x.AssumeDefaultVersionWhenUnspecified = true;

                x.ReportApiVersions = true;

                // If you want to read which API version the user requests from HTTP header , you can use the line below.
                //x.ApiVersionReader = new HeaderApiVersionReader ("x-starterapi-version");
            });

            //Configure Application Insights
            services.AddApplicationInsightsTelemetry();

            ConfigureEventBus(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BlendNet API V1");
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        /// <summary>
        /// Configure Event Bus
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureEventBus(IServiceCollection services)
        {
            //event bus related registrations
            string serviceBusConnectionString = Configuration.GetValue<string>("ServiceBusConnectionString");

            string serviceBusTopicName = Configuration.GetValue<string>("ServiceBusTopicName");

            services.AddSingleton<EventBusConnectionData>(ebcd =>
            {
                EventBusConnectionData eventBusConnectionData = new EventBusConnectionData();

                eventBusConnectionData.ServiceBusConnectionString = serviceBusConnectionString;

                eventBusConnectionData.TopicName = serviceBusTopicName;

                return eventBusConnectionData;
            });

            services.AddSingleton<IEventBus, EventServiceBus>();
        }
    }
}