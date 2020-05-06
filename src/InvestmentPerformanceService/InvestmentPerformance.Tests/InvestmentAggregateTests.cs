using System;
using System.Linq;
using InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate;
using InvestmentPerformance.Infrastructure.DataSeeding;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InvestmentPerformance.Tests
{
    [TestClass]
    public class InvestmentAggregateTests
    {
        public InvestmentAggregateTests()
        {
        }

        [TestMethod]
        public void When_Term_Is_Less_Than_Or_Equal_To_One_Then_TermLength_Is_Short()
        {
            // Arrange
            var investments = InvestmentDataSeeding.GetData().ToList();
            var investment = investments.Where(e => e.Term <= 1).FirstOrDefault();

            // Assert
            Assert.IsTrue(investment.TermLength == Terms.Short.ToString());
        }

        [TestMethod]
        public void When_Term_Is_Greater_Than_One_Then_TermLength_Is_Long()
        {
            // Arrange
            var investments = InvestmentDataSeeding.GetData().ToList();
            var investment = investments.Where(e => e.Term > 1).FirstOrDefault();

            // Assert
            Assert.IsTrue(investment.TermLength == Terms.Long.ToString());
        }
    }
}
