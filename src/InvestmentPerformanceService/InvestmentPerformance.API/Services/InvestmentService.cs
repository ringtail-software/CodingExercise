using System;
using System.Threading.Tasks;
using InvestmentPerformance.API.Services.Interfaces;
using InvestmentPerformance.Domain.AggregatesModel;
using InvestmentPerformance.Domain.AggregatesModel.InvestmentAggregate;
using Microsoft.Extensions.Logging;

namespace InvestmentPerformance.API.Services
{
    public class InvestmentService : IInvestmentService
    {
        private readonly IInvestmentReadOnlyRepository _investmentReadOnlyRepository;
        private readonly ILogger<InvestmentService> _logger;

        public InvestmentService(IInvestmentReadOnlyRepository investmentReadOnlyRepository, ILogger<InvestmentService> logger)
        {
            _logger = logger;
            _investmentReadOnlyRepository = investmentReadOnlyRepository;
        }

        public async Task<Investment> GetInvestmentAsync(int userId)
        {
            Investment investment = null;

            try
            {
                _logger.LogInformation("");
                investment = await _investmentReadOnlyRepository.GetInvestmentAsync(userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return investment;
        }

        public async Task<InvestmentDetail> GetInvestmentDetailsAsync(int investmentId)
        {
            InvestmentDetail investmentDetail = null;

            try
            {
                _logger.LogInformation("");
                investmentDetail = await _investmentReadOnlyRepository.GetInvestmentDetailsAsync(investmentId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return investmentDetail;
        }
    }
}
