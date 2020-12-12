using InvestmentPerformance.Data.Context;
using InvestmentPerformance.Data.Entities;
using InvestmentPerformance.WebAPI.Models;
using InvestmentPerformance.WebAPI.Repository;
using InvestmentPerformance.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentPerformance.WebAPI.Tests
{
    [TestClass]
    public class InvestmentsControllerTest
    {
        private InvestmentsController _controller;
        private IInvestmentPerformanceRepository _repository;

        public InvestmentsControllerTest()
        {
            // arrange
            _repository = new FakeInvestmentPerformanceRepository();
            _controller = new InvestmentsController(_repository, new NullLogger<InvestmentsController>());
        }

        #region  GetAllUserInvestments Tests

        [TestMethod]
        public void GetAllUserInvestments_ReturnsOk()
        {
            // act
            var response = _controller.GetAllUserInvestments(1).Result;

            // assert
            Assert.IsTrue(typeof(OkObjectResult).IsInstanceOfType(response));
        }

        [TestMethod]
        public void GetAllUserInvestments_ReturnsNoResults()
        {
            // act
            var response = _controller.GetAllUserInvestments(99).Result as OkObjectResult;
            var content = response.Value as List<UserInvestmentsResponse>;

            // assert
            Assert.AreEqual(0, content.Count);
        }

        [TestMethod]
        public void GetAllUserInvestments_VerifyCount()
        {
            // act
            var response = _controller.GetAllUserInvestments(1).Result as OkObjectResult;
            var content = response.Value as List<UserInvestmentsResponse>;

            // assert
            Assert.AreEqual(2, content.Count);
        }

        #endregion

        #region GetUserInvestmentDetails Tests

        [TestMethod]
        public void GetUserInvestmentDetails_ReturnsOk()
        {
            // act
            var response = _controller.GetUserInvestmentDetails(1, 1).Result;

            // assert
            Assert.IsTrue(typeof(OkObjectResult).IsInstanceOfType(response));
        }

        [TestMethod]
        public void GetUserInvestmentDetails_ReturnsNoResults()
        {
            // act
            var response = _controller.GetUserInvestmentDetails(99, 1).Result as OkObjectResult;
            var content = response.Value as UserInvestmentsResponse;

            // assert
            Assert.IsNull(content.CostBasis);
        }

        [TestMethod]
        public void GetUserInvestmentDetails_ValidateTotalGain()
        {
            //arrange
            var userInvestment = _repository.GetInvestmentDetailsById(1, 1);
            var correctTotalGain = (userInvestment.Stock.CurrentPrice - userInvestment.CostBasis) * userInvestment.ShareCount;

            // act
            var response = _controller.GetUserInvestmentDetails(1, 1).Result as OkObjectResult;
            var content = response.Value as UserInvestmentsResponse;

            // assert
            Assert.AreEqual(content.TotalGain, correctTotalGain);
        }

        [TestMethod]
        public void GetUserInvestmentDetails_ValidateTerm()
        {
            //arrange
            var userInvestment = _repository.GetInvestmentDetailsById(1, 1);
            var correctTerm = userInvestment.PurchaseDate.AddYears(1) > DateTime.Now ? "Short Term" : "Long Term";

            // act
            var response = _controller.GetUserInvestmentDetails(1, 1).Result as OkObjectResult;
            var content = response.Value as UserInvestmentsResponse;

            // assert
            Assert.AreEqual(content.Term, correctTerm);
        }

        #endregion
    }
}
