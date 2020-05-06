using Autofac;
using AutoMapper;
using InvestmentPerformance.API.Infrastructure.AutofacModules;
using InvestmentPerformance.Infrastructure;
using InvestmentPerformance.Infrastructure.DataSeeding;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace InvestmentPerformance.API
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
            services.AddControllers();

            services.AddLogging(config => config.AddConsole());

            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<InvestmentPerformanceContext>(opt => opt.UseInMemoryDatabase("InvestmentPerformance"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InvestmentPerformance.API", Version = "v1" });
            });

        }

        // ConfigureContainer is where you can register things directly
        // with Autofac. This runs after ConfigureServices so the things
        // here will override registrations made in ConfigureServices.
        // Don't build the container; that gets done for you by the factory.
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // Register your own things directly with Autofac, like:
            builder.RegisterModule(new ApplicationModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var context = app.ApplicationServices.GetService<InvestmentPerformanceContext>();
            SeedData(context);

            app.UseSwagger();

            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "InvestmentPerformance.API V1"); });

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SeedData(InvestmentPerformanceContext context)
        {
            var investments = InvestmentDataSeeding.GetData();
            context.Investments.AddRange(investments);

            context.SaveChanges();
        }
    }
}
