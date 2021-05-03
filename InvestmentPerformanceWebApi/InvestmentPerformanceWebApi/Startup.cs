using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using InvestmentPerformanceWebApi.Domain;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace InvestmentPerformanceWebApi
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
            services.AddControllers()
                .AddJsonOptions(o =>
                {
                    o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InvestmentPerformanceWebApi", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddDbContext<InvestmentDataContext>(options =>
            {
                var connectionString = Configuration.GetConnectionString("InvestmentConnectionString");
                if (connectionString != null)
                    options.UseSqlServer(connectionString);
                else
                    options.UseInMemoryDatabase("Investment");
            });

            services.AddScoped<InvestmentDal>();
            services.AddScoped<InvestmentManager>();
            services.AddScoped<StockDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Program> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InvestmentPerformanceWebApi v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var path = context.Features.Get<IExceptionHandlerPathFeature>();
                Exception ex = path.Error;

                logger.LogError(ex, "Application error");
            }));

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
