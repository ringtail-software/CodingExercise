using InvestmentPerformance.WebApi.Controllers;
using InvestmentPerformance.WebApi.Models;
using InvestmentPerformance.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading.Tasks;

namespace InvestmentPerformance.WebApi.Tests
{
    [TestClass]
    public class UserInvestmentDetailsControllerTests
    {
        UserInvestmentDetailsController controller;
        Mock<ILogger<UserInvestmentDetailsController>> mockLogger = new Mock<ILogger<UserInvestmentDetailsController>>();
        Mock<IInvestmentDetailsRepository> mockService = new Mock<IInvestmentDetailsRepository>();

        public UserInvestmentDetailsControllerTests()
        {
            controller = new UserInvestmentDetailsController(mockLogger.Object, mockService.Object);
        }

        [TestMethod]
        public async Task GetUserInvestmentDetailsAsync_Ok()
        {
            var userId = 1;
            var investmentId = 2;

            mockService.Setup(m => m.GetInvestmentDetailsAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new InvestmentDetails());

            var result = await controller.GetUserInvestmentDetailsAsync(userId, investmentId);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            mockService.Verify(m => m.GetInvestmentDetailsAsync(userId, investmentId), Times.Once);
        }

        [TestMethod]
        public async Task GetUserInvestmentDetailsAsync_NotFound()
        {
            var userId = 1;
            var investmentId = 2;

            mockService.Setup(m => m.GetInvestmentDetailsAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(null as InvestmentDetails);

            var result = await controller.GetUserInvestmentDetailsAsync(userId, investmentId);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            mockService.Verify(m => m.GetInvestmentDetailsAsync(userId, investmentId), Times.Once);
        }

        [TestMethod]
        public async Task GetUserInvestmentDetailsAsync_InternalServerError()
        {
            var userId = 1;
            var investmentId = 2;

            mockService.Setup(m => m.GetInvestmentDetailsAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            var result = await controller.GetUserInvestmentDetailsAsync(userId, investmentId);

            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            mockService.Verify(m => m.GetInvestmentDetailsAsync(userId, investmentId), Times.Once);
        }
    }
}
