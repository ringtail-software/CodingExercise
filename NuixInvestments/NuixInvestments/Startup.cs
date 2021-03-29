using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NuixInvestments.Data;
using NuixInvestments.MiddleWare.Data.Repo.Interfaces;
using NuixInvestments.MiddleWare.Data.Repo.SQL;
using NuixInvestments.MiddleWare.Data.Repo.Static;

namespace NuixInvestments
{
    public class Startup
    {
        private const string USE_STATIC_DATABASE = "UseStaticDatabase";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            bool useStaticDatabase = Configuration.GetValue<bool>(USE_STATIC_DATABASE);

            if (useStaticDatabase)
            {
                _ = services.AddScoped<IUserRepo, StaticUserRepo>();
            }
            else
            {
                _ = services.AddScoped<IUserRepo, SQLUserRepo>();
            }

            services.AddScoped<IMiddleWare, Data.MiddleWare>();
            services.AddControllers();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
