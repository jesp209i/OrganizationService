using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrganizationService.ApplicationService.Extensions;
using OrganizationService.Infrastructure.Extensions;
using OrganizationService.Worker.Extensions;
using Rebus.ServiceProvider;

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
            services.AddInfrastructure(Configuration);
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
