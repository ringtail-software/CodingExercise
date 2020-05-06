using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using InvestmentPerformance.API.Application.Models;
using InvestmentPerformance.API.Application.Profiles;
using InvestmentPerformance.API.Application.Services.Interfaces;
using InvestmentPerformance.Application.API.Services;
using InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate;
using InvestmentPerformance.Infrastructure.Repositories;
using InvestmentPerformance.Tests.MockData;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace InvestmentPerformance.Tests
{
    [TestClass]
    public class InvestmentServiceTests
    {
        private readonly IMapper _mapper;
        private readonly ILogger<InvestmentService> _mockLogger;
        private readonly IInvestmentReadOnlyRepository _repository;
        private readonly IInvestmentService _investmentService;

        public InvestmentServiceTests()
        {
            // configure the mapper used by this service
            var investmentProfile = new InvestmentProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(investmentProfile));
            _mapper = new Mapper(configuration);

            // configure the logger used by this service
            _mockLogger = new Mock<ILogger<InvestmentService>>().Object;

            // configure the repository used by this service
            var context = InvestmentMockData.GetContext();

            _repository = new InvestmentReadOnlyRepository(context);

            _investmentService = new InvestmentService(_repository, _mockLogger, _mapper);
        }

        [TestMethod]
        public async Task GetUserInvestmentsAsync_Returns_Valid_ViewModel()
        {
            // Arrange
            int userId = 1;

            // Act 
            var userInvestments = await _investmentService.GetUserInvestmentsAsync(userId);

            // Assert
            Assert.IsInstanceOfType(userInvestments, typeof(IEnumerable<UserInvestment>));
        }

        [TestMethod]
        public async Task GetInvestmentAsync_Returns_Valid_ViewModel()
        {
            // Arrange
            int investmentId = 1;

            // Act
            var investmentDetails = await _investmentService.GetInvestmentDetailsAsync(investmentId);

            // Assert
            Assert.IsInstanceOfType(investmentDetails, typeof(InvestmentDetails));
        }
    }
}
