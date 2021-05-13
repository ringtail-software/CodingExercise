using InvestmentPerformance.Api.Entities;
using InvestmentPerformance.Api.StartupStuff.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Json.Serialization;

namespace InvestmentPerformance.Api.AppStartup
{
    public class Startup
    {
        private const string ClientCorsPolicyName = "ClientCorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InvestmentPerformanceDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("InvestmentPerformance")));

            var domain = $"https://{Configuration["Auth0:Domain"]}/";
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = domain;
                    options.Audience = Configuration["Auth0:Audience"];

                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        NameClaimType = ClaimTypes.NameIdentifier,
                    };
                });

            services.AddCors(options =>
            {
                options.AddPolicy(name: ClientCorsPolicyName,
                    builder =>
                    {
                        builder
                            .WithOrigins("http://localhost:3000")
                            .WithHeaders(new[] { HeaderNames.Authorization, HeaderNames.Accept, HeaderNames.ContentType })
                            .WithMethods(new[] { "GET", "POST", "PUT", "OPTIONS" });
                    });
            });

            services.RegisterServices();

            services.AddHttpContextAccessor();

            services.AddMediatR(typeof(Startup));

            services
                .AddControllers()
                .AddJsonOptions(opts =>
                {
                    opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(ClientCorsPolicyName);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
