using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using InvestmentPerformance.API.Application.Models;
using InvestmentPerformance.Domain.AggregatesModel;
using InvestmentPerformance.Infrastructure.DataSeeding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InvestmentPerformance.Tests
{
    /// <summary>
    /// Test that mappings are working correctly. 
    /// </summary>
    [TestClass]
    public class InvestmentProfileTests
    {
        public InvestmentProfileTests() {}

        [TestMethod]
        public void Mapping_UserInvestments_Is_Valid()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Investment, UserInvestment>();
            });

            IMapper mapper = config.CreateMapper();
            var investments = InvestmentDataSeeding.GetData().ToList();

            var userInvestments = investments.Where(e => e.UserId == 1);

            // Act
            var dest = mapper.Map<IEnumerable<Investment>, IEnumerable<UserInvestment>>(userInvestments);

            // Assert

            // automapper provides a cool assert method that checks to make sure every single Destination
            // type member has a corresponding type member on the source type.
            // https://docs.automapper.org/en/stable/Configuration-validation.html
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }

        [TestMethod]
        public void Mapping_InvestmentDetails_Is_Valid()
        {
            // Arrange
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Investment, InvestmentDetails>();
            });

            IMapper mapper = config.CreateMapper();
            var investments = InvestmentDataSeeding.GetData().ToList();

            var investment = investments.FirstOrDefault(e => e.Id == 1);

            // Act
            var dest = mapper.Map<Investment, InvestmentDetails>(investment);

            // Assert
            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
