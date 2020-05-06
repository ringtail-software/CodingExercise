using System.Linq;
using System.Threading.Tasks;
using InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate;
using InvestmentPerformance.Domain.SeedWork;
using InvestmentPerformance.Infrastructure.DataSeeding;
using InvestmentPerformance.Infrastructure.Repositories;
using InvestmentPerformance.Tests.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InvestmentPerformance.Tests
{
    /// <summary>
    /// Tests for all repository functions
    /// </summary>
    [TestClass]
    public class InvestmentReadOnlyRepositoryTests
    {
        private readonly IInvestmentReadOnlyRepository _repository;

        public InvestmentReadOnlyRepositoryTests()
        {
            // configure the repository used by this service
            var context = InvestmentMockData.GetContext();
            _repository = new InvestmentReadOnlyRepository(context);
        }

        [TestMethod]
        public async Task GetAllInvestmentsAsync_Returns_Empty_Default_Value_When_Investments_Do_Not_Exist()
        {
            using (var context = InvestmentMockData.GetEmptyContext())
            {
                using (var repo = new InvestmentReadOnlyRepository(context))
                {
                    var investments = await repo.GetAllInvestmentsAsync();

                    Assert.IsTrue(investments.Count() == 0);
                }
            }
        }

        [TestMethod]
        public async Task GetAllInvestmentsAsync_Returns_All_Investments_When_Investments_Exist()
        {
            // Arrange
            var mockInvestments = InvestmentDataSeeding.GetData();

            // Act
            var investments = await _repository.GetAllInvestmentsAsync();

            // Assert
            Assert.IsTrue(investments.Count() > 0);
            Assert.IsTrue(investments.Count() == mockInvestments.Count());
        }

            /// <summary>
            /// keep pattern in check with DDD (domain driven design)
            /// </summary>
        [TestMethod]
        public async Task GetAllInvestmentsAsync_Returns_AggregateRoot_When_Investments_Exist()
        {
            // Act
            var investments = await _repository.GetAllInvestmentsAsync();

            // Assert
            Assert.IsInstanceOfType(investments.FirstOrDefault(), typeof(IAggregateRoot));

        }

        [TestMethod]
        public async Task GetUserInvestmentsAsync_Returns_Collection_When_User_Investments_Exist()
        {
            // Arrange
            int userId = 1;

            // Act
            var userInvestments = await _repository.GetUserInvestmentsAsync(userId);

            // Assert
            Assert.IsTrue(userInvestments.Count() > 0);
        }

        [TestMethod]
        public async Task GetUserInvestmentsAsync_Returns_Empty_Collection_When_User_Investments_Do_Not_Exist()
        {
            // Arrange
            int nonUserId = 3;

            // Act
            var userInvestments = await _repository.GetUserInvestmentsAsync(nonUserId);

            // Assert
            Assert.IsTrue(userInvestments.Count() == 0);
        }

        /// <summary>
        /// keep pattern in check with DDD (domain driven design)
        /// </summary>
        [TestMethod]
        public async Task GetUserInvestmentsAsync_Returns_AggregateRoot_When_Investments_Exist()
        {
            // Arrange
            int investmentId = 1;

            // Act
            var userInvestments = await _repository.GetUserInvestmentsAsync(investmentId);

            // Assert
            Assert.IsInstanceOfType(userInvestments.FirstOrDefault(), typeof(IAggregateRoot));
        }

        [TestMethod]
        public async Task GetInvestmentAsync_Returns_Null_When_Investment_Does_Not_Exist()
        {
            // Arrange
            int nonInvestmentId = 11;

            // Act
            var investment = await _repository.GetInvestmentAsync(nonInvestmentId);

            // Assert
            Assert.IsNull(investment);
        }

        [TestMethod]
        public async Task GetInvestmentAsync_Returns_Not_Null_When_Investment_Exist()
        {
            // Arrange
            int investmentId = 1;

            // Act 
            var investment = await _repository.GetInvestmentAsync(investmentId);

            // Assert
            Assert.IsNotNull(investment);
        }

        /// <summary>
        /// keep pattern in check with DDD (domain driven design)
        /// </summary>
        [TestMethod]
        public async Task GetInvestmentAsync_Returns_AggregateRoot_When_Investment_Exist()
        {
            // Arrange
            int investmentId = 1;

            // Act
            var investment = await _repository.GetInvestmentAsync(investmentId);

            // Assert
            Assert.IsInstanceOfType(investment, typeof(IAggregateRoot));
        }
    }
}
