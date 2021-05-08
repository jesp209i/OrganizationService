using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using OrganizationService.ApplicationService.Extensions;
using OrganizationService.Infrastructure.Extensions;
using OrganizationService.Persistence.Extensions;
using OrganizationService.Worker.Extensions;
using Rebus.Bus;
using Rebus.ServiceProvider;
using System;

namespace OrganizationService.Worker
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddApplicationServices();
            services.AddInfrastructure();
            services.AddPersistence(Configuration);
            services.AddHealthChecks();
            //services.Configure<HealthCheckPublisherOptions>(options => options.Delay = TimeSpan.FromSeconds(5));
            services.AddRebusServiceBus(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseHealthChecks(Constants.Routes.HealthCheckPath);
            app.ApplicationServices.UseRebus();
            //app.UseHttpsRedirection();
            app.UseDefaultFiles();
            app.UseStaticFiles();
        }
    }
}
