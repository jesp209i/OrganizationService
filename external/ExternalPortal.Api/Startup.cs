using ExternalPortal.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrganizationService.Shared.Messages.Commands.Organization;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using Rebus.ServiceProvider;

namespace ExternalPortal.Api
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
            services.AddCors(options => 
            {
                options.AddPolicy("ignoreCors",
                    builder =>
                    {
                        builder
                        .WithOrigins("http://localhost:8080", "http://127.0.0.1:8080")
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });
            services.AddControllers();
            string inputQueue = "Servicebus_Organization_input".ToLower();

            var servicebusConnectionString = Configuration["SERVICEBUS_CONNECTIONSTRING"];

            services.AddRebus(rc =>
                rc.Logging(l => l.ColoredConsole())
                .Transport(t => t.UseAzureServiceBusAsOneWayClient(servicebusConnectionString)
                    .UseLegacyNaming())
                .Routing(r => r.TypeBased()
                    .Map(typeof(CreateOrganizationCommand), inputQueue)
                    .Map(typeof(ChangeOrganizationAddressCommand), inputQueue)
                    .Map(typeof(ChangeOrganizationVatNumberCommand), inputQueue)
                    .Map(typeof(ChangeOrganizationWebsiteCommand), inputQueue))
            );

            services.AddHttpClient<OrganizationApiService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("ignoreCors");
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
