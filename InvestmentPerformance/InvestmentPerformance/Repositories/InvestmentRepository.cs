using Dapper;
using InvestmentPerformance.Dtos;
using InvestmentPerformance.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace InvestmentPerformance.Repositories
{
    public class InvestmentRepository : IInvestmentRepository
    {
        private readonly string _connStr;
        private ILogger<InvestmentRepository> _logger;

        public InvestmentRepository(IConfiguration configuration, ILogger<InvestmentRepository> logger)
        {
            _connStr = configuration.GetConnectionString("InvestmentDbConn");
            _logger = logger;
        }

        public async Task<List<InvestmentDto>> GetInvestments(Guid userGuid)
        {
            try
            {
                string querystring =
                    $"  select inv.Name, inv.Type, inv.InvestmentId from  Investments inv  inner join" +
                    $" Transactions tr on inv.InvestmentId = tr.InvestmentId"+
                    $" where tr.UserGuid = '{userGuid}'";

                List<InvestmentDto> investments = new List<InvestmentDto>();

                using (IDbConnection db = new SqlConnection(_connStr))
                {
                    var result = await db.QueryAsync<InvestmentDto>(querystring);
                    investments = result.ToList();
                }
                return investments;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw ex;
            }
        }

        public async Task<InvestmentTransactionDto> GetInvestmentDetails(Guid userGuid, string investmentName)
        {
            try
            {
                string querystring = $"select inv.Name, tr.PurchasePrice, tr.PurchaseTimeStamp, tr.TransactionId, inv.InvestmentId, tr.Shares " +
                    $"from  Investments inv  inner join " +
                    $"Transactions tr on inv.InvestmentId = tr.InvestmentId " +
                    $"where tr.UserGuid = '{userGuid}' " +
                    $"and inv.Name = '{investmentName}'";

                InvestmentTransactionDto transaction = new InvestmentTransactionDto();

                using (IDbConnection db = new SqlConnection(_connStr))
                {
                    var result = await db.QueryAsync<InvestmentTransactionDto>(querystring);
                    transaction = result.FirstOrDefault();
                }
                return transaction;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
                throw ex;
            }
        }
    }
}


