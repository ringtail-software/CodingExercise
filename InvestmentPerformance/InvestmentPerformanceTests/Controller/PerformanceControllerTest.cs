using InvestmentPerformance.Controllers;
using InvestmentPerformance.Models;
using InvestmentPerformance.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace InvestmentPerformance.Controller.Tests
{
    public class PerformanceControllerTest
    {
        private Mock<ILogger<PerformanceController>> _mocklogger;
        private Mock<IInvestmentService> _mockInvestmentService;
        private PerformanceController _performanceController;

        public PerformanceControllerTest() {
            _mocklogger =  new Mock<ILogger<PerformanceController>>();
            _mockInvestmentService = new Mock<IInvestmentService>();
            _performanceController = new PerformanceController(_mockInvestmentService.Object, _mocklogger.Object);
        }

        [Test]
        public async Task Always_Return_ExpectedResult_GetInvestmentPerformanceDetails()
        {
            InvestmentDetails expectedDetails = new InvestmentDetails()
            {
                CostBasisPerShare = 33.33,
                Profit = 111.1,
                Shares=10,
                Term="ShortTerm",
                CurrentValue=11.11,
                CurrentPrice=22.22
            };
            _mockInvestmentService.Setup(p => p.GetInvestmentPerformanceDetails(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(Task.FromResult(expectedDetails)).Verifiable();

            var result = await _performanceController.Get(Guid.NewGuid(), "investmentName") as OkObjectResult;
            var ans = result.Value as InvestmentDetails;

            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.AreEqual(expectedDetails.CurrentPrice, ans.CurrentPrice);
            _mockInvestmentService.Verify(x => x.GetInvestmentPerformanceDetails(It.IsAny<Guid>(), It.IsAny<string>()), Times.Once());
        }

        [Test]
        public async Task Always_Return_NotFound_GetInvestmentPerformanceDetails()
        {
            _mockInvestmentService.Setup(p => p.GetInvestmentPerformanceDetails(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(Task.FromResult<InvestmentDetails>(null));

            var result = await _performanceController.Get(Guid.NewGuid(), "investmentName") as NotFoundObjectResult;
            var ans = result.Value as InvestmentDetails;

            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);
            Assert.IsNull(ans);
        }

        [Test]
        public async Task Always_Return_ExpectedResult_GetInvestmentList()
        {
            List<Investment> expectedList = new List<Investment>()
            {
                new Investment()
                {
                    Name="Nuix",
                    Id=1
                },
                new Investment()
                {
                    Name="Google",
                    Id=2
                }
            };

            _mockInvestmentService.Setup(p => p.GetInvestmentList(It.IsAny<Guid>()))
                .Returns(Task.FromResult<IEnumerable<Investment>>(expectedList)).Verifiable();

            var result = await _performanceController.Get(Guid.NewGuid()) as OkObjectResult;
            var resultlist = result.Value as List<Investment>;

            Assert.AreEqual(StatusCodes.Status200OK, result.StatusCode);
            Assert.AreEqual(expectedList.Count, resultlist.Count);
            _mockInvestmentService.Verify(x => x.GetInvestmentList(It.IsAny<Guid>()), Times.Once());
        }

        [Test]
        public async Task Always_Return_NotFound_GetInvestmentList()
        {
            List<Investment> emptyList = new List<Investment>();     
            _mockInvestmentService.Setup(p => p.GetInvestmentList(It.IsAny<Guid>()))
                .Returns(Task.FromResult<IEnumerable<Investment>>(emptyList)).Verifiable();

            var result = await _performanceController.Get(Guid.NewGuid()) as NotFoundObjectResult;

            Assert.AreEqual(StatusCodes.Status404NotFound, result.StatusCode);
            Assert.IsNull(result.Value);
        }
    }
}
