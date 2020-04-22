using Dapper;
using InvestmentPerformanceApi.Models;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace InvestmentPerformanceApi.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly IConfiguration _configuration;

        public InvestmentRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Investment> GetInvestmentsByUser(int userId)
        {
            const string sql = @"SELECT sp.[Id], s.[Name]
                FROM[Investment].[dbo].[StockPurchase] sp
                INNER JOIN[Investment].[dbo].[Stock] s on sp.StockId = s.Id
                WHERE UserId = @UserId";

            IEnumerable<Investment> investments;
            using (var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
            {
                investments = connection.Query<Investment>(sql, new { UserId = userId });
            }

            return investments;
        }

        public InvestmentPerformance GetInvestmentDetail(int investmentId)
        {
            const string sql = @"SELECT sp.[Id],
                                       s.[Name],
                                       sp.Shares,
	                                   sp.PurchaseCostPerShare,
	                                   sp.Shares * s.Price As CurrentValue,
	                                   s.Price As CurrentPrice,
	                                   sp.PurchaseDate,
                                       (sp.Shares * s.Price) - (sp.Shares * sp.PurchaseCostPerShare) As NetGain
                                FROM [Investment].[dbo].[StockPurchase] sp
                                INNER JOIN [Investment].[dbo].[Stock] s on sp.StockId = s.Id
                                WHERE sp.[Id] = @InvestmentId";

            StockPurchase stockPurchase;
            using (var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
            {
                stockPurchase = connection.QuerySingleOrDefault<StockPurchase>(sql, new { InvestmentId = investmentId });
            }

            InvestmentPerformance investmentPerformance = null;
            if (stockPurchase != null)
            {
                investmentPerformance = new InvestmentPerformance
                {
                    Id = stockPurchase.Id,
                    Name = stockPurchase.Name,
                    Shares = stockPurchase.Shares,
                    CostBasisPerShare = stockPurchase.PurchaseCostPerShare,
                    CurrentValue = stockPurchase.CurrentValue,
                    CurrentPrice = stockPurchase.CurrentPrice,
                    Term = PerformanceCalculationHelper.GetTerm(stockPurchase.PurchaseDate),
                    NetGain = PerformanceCalculationHelper.CalculateNetGain(stockPurchase.Shares, stockPurchase.CurrentPrice, stockPurchase.PurchaseCostPerShare),
                };
            }

            return investmentPerformance;
        }
    }
}
