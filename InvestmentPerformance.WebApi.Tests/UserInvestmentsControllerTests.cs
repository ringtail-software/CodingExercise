using InvestmentPerformance.WebApi.Controllers;
using InvestmentPerformance.WebApi.Models;
using InvestmentPerformance.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InvestmentPerformance.WebApi.Tests
{
    [TestClass]
    public class UserInvestmentsControllerTests
    {
        UserInvestmentsController controller;
        Mock<ILogger<UserInvestmentsController>> mockLogger = new Mock<ILogger<UserInvestmentsController>>();
        Mock<IInvestmentsRepository> mockService = new Mock<IInvestmentsRepository>();

        public UserInvestmentsControllerTests()
        {
            controller = new UserInvestmentsController(mockLogger.Object, mockService.Object);
        }

        [TestMethod]
        public async Task GetUserInvesmentsAsync_Ok()
        {
            var userId = 1;
            var investments = new List<Investment>();

            mockService.Setup(m => m.GetInvestmentsAsync(It.IsAny<int>()))
                .ReturnsAsync(investments);

            var result = await controller.GetUserInvestmentsAsync(userId);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            mockService.Verify(m => m.GetInvestmentsAsync(userId), Times.Once);
        }

        [TestMethod]
        public async Task GetUserInvestmentsAsync_NotFound()
        {
            var userId = 1;

            mockService.Setup(m => m.GetInvestmentsAsync(It.IsAny<int>()))
                .ReturnsAsync(null as IEnumerable<Investment>);

            var result = await controller.GetUserInvestmentsAsync(userId);

            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
            mockService.Verify(m => m.GetInvestmentsAsync(userId), Times.Once);
        }

        [TestMethod]
        public async Task GetUserInvestmentsAsync_InternalServerError()
        {
            var userId = 1;

            mockService.Setup(m => m.GetInvestmentsAsync(It.IsAny<int>()))
                .ThrowsAsync(new Exception());

            var result = await controller.GetUserInvestmentsAsync(userId);

            Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
            mockService.Verify(m => m.GetInvestmentsAsync(userId), Times.Once);
        }
    }
}
