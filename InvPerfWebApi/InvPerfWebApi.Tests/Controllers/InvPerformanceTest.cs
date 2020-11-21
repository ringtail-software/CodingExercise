using InvPerfWebApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
//using System.Web.Http;
using InvPerfWebApi.Models;


namespace InvPerfWebApi.Tests.Controllers
{
    [TestClass]
    public class InvPerformanceTest
    {
        [TestMethod]
        public void GetUserInvestments()
        {
            //Testing the get investments method
            // Arrange
            InvPerformanceController controller = new InvPerformanceController();
            string userName = "User2";
            List<UserInvestment> testList = new List<UserInvestment>();
            UserInvestment testElement = new UserInvestment();
            testElement.userName = "User2";
            testList.Add(testElement);


            // Act
            List<UserInvestment> result = controller.Get(userName);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(testList.ElementAt(0).userName, result.ElementAt(0).userName);
        }

        [TestMethod]
        public void GetUserInvestmenData()
        {
            //Testing the get performance data method
            // Arrange
            InvPerformanceController controller = new InvPerformanceController();
            string userName = "User2";
            string investmentName = "Investment2";
            List<UserInvestmentDetail> testList = new List<UserInvestmentDetail>();
            UserInvestmentDetail testElement = new UserInvestmentDetail();
            testElement.userName = "User2";
            testElement.invName = "Investment2";
            testList.Add(testElement);
            // Act
            List<UserInvestmentDetail> result = controller.Get(userName, investmentName);
 
            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual(testList.ElementAt(0).userName, result.ElementAt(0).userName);
            Assert.AreEqual(testList.ElementAt(0).invName, result.ElementAt(0).invName);
        }

     }
}
