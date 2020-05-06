using System;
using Autofac;
using InvestmentPerformance.API.Application.Services.Interfaces;
using InvestmentPerformance.Application.API.Services;
using InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate;
using InvestmentPerformance.Infrastructure.Repositories;

namespace InvestmentPerformance.API.Infrastructure.AutofacModules
{
    /// <summary>
    /// Using autofac as the IoC container framework for implementing automatic dependency injection
    /// </summary>
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InvestmentReadOnlyRepository>()
                .As<IInvestmentReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<InvestmentService>()
                .As<IInvestmentService>()
                .InstancePerLifetimeScope();
        }
    }
}
