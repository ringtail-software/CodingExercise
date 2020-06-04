using InvestmentPerformance.Dtos;
using InvestmentPerformance.Models;
using InvestmentPerformance.Repositories;
using InvestmentPerformance.Resource;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace InvestmentPerformance.Services
{
    public class InvestmentService : IInvestmentService
    {
        private IInvestmentRepository _investmentRepository;
        private ICurrentPriceService _currentPriceService;
        private readonly ILogger<InvestmentService> _logger;

        public InvestmentService(IInvestmentRepository investmentRepository, ICurrentPriceService currentPriceService, ILogger<InvestmentService> logger)
        {
            _investmentRepository = investmentRepository;
            _currentPriceService = currentPriceService;
            _logger = logger;
        }
        public async Task<IEnumerable<Investment>> GetInvestmentList(Guid userGuid)
        {
            try
            {
                //map Dto to Investment Model list.
                //  Since it is a simple mapping will just do it in code.
                //  If more complex mapping, automapper nuget package will need to be imported.
                List<Investment> investmentList = new List<Investment>();
                _logger.LogInformation($"Attempt GetInvestments. UserGuid: {userGuid}");
                IEnumerable<InvestmentDto> investmentDtoList = await _investmentRepository.GetInvestments(userGuid);
                foreach (InvestmentDto dto in investmentDtoList)
                {
                    investmentList.Add(
                        new Investment()
                        {
                            Name = dto.Name,
                            Id = dto.InvestmentId
                        }
                    );
                }
                _logger.LogInformation($"Attempt Success. GetInvestments. UserGuid: {userGuid}");

                return investmentList;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error GetInvestments. UserGuid: {userGuid}: {ex.Message}");
                throw ex;
            }
        }

        /// <summary>
        /// Handle all the calculations in this service method
        /// </summary>
        /// <param name="userGuid"></param>
        /// <param name="investmentName"></param>
        /// <returns></returns>
        public async Task<InvestmentDetails> GetInvestmentPerformanceDetails(Guid userGuid, string investmentName)
        {
            try
            {
                _logger.LogInformation($"Attempt GetInvestmentPerformanceDetails. UserGuid: {userGuid} , investmentName: {investmentName}");

                InvestmentTransactionDto transactionDto = await _investmentRepository.GetInvestmentDetails(userGuid, investmentName);
                if (transactionDto == null) return null;

                //map some of the transaction details to Investment details model.  
                InvestmentDetails details = new InvestmentDetails()
                {
                    Shares = transactionDto.Shares,
                    CostBasisPerShare = transactionDto.PurchasePrice
                };
                //get the current price.  This call is to mimick calling a realtime stock ticker api.
                double currentPrice = _currentPriceService.GetCurrentPrice(transactionDto.PurchasePrice);
                details.CurrentPrice = currentPrice;

                //calculate performance data
                details.Term = Calculator.CalculateTerm(transactionDto.PurchaseTimeStamp).ToString();
                details.Profit = Calculator.CalculateProfit(transactionDto.PurchasePrice, transactionDto.Shares, currentPrice);
                details.CurrentValue = Calculator.CalculateCurrentValue(transactionDto.Shares, currentPrice);
                return details;
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error GetInvestmentPerformanceDetails. UserGuid: {userGuid}, investmentName: {investmentName}: {ex.Message}");
                throw ex;
            }

        }


    }
}
