using InvestmentPerformance.Dtos;
using InvestmentPerformance.Models;
using InvestmentPerformance.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InvestmentPerformance.Services.Tests
{
    public class InvestmentServiceTests
    {

        private Mock<ILogger<InvestmentService>> _mocklogger;
        private Mock<IInvestmentRepository> _mockInvestmentRepository;
        private InvestmentService _investmentService;
        private Mock<ICurrentPriceService> _mockCurrentPriceService;

        public InvestmentServiceTests()
        {
            _mocklogger = new Mock<ILogger<InvestmentService>>();
            _mockInvestmentRepository = new Mock<IInvestmentRepository>();
            _mockCurrentPriceService = new Mock<ICurrentPriceService>();
            _investmentService = new InvestmentService(_mockInvestmentRepository.Object, _mockCurrentPriceService.Object, _mocklogger.Object);
        }

        [Test]
        public async Task Always_Return_ExpectedResult_GetInvestmentPerformanceDetails()
        {
            InvestmentTransactionDto expectedDetails = new InvestmentTransactionDto()
            {
                 InvestmentId=1,
                 TransactionId=2,
                 Name="Nuix",
                 PurchaseTimeStamp = DateTime.Now,
                 PurchasePrice = 33.33,
                 Shares=10
            };

            _mockInvestmentRepository.Setup(p => p.GetInvestmentDetails(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(Task.FromResult(expectedDetails)).Verifiable();

            var result = await _investmentService.GetInvestmentPerformanceDetails(Guid.NewGuid(), "investmentName");

            Assert.AreEqual(expectedDetails.Shares, result.Shares);
            _mockInvestmentRepository.Verify(x => x.GetInvestmentDetails(It.IsAny<Guid>(), It.IsAny<string>()), Times.Once());
        }
        [Test]
        public async Task Always_Return_Null_GetInvestmentPerformanceDetails()
        {
            _mockInvestmentRepository.Setup(p => p.GetInvestmentDetails(It.IsAny<Guid>(), It.IsAny<string>()))
                .Returns(Task.FromResult<InvestmentTransactionDto>(null));

            var result = await _investmentService.GetInvestmentPerformanceDetails(Guid.NewGuid(), "investmentName");

            Assert.IsNull(result);
        }

        [Test]
        public async Task Always_Return_ExpectedResult_GetInvestments()
        {

            List<InvestmentDto> invList = new List<InvestmentDto>()
            {
                new InvestmentDto()
                {
                    Name = "nuix",
                    Type = InvestmentType.Stock,
                    InvestmentId = 1
                },
                new InvestmentDto()
                {
                    Name = "google",
                    Type = InvestmentType.Stock,
                    InvestmentId = 2
                }
            };

            _mockInvestmentRepository.Setup(p => p.GetInvestments(It.IsAny<Guid>()))
                .Returns(Task.FromResult<List<InvestmentDto>>(invList)).Verifiable();

            var result = await _investmentService.GetInvestmentList(Guid.NewGuid());

            Assert.AreEqual(invList.Count, result.Count());
            _mockInvestmentRepository.Verify(x => x.GetInvestments(It.IsAny<Guid>()), Times.Once());
        }

        [Test]
        public async Task Always_Return_NotFound_GetInvestments()
        {
            //clear the calls to getInvestments repo
            _mockInvestmentRepository.Invocations.Clear();
            List<InvestmentDto> emptyList = new List<InvestmentDto>();
            _mockInvestmentRepository.Setup(p => p.GetInvestments(It.IsAny<Guid>()))
                .Returns(Task.FromResult<List<InvestmentDto>>(emptyList)).Verifiable();

            var result = await _investmentService.GetInvestmentList(Guid.NewGuid());
           
            Assert.AreEqual(result.Count(), 0);
            _mockInvestmentRepository.Verify(x => x.GetInvestments(It.IsAny<Guid>()), Times.Once());

        }
    }
}