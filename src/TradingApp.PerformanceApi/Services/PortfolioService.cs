namespace TradingApp.PerformanceApi.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using TradingApp.Data.Entities;
    using TradingApp.Data.Repositories;
    using TradingApp.PerformanceApi.Models;

    /// <summary>
    /// Implementation of the <see cref="IPortfolioService"/> interface.
    /// </summary>
    public class PortfolioService : IPortfolioService
    {
        private readonly IRepository<Investment> investmentRepository;
        private readonly IStockPriceService stockPrices;

        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioService"/> class.
        /// </summary>
        /// <param name="investmentRepository">Data access repository for investments.</param>
        /// <param name="stockPrices">Stock pricing service.</param>
        public PortfolioService(IRepository<Investment> investmentRepository, IStockPriceService stockPrices)
        {
            this.investmentRepository = investmentRepository;
            this.stockPrices = stockPrices;
        }

        /// <inheritdoc />
        public InvestmentDetails GetInvestmentDetails(int id)
        {
            var investment = this.investmentRepository.FindById(id);

            return new InvestmentDetails
            {
                Id = investment.Id,
                UserId = investment.UserId,
                Name = investment.Name,
                PurchaseDate = investment.PurchaseDate,
                Shares = investment.Shares,
                CostBasisPerShare = investment.PurchasePrice,
                CurrentPricePerShare = this.stockPrices.GetCurrentPrice(investment.Name),
            };
        }

        /// <inheritdoc />
        public ICollection<InvestmentSummary> GetInvestments()
        {
            return this.investmentRepository.GetAll()
                .Select(this.MapSummary)
                .ToList();
        }

        /// <inheritdoc />
        public ICollection<InvestmentSummary> GetInvestmentsByUserId(int userId)
        {
            return this.investmentRepository.GetAll()
                .Where(entity => entity.UserId == userId)
                .Select(this.MapSummary)
                .ToList();
        }

        /// <summary>
        /// Map an investment entity to to a summary model.
        /// </summary>
        /// <param name="entity">The db entity.</param>
        /// <returns>The summary model.</returns>
        private InvestmentSummary MapSummary(Investment entity)
        {
            return new InvestmentSummary
            {
                Id = entity.Id,
                UserId = entity.UserId,
                Name = entity.Name,
            };
        }
    }
}
