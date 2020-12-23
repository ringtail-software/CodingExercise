using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json.Serialization;
using ZachAlbertCodingExercise.Domain;
using System.Data.SQLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

//using System.Web.Http.Cors;

namespace ZachAlbertCodingExercise
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var jsonFormatter = config.Formatters.JsonFormatter;
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            jsonFormatter.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;

            // Web API routes
            config.MapHttpAttributeRoutes();

            var connection = new SQLiteConnection("Data Source=:memory:");
            connection.Open();

            SQLiteCommand cmd = connection.CreateCommand();

            cmd.CommandText = @"CREATE TABLE [User] 
                                (
                                    [UserId] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT,
                                    [Name] TEXT  NULL
                                )";

            cmd.ExecuteNonQuery();


            connection.Close();

            var builder = new ContainerBuilder();

            builder.RegisterType<InvestmentDal>();
            builder.RegisterType<InvestmentManager>();
            //builder.RegisterType<IConfiguration>(); 
            //builder.Register
            //    (c => new SQLiteConnection()).As<SQLiteConnection>().SingleInstance();

            //builder.Register(c =>
            //{
            //    var temp = c.Resolve<IConfiguration>();

            //    var opt = new DbContextOptionsBuilder<InvestmentContext>();
            //    opt.UseSqlite(temp.GetSection("ConnectionStrings:MyConnection:ConnectionString").Value);

            //    return new InvestmentContext(opt.Options);
            //}).AsSelf().InstancePerLifetimeScope();

            builder.Register(c =>
            {
                //var temp = c.Resolve<IConfiguration>();

                var opt = new DbContextOptionsBuilder<InvestmentContext>();
                opt.UseSqlite("Data Source=:memory:");

                return new InvestmentContext(opt.Options);
            }).As<DbContext>().InstancePerLifetimeScope();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}/{investmentId}",
                defaults: new { investmentId = RouteParameter.Optional }
            );
        }
    }
}
